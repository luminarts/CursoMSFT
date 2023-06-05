using System;
using Jwl;
using Mp;
using Obst;
using Rbt;

namespace Jc
{
public class JewelCollector {

    public static void Main() {
    
        bool running = true;

        Mp.Map.MapInfo mapinfo = new Mp.Map.MapInfo();
        Robot rbt = new Robot();

        string[,] mapa = mapinfo.Cell;
        void PrintMap()
        {
                        // Printagem do mapa
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    Console.Write(mapa[i, j] + " ");
                }
                Console.WriteLine();
            }
        }    

        do {
            PrintMap();
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
    