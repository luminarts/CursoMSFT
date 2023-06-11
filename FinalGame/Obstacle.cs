using Rbt;
using Jc;
using System.Collections.Generic;

namespace Obst
{
    public class Obstacle
    {
        Random rnd = new Random();
        
        public string name = "";
        List<(int, int)> unique = new List<(int, int)>();
        int numoftrees = 5;
        int numofwater = 5;
        int numofradio = 5;
        public int[,] Tree()
        {
            name = "$$";
            int[,] treepositions = new int[numoftrees,2];
            
            void UniquePairs(int numoftrees)
            {
                while (unique.Count < numoftrees)
                {
                    int x = rnd.Next(10);
                    int y = rnd.Next(10);
                    var pair = (x, y);
                    if (unique.Contains(pair) == false && pair != (0,0))
                    {
                        unique.Add(pair);
                    }
                }
            }

            UniquePairs(numoftrees);

            for (int i = 0; i < unique.Count; i++)
            {
                int x = unique[i].Item1;
                int y = unique[i].Item2;
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
            int[,] waterpositions = new int[numofwater,2];

            void UniquePairs(int numofwater)
            {
                while (unique.Count < numofwater + numoftrees)
                {
                    int x = rnd.Next(10);
                    int y = rnd.Next(10);
                    var pair = (x, y);
                    if (unique.Contains(pair) == false && pair != (0,0))
                    {
                        unique.Add(pair);
                    }
                }
            }

            UniquePairs(numofwater);

            for (int i = numoftrees; i < numofwater + numoftrees; i++)
            {
                int x = unique[i].Item1;
                int y = unique[i].Item2;
                waterpositions[i-numoftrees,0] = x;
                waterpositions[i-numoftrees,1] = y;
            // fazer condição de não ter nenhum igual entre si
            // fazer condição de não ter nenhum igual a outros elementos        
            }
            return waterpositions;
        }
        public void Empty()
        {
            name = "--";
        }
        public int[,] RadioactiveElement()
        {
            name = "!!";
            int[,] radiopositions = new int[numofradio,2];

            void UniquePairs(int numofradio)
            {
                while (unique.Count < numofradio + numoftrees + numofwater)
                {
                    int x = rnd.Next(10);
                    int y = rnd.Next(10);
                    var pair = (x, y);
                    if (unique.Contains(pair) == false && pair != (0,0))
                    {
                        unique.Add(pair);
                    }
                }
            }

            UniquePairs(numofradio);

            for (int i = numoftrees + numofwater; i < numofradio + numoftrees + numofwater; i++)
            {
                int x = unique[i].Item1;
                int y = unique[i].Item2;
                radiopositions[i-numoftrees-numofwater,0] = x;
                radiopositions[i-numoftrees-numofwater,1] = y;
            // fazer condição de não ter nenhum igual entre si
            // fazer condição de não ter nenhum igual a outros elementos        
            }
            return radiopositions;
        }
        public int ObstacleEnergy(string[,] mapa, int energy,int x, int y)
        {
            Robot rbt = new Robot();
            
            if (y > 0 && (mapa[x,y-1] == "$$"))
                {
                    energy += 3;
                    Console.WriteLine($"Olha, uma árvore! Energia: {energy}");
                }
            else if (x > 0 && mapa[x-1,y] == "$$")
                {
                    energy += 3;
                    Console.WriteLine($"Olha, uma árvore! Energia: {energy}");
                }
            else if (y < 9 && mapa[x,y+1] == "$$")
                {
                    energy += 3;
                    Console.WriteLine($"Olha, uma árvore! Energia: {energy}");
                }
            else if (x < 9 && mapa[x+1,y] == "$$")
                {
                    energy += 3;
                    Console.WriteLine($"Olha, uma árvore! Energia: {energy}");
                }
            if (x > 0 && mapa[x-1,y] == "!!")
                {
                    energy -= 10;
                    Console.WriteLine($"Você sente sua vida sendo sugada por dentro! Energia: {energy}");
                }
            else if (y < 9 && mapa[x,y+1] == "!!")
                {
                    energy -= 10;
                    Console.WriteLine($"Você sente sua vida sendo sugada por dentro! Energia: {energy}");
                }
            else if (x < 9 && mapa[x+1,y] == "!!")
                {
                    energy -= 10;
                    Console.WriteLine($"Você sente sua vida sendo sugada por dentro! Energia: {energy}");
                }
            else if (y > 0 && mapa[x,y-1] == "!!")
                {
                    energy -= 10;
                    Console.WriteLine($"Você sente sua vida sendo sugada por dentro! Energia: {energy}");
                }
            else{
                Console.WriteLine($"Não tem nenhum item de recuperação de energia perto. Posição: {rbt.position[0]},{y} | Energia: {energy}");
            }
            return energy;
        }
    }    
}
