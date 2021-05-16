using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bipartite_graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph theGraph = new Graph();
            theGraph.addVertex('A'); // 0
            theGraph.addVertex('B'); // 1
            theGraph.addVertex('C'); // 2
            theGraph.addVertex('D'); // 3
            theGraph.addVertex('E'); // 4
            theGraph.addVertex('F'); // 5
            theGraph.addVertex('G'); // 6
            theGraph.addVertex('H'); // 7
            theGraph.addVertex('I'); // 8
            theGraph.addVertex('J'); // 9

            theGraph.addEdge(1, 0); // BA
            theGraph.addEdge(2, 0); // CA
            theGraph.addEdge(4, 0); // EA
            theGraph.addEdge(6, 1); // GB
            theGraph.addEdge(4, 2); // EC
            theGraph.addEdge(7, 2); // HC
            theGraph.addEdge(7, 3); // HD
            theGraph.addEdge(9, 3); // JD
            theGraph.addEdge(7, 5); // HF
            theGraph.addEdge(8, 5); // IF
            theGraph.addEdge(8, 6); // IG
            theGraph.addEdge(9, 6); // JG
            theGraph.addEdge(9, 8); // JI

            theGraph.dfs(); // Обход в глубину
            Console.ReadKey(true);
        }
    }
}
