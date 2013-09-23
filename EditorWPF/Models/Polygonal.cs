using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorWPF.Models
{
    internal class Polygonal : Tool
    {
        private const string ToolName = "Polygonal";

        public Polygonal()
            : base(ToolName)
        {
        }
    }
}
