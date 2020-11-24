using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace DesktopFacebookInterface
{
    public partial class FormShowAlbum : Form
    {
        Album m_Album;
        readonly string[] m_AlbumPhotos;
        private int m_PhotoIndex = 0;

        public FormShowAlbum(Album i_Album)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.FromArgb(66, 103, 178);
            m_Album = i_Album;
            this.Text = m_Album.Name;
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
