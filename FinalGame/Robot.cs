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
        // public void Grab()
        // {
        //     Jewel jwl = new Jewel();
        //     JewelCollector jc = new JewelCollector();
        //     int[,] redpositions = jwl.Red();
        //     int[,] greenpositions = jwl.Green();
        //     int[,] bluepositions = jwl.Blue();
        //     for (int i = 0; i < redpositions.GetLength(0); i++)
        //     {
        //         for (int j = 0; j < redpositions.GetLength(0); j++)
        //         {
        //             jc.
        //         }
        //     }
             
        // }
    }

}
