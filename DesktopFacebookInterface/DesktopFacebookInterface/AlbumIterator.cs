using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopFacebookInterface
{
    class AlbumIterator : IAlbumIterator
    {
        private Album m_Album;
        public int m_CurrentIndex { get; private set; }
        public int m_Count { get; }

        public AlbumIterator(Album i_Album)
        {
            m_Album = i_Album;
            m_Count = m_Album.Photos.Count;
            m_CurrentIndex = -1;
        }

        public object Current
        {
            get 
            {
                return m_Album.Photos[m_CurrentIndex];
            }
        }

        public bool MoveNext()
        {
            if(m_Count != m_Album.Photos.Count)
            {
                throw new Exception("Collection cannot be changed during iteration.");
            }
            
            if(m_CurrentIndex >= m_Count)
            {
                throw new Exception("Reached the end of the collection.");
            }

            return ++m_CurrentIndex < m_Album.Photos.Count;
        } 

        public bool MovePrev()
        {
            if(m_Count != m_Album.Photos.Count)
            {
                throw new Exception("Collection cannot be changed during iteration.");
            }
            
            if(m_CurrentIndex < 0)
            {
                throw new Exception("Reached the beggining of the collection.");
            }

            return --m_CurrentIndex >= 0;
        }

        public void reset()
        {
            m_CurrentIndex = -1;
        }
    }
}
