using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueControl
{
    public interface IQueue<T>where T:class
    {
        T dequeue();                // - удаляет и возвращает первый элемент в очереди
        void enqueue(T tObject);         // - добавляет последний элемент в очередь
        bool isEmpty();                  // - возвращает true если очередь пуста
        int size();                      // - возвращает количество элементов в очереди
        void sortByID();                 // - сортирует элементы по возрастанию ID
        void sortByPhoneNumber();        // - сортирует элементы по возрастанию PhoneNumber

    }
}
