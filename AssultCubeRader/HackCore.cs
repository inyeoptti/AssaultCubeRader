using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AssultCubeRader
{
	class HackCore
	{
		[DllImport("kernel32")]
		public static extern IntPtr OpenProcess(Int32 Access, Boolean InheritHandle, Int32 ProcessId);
		[DllImport("kernel32")]
		static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, out uint lpNumberOfBytesRead);
		[DllImport("kernel32")]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, out uint nNumberOfBytesWritten);

		public int PID = 0;
		private IntPtr handle = (IntPtr)0;
		private Process acProcess = null;
		public HackCore(int pid) {
			this.PID = pid;
			SetPid(pid);
		}
		public void SetPid(int pid)
		{
			if (PID != 0) acProcess = Process.GetProcessById(pid);
			else acProcess = null;

			if(acProcess != null && !acProcess.HasExited && acProcess.MainWindowTitle != "AssaultCube")
			{
				acProcess = null;
				handle = (IntPtr)0;
			}

			handle = acProcess.Handle;
		}

		public void EnableInfAmmo()
		{
			if(handle != (IntPtr)0)
			{

			}
		}
		public void DisableInfAmmo()
		{

		}
	}
}
