using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.SocketServerInterfaces
{
    public interface ISocketServerInfo
    {
        int SessionExceptionCount { get; }
        int ServerExceptionCount { get; }
        int SessionCount { get; }
        int DatabaseExceptionCount { get; }
        int DatagramQueueLength { get; }
        int ErrorDatagramCount { get; }
        int MaxSessionCount { get; }
        int ReceiveBufferSize { get; }
        int ReceivedDatagramCount { get; }
        int SendBufferSize { get; }

        int ServerPort { get; set; }
        int AcceptListenTimeInterval { get; set; }
        int CheckDatagramQueueTimeInterval { get; set; }
        int CheckSessionTableTimeInterval { get; set; }
        int LoopWaitTime { get; set; }
        int MaxDatagramSize { get; set; }
        int MaxListenQueueLength { get; set; }
        int MaxReceiveBufferSize { get; set; }
        int MaxSameIPCount { get; set; }
        int MaxSessionTableLength { get; set; }
        int MaxSessionTimeout { get; set; }
    }
}
