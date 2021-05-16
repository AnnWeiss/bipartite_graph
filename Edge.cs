using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bipartite_graph
{
    class Edge //Ребро
    {
        public int vertex1 { get; set; }
        public int vertex2 { get; set; }
        public Edge(int _v1, int _v2)
        {
            vertex1 = _v1;
            vertex2 = _v2;
        }
    }
}
