﻿
namespace QueueControl
{
    public class PersonQueue
    {
        public Person QPerson{get; set;} //Person that stands in Queue
        public int nextPersonId { get; set; } //next Person id(if exist), or by default 0

        public PersonQueue(Person person)
        {
            QPerson = person;
            nextPersonId = 0;
        }
    }
}
