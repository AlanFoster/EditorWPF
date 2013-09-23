using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorWPF.Models
{
    class Pen : Tool
    {
        private const string ToolName = "Pen";

        public Pen()
            : base(ToolName)
        {
        }
    }
}
