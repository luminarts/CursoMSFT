using System;
using Jc;
using Mp;
using Jwl;

namespace Rbt
{
    public class Robot
    {
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
            if (position[0] + 1 < 10)
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
            if (position[1] + 1 < 10)
            {
                position[1]++;

            }
        }
        public void Grab(string[,] mapa)
        {
            
            List<string> jewels = new List<string> {"JB","JR","JG"};
            
            if(position[0] > 0 && jewels.Contains(mapa[position[0] - 1,position[1]]))
            {
                bag.Add(mapa[position[0] - 1,position[1]]);
                mapa[position[0] - 1,position[1]] = "--";
            }
            if(position[0] < 9 && jewels.Contains(mapa[position[0] + 1,position[1]]))
            {
                bag.Add(mapa[position[0] + 1,position[1]]);
                mapa[position[0] + 1,position[1]] = "--";
            }
            if (position[1] > 0 && jewels.Contains(mapa[position[0],position[1] - 1]))
            {
                bag.Add(mapa[position[0],position[1] - 1]);
                mapa[position[0],position[1] - 1] = "--";
            }
            if (position[1] < 9 && jewels.Contains(mapa[position[0],position[1] + 1]))
            {
                bag.Add(mapa[position[0],position[1] + 1]);
                mapa[position[0],position[1] + 1] = "--";
            }

        }
    } // criar função de conversão de string para int (joia para pontos) + bag de armazenar pontos

}
