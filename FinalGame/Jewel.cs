namespace Jwl
{
    public class Jewel
    {
    
        Random rnd = new Random();
        public int points;
        public string name = "";
        public int redpoints = 100;
        public int greenpoints = 50;
        public int bluepoints = 10;
        /// <summary>
        /// Esse método serve para gerar valores aleatórios para as posições das jewels vermelhas.
        /// </summary>
        /// <returns>Retorna uma matriz reds x 2, onde reds é o número de jewels vermelhas.</returns>
        public int[,] Red()
        {
            name = "JR";
            int reds = 2;
            int[,] redpositions = new int[reds,2];

            for (int r = 0; r < reds; r++)
            {
                int x = rnd.Next(10);
                int y = rnd.Next(10);
                while (x == y && x == 0)
                {
                    x = rnd.Next(10);
                    y = rnd.Next(10);
                }
                redpositions[r,0] = x;
                redpositions[r,1] = y;   
                // fazer condição de não ter nenhum igual entre si
                // fazer condição de não ter nenhum igual a outros elementos                              
            }
            return redpositions;

        }
        /// <summary>
        /// Esse método serve para gerar valores aleatórios para as posições das jewels verdes.
        /// </summary>
        /// <returns>Retorna uma matriz greens x 2, onde greens é o número de jewels verdes.</returns>
        public int [,] Green()
        {
            name = "JG";
            int greens = 2;
            int[,] greenpositions = new int[greens,2];

            for (int r = 0; r < greens; r++)
            {
                int x = rnd.Next(10);
                int y = rnd.Next(10);
            
                while (x == y && x == 0)
                {
                    x = rnd.Next(10);
                    y = rnd.Next(10);
                }  
                greenpositions[r,0] = x;
                greenpositions[r,1] = y;
            }
            return greenpositions;
        }
        /// <summary>
        /// Esse método serve para gerar valores aleatórios para as posições das jewels azuis.
        /// </summary>
        /// <returns>Retorna uma matriz blues x 2, onde blues é o número de jewels azuis.</returns>
        public int[,] Blue()
        {
            name = "JB";
            int blues = 4;
            int[,] bluepositions = new int[blues,2];

            for (int r = 0; r < blues; r++)
            {
                int x = rnd.Next(10);
                int y = rnd.Next(10);
                
                while (x == y && x == 0)
                {
                    x = rnd.Next(10);
                    y = rnd.Next(10);
                }
                bluepositions[r,0] = x;
                bluepositions[r,1] = y;   
            }
            return bluepositions;
        }
    }
}