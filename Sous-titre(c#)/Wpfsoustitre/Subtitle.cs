using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfsoustitre
{
    class Subtitle
    {
        public TimeSpan TimeStart;
        public TimeSpan TimeEnd;
        public string subt;

        public Subtitle(string sub, string TStart, string TEnd)
        {
            subt = sub;
            TimeStart = TimeSpan.Parse(TStart);
            TimeEnd = TimeSpan.Parse(TEnd);
        }
    }
}
