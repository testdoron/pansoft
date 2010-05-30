using System;
using System.Collections.Generic;
using System.Text;
using com.pan.csharp.TicketGetter.OptionForm;

namespace Demo.TicketGetterOptionForm
{
    class Program
    {
        static void Main(string[] args)
        {
            OptionForm form = OptionForm.Instance();
            form.ShowDialog();
        }
    }
}
