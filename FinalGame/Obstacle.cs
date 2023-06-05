namespace Obst
{
    public class Obstacle
    {

        public string name = "";
        Random rnd = new Random();

        
        public int[,] Tree()
        {
            name = "$$";
            int numoftrees = rnd.Next(2,7);
            int[,] treepositions = new int[numoftrees,2];
            
            for (int i = 0; i < numoftrees; i++)
            {
                int x = rnd.Next(10);
                int y = rnd.Next(10);
                while(x == y && x == 0)
                {
                    x = rnd.Next(1,10);
                    y = rnd.Next(1,10);
                }
                treepositions[i,0] = x;
                treepositions[i,1] = y;
            // fazer condição de não ter nenhum igual entre si
            // fazer condição de não ter nenhum igual a outros elementos        
            }
            return treepositions;
        }
        
        public int[,] Water()
        {
            name = "##";
            int numofwater = rnd.Next(3,8);
            int[,] waterpositions = new int[numofwater,2];

            for (int i = 0; i < numofwater; i++)
            {
                int x = rnd.Next(10);
                int y = rnd.Next(10);
                while (x == y && x == 0)
                {
                    x = rnd.Next(1,10);
                    y = rnd.Next(1,10);
                }
                waterpositions[i,0] = x;
                waterpositions[i,1] = y;
            // fazer condição de não ter nenhum igual entre si
            // fazer condição de não ter nenhum igual a outros elementos        
            }
            return waterpositions;
        }
        public void Empty()
        {
            name = "--";
        }
    }    
}
