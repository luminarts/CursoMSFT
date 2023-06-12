using System;
using Jc;
using Mp;
using Jwl;

namespace Rbt
{
    public class Robot 
    {
        Map.MapInfo newMap = new Map.MapInfo();

        public string name = "ME";
        public int[] position = {0,0};
        public int points;
        public List<string> bag = new List<string>();
        public void Left()
        {
            if (position[0] - 1 >= 0)
            {
                position[0]--;
            }
        }
        public void Right()
        {
            if (position[0] + 1 < newMap.Cell.GetLength(0))
            {
                position[0]++;

            }
        }
        public void Up()
        {
            if (position[1] - 1 >= 0)
            {
                position[1]--;

            }
        }
        public void Down()
        {
            if (position[1] + 1 < newMap.Cell.GetLength(0))
            {
                position[1]++;

            }
        }
        public int Grab(string[,] mapa, int energy)
        {
            
            List<string> jewels = new List<string> {"JB","JR","JG"};
            
            if(position[0] > 0 && jewels.Contains(mapa[position[0] - 1,position[1]]))
            {
                bag.Add(mapa[position[0] - 1,position[1]]);
                if (mapa[position[0] - 1,position[1]] == "JB")
                {
                    energy += 5;
                }
                mapa[position[0] - 1,position[1]] = "--";
            }
            if(position[0] < newMap.Cell.GetLength(0) - 1 && jewels.Contains(mapa[position[0] + 1,position[1]]))
            {
                bag.Add(mapa[position[0] + 1,position[1]]);
                if (position[0] < newMap.Cell.GetLength(0) - 1 && mapa[position[0] + 1,position[1]] == "JB")
                {
                    energy += 5;
                }
                mapa[position[0] + 1,position[1]] = "--";
            }
            if (position[1] > 0 && jewels.Contains(mapa[position[0],position[1] - 1]))
            {
                bag.Add(mapa[position[0],position[1] - 1]);
                if (position[1] > 0 && mapa[position[0],position[1] - 1] == "JB")
                {
                    energy += 5;
                }
                mapa[position[0],position[1] - 1] = "--";
            }
            if (position[1] < newMap.Cell.GetLength(0) - 1 && jewels.Contains(mapa[position[0],position[1] + 1]))
            {
                bag.Add(mapa[position[0],position[1] + 1]);
                if (position[1] < newMap.Cell.GetLength(0) - 1 && mapa[position[0], position[1] + 1] == "JB")
                {
                    energy += 5;
                }
                mapa[position[0],position[1] + 1] = "--";
            }
            return energy;
        }
    } 

}
