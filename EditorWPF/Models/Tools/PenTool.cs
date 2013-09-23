using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorWPF.Models.Tools
{
    class PenTool : Tool
    {
        private const string ToolName = "Pen";

        public PenTool()
            : base(ToolName)
        {
        }
    }
}
