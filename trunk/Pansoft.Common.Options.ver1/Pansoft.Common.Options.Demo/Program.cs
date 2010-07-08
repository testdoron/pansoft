using System;
using System.Collections.Generic;
using System.Text;

namespace Pansoft.Common.Options.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IOptionManager ow = OptionWorker.Current;
            ow.Initializes("my.option", true);
            Console.WriteLine(ow.Option[0].Value.Value);
            
        }
    }
}
