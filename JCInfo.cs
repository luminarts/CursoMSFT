using Mp;
using Jwl;

public class JCInfo {
        public static Map.MapInfo mapinfo = new Map.MapInfo();
        public string [,] gamemap = new string[mapinfo.Cell.GetLength(0),mapinfo.Cell.GetLength(1)];
        List<string> jewels = new List<string> {"JB","JR","JG"};
        /// <summary>
        /// Este método serve para a geração inicial do mapa antes de imprimí-lo.
        /// </summary>
        /// <returns>Retorna uma matriz chamada gamemap</returns>
        public string[,] MapInitialization()
        {   
            Map newMap = new Map(); 
            gamemap = newMap.GenerateMap(); 
            return gamemap;
        }
        /// <summary>
        /// Esse método serve para imprimir o mapa no terminal.
        /// </summary>
        /// <param name="gamemap"> esse parâmetro será a matriz do mapa a ser impressa</param>
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
        /// <summary>
        /// Esse método serve para imprimir o valor das joias coletadas e a quantidade.
        /// </summary>
        /// <param name="b"> b é um parâmetro de coleção-lista, que será a referência dos nomes das jewels</param>
        /// <param name="v"> v é um parâmetro inteiro para definir o valor que a soma das joias coletadas dão</param>
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
        /// <summary>
        /// Esse método serve para gerar um novo mapa em um novo nível. Necessita revisão, pois não funciona corretamente no atual momento.
        /// </summary>
        /// <param name="mapa">mapa é o parâmetro matricial em que será colocado o mapa atual do jogo</param>
        /// <param name="n">n é o parâmetro que indica o nível de jogo. Inutilizado no momento.</param>
        /// <returns>retorna x, que seria o mapa modificado ou p, que é o mapa não-modificado.</returns>
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
        }
        /// <summary>
        /// Esse método serve para verificar a existência de jewels no mapa
        /// </summary>
        /// <param name="mapa">mapa é o parâmetro matricial em que será colocado o mapa atual do jogo</param>
        /// <param name="jewels">jewels é o parâmetro de coleção-lista que fará referência à lista de tipos de jewels existentes</param>
        /// <returns>true se há jewels no mapa e false se não há</returns>
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