using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bipartite_graph
{
    class StackX
    {
        private int SIZE = 10;
        private int[] st;
        private int top;
        public StackX()
        {
            st = new int[SIZE]; // Создание массива
            top = -1;
        }
        public void push(int j) // Размещение элемента в стеке
        { 
            st[++top] = j; 
        }
        public int pop() // Извлечение элемента из стека
        { 
            return st[top--];
        }
        public int peek() // Чтение с вершины стека
        {
            return st[top]; 
        }
        public bool isEmpty() // true, если стек пуст
        {
            return (top == -1); 
        }
    }
}

