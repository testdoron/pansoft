using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pansoft.SocketServerInterfaces;

namespace Pansoft.SocketServerImplementations
{
    public class SocketServer : ISocketServerInfo, ISocketServerEvent, ISocketServer, ISocketServerSession
    {
        #region ISocketServerInfo 成员

        public int SessionExceptionCount
        {
            get { throw new NotImplementedException(); }
        }

        public int ServerExceptionCount
        {
            get { throw new NotImplementedException(); }
        }

        public int SessionCount
        {
            get { throw new NotImplementedException(); }
        }

        public int DatabaseExceptionCount
        {
            get { throw new NotImplementedException(); }
        }

        public int DatagramQueueLength
        {
            get { throw new NotImplementedException(); }
        }

        public int ErrorDatagramCount
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxSessionCount
        {
            get { throw new NotImplementedException(); }
        }

        public int ReceiveBufferSize
        {
            get { throw new NotImplementedException(); }
        }

        public int ReceivedDatagramCount
        {
            get { throw new NotImplementedException(); }
        }

        public int SendBufferSize
        {
            get { throw new NotImplementedException(); }
        }

        public int ServerPort
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int AcceptListenTimeInterval
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int CheckDatagramQueueTimeInterval
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int CheckSessionTableTimeInterval
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int LoopWaitTime
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MaxDatagramSize
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MaxListenQueueLength
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MaxReceiveBufferSize
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MaxSameIPCount
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MaxSessionTableLength
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MaxSessionTimeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ISocketServerEvent 成员

        public event EventHandler DatabaseCloseException;

        public event EventHandler DatabaseException;

        public event EventHandler DatabaseOpenException;

        public event EventHandler DatagramAccepted;

        public event EventHandler DatagramDelimiterError;

        public event EventHandler DatagramError;

        public event EventHandler DatagramHandled;

        public event EventHandler DatagramOversizeError;

        public event EventHandler ServerClosed;

        public event EventHandler ServerException;

        public event EventHandler ServerListenPaused;

        public event EventHandler ServerListenResumed;

        public event EventHandler ServerStarted;

        public event EventHandler SessionConnected;

        public event EventHandler SessionDisconnected;

        public event EventHandler SessionReceiveException;

        public event EventHandler SessionRejected;

        public event EventHandler SessionSendException;

        public event EventHandler SessionTimeout;

        public event EventHandler ShowDebugMessage;

        #endregion

        #region ISocketServer 成员

        public bool Closed
        {
            get { throw new NotImplementedException(); }
        }

        public bool ListenPaused
        {
            get { throw new NotImplementedException(); }
        }

        public bool Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void PauseListen()
        {
            throw new NotImplementedException();
        }

        public void ResumeListen()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ISocketServerSession 成员

        public void SendToAllSessions(string datagramText)
        {
            throw new NotImplementedException();
        }

        public void SendToSession(int sessionId, string datagramText)
        {
            throw new NotImplementedException();
        }

        public void CloseAllSessions()
        {
            throw new NotImplementedException();
        }

        public void CloseSession(int sessionId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
