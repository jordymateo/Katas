using System;
using System.Collections.Generic;

namespace _2019_06_08
{
    public class BallsSorter
    {
        public List<int> balls { get; private set; } = new List<int>();

        public void Add(int v)
        {
            int index = 0;
            foreach(var ball in balls)
            {
                if (v < ball)
                    break;

                index++;
            }

            balls.Insert(index, v);
        }
    }
}