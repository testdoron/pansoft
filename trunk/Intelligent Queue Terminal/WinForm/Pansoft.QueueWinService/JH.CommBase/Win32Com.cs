using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace JH.CommBase
{
    public class Win32Com
    {
        /// <summary>
        /// Opening Testing and Closing the Port Handle.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile(String lpFileName, UInt32 dwDesiredAccess, UInt32 dwShareMode,
            IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition, UInt32 dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        //Constants for errors:
        public const UInt32 ERROR_FILE_NOT_FOUND = 2;
        public const UInt32 ERROR_INVALID_NAME = 123;
        public const UInt32 ERROR_ACCESS_DENIED = 5;
        public const UInt32 ERROR_IO_PENDING = 997;
        public const UInt32 ERROR_IO_INCOMPLETE = 996;

        //Constants for return value:
        public const Int32 INVALID_HANDLE_VALUE = -1;

        //Constants for dwFlagsAndAttributes:
        public const UInt32 FILE_FLAG_OVERLAPPED = 0x40000000;

        //Constants for dwCreationDisposition:
        public const UInt32 OPEN_EXISTING = 3;

        //Constants for dwDesiredAccess:
        public const UInt32 GENERIC_READ = 0x80000000;
        public const UInt32 GENERIC_WRITE = 0x40000000;

        [DllImport("kernel32.dll")]
        public static extern Boolean CloseHandle(IntPtr hObject);

        /// <summary>
        /// Manipulating the communications settings.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern Boolean GetCommState(IntPtr hFile, ref DCB lpDCB);

        [DllImport("kernel32.dll")]
        public static extern Boolean GetCommTimeouts(IntPtr hFile, out COMMTIMEOUTS lpCommTimeouts);

        [DllImport("kernel32.dll")]
        public static extern Boolean BuildCommDCBAndTimeouts(String lpDef, ref DCB lpDCB, ref COMMTIMEOUTS lpCommTimeouts);

        [DllImport("kernel32.dll")]
        public static extern Boolean SetCommState(IntPtr hFile, [In] ref DCB lpDCB);

        [DllImport("kernel32.dll")]
        public static extern Boolean SetCommTimeouts(IntPtr hFile, [In] ref COMMTIMEOUTS lpCommTimeouts);

        [DllImport("kernel32.dll")]
        public static extern Boolean SetupComm(IntPtr hFile, UInt32 dwInQueue, UInt32 dwOutQueue);

        [StructLayout(LayoutKind.Sequential)]
        public struct COMMTIMEOUTS
        {
            //JH 1.1: Changed Int32 to UInt32 to allow setting to MAXDWORD
            public UInt32 ReadIntervalTimeout;
            public UInt32 ReadTotalTimeoutMultiplier;
            public UInt32 ReadTotalTimeoutConstant;
            public UInt32 WriteTotalTimeoutMultiplier;
            public UInt32 WriteTotalTimeoutConstant;
        }
        //JH 1.1: Added to enable use of "return immediately" timeout.
        public const UInt32 MAXDWORD = 0xffffffff;

        [StructLayout(LayoutKind.Sequential)]
        public struct DCB
        {
            public Int32 DCBlength;
            public Int32 BaudRate;
            public Int32 PackedValues;
            public Int16 wReserved;
            public Int16 XonLim;
            public Int16 XoffLim;
            public Byte ByteSize;
            public Byte Parity;
            public Byte StopBits;
            public Byte XonChar;
            public Byte XoffChar;
            public Byte ErrorChar;
            public Byte EofChar;
            public Byte EvtChar;
            public Int16 wReserved1;

            public void init(bool parity, bool outCTS, bool outDSR, int dtr, bool inDSR, bool txc, bool xOut,
                bool xIn, int rts)
            {
                //JH 1.3: Was 0x8001 ans so not setting fAbortOnError - Thanks Larry Delby!
                DCBlength = 28; PackedValues = 0x4001;
                if (parity) PackedValues |= 0x0002;
                if (outCTS) PackedValues |= 0x0004;
                if (outDSR) PackedValues |= 0x0008;
                PackedValues |= ((dtr & 0x0003) << 4);
                if (inDSR) PackedValues |= 0x0040;
                if (txc) PackedValues |= 0x0080;
                if (xOut) PackedValues |= 0x0100;
                if (xIn) PackedValues |= 0x0200;
                PackedValues |= ((rts & 0x0003) << 12);

            }
        }

        /// <summary>
        /// Reading and writing.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean WriteFile(
            IntPtr fFile, 
            Byte[] lpBuffer, 
            UInt32 nNumberOfBytesToWrite,
            out UInt32 lpNumberOfBytesWritten, 
            IntPtr lpOverlapped);

        [DllImport("kernel32.dll ")]
        public static extern int CreateFile(
          string lpFileName,
          uint dwDesiredAccess,
          int dwShareMode,
          int lpSecurityAttributes,
          int dwCreationDisposition,
          int dwFlagsAndAttributes,
          int hTemplateFile
          );
        [DllImport("kernel32.dll ")]
        public static extern bool WriteFile(
          int hFile,
          byte[] lpBuffer,
          int nNumberOfBytesToWrite,
          ref   int lpNumberOfBytesWritten,
          ref   OVERLAPPED lpOverlapped
          );
        [DllImport("kernel32.dll ")]
        public static extern bool CloseHandle(
          int hObject
          );
        [DllImport("kernel32.dll ")]
        public static extern bool ReadFile(
           int hFile,
           out byte[] lpBuffer,
           int nNumberOfBytesToRead,
           ref int lpNumberOfBytesRead,
           ref OVERLAPPED lpOverlapped);


        [StructLayout(LayoutKind.Sequential)]
        public struct OVERLAPPED
        {
            public UIntPtr Internal;
            public UIntPtr InternalHigh;
            public UInt32 Offset;
            public UInt32 OffsetHigh;
            public IntPtr hEvent;
        }

        [DllImport("kernel32.dll")]
        public static extern Boolean SetCommMask(IntPtr hFile, UInt32 dwEvtMask);

        // Constants for dwEvtMask:
        public const UInt32 EV_RXCHAR = 0x0001;
        public const UInt32 EV_RXFLAG = 0x0002;
        public const UInt32 EV_TXEMPTY = 0x0004;
        public const UInt32 EV_CTS = 0x0008;
        public const UInt32 EV_DSR = 0x0010;
        public const UInt32 EV_RLSD = 0x0020;
        public const UInt32 EV_BREAK = 0x0040;
        public const UInt32 EV_ERR = 0x0080;
        public const UInt32 EV_RING = 0x0100;
        public const UInt32 EV_PERR = 0x0200;
        public const UInt32 EV_RX80FULL = 0x0400;
        public const UInt32 EV_EVENT1 = 0x0800;
        public const UInt32 EV_EVENT2 = 0x1000;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean WaitCommEvent(IntPtr hFile, IntPtr lpEvtMask, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        public static extern Boolean CancelIo(IntPtr hFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean ReadFile(IntPtr hFile, [Out] Byte[] lpBuffer, UInt32 nNumberOfBytesToRead,
            out UInt32 nNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        public static extern Boolean TransmitCommChar(IntPtr hFile, Byte cChar);

        /// <summary>
        /// Control port functions.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern Boolean EscapeCommFunction(IntPtr hFile, UInt32 dwFunc);

        // Constants for dwFunc:
        public const UInt32 SETXOFF = 1;
        public const UInt32 SETXON = 2;
        public const UInt32 SETRTS = 3;
        public const UInt32 CLRRTS = 4;
        public const UInt32 SETDTR = 5;
        public const UInt32 CLRDTR = 6;
        public const UInt32 RESETDEV = 7;
        public const UInt32 SETBREAK = 8;
        public const UInt32 CLRBREAK = 9;

        [DllImport("kernel32.dll")]
        public static extern Boolean GetCommModemStatus(IntPtr hFile, out UInt32 lpModemStat);

        // Constants for lpModemStat:
        public const UInt32 MS_CTS_ON = 0x0010;
        public const UInt32 MS_DSR_ON = 0x0020;
        public const UInt32 MS_RING_ON = 0x0040;
        public const UInt32 MS_RLSD_ON = 0x0080;

        /// <summary>
        /// Status Functions.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean GetOverlappedResult(IntPtr hFile, IntPtr lpOverlapped,
            out UInt32 nNumberOfBytesTransferred, Boolean bWait);

        [DllImport("kernel32.dll")]
        public static extern Boolean ClearCommError(IntPtr hFile, out UInt32 lpErrors, IntPtr lpStat);
        [DllImport("kernel32.dll")]
        public static extern Boolean ClearCommError(IntPtr hFile, out UInt32 lpErrors, out COMSTAT cs);

        //Constants for lpErrors:
        public const UInt32 CE_RXOVER = 0x0001;
        public const UInt32 CE_OVERRUN = 0x0002;
        public const UInt32 CE_RXPARITY = 0x0004;
        public const UInt32 CE_FRAME = 0x0008;
        public const UInt32 CE_BREAK = 0x0010;
        public const UInt32 CE_TXFULL = 0x0100;
        public const UInt32 CE_PTO = 0x0200;
        public const UInt32 CE_IOE = 0x0400;
        public const UInt32 CE_DNS = 0x0800;
        public const UInt32 CE_OOP = 0x1000;
        public const UInt32 CE_MODE = 0x8000;

        [StructLayout(LayoutKind.Sequential)]
        public struct COMSTAT
        {
            public const uint fCtsHold = 0x1;
            public const uint fDsrHold = 0x2;
            public const uint fRlsdHold = 0x4;
            public const uint fXoffHold = 0x8;
            public const uint fXoffSent = 0x10;
            public const uint fEof = 0x20;
            public const uint fTxim = 0x40;
            public UInt32 Flags;
            public UInt32 cbInQue;
            public UInt32 cbOutQue;
        }
        [DllImport("kernel32.dll")]
        public static extern Boolean GetCommProperties(IntPtr hFile, out COMMPROP cp);

        [StructLayout(LayoutKind.Sequential)]
        public struct COMMPROP
        {
            public UInt16 wPacketLength;
            public UInt16 wPacketVersion;
            public UInt32 dwServiceMask;
            public UInt32 dwReserved1;
            public UInt32 dwMaxTxQueue;
            public UInt32 dwMaxRxQueue;
            public UInt32 dwMaxBaud;
            public UInt32 dwProvSubType;
            public UInt32 dwProvCapabilities;
            public UInt32 dwSettableParams;
            public UInt32 dwSettableBaud;
            public UInt16 wSettableData;
            public UInt16 wSettableStopParity;
            public UInt32 dwCurrentTxQueue;
            public UInt32 dwCurrentRxQueue;
            public UInt32 dwProvSpec1;
            public UInt32 dwProvSpec2;
            public Byte wcProvChar;
        }

    }
}
