using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.SocketServerInterfaces
{
    public interface ISocketServerEvent
    {
        event EventHandler DatabaseCloseException;
        event EventHandler DatabaseException;
        event EventHandler DatabaseOpenException;
        event EventHandler DatagramAccepted;
        event EventHandler DatagramDelimiterError;
        event EventHandler DatagramError;
        event EventHandler DatagramHandled;
        event EventHandler DatagramOversizeError;
        event EventHandler ServerClosed;
        event EventHandler ServerException;
        event EventHandler ServerListenPaused;
        event EventHandler ServerListenResumed;
        event EventHandler ServerStarted;
        event EventHandler SessionConnected;
        event EventHandler SessionDisconnected;
        event EventHandler SessionReceiveException;
        event EventHandler SessionRejected;
        event EventHandler SessionSendException;
        event EventHandler SessionTimeout;
        event EventHandler ShowDebugMessage;
    }

}
