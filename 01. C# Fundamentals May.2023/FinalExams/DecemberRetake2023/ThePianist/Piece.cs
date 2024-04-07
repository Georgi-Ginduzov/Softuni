using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePianist
{
    public class Piece
    {
        private string name;
        private string composer;
        private string key;

        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
