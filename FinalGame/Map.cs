using Obst;
using Jwl;
using Rbt;
using System.Collections.Generic;

namespace Mp
{
    public class Map
    {
        /// <summary>
        /// Esse método serve para gerar o mapa a partir de outros métodos combinados.
        /// </summary>
        /// <returns>Retorna uma matrix x, que representa o mapa gerado.</returns>
        public string[,] GenerateMap()
        {
            MapInfo newMap = new MapInfo();

            newMap.CellObstacleGeneration();
            newMap.CellJewelGeneration();
            newMap.CellRobotGeneration();
            string[,] x;
            x = newMap.Cell;
            return x; 
        }

        public class MapInfo
        {
            
            string[] obstacles = new string[3];
            public string[,] Cell = new string[10,10];
            public int x;
            public int y;
            /// <summary>
            /// Esse método serve para colocar os obstáculos nos lugares definidos por suas posições, que por sua vez, foram definidas na classe Obstacle
            /// </summary>
            public void CellObstacleGeneration()
            {
                Obstacle obst = new Obstacle();

                int[,] treepositions = obst.Tree();

                for (int i = 0; i < treepositions.GetLength(0); i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x = treepositions[i,j];
                        }
                        else
                        {
                            y = treepositions[i,j];
                            Cell[x,y] = obst.name;
                        }
                    }
                }

                int[,] waterpositions = obst.Water();

                for (int i = 0; i < waterpositions.GetLength(0); i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x = waterpositions[i,j];
                        }
                        else
                        {
                            y = waterpositions[i,j];
                            Cell[x,y] = obst.name;
                        }
                    }
                }

                int[,] radiopositions = obst.RadioactiveElement();

                for (int i = 0; i < radiopositions.GetLength(0); i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x = radiopositions[i,j];
                        }
                        else
                        {
                            y = radiopositions[i,j];
                            Cell[x,y] = obst.name;
                        }
                    }
                }
                
                obst.Empty();

                for (int i = 0; i < Cell.GetLength(0); i++)
                {
                    for (int j = 0; j < Cell.GetLength(1); j++)
                    {
                        if (Cell[i,j] == null)
                        {
                            Cell[i,j] = obst.name;
                            
                        }

                    }
                }
            }
            /// <summary>
            /// Esse método serve para colocar as jóias nos lugares definidos por suas posições, que por sua vez, foram definidas na classe Jewel
            /// </summary>
            public void CellJewelGeneration()
            {
                Jewel jwl = new Jewel();
                int[,] redpositions = jwl.Red();

                for (int i = 0; i < redpositions.GetLength(0); i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x = redpositions[i,j];
                        }
                        else
                        {
                            y = redpositions[i,j];
                            Cell[x,y] = jwl.name;
                        }
                    }
                }

                int[,] greenpositions = jwl.Green();

                for (int i = 0; i < greenpositions.GetLength(0); i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x = greenpositions[i,j];
                        }
                        else
                        {
                            y = greenpositions[i,j];
                            Cell[x,y] = jwl.name;
                        }
                    }
                }

                int[,] bluepositions = jwl.Blue();

                for (int i = 0; i < bluepositions.GetLength(0); i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            x = bluepositions[i,j];
                        }
                        else
                        {
                            y = bluepositions[i,j];
                            Cell[x,y] = jwl.name;
                        }
                    }
                }
            }
            /// <summary>
            /// Esse método serve para colocar o robô no seu lugar definido por sua posição, que por sua vez, foram definidas na classe Robot.
            /// </summary>
            public void CellRobotGeneration()
            {
                Robot rbt = new Robot();
                Cell[rbt.position[0], rbt.position[1]] = rbt.name;
            }      
        }
    }
}
