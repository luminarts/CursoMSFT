using System;
using Jwl;
using Mp;
using Obst;
using Rbt;

namespace Jc
{
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