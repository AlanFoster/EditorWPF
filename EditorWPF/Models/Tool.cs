using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorWPF.Models
{
    abstract class Tool : ITool
    {
        public string Name { get; private set; }

        protected Tool(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
