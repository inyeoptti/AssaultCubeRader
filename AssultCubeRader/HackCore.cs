using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssaultCubeRader
{
	class HackCore
	{
		[DllImport("kernel32")]
		public static extern IntPtr OpenProcess(Int32 Access, Boolean InheritHandle, Int32 ProcessId);
		[DllImport("kernel32")]
		static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, out uint lpNumberOfBytesRead);
		[DllImport("kernel32")]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, out uint nNumberOfBytesWritten);

		private static IntPtr PLAYERBASEPTR = (IntPtr)0x00509B74;

		public int PID = 0;
		private IntPtr handle = (IntPtr)0;
		private Process acProcess = null;
		public HackCore(int pid) {
			this.PID = pid;
			SetPid(pid);
		}
		public void SetPid(int pid)
		{
			if (pid != 0) acProcess = Process.GetProcessById(pid);
			else acProcess = null;

			if(acProcess != null && !acProcess.HasExited && acProcess.MainWindowTitle != "AssaultCube")
			{
				acProcess = null;
				handle = (IntPtr)0;
			}

			if(acProcess != null) handle = acProcess.Handle;
		}

		private Timer infAmmoTimer;
		public unsafe void EnableInfAmmo()
		{
			if(handle != (IntPtr)0)
			{
				if (infAmmoTimer == null) infAmmoTimer = new Timer(SetMaxAmmoAll, null, 0, 100);
			}
		}
		public void DisableInfAmmo()
		{
			if (infAmmoTimer != null) infAmmoTimer.Dispose();
		}
		public unsafe void SetMaxAmmoAll(object stateInfo)
		{
			if(handle != (IntPtr)0)
			{
				//var proc = OpenProcess(0x0008|0x0010|0x0020, false, acProcess.Id);
				IntPtr playerBasePtr = Marshal.AllocHGlobal(4);

				int maxValue = 9999;
				IntPtr pMaxValue = new IntPtr(&maxValue);

				if (ReadProcessMemory(handle, PLAYERBASEPTR, playerBasePtr, sizeof(int), out _))
				{
					var playerBase = Marshal.ReadIntPtr(playerBasePtr);
					Marshal.FreeHGlobal(playerBasePtr);
					WriteProcessMemory(handle, playerBase + 0x114, pMaxValue, 4, out _);//reserve pistol
					WriteProcessMemory(handle, playerBase + 0x118, pMaxValue, 4, out _);//reserve Carbine
					WriteProcessMemory(handle, playerBase + 0x11c, pMaxValue, 4, out _);//reserve shotgun
					WriteProcessMemory(handle, playerBase + 0x120, pMaxValue, 4, out _);//reserve smg
					WriteProcessMemory(handle, playerBase + 0x124, pMaxValue, 4, out _);//reserve SR
					WriteProcessMemory(handle, playerBase + 0x128, pMaxValue, 4, out _);//reserve AR
					WriteProcessMemory(handle, playerBase + 0x134, pMaxValue, 4, out _);//reserve akimbo

					WriteProcessMemory(handle, playerBase + 0x13c, pMaxValue, 4, out _);//clip pistol
					WriteProcessMemory(handle, playerBase + 0x140, pMaxValue, 4, out _);//clip Carbine
					WriteProcessMemory(handle, playerBase + 0x144, pMaxValue, 4, out _);//clip shotgun
					WriteProcessMemory(handle, playerBase + 0x148, pMaxValue, 4, out _);//clip smg
					WriteProcessMemory(handle, playerBase + 0x14c, pMaxValue, 4, out _);//clip SR
					WriteProcessMemory(handle, playerBase + 0x150, pMaxValue, 4, out _);//clip AR
					WriteProcessMemory(handle, playerBase + 0x15c, pMaxValue, 4, out _);//clip akimbo
				}
			}
		}

		public void DisableInfHealth()
		{
			infHpTimer.Dispose();
		}

		private Timer infHpTimer;
		public void EnableInfHealth()
		{
			if (handle != (IntPtr)0)
			{
				if (infHpTimer == null) infHpTimer = new Timer(SetMaxHealth, null, 0, 100);
			}
		}


		private unsafe void SetMaxHealth(object state)
		{
			if(handle != (IntPtr)0)
			{
				IntPtr playerBasePtr = Marshal.AllocHGlobal(4);

				int healthValue = 1000;
				IntPtr pHealthValue = new IntPtr(&healthValue);

				if(ReadProcessMemory(handle, PLAYERBASEPTR, playerBasePtr, 4, out _))
				{
					var playerBase = Marshal.ReadIntPtr(playerBasePtr);
					Marshal.FreeHGlobal(playerBasePtr);

					WriteProcessMemory(handle, playerBase + 0xF8, pHealthValue, 4, out _);
				}
			}
		}
	}
}
