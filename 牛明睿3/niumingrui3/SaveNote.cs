using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace shiyan3
{
    class SaveNote
    {
        public void Savenote(object sender, SaveType text)
        {
            StreamWriter sw = new StreamWriter(@"h:\notebook.txt");
            sw.WriteLine(text);
            Console.WriteLine("笔记本保存成功");
            sw.Close();
        }
    }
}