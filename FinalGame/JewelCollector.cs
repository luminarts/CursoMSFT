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
            Map.run();
            mapa = mapinfo.Cell;
            return mapa;
        }
        public void PrintMap(string[,] mapa)
        {

            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    Console.Write(mapa[i, j] + " ");
                }
                Console.WriteLine();
            }
        }            
    }
    public class JewelCollector
    {
        public static void Main() {
            Robot rbt = new Robot();
            JCInfo jc = new JCInfo();
            string[,] gamemap = jc.MapInitialization();


            bool running = true;
            do {
                jc.PrintMap(gamemap);
                Console.WriteLine("Enter the command: ");

                string? command = Console.ReadLine();

                if (command.Equals("quit")) {
                    running = false;
                    
                } else if (command.Equals("w")) {
                    rbt.Up();

                } else if (command.Equals("a")) {
                    rbt.Left();

                } else if (command.Equals("s")) {
                    rbt.Down();

                
                    
                } else if (command.Equals("d")) {
                    rbt.Right();

                
                } else if (command.Equals("g")) {
            
            

                } else {

                    Console.WriteLine("Por favor, digite algum comando válido");
                
                }
            } while (running);        
            
        }
    }    
}