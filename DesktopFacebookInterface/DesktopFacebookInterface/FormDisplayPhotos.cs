using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebookInterface
{
    public partial class FormDisplayPhotos : Form
    {
        public FormDisplayPhotos(Album m_Album)
        {
            InitializeComponent();
            this.photosBindingSource.DataSource = m_Album.Photos;
            this.Text = m_Album.Name;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            photosBindingSource.MoveNext();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            photosBindingSource.MovePrevious();
        }

        private void UpdateButtons()
        {
            buttonPrev.Enabled = (photosBindingSource.Position == 0) ? false : true;
            buttonNext.Enabled = (photosBindingSource.Position == photosBindingSource.Count - 1) ? false : true;
        }

        private void photosBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
