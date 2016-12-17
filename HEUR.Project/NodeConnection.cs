using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    public class NodeConnection
    {
        public int firstNode { get; set; }
        public int secondNode { get; set; }
        public int capacity { get; set; }
        public double energyConsumption { get; set; }
        public double latency { get; set; }

        public NodeConnection(int firstNode, int secondNode, int capacity, double energyConsumption, double latency)
        {
            this.firstNode = firstNode;
            this.secondNode = secondNode;
            this.capacity = capacity;
            this.energyConsumption = energyConsumption;
            this.latency = latency;
        }
    }
}
