using System;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
         Tower[] towerone = new Tower[1];
         Tower[] towertwo = new Tower[2];
         Tower[] towerthree = new Tower[3];
         Block bigBlock = new Block(3);
         Block medBlock = new Block(2);
         Block smallBlock = new Block(1);
         towerone.


            
        }
    }

    class Tower
    {
        public Tower[] towers { get; set;}
        private Block[] blocks;

        public void PushBock()
        {

        }
        public void PopBlock()
        {

        }
    }


    class Block
    {
        public Block(int weight)

        {
            

        }
    }
}
