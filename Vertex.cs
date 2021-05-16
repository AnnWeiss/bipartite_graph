using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bipartite_graph
{
    class Vertex //Вершина
    {
        public char label { get; set; } // Метка (например, ‘A’)
        public bool wasVisited { get; set; }
        public int color { get; set; }
        public bool isConflict { get; set; }
        public Vertex(char vertexLabel)
        {
            label = vertexLabel;
            wasVisited = false;
            isConflict = false;
            color = -1;
        }
        
    }
}
