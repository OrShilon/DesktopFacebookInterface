using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface.UI
{
    public partial class FormDisplayPhotos : Form
    {
        private AlbumIterator m_AlbumIterator;
        private Photo m_Current;

        public FormDisplayPhotos(IAlbumIterator i_AlbumIterator)
        {
            InitializeComponent();
            m_AlbumIterator = i_AlbumIterator as AlbumIterator;
            m_AlbumIterator.MoveNext();
            buttonPrev.Enabled = false;
            m_Current = m_AlbumIterator.Current as Photo;
            imageNormalPictureBox.LoadAsync(m_Current.PictureNormalURL);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            bool next = m_AlbumIterator.MoveNext();
            if (next)
            {
                m_Current = m_AlbumIterator.Current as Photo;
                imageNormalPictureBox.LoadAsync(m_Current.PictureNormalURL);
            }

            buttonNext.Enabled = m_AlbumIterator.m_CurrentIndex != m_AlbumIterator.m_Count - 1;
            buttonPrev.Enabled = true;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            bool prev = m_AlbumIterator.MovePrev();
            if (prev)
            {
                m_Current = m_AlbumIterator.Current as Photo;
                imageNormalPictureBox.LoadAsync(m_Current.PictureNormalURL);
            }

            buttonPrev.Enabled = m_AlbumIterator.m_CurrentIndex != 0;
            buttonNext.Enabled = true;
        }

        private void UpdateButtons()
        {
            buttonPrev.Enabled = (m_AlbumIterator.m_CurrentIndex < 0) ? false : true;
            buttonNext.Enabled = (m_AlbumIterator.m_CurrentIndex == m_AlbumIterator.m_Count) ? false : true;
        }
    }
}
