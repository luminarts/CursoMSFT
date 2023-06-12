using Mp;
using Jwl;

public class JCInfo {
        public static Map.MapInfo mapinfo = new Map.MapInfo();
        public string [,] gamemap = new string[mapinfo.Cell.GetLength(0),mapinfo.Cell.GetLength(1)];
        List<string> jewels = new List<string> {"JB","JR","JG"};
        public string[,] MapInitialization()
        {   
            Map newMap = new Map(); 
            gamemap = newMap.GenerateMap(); 
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
        public string[,] NewStage(string[,] mapa, int n) //After all jewels are collected, move to nerbt.position[0]t phase (increase map and items) (maybe put main() inside main, so that it runs in itself?)
        {   
        if (mapa.GetLength(0) < 31)
        {
            Map mp = new Map();
            Console.WriteLine(mapa.GetLength(0));
            mp.GenerateMap();
            string[,] x = mapinfo.Cell;
            return x; 
        }
        else{
            string[,] p = new string[10,10];
            return p;
        }
            // aumento do gamemap   // aumento de itens
            //
        }
        public bool JewelsInMap(string[,] mapa, List<string> jewels)
        {
            foreach(string jewel in jewels)
            {
                int k = mapa.GetLength(0);
                
                for (int x = 0; x < k; x++)
                {
                    for (int y = 0; y < k; y++)
                    {
                        if (mapa[x, y] == jewel)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }