using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUP_GM
{
    internal class GenreClass
    {
        public Genre Genre { get; set; }  
        public bool Is { get; set; }
        public GenreClass(Genre genre, bool f)
        {
            Genre = genre;
            Is = f; 
        }
    }
}
