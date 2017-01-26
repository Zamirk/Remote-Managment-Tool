using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent._3Model
{
    public class Song
    {
        #region Members
        string _artistName;
        string _songTitle;
        #endregion

        #region Properties
        /// The artist name.
        public string ArtistName
        {
            get { return _artistName; }
            set { _artistName = value; }
        }

        /// The song title.
        public string SongTitle
        {
            get { return _songTitle; }
            set { _songTitle = value; }
        }
        #endregion
    }
}
