Base Class Library for RS232 Communications.
--------------------------------------------
Ref: "Serial Comm: Use P/Invoke to Develop a .NET Base Class Library
for Serial Device Communications" John Hind, MSDN Magazine, Oct 2002.

V1.3 February 2004.

LIBRARY

CommBase.dll
  The library redistributable assembly - .NET managed code.
  Contains namespace JH.CommBase. Requires Unmanaged Code Permission.

CommBase.xml
  Intellisense comments for the library. Copy this to the same directory as
  CommBase.dll when referencing the library in the development environment.

CommBaseSource\CommBase.cs
CommBaseSource\CommPingPong.cs
CommbaseSource\AssemblyInfo.cs
  Source code for CommBase.dll assembly. Build in a Visual Studio C# Class
  Library project. Set the XML Documentation File option in configuration
  properties to rebuild the Intellisense comments.


EXAMPLES

LineTerm.vb
  Source code for LineTerm example. Build in a Visual Studio VB Console
  Application project. Requires a reference to CommBase.dll.

BaseTerm.exe
  Compiled example. Requires CommBase.dll in same directory to run.

BaseTermSource\BaseTerm.cs
BaseTermSource\TermForm.cs
BaseTermSource\SettingsForm.cs
BaseTermSource\InfoForm.cs
BaseTermSource\AssemblyInfo.cs
  Source code for BaseTerm example. Build in a Visual Studio C# Windows
  Application project. Requires a reference to CommBase.dll.


REVISION HISTORY

V1.0	- Initial Release, Sept 2002.

V1.1	- Minor Revision, December 2002.
  - Removed dependancy on NT/2000/XP. Should now run on W98, ME etc.
  - Eliminated use of CancelIO which was causing occasional data loss.
  - Use static version of Encoding.ASCII in CommLine for efficiency.
  - Added new CommPingPong class for single byte packetisation.

V1.2	- Minor Revision, December 2002.
  - Fixed bug with received break condition handling.
  - Interlocked rx thread startup with ManualResetEvent for robustness.
  - Added defaulting mechanism for handshake thresholds to avoid errors
    due to fixed defaults conflicting with driver queue size defaults.
  - Changed default for sendTimeoutMultiplier for not NT-based platform to
    a high value as W98 etc. do not seem to interpret 0 as infinite.

V1.3	- Minor Revision, February 2004.
  - Automatically try \\.\COMn form of port name if COMn or COMn: fails
    i.e. when n > 9 on some systems.
  - Added CommBase.IsCongested to test for buffer growth when sending
    data with CheckAllSends = false.
  - Added CommBase.IsPortAvailable to test existance / availability of
    a named port.
  - BaseTerm sample settings dialog now enumerates available ports in the
    port dropdown using the CommBase.IsPortAvailable function.
  - BaseTerm sample queue status dialog made non-modal and auto-refreshing.
  - Other minor presentational improvements to BaseTerm sample.
  - Corrected bugs which caused occasional crashes on port closure.
  - Corrected bugs which caused unnecessary exceptions when sending
    data at low baud rates with CheckAllSends = false.
  - Fixed bug in setting RTS state.
  - Deleted virtual function CommBase.OnRing which was never getting
    called: use CommBase.OnStatusChange instead.
  - Fixed bug preventing setting of fAbortOnError in DCB.
  - Corrected the BaseTerm sample to use proper marshalling for
    multi-threaded Windows Forms.
  - Corrected STH -> STX in ASCII enumeration.


