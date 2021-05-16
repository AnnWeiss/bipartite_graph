using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bipartite_graph
{
    class Graph
    {
        private static int MAX_VERTS = 10;
        private int nVerts = 0; // Текущее количество вершин
        public List<Vertex> verticesList { get; set; }
        public List<Edge> edgesList { get; set; }
        int[,] Matrix= new int[MAX_VERTS, MAX_VERTS];
        private StackX theStack;
        public Graph()
        {
            verticesList = new List<Vertex>();
            edgesList = new List<Edge>();

            for (int i = 0; i < MAX_VERTS; i++) // Матрица смежности заполняется нулями
            {
                for (int j = 0; j < MAX_VERTS; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
            theStack = new StackX();
        }
        public void addVertex(char vertexLabel)
        {
            verticesList.Add(new Vertex(vertexLabel));
            nVerts++;
        }
        public void addEdge(int startVert, int endVert)
        {
            Matrix[startVert,endVert] = 1;
            Matrix[endVert,startVert] = 1;
        }
        public void displayVertex(int v)
        {
            Console.Write(verticesList[v].label + " ");
        }
        public void dfs()
        {
            verticesList[0].wasVisited = true;
            displayVertex(0);
            theStack.push(0);
            verticesList[0].color = 1;

            while (!theStack.isEmpty()) // Пока стек не опустеет
            {
                // Получение непосещенной вершины, смежной к текущей
                int v0 = theStack.peek();
                int v = getAdjUnvisitedVertex(v0);
                if (v == -1)
                { // Если такой вершины нет,
                    theStack.pop(); // элемент извлекается из стека
                }
                else // Если вершина найдена
                {
                    if (verticesList[v].color == -1)
                    {
                        verticesList[v].wasVisited = true; // Пометка
                        verticesList[v].color = verticesList[v0].color == 1 ? 0 : 1;
                        displayVertex(v); // Вывод
                        theStack.push(v); // Занесение в стек
                    }
                }
            }
            Console.WriteLine("\n" + "Исходный граф содержит " + verticesList.Count + " вершин");
            // перебрать и проверить конфликтные ребра
            for (int k = 0; k < nVerts; k++)
            {
                for (int i = 0; i < nVerts; i++)
                {
                    if (Matrix[k,i] == 1)
                    {
                        if (verticesList[k].color==verticesList[i].color)
                        {
                            verticesList[i].isConflict = true;
                            verticesList[k].isConflict = false;//выбрать только одну конфликтную вершину
                        }
                    }
                }
            }
            //вывод всех вершин которые не конфликтные
            displayNonConflictVertices();
            displayRedVertices();
            displayBlueVertices();
            // Стек пуст, работа закончена
            for (int j = 0; j < nVerts; j++)
            { 
                verticesList[j].wasVisited = false; // Сброс флагов
                verticesList[j].color = -1;
                verticesList[j].isConflict=false;
            }
        }

        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < nVerts; j++)
            {
                if (Matrix[v, j] == 1 && verticesList[j].wasVisited == false)
                {
                    return j; // Возвращает первую найденную вершину
                } 
            }
            return -1; // Таких вершин нет
        }
        public void displayNonConflictVertices()
        {
            Console.WriteLine("\n");
            int a = 0;
            foreach (Vertex v in verticesList)
            {
                if (v.isConflict==false)
                {
                    Console.Write(v.label + " ");
                    a++;
                }
            }
            Console.WriteLine("\n"+"Двудольный подграф содержит " + a + " вершин");
        }
        public void displayRedVertices()
        {
            Console.WriteLine("\n");
            int a = 0;
            foreach (Vertex v in verticesList)
            {
                if (v.color == 0 && v.isConflict == false)
                {
                    Console.Write(v.label + " ");
                    a++;
                }
            }
            Console.WriteLine("\n" + "Вершин из множества Red: " + a);
        }

        public void displayBlueVertices()
        {
            Console.WriteLine("\n");
            int a = 0;
            foreach (Vertex v in verticesList)
            {
                if (v.color == 1 && v.isConflict == false)
                {
                    Console.Write(v.label + " ");
                    a++;
                }
            }
            Console.WriteLine("\n" + "Вершин из множества Blue: " + a);
        }
    }

}
