using System;
using Jwl;
using Mp;
using Obst;
using Rbt;

namespace Jc
{
    public class JCInfo {
        public static Map.MapInfo mapinfo = new Map.MapInfo();
        public string [,] mapa = new string[mapinfo.Cell.GetLength(0),mapinfo.Cell.GetLength(1)];
        public string[,] MapInitialization()
        {   
            Map genmap = new Map(); 
            mapa = genmap.generatemap(); // will keep generating a new random map
            return mapa;
        }
        public void PrintMap(string[,] mapa)
        {

            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    Console.Write(mapa[j, i] + " ");
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
        public void NewStage() //After all jewels are collected, move to next phase (increase map and items) (maybe put main() inside main, so that it runs in itself?)
        {

        }
    }
    public class JewelCollector
    {
        public static void Main() {
            Robot rbt = new Robot();
            JCInfo jc = new JCInfo();
            string[,] gamemap = jc.MapInitialization();
            List<string> blockades = new List<string> {"##","$$","JB","JR","JG"};
            List<string> jewels = new List<string> {"JB","JR","JG"};
            int value = 0;

            bool running = true;
            do {
                jc.PrintMap(gamemap);
                jc.PrintBag(rbt.bag, value);
                Console.WriteLine("Enter the command: ");

                ConsoleKeyInfo command = Console.ReadKey();

                Console.WriteLine();

                int x = rbt.position[0];
                int y = rbt.position[1];

                if (command.Key == ConsoleKey.Q) {
                    running = false;
                    
                } else if (command.Key == ConsoleKey.W) {
                    
                    if (blockades.Contains(gamemap[x,y-1]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Up();
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }
                    
                } else if (command.Key == ConsoleKey.A) {

                    if (blockades.Contains(gamemap[x-1,y]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Left();
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }
                    
                } else if (command.Key == ConsoleKey.S) {
                    if (blockades.Contains(gamemap[x,y + 1]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Down();
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }

                
                    
                } else if (command.Key == ConsoleKey.D) {
                    if (blockades.Contains(gamemap[x + 1,y]) == false)
                    {
                        gamemap[rbt.position[0],rbt.position[1]] = "--";
                        rbt.Right();
                        gamemap[rbt.position[0],rbt.position[1]] = "ME";
                    }

                
                } else if (command.Key == ConsoleKey.G) {
                    
                    rbt.Grab(gamemap);

                } else {

                    Console.WriteLine("Por favor, digite algum comando válido");
                
                }
            } while (running);        
            
        }
    }    
}