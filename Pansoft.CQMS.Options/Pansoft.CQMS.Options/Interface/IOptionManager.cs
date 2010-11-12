using System;
using System.IO;
namespace Pansoft.ManagerDesktop.Options.Manager
{
    interface IOptionManager
    {
        FileInfo Backup(string file);
        OptionCollection Options { get; }
        void Initializes(string optionFile);
        bool IsChange { get; }
        void ReLoad();
        bool Save();
    }
}
