using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = int.Parse(Console.ReadLine()).ToString().Select(x => int.Parse(x.ToString())).ToArray();
            int[] pyramid = new int[numbers.Length];
            pyramid[0] = numbers[0];
            pyramid[1] = numbers[1];
            if (pyramid[1] > pyramid[0])
            {
                swap(pyramid, 0, 1);
            }
            for (int i = 2; i < numbers.Length; i++)
            {
                Console.WriteLine("Добавляем в пирамиду " + numbers[i]);
                pyramid[i] = numbers[i];
                for (int j = 0; j < pyramid.Length; j++)
                {
                    Console.Write(pyramid[j]);
                }
                Console.WriteLine();
                build(pyramid, i);
            }
            print(pyramid);
            int[] pyramidFirst = new int[pyramid.Length + 1];
            pyramidFirst[0] = int.Parse(Console.ReadLine());
            for (int i = 1; i < pyramidFirst.Length; i++)
            {
                pyramidFirst[i] = pyramid[i - 1];
            }
            print(pyramidFirst);
            buildFirst(pyramidFirst, 0);
            print(pyramidFirst);
            
            



        }
        static void buildFirst(int[] pyramidFirst,int i)
        {
            if (i * 2 + 2 > pyramidFirst.Length - 1)
            {
                if (i * 2 > pyramidFirst.Length)
                    return;
                else
                {
                    if (pyramidFirst[i] < pyramidFirst[i * 2 + 1])
                    {
                        swap(pyramidFirst, i, i * 2 + 1);
                        return;
                    }
                }
            }
            
            if (pyramidFirst[i*2+1]>=pyramidFirst[i * 2 + 2])
            {
                if (pyramidFirst[i] < pyramidFirst[i*2+1])
                {
                    swap(pyramidFirst, i, i * 2 + 1);
                    
                    buildFirst(pyramidFirst,i*2+1);
                }
            }
            else
            {
                if (pyramidFirst[i] < pyramidFirst[i * 2 + 2])
                {
                    swap(pyramidFirst, i, i * 2 + 2);
                    buildFirst(pyramidFirst, i * 2 + 2);
                }

            }
        }
        static int[] swap(int[] numbers,int i,int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
            return numbers;
        }
        static void build(int[] pyramid,int i)
        {
            if (pyramid[(i - 1) / 2] < pyramid[i])
            {
                swap(pyramid, (i - 1) / 2, i);
                Console.WriteLine("Замена " + pyramid[(i - 1) / 2] + " на " + pyramid[i]);
                build(pyramid, (i - 1) / 2);
            }
        }
        static void print(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);
            }
            Console.WriteLine();
        }
        static void move(int[]pyramid )
        {
            for ( int i = pyramid.Length-2 ;i != 0 ;i--)
            {
                swap(pyramid, i+1, i);            
            }
        }


    }
}
