using System;

namespace QueueControl
{
    class Program
    {

        public static readonly Random r = new Random();
        public static int[] arrUniqueID=new int[100];
        public static int arrUniqueIndex=0;
        public static void QControl(string queueString)
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("Program Started!!!");
            Console.WriteLine("Input: " + queueString);
            string[] arrayString = queueString.Split(" ".ToCharArray()); //массив arrayString для хранение все значение отдельно
            int n = 0;
            if (int.TryParse(arrayString[0], out n))
            {
                Console.WriteLine("Entered n is: " + n);
                int count = 0;//для считывание количество  добавленных элементов
                QueueControl queue = new QueueControl(n);
                Console.WriteLine("Queue is initialized, and queue size is: " + queue.size());
                Console.WriteLine("Before adding objects, Queue is empty? => " + queue.isEmpty());
                
                for (int i = 1; i <= n && i <=arrayString.Length; i++)
                {
                    Person person = new Person(generateUniqueId(), arrayString[i]);
                    queue.enqueue(person);
                    Console.WriteLine("added : " + person.ToString());
                }

                Console.WriteLine("After adding, Queue is empty? => " + queue.isEmpty());
                Console.WriteLine("Now the queue size is " + queue.size());
                Console.WriteLine("First element in queue: " + queue.ArrQueue[queue.First].QPerson);
                Console.WriteLine("Last element in queue: " + queue.ArrQueue[queue.Last].QPerson);
                Console.WriteLine("\nSorted By Id : ");
                queue.sortByID();
                Console.WriteLine("\nSorted By PhoneNumber : ");
                queue.sortByPhoneNumber();
                Console.WriteLine("\nCalling function dequeue(): " + queue.dequeue());
                Console.WriteLine(queue.size());
                Console.WriteLine("Calling function enqueue().... ");
                queue.enqueue(new Person(11, "+77474010313"));
                Console.WriteLine("Now the last element is : " + queue.ArrQueue[queue.Last].QPerson);
            }
            else
            {
                Console.WriteLine("Entered wrong string line ");
            }

            Console.WriteLine("========================================================================");

        }

        private static int generateUniqueId()
        {
            int Id = 0;
            bool find = true;
            while (true)
            {
                Id = r.Next(r.Next(1,1000000));
                foreach(int num in arrUniqueID)
                {
                    find = (num == Id) ?  false : true;
                }
                if (find)
                {
                    arrUniqueID[arrUniqueIndex] = Id;
                    return Id;
                }
            }
            return 0;
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
