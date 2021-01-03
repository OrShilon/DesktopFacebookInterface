﻿using System;
using System.Collections.Generic;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public sealed class UserInformationWrapper
    {
        private static UserInformationWrapper s_Instance = null;
        private static readonly object sr_Lock = new object();
        private User m_LoginUser = null;

        public void SetUser(User i_User)
        {
            m_LoginUser = i_User;
        }

        private UserInformationWrapper()
        {
        }

        public static UserInformationWrapper GetUserWrapper
        {
            get
            {
                if(s_Instance == null)
                {
                    lock(sr_Lock)
                    {
                        if(s_Instance == null)
                        {
                            s_Instance = new UserInformationWrapper();
                        }
                    }
                }
                return s_Instance;
            }
        }

        public string Name
        { 
            get
            {
                return m_LoginUser.Name;
            } 
        }

        public string PictureNormalURL
        {
            get
            {
                return m_LoginUser.PictureNormalURL;
            }
        }

        public User User
        {
            get
            {
                return m_LoginUser;
            }
        }

        public GeoPostedItem PostStatus(string i_ImagePath, string i_Status)
        {
            GeoPostedItem newPostedItem = null;

            if (i_ImagePath == null)
            {
                newPostedItem = User.PostStatus(i_Status);
            }
            else
            {
                newPostedItem = User.PostPhoto(i_ImagePath, i_Status);
            }

            return newPostedItem;
        }

        public List<string> fetchAbout()
        {
            List<string> listUserInfo = new List<string>();

            if (!string.IsNullOrEmpty(User.Name))
            {
                listUserInfo.Add(string.Format("Name: {0}", User.Name));
            }

            if (!string.IsNullOrEmpty(User.Gender.ToString()))
            {
                listUserInfo.Add(string.Format("Gender: {0}", User.Gender.ToString()));
            }

            if (!string.IsNullOrEmpty(User.Birthday))
            {
                listUserInfo.Add(string.Format("Birthday: {0}", User.Birthday));
            }

            if (!string.IsNullOrEmpty(User.Email))
            {
                listUserInfo.Add(string.Format("Email: {0}", User.Email));
            }

            if (User.Hometown != null)
            {
                if (!string.IsNullOrEmpty(User.Hometown.Name))
                {
                    listUserInfo.Add(string.Format("City: {0}", User.Hometown.Name));
                }
            }

            if (!string.IsNullOrEmpty(User.RelationshipStatus.Value.ToString()))
            {
                listUserInfo.Add(string.Format("Relationship Status: {0}", User.RelationshipStatus.Value.ToString()));
            }

            return listUserInfo;
        }

        public string fetchCoverPhotoURL()
        {
            string coverPhotoURL = string.Empty;

            foreach (Album album in User.Albums)
            {
                string albumName = album.Name.ToLower();

                if (albumName.Equals("cover photos"))
                {
                    coverPhotoURL = album.Photos[0].PictureNormalURL;
                }
            }

            return coverPhotoURL;
        }

        public List<string> fetchTimeline()
        {
            List<string> listTimeLine = new List<string>();

            foreach (Post post in User.WallPosts)
            {
                if (post.Message != null)
                {
                    listTimeLine.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listTimeLine.Add(post.Caption);
                }
            }

            if (User.WallPosts.Count == 0)
            {
                listTimeLine.Add("Your timeline has 0 posts!");
            }

            return listTimeLine;
        }

        public FacebookObjectCollection<Album> FetchAlbums()
        {
            return m_LoginUser.Albums;
        }
        
        public FacebookObjectCollection<Page> FetchLikedPages()
        {
            return m_LoginUser.LikedPages;
        }
        
        public FacebookObjectCollection<Event> FetchEvents()
        {
            return m_LoginUser.Events;
        }

        public FacebookObjectCollection<User> FetchFriends()
        {
            return m_LoginUser.Friends;
        }

        public List<string> FetchPostsByDate(DateTime i_StartDate, DateTime i_EndDate)
        {
            List<string> filteredPosts = new List<string>();

            foreach (Post post in User.Posts)
            {
                DateTime createdDate = post.CreatedTime.Value.Date;

                if (createdDate > i_StartDate && createdDate < i_EndDate)
                {
                    string postString = string.Empty;

                    if (post.Message != null)
                    {
                        postString = post.Message;
                    }
                    else if (post.Caption != null)
                    {
                        postString = post.Caption;
                    }

                    filteredPosts.Add(string.Format("{0}/{1}/{2}: {3}", createdDate.Day, createdDate.Month, createdDate.Year, postString));
                }
            }

            if (User.Posts.Count == 0)
            {
                filteredPosts.Add(string.Format("No posts found between {0} - {1}", i_StartDate, i_EndDate));
            }

            return filteredPosts;
        }

        public List<string> fetchCheckInsByDate(DateTime i_StartDate, DateTime i_EndDate)
        {
            List<string> filteredCheckIns = new List<string>();

            foreach (Checkin checkin in User.Checkins)
            {
                DateTime createdDate = checkin.CreatedTime.Value.Date;

                if (createdDate > i_StartDate && createdDate < i_EndDate)
                {
                    string checkInString = string.Empty;

                    if (checkin.Message != null)
                    {
                        checkInString = checkin.Message;
                    }
                    else if (checkin.Caption != null)
                    {
                        checkInString = checkin.Caption;
                    }

                    filteredCheckIns.Add(string.Format("{0}/{1}/{2}: {3}", createdDate.Day, createdDate.Month, createdDate.Year, checkInString));
                }
            }

            if (User.Checkins.Count == 0)
            {
                filteredCheckIns.Add(string.Format("No checkins found between {0} - {1}", i_StartDate, i_EndDate));
            }

            return filteredCheckIns;
        }

        public List<string> fetchEventsByDate(DateTime i_StartDate, DateTime i_EndDate)
        {
            List<string> filteredEvents = new List<string>();

            foreach (Event userEvent in User.Events)
            {
                DateTime startDate = userEvent.StartTime.Value.Date;
                if (userEvent.StartTime > i_StartDate && userEvent.StartTime < i_EndDate)
                {
                    filteredEvents.Add(string.Format("{0}/{1}/{2}: {3}", startDate.Day, startDate.Month, startDate.Year, userEvent.Name));
                }
            }

            if (User.Events.Count == 0)
            {
                filteredEvents.Add(string.Format("No events found between {0} - {1}", i_StartDate, i_EndDate));
            }

            return filteredEvents;
        }
    }
}
