using System;
using Jc;
using Mp;
using Jwl;

namespace Rbt
{
    /// <summary>
    /// Essa classe armazena as informações de movimentação e ações do robô, além de sua relação energética com a joia azul
    /// </summary>
    public class Robot 
    {
        Map.MapInfo newMap = new Map.MapInfo();

        public string name = "ME";
        public int[] position = {0,0};
        public int points;
        public List<string> bag = new List<string>();
        /// <summary>
        /// Esse método serve para executar a movimentação do robô para a esquerda no mapa.
        /// </summary>
        public void Left()
        {
            if (position[0] - 1 >= 0)
            {
                position[0]--;
            }
        }
        /// <summary>
        /// Esse método serve para executar a movimentação do robô para a direita no mapa.
        /// </summary>
        public void Right()
        {
            if (position[0] + 1 < newMap.Cell.GetLength(0))
            {
                position[0]++;

            }
        }
        /// <summary>
        /// Esse método serve para executar a movimentação do robô para cima no mapa.
        /// </summary>
        public void Up()
        {
            if (position[1] - 1 >= 0)
            {
                position[1]--;

            }
        }
        /// <summary>
        /// Esse método serve para executar a movimentação do robô para baixo no mapa.
        /// </summary>
        public void Down()
        {
            if (position[1] + 1 < newMap.Cell.GetLength(0))
            {
                position[1]++;

            }
        }
        /// <summary>
        /// Esse método serve para realizar a coleta das jewels no mapa e as relações de energia com a jewel azul.
        /// </summary>
        /// <param name="mapa">O parâmetro mapa serve para se orientar em relação à distância do robô à jewel</param>
        /// <param name="energy">O parâmetro energy serve para armazenar as interações de energy que houver com a jewel azul</param>
        /// <returns>Retorna o valor de energy final após as interações para substituir o valor anterior.</returns>
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
