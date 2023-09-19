using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Task
    {
        public int id { get; set; }
        public string done {  get; set; }
        public string dueDate { get; set; }
        public string priority { get; set; }
        public string task { get; set; }

        public Task() { }

        public Task(int id, string done, string dueDate, string priority, string taskName)
        {
            this.id = id;
            this.done = done;  
            this.dueDate = dueDate;
            this.priority = priority;
            this.task = taskName;
        }
    }
}
