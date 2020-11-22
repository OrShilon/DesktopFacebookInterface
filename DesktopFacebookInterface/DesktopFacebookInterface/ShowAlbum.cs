using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    public partial class ShowAlbum : Form
    {
        Album m_Album;
        readonly string[] m_AlbumPhotos;
        int indexInAlbum = 0;

        public ShowAlbum(Album i_Album)
        {
            m_Album = i_Album;
            InitializeComponent();
            labelAlbumName.Text = m_Album.Name;
            m_AlbumPhotos = new string[m_Album.Photos.Count];
            buildImageArray();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            displayImage();
        }

        private void buildImageArray()
        {
            int index = 0;

            foreach(Photo photo in m_Album.Photos)
            {
                m_AlbumPhotos[index] = photo.PictureNormalURL;
                index++;
            }
        }

        private void displayImage()
        {
            pictureBoxImage.LoadAsync(m_AlbumPhotos[indexInAlbum]);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if(indexInAlbum == m_AlbumPhotos.Length - 1)
            {
                indexInAlbum = 0;
            }
            else
            {
                indexInAlbum++;
            }

            displayImage();
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            if (indexInAlbum == 0)
            {
                indexInAlbum = m_AlbumPhotos.Length - 1;
            }
            else
            {
                indexInAlbum--;
            }

            displayImage();
        }
    }
}
