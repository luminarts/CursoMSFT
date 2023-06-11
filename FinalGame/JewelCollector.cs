using System;
using Jwl;
using Mp;
using Obst;
using Rbt;

namespace Jc
{
    public class JCInfo {
        public static Map.MapInfo mapinfo = new Map.MapInfo();
        public string [,] gamemap = new string[mapinfo.Cell.GetLength(0),mapinfo.Cell.GetLength(1)];
        public string[,] MapInitialization()
        {   
            Map genmap = new Map(); 
            gamemap = genmap.generatemap(); // will keep generating a new random map
            return gamemap;
        }
        public void PrintMap(string[,] gamemap)
        {

            for (int i = 0; i < gamemap.GetLength(0); i++)
            {
                for (int j = 0; j < gamemap.GetLength(1); j++)
                {
                    Console.Write(gamemap[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
        public void PrintBag(List<string> b, int v)
        {
            int ammount = b.Count;
            Jewel jwl = new Jewel();

            foreach (string jewel in b)
            {
                if (jewel == "JG")
                {
                    v += jwl.greenpoints;
                }
                else if (jewel == "JB")
                {
                    v += jwl.bluepoints;
                }
                else if (jewel == "JR")
                {
                    v += jwl.redpoints;
                }
            }
            
            Console.WriteLine($"Bag total items: {ammount} | Bag total value: {v}");

            
        }
        public void NewStage() //After all jewels are collected, move to nerbt.position[0]t phase (increase map and items) (maybe put main() inside main, so that it runs in itself?)
        {
            // aumento do gamemap
            // aumento de itens
            //
        }
    }
    public class JewelCollector
    {
        public static void Main() {
            Robot rbt = new Robot();
            JCInfo jc = new JCInfo();
            Obstacle obst = new Obstacle();
            Jewel jwl = new Jewel();

            string[,] gamemap = jc.MapInitialization();
            List<string> blockades = new List<string> {"##","$$","JB","JR","JG"};
            List<string> jewels = new List<string> {"JB","JR","JG"};
            List<string> obstacles = new List<string> {"##", "$$"};
            int value = 0;
            int energy = 100;

            bool running = true;
            do {
                jc.PrintMap(gamemap);
                jc.PrintBag(rbt.bag, value);
                energy = obst.ObstacleEnergy(gamemap,energy,rbt.position[0],rbt.position[1]);
               
                Console.WriteLine($"Energia Restante: {energy}");

                Console.WriteLine("Enter the command: ");

                ConsoleKeyInfo command = Console.ReadKey();

                Console.WriteLine();


                if (energy <= 0)
                {
                    Console.WriteLine("Você ficou sem energia! Tente de novo.");
                    running = false;
                }

                if (command.Key == ConsoleKey.Q) {
                    running = false;
                    
                } else if (command.Key == ConsoleKey.W) {
                    
                    //antes dele se mexer, identificar presença de elemento radioativo e realizar a condição de transpassagem
                    if (blockades.Contains(gamemap[rbt.position[0],rbt.position[1]-1]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Up();
                        energy--;
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }
                    
                } else if (command.Key == ConsoleKey.A) {
                    //antes dele se mexer, identificar presença de elemento radioativo e realizar a condição de transpassagem
                    if (blockades.Contains(gamemap[rbt.position[0]-1,rbt.position[1]]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Left();
                        energy--;
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }
                    
                } else if (command.Key == ConsoleKey.S) {


                    //antes dele se mexer, identificar presença de elemento radioativo e realizar a condição de transpassagem
                    if (blockades.Contains(gamemap[rbt.position[0],rbt.position[1] + 1]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Down();
                        energy--;
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }

                
                    
                } else if (command.Key == ConsoleKey.D) {

                    //antes dele se mexer, identificar presença de elemento radioativo e realizar a condição de transpassagem
                    if (blockades.Contains(gamemap[rbt.position[0] + 1,rbt.position[1]]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Right();
                        energy--;
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }

                
                } else if (command.Key == ConsoleKey.G) {
                    
                    energy = rbt.Grab(gamemap, energy);
                    
                } else {

                    Console.WriteLine("Por favor, digite algum comando válido");
                
                }
            } while (running);        
            
        }
    }    
}