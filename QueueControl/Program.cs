using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueControl
{
    class Program
    {
        public static void QControl(string queueString)
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("Program Started!!!\nEnter line:");
            Console.WriteLine("Input: " + queueString);
            string[] arrayString = queueString.Split(" ".ToCharArray());
            int n = 0;
            if (int.TryParse(arrayString[0], out n))
            {
                Console.WriteLine("Entered n is: " + n);
                int count = 0;
                QueueControl queue = new QueueControl(n);
                Console.WriteLine("Queue is initialized, and queue size is: " + queue.size());
                Console.WriteLine("Before adding objects, Queue is empty? => " + queue.isEmpty());
                for (int i = 1; count < n && i <= n && i <=arrayString.Length; i++, count++)
                {
                    Person person = new Person(count, arrayString[i]);
                    queue.enqueue(person);
                    Console.WriteLine("added : " + person.ToString());
                }
                Console.WriteLine("After adding, Queue is empty? => " + queue.isEmpty());
                Console.WriteLine("Now the queue size is " + queue.size());
                Console.WriteLine("First element in queue: " + queue.ArrQueue[queue.First].QPerson.ToString());
                Console.WriteLine("Last element in queue: " + queue.ArrQueue[queue.Last].QPerson.ToString());
                Console.WriteLine("Calling function dequeue(): " + queue.dequeue());
                Console.WriteLine("Calling function enqueue(5,'+7474010313').... ");
                queue.enqueue(new Person(count, "+77474010313"));
                Console.WriteLine("Now the last element is : " + queue.ArrQueue[queue.Last].QPerson);
            }
            else
            {
                Console.WriteLine("Entered wrong string line ");
            }

            Console.WriteLine("========================================================================");

        }

        static void Main(string[] args)
        {
            QControl("5 +77777777 +88888888 +99999999 +1000000 +3333333");
            QControl("3 +77777777 +88888888 +99999999 +1000000 +3333333");

            Console.WriteLine("Now Enter input: ");
            string queueString = Console.ReadLine();
            QControl(queueString);
            Console.WriteLine("End....");
            Console.ReadKey();
        }
        
    }
}
