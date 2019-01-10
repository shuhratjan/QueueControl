using System;

namespace QueueControl
{
    public class QueueControl : IQueue<Person>
    {
        public int First { get; set; }
        public int Last { get; set; }
        public PersonQueue[] ArrQueue;

        public QueueControl(int size)
        {
            ArrQueue = new PersonQueue[size];
            First = -1;
            Last = -1;
        }

        public Person dequeue()
        {
            if (!isEmpty())
            {
                PersonQueue tmp = ArrQueue[First];
                if (tmp.nextPersonId != 0)
                {
                    First = tmp.nextPersonId;
                    tmp.QPerson = null;
                    tmp = null;
                    return ArrQueue[First].QPerson;
                }
                else
                {
                    First = -1;
                }
                tmp = null;
            }
            return null;
        }

        public void enqueue(Person person)
        {
            if (size() > Last)
            {
                PersonQueue tmp = new PersonQueue(person);
                if (isEmpty())
                {
                    First = Last = 0;
                    ArrQueue[First] = tmp;
                }
                else
                {
                    ArrQueue[Last].nextPersonId = Last + 1;
                    Last++;
                    ArrQueue[Last] = tmp;
                }
            }
            else
            {
                Console.WriteLine("Not added,the queue size is full !!!");
            }
        }

        public bool isEmpty()
        {
            return (First == -1) ? true : false;
        }

        public int size()
        {
            if (isEmpty()) return 0;

            int size = 1, current = First;
            while (ArrQueue[current].nextPersonId != 0)
            {
                current++;
                size++;
            }
            return size;
        }

        public void sortByID()
        {
            
            if (isEmpty())
            {
                Console.WriteLine("The queue is Empty");
            }
            
            PersonQueue[] arrSortedById = new PersonQueue[size()];
            for (int i = First; i <Last; i++)
            {
                if(arrSortedById[i].QPerson.PersonId> arrSortedById[i + 1].QPerson.PersonId)
                {
                    PersonQueue tmp = ArrQueue[i+1];
                    for (int j=i; j>First; j--)
                    {
                        ArrQueue[j+1] = ArrQueue[j];
                        if (tmp.QPerson.PersonId > ArrQueue[j - 1].QPerson.PersonId)
                        {
                            ArrQueue[j] = tmp;
                            break;
                        }
                    }
                }
            }

            foreach(PersonQueue personQueue in arrSortedById)
            {
                Console.WriteLine(personQueue.QPerson.PersonId + " => " + personQueue.QPerson.PhoneNumber);
            }
        }

        public void sortByPhoneNumber()
        {
            
        }

    }
}
