using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {

            Tower towerone = new Tower("A"); 
            Tower towertwo = new Tower("B");
            Tower towerthree = new Tower("C");
            Block bigBlock = new Block(3);
            Block medBlock = new Block(2);
            Block smallBlock = new Block(1);

            List<Tower> Towers = new List<Tower>();

            Towers.Add(towerone);
            Towers.Add(towertwo);
            Towers.Add(towerthree);

        
            Console.WriteLine("ay");
         


            towerone.blocks.Add(bigBlock);
            towerone.blocks.Add(medBlock);
            towerone.blocks.Add(smallBlock);
         

         
            Console.WriteLine($"1| {towerone.GetBlocks()}");
            Console.WriteLine($"2| {towertwo.GetBlocks()}");
            Console.WriteLine($"3| {towerthree.GetBlocks()}");
            
            MoveBlock();

            void MoveBlock()
            {          
            Console.WriteLine("Which tower would you like to move the block From? A, B, or C?");
            string fromTower = Console.ReadLine().ToLower();
            Console.WriteLine("Which tower would you like to move the block TO? A, B, or C?");
            string toTower = Console.ReadLine().ToLower();
            }

            
        }  
            
        
    }

    class Tower
    {

        public List<Block> blocks = new List<Block>();
        public string name {get; private set;}


        


        public Tower(string name)
        {
            this.name = name;
            this.blocks = new List<Block>();
        }

        public bool addBlock(Tower fromTower, Tower toTower)
        {
            Block movingBlock = fromTower.blocks[fromTower.blocks.Count -1];
            Block lastBlock = toTower.blocks[toTower.blocks.Count -1];
            if(lastBlock.weight >movingBlock.weight)
            {
                return false;
            }
            else
            {
                fromTower.blocks.Remove(movingBlock);
                toTower.blocks.Add(movingBlock);
                return true;
            }

        }  
        public string GetBlocks()
        {
            string column = "";
            if(blocks.Count > 0)
            {
                foreach(var b in blocks)
                {
                    if( b != null)
                    {
                        column += b.weight.ToString();
                    }
                }
                
            }
            return column;
        }         
    }


    public class Block
    {
        public int weight {get; private set;}

        public Block(int weight)

        {
            this.weight = weight;
            
        }
    }


}
