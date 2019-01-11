using System;

namespace QueueControl
{
    public class QueueControl : IQueue<Person>
    {
        public int First { get; set; }
        public int Last { get; set; }
        public PersonQueue[] ArrQueue; // для хранение объектов

        public QueueControl(int size)
        {
            ArrQueue = new PersonQueue[size];
            First = Last = -1;
        }

        public Person dequeue()
        {
            if (!isEmpty())
            {
                PersonQueue tmp = ArrQueue[First];
                ArrQueue[First] = null;
                if (tmp.nextPersonId != 0)
                {
                    First = getPlace(tmp.nextPersonId);
                    tmp.QPerson = null; tmp = null;

                    return ArrQueue[First].QPerson;
                }
                else
                {
                    First = Last = -1;
                }
                tmp = null;
            }
            return null;
        }


        //Return index of object in array
        public int getPlace(int id)
        {
            int index = -1;
            for (int i = 0; i < ArrQueue.Length; i++)
            {
                if (ArrQueue[i] != null && ArrQueue[i].QPerson.PersonId == id)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void enqueue(Person person)
        {
            int sizeOfQueue = size();
            if (sizeOfQueue < ArrQueue.Length)
            {
                PersonQueue tmp = new PersonQueue(person);
                if (sizeOfQueue==0)
                {
                    First = Last = 0;
                    ArrQueue[First] = tmp;

                }
                else
                {
                    for(int i=0; i<ArrQueue.Length; i++)
                    {
                        if (ArrQueue[i] == null)
                        {
                            ArrQueue[Last].nextPersonId = person.PersonId;
                            Last = i;
                            ArrQueue[Last] = tmp;
                            break;
                        }
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Not added,the queue size is full !!!");
            }
        }

        public bool isEmpty()
        {
            return (size() == 0) ? true : false;
        }

        public int size()
        {
            if (First == -1) return 0;

            int size = 1, current = First;

            while (ArrQueue[current].nextPersonId != 0)
            {
                size++;
                current = getPlace(ArrQueue[current].nextPersonId);
            }
            return size;
        }

        public void sortByID()
        {
            int sizeOfQueue = size();
            if (sizeOfQueue==0)
            {
                Console.WriteLine("The queue is Empty");
                return;
            }

            PersonQueue[] arrSortedById = new PersonQueue[sizeOfQueue];
            int index = First;
            
            for(int i=0; i<sizeOfQueue; i++)
            {
                arrSortedById[i] = ArrQueue[index];
                if (ArrQueue[index].nextPersonId != 0)
                {
                    index = getPlace(ArrQueue[index].nextPersonId);
                }
                
            }

            for (int i = 0; i < sizeOfQueue; i++)
            {
                for (int j = i + 1; j <sizeOfQueue-1; j++)
                {
                    int a = arrSortedById[i].QPerson.PersonId;
                    int b = arrSortedById[j].QPerson.PersonId;
                    if (a > b)
                    {
                        var tmp = arrSortedById[i];
                        arrSortedById[i] = arrSortedById[j];
                        arrSortedById[j] = tmp;
                    }
                }
            }

            foreach (PersonQueue personQueue in arrSortedById)
            {
                Console.WriteLine(personQueue.QPerson.PersonId + " => " + personQueue.QPerson.PhoneNumber);
            }
        }

        public void sortByPhoneNumber()
        {
            int sizeOfQueue = size();
            if (sizeOfQueue == 0)
            {
                Console.WriteLine("The queue is Empty");
                return;
            }

            PersonQueue[] arrSortedByPhoneNumber = new PersonQueue[sizeOfQueue];
            int index = First;

            for (int i = 0; i < sizeOfQueue; i++)
            {
                arrSortedByPhoneNumber[i] = ArrQueue[index];
                if (ArrQueue[index].nextPersonId != 0)
                {
                    index = getPlace(ArrQueue[index].nextPersonId);
                }

            }

            for (int i = 0; i < sizeOfQueue; i++)
            {
                for (int j = i + 1; j <sizeOfQueue-1; j++)
                {
                    string a = arrSortedByPhoneNumber[i].QPerson.PhoneNumber;
                    string b = arrSortedByPhoneNumber[j].QPerson.PhoneNumber;
                    if (a.CompareTo(b) > 0)
                    {
                        var tmp = arrSortedByPhoneNumber[i];
                        arrSortedByPhoneNumber[i] = arrSortedByPhoneNumber[j];
                        arrSortedByPhoneNumber[j] = tmp;
                    }
                }
            }


            foreach (PersonQueue personQueue in arrSortedByPhoneNumber)
            {
                Console.WriteLine(" { " + personQueue.QPerson.PersonId + " => " + personQueue.QPerson.PhoneNumber + " } ");
            }
        }

    }
}
