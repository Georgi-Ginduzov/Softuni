using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class MuseElf : Elf
    {
        public MuseElf(string username, int lavel) : base(username, lavel)
        {
            
        }

        public string Username { get; set; }
        public int Level { get; set; }
    }
}
