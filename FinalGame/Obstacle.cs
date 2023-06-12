using Rbt;
using Jc;
using System.Collections.Generic;
using Mp;


namespace Obst
{
    public class Obstacle
    {
        Random rnd = new Random();
        JewelCollector jc = new JewelCollector();
        Map.MapInfo Map = new Map.MapInfo();

        public string name = "";
        List<(int, int)> unique = new List<(int, int)>();
        int numoftrees = 5;
        int numofwater = 5;
        int numofradio = 5;
        /// <summary>
        /// Esse método serve para gerar as posições dos obstáculos de Tree de forma aleatória e única.
        /// </summary>
        /// <returns>Esse método retorna uma matriz numoftrees x 2, onde numoftrees é o número de Trees gerado aleatoriamente.</returns>
        public int[,] Tree()
        {
            name = "$$";
            int[,] treepositions = new int[numoftrees,2];
            /// <summary>
            /// Esse método serve para garantir a unicidade dos pares de posições dos obstáculos, garantindo que não há superposição de obstáculos.
            /// </summary>
            /// <param name="numoftrees"> o parâmetro numoftrees é utilizado para garantir que a coleção-lista unique tenha exatamente numoftrees elementos, garantindo a unicidade de cada um</param>
            void UniquePairs(int numoftrees)
            {
                while (unique.Count < numoftrees)
                {
                    int x = rnd.Next(Map.Cell.GetLength(0));
                    int y = rnd.Next(Map.Cell.GetLength(0));
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
        /// <summary>
        /// Esse método serve para gerar as posições dos obstáculos de Water de forma aleatória e única.
        /// </summary>
        /// <returns>Esse método retorna uma matriz numofwater x 2, onde numofwater é o número de Water gerado aleatoriamente.</returns>
        public int[,] Water()
        {
            name = "##";
            int[,] waterpositions = new int[numofwater,2];
            /// <summary>
            /// Esse método serve para garantir a unicidade dos pares de posições dos obstáculos, garantindo que não há superposição de obstáculos.
            /// </summary>
            /// <param name="numofwater"> o parâmetro numofwater é utilizado para garantir que a coleção-lista unique tenha exatamente numofwater elementos, garantindo a unicidade de cada um</param>
            void UniquePairs(int numofwater)
            {
                while (unique.Count < numofwater + numoftrees)
                {
                    int x = rnd.Next(Map.Cell.GetLength(0));
                    int y = rnd.Next(Map.Cell.GetLength(0));
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
        /// <summary>
        /// Esse método define o nome do Empty, isto é, tudo que é vazio no mapa.
        /// </summary>
        public void Empty()
        {
            name = "--";
        }
        /// <summary>
        /// Esse método serve para gerar as posições dos obstáculos de elementos radioativos de forma aleatória e única.
        /// </summary>
        /// <returns>Esse método retorna uma matriz numofradio x 2, onde numofradio é o número de elementos radioativos gerado aleatoriamente.</returns>
        public int[,] RadioactiveElement()
        {
            name = "!!";
            int[,] radiopositions = new int[numofradio,2];
            /// <summary>
            /// Esse método serve para garantir a unicidade dos pares de posições dos obstáculos, garantindo que não há superposição de obstáculos.
            /// </summary>
            /// <param name="numofradio"> o parâmetro numofradio é utilizado para garantir que a coleção-lista unique tenha exatamente numofradio elementos, garantindo a unicidade de cada um</param>
            void UniquePairs(int numofradio)
            {
                while (unique.Count < numofradio + numoftrees + numofwater)
                {
                    int x = rnd.Next(Map.Cell.GetLength(0));
                    int y = rnd.Next(Map.Cell.GetLength(0));
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
        /// <summary>
        /// Esse método serve realizar as interações do robô com os obstáculos que geram alteração no nível de energia.
        /// </summary>
        /// <param name="mapa">o parâmetro matricial mapa é utilizado para se referenciar à elementos no mapa do jogo </param>
        /// <param name="energy">o parâmetro inteiro de energy é utilizado como a variável que sofrerá as adições e subtrações em cada interação</param>
        /// <param name="x">o parâmetro x será utilizado para analisar a relação de distância do robô aos obstáculos analisados no eixo x </param>
        /// <param name="y">o parâmetro y será utilizado para analisar a relação de distância do robô aos obstáculos analisados no eixo y</param>
        /// <returns>Retorna o valor de energy final após as interações</returns>
        public int ObstacleEnergy(string[,] mapa, int energy,int x, int y)
        {   
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
                Console.WriteLine($"Não tem nenhum item de recuperação de energia perto. Posição: {x},{y} | Energia: {energy}");
            }
            return energy;
        }
    }    
}
