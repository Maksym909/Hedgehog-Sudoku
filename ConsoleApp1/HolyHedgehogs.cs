using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Hedgehog
    {
        #region
        enum Color : int
        {
            Red = 0,
            Green = 1,
            Blue = 2
        }
        // 0 - червоний, 1 - зелений, 2 - синій.
        private int CheckColor(int requireColor)
        {
            int last = (int)Enum.GetValues(typeof(Color)).Cast<Color>().Last();
            int first =(int) Enum.GetValues(typeof(Color)).Cast<Color>().First();
            if (requireColor < first && requireColor > last)
                return -1;
            else
                return 0;
        }
        private int CheckAmount(int requireColor, int[] hedgehogs)
        {
            if (hedgehogs[requireColor] == hedgehogs.Sum())
                return -1;
            else 
                return 0;
        }
        private int CheckNegativeNumb(int[] hedgehogs)
        {
            for (int i = 0; i < hedgehogs.Length; i++)
            {
                if (hedgehogs[i] < 0 || hedgehogs[i] > int.MaxValue)
                    return -1;
            }

            return 0;
        }
        private int CheckAll(int requireColor, int[] hedgehogs)
        {
            int color = CheckColor(requireColor);
            int negativeNumb = CheckNegativeNumb(hedgehogs);
            int amount = CheckAmount(requireColor, hedgehogs);
            
            bool result = color + negativeNumb + amount == 0 ? true : false;
            if (result)
                return 0;
            else
                return -1;

        }

        private  int Logic(int requireColor, int[] hedgehogs)
        {
            int allHedgehogs = hedgehogs.Sum();
            int require = hedgehogs[requireColor];
            int counter = 0;
            int tempColor;

            do{
                counter++;
                if (allHedgehogs - hedgehogs.Max()-hedgehogs.Min() == allHedgehogs / hedgehogs.Length) // correct count if all colors equal 
                {
                    return counter;
                }

                tempColor = hedgehogs.ToList().IndexOf(hedgehogs.Max());  
                for (int i = 0; i < hedgehogs.Length; i++)
                {
                    if (i != tempColor)
                    {
                        hedgehogs[i] += hedgehogs[tempColor];
                        hedgehogs[tempColor] = 0;
                    }
                }
                allHedgehogs -= hedgehogs[tempColor];
                require -= hedgehogs[tempColor];
                hedgehogs[tempColor] = 0;
                

                if (require == allHedgehogs)
                {
                    return counter;
                }

                if (require == 0 || allHedgehogs - require < 2)
                {
                    return -1;
                }
              
            } while (tempColor != requireColor);


            return counter;
        }
        #endregion
        public int ChangeColor(int requireColor, int[] hedgehogs)
        {
            if (CheckAll(requireColor, hedgehogs) == 0)
                return Logic(requireColor, hedgehogs);
            else
                return -1;
        }

    }
    public class HolyHedgehogs
    {
       
        public static void Main()
        {
            int[] list = new[] { 8,1,9 }; //3
            int[] list1 = new[] { 0, 0, 10 }; //-1
            int[] list2 = new[] { 15, 15, 15 }; //1
            int[] list3 = new[] { -1, 4, 85 };//-1
            int[] list4 = new[] {1001, 1001, 1001 };
           

            Hedgehog hedge = new Hedgehog();

            Console.WriteLine(hedge.ChangeColor(1, list)); //3
            Console.WriteLine(hedge.ChangeColor(2, list1));//-1
            Console.WriteLine(hedge.ChangeColor(0, list2));//1

            Console.WriteLine(hedge.ChangeColor(1, list3));//-1
            Console.WriteLine(hedge.ChangeColor(2, list4));//1



        }
    }
}
