using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    public class RequiredBandwidth
    {
        public int componentOne { get; set; }
        public int componentTwo { get; set; }
        public int bandwith { get; set; }

        public RequiredBandwidth(int componentOne, int componentTwo, int bandwith)
        {
            this.componentOne = componentOne;
            this.componentTwo = componentTwo;
            this.bandwith = bandwith;
        }
    }
}
