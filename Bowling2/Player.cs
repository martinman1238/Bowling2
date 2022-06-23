using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bowling2
{
    public class Player
    {
        public string? name;
        //public List<string> scores=new List<string>();
        public List<Tuple<string, int, int>> scores = new List<Tuple<string, int, int>>();

    }
}
