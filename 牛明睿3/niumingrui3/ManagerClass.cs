using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace shiyan3
{
    class ManagerClass
    {
        public delegate void NewClassEventHander();
        public event NewClassEventHander NewClassEvent;
        protected virtual void NewCEvent(EventArgs e)
        {
            if (NewClassEvent != null)
            {
                NewClassEvent();
            }
        }
        public void ShowClass()
        {
            Console.WriteLine("可以查看笔记类型");
            String text = string.Empty;
            StreamReader sr = new StreamReader(@"h:\notebook.txt");
            text = sr.ReadToEnd();

            Console.WriteLine(text);
            sr.Close();

            Console.WriteLine("是否需要添加笔记类型(y/n)");
            string answer = Console.ReadLine();
            if (answer.Equals("y"))
            {

                EventArgs e = new EventArgs();
                NewCEvent(e);
            }
            else { }
        }
    }
}