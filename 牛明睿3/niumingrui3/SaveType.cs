using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shiyan3
{
    class SaveType : EventArgs
    {
        public readonly string text;
        public SaveType(String text)
        {
            this.text = text;
        }
    }
}