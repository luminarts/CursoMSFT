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
            if (position[0]-- >= 0)
            {
                position[0]--;

            }
        }
        public void Right()
        {
            if (position[0]++ < 10)
            {
                position[0]++;

            }
        }
        public void Up()
        {
            if (position[1]-- >= 0)
            {
                position[1]--;

            }
        }
        public void Down()
        {
            if (position[1]++ < 10)
            {
                position[1]++;

            }
        }
        public void Grab()
        {
            Jewel jwl = new Jewel();
            int[,] redpositions = jwl.Red();
            int[,] greenpositions = jwl.Green();
            int[,] bluepositions = jwl.Blue();
            // foreach (int[] i in redpositions)
            // {

            // }
        }
    }

}
