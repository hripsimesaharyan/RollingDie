using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDie
{
    public class RollingDieSelectEventArgs:EventArgs
    {

        public int count { get; set; }
        public RollingDieSelectEventArgs(int count)
        {
            this.count = count;
        }
        
    }
}
