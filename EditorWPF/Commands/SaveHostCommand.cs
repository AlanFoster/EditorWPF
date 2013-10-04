using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EditorWPF.Views;
using Microsoft.Win32;
using RestSharp;
using RestSharp.Deserializers;

namespace EditorWPF.Commands
{
    public class SaveHostCommand : Command<IBitmappable>
    {
        public override void Execute(IBitmappable bitmappable)
        {
          
        }
      
        public class Response
        {
            public string Message { get; set; }
            public string Url { get; set; }
        }
    }
}
