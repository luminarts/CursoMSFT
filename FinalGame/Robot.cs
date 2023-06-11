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
        public int bag;
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
            if (position[0] + 1)
        }
    } // criar função de conversão de string para int (joia para pontos) + bag de armazenar pontos

}
