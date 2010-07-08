using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.SocketServerInterfaces
{
    public interface ISocketServer
    {
        bool Closed { get; }
        bool ListenPaused { get; }

        bool Start();
        void Stop();
        void PauseListen();
        void ResumeListen();
    }

}
