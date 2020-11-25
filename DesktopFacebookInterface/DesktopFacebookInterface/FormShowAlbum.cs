using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    internal partial class FormShowAlbum : Form
    {
        private readonly string[] m_AlbumPhotos; 
        private Album m_Album;
        private int m_PhotoIndex = 0;

        public FormShowAlbum(Album i_Album)
        {
            m_Album = i_Album;
            m_AlbumPhotos = new string[m_Album.Photos.Count];
            
            InitializeComponent();
            this.BackColor = System.Drawing.Color.FromArgb(66, 103, 178);
            this.Text = m_Album.Name;
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
            pictureBoxImage.LoadAsync(m_AlbumPhotos[m_PhotoIndex]);
            UpdateButtonPrevious();
            UpdateButtonNext();
        }

        private void UpdateButtonPrevious()
        {
            ButtonPrevious.Enabled = (m_PhotoIndex == 0) ? false : true;
        }

        private void UpdateButtonNext()
        {
            ButtonNext.Enabled = (m_PhotoIndex == m_AlbumPhotos.Length - 1) ? false : true;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if(m_PhotoIndex == m_AlbumPhotos.Length - 1)
            {
                m_PhotoIndex = 0;
            }
            else
            {
                m_PhotoIndex++;
            }

            displayImage();
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            if (m_PhotoIndex == 0)
            {
                m_PhotoIndex = m_AlbumPhotos.Length - 1;
            }
            else
            {
                m_PhotoIndex--;
            }

            displayImage();
        }
    }
}
