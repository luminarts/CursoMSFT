using Mp;
using Jwl;

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