using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    public class Route
    {
        public int componentOne { get; set; }
        public int componentTwo { get; set; }
        public List<int> comunicationNodes { get; set; }
        public List<NodeConnection> nodeConnections { get; set; }

    }
}
