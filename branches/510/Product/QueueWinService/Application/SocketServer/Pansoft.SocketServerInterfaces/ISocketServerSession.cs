using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.SocketServerInterfaces
{
    public interface ISocketServerSession
    {
        void SendToAllSessions(string datagramText);
        void SendToSession(int sessionId, string datagramText);
        void CloseAllSessions();
        void CloseSession(int sessionId);
    }
}
