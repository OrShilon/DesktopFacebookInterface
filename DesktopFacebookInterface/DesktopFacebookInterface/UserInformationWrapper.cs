using System;
using System.Collections.Generic;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    internal class UserInformationWrapper
    {
        private User m_LoginUser;

        public UserInformationWrapper(User i_LoginUser)
        {
            m_LoginUser = i_LoginUser;
        }

        public User User
        {
            get
            {
                return m_LoginUser;
            }
        }

        public List<string> fetchAbout()
        {
            List<string> listUserInfo = new List<string>();

            if (!string.IsNullOrEmpty(m_LoginUser.Name))
            {
                listUserInfo.Add(string.Format("Name: {0}", m_LoginUser.Name));
            }

            if (!string.IsNullOrEmpty(m_LoginUser.Gender.ToString()))
            {
                listUserInfo.Add(string.Format("Gender: {0}", m_LoginUser.Gender.ToString()));
            }

            if (!string.IsNullOrEmpty(m_LoginUser.Birthday))
            {
                listUserInfo.Add(string.Format("Birthday: {0}", m_LoginUser.Birthday));
            }

            if (!string.IsNullOrEmpty(m_LoginUser.Email))
            {
                listUserInfo.Add(string.Format("Email: {0}", m_LoginUser.Email));
            }

            if (m_LoginUser.Hometown != null)
            {
                if (!string.IsNullOrEmpty(m_LoginUser.Hometown.Name))
                {
                    listUserInfo.Add(string.Format("City: {0}", m_LoginUser.Hometown.Name));
                }
            }

            if (!string.IsNullOrEmpty(m_LoginUser.RelationshipStatus.Value.ToString()))
            {
                listUserInfo.Add(string.Format("Relationship Status: {0}", m_LoginUser.RelationshipStatus.Value.ToString()));
            }

            return listUserInfo;
        }

        public string fetchCoverPhotoURL()
        {
            string coverPhotoURL = "";

            foreach (Album album in m_LoginUser.Albums)
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

            if (User.Posts.Count == 0)
            {
                listTimeLine.Add("Your timeline has 0 posts!");
            }

            return listTimeLine;
        }

        public List<Post> fetchPostsByDate(DateTime i_StartDate, DateTime i_EndDate)
        {
            List<Post> filteredPosts = new List<Post>();

            foreach (Post post in User.Posts)
            {
                if (post.CreatedTime.Value.Date > i_StartDate && post.CreatedTime.Value.Date < i_EndDate)
                {
                    filteredPosts.Add(post);
                }
            }

            return filteredPosts;
        }

        public List<Photo> fetchPhotosByDate(DateTime i_StartDate, DateTime i_EndDate)
        {
            List<Photo> filteredPics = new List<Photo>();

            foreach (Album album in m_LoginUser.Albums)
            {
                foreach (Photo picture in album.Photos)
                {
                    if (picture.CreatedTime.Value.Date > i_StartDate && picture.CreatedTime.Value.Date < i_EndDate)
                    {
                        filteredPics.Add(picture);
                    }
                }
            }

            return filteredPics;
        }

        public List<Checkin> fetchCheckInsByDate(DateTime i_StartDate, DateTime i_EndDate)
        {
            List<Checkin> filteredCheckIns = new List<Checkin>();

            foreach (Checkin checkin in m_LoginUser.Checkins)
            {
                if (checkin.CreatedTime.Value.Date > i_StartDate && checkin.CreatedTime.Value.Date < i_EndDate)
                {
                    filteredCheckIns.Add(checkin);
                }
            }

            return filteredCheckIns;
        }

        public List<Event> fetchEventsByDate(DateTime i_StartDate, DateTime i_EndDate)
        {
            List<Event> filteredEvents = new List<Event>();

            foreach (Event userEvent in m_LoginUser.Events)
            {
                if (userEvent.StartTime > i_StartDate && userEvent.StartTime < i_EndDate)
                {
                    filteredEvents.Add(userEvent);
                }
            }

            return filteredEvents;
        }
    }
}
