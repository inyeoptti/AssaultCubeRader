using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace AssaultCubeRader
{
	public partial class Form1 : MaterialForm
	{
		public Form1()
		{
			InitializeComponent();
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Blue400, TextShade.WHITE);
		}

		private Process acProcess = null;
		private HackCore hackCore = new HackCore(0);

		private void Form1_Load(object sender, EventArgs e)
		{
			
			acProcess = FindACProcess();
			if (acProcess == null)
				SetFormState(0);
			else
			{
				SetFormState(1);
				hackCore.PID = acProcess.Id;
			}
		}

		private void statusCheckTimer_Tick(object sender, EventArgs e)
		{
			if (acProcess != null && !acProcess.HasExited) return;

			acProcess = FindACProcess();
			if (acProcess == null || acProcess.HasExited) {
				SetFormState(0);
				return;
			}
			SetFormState(1);
			hackCore.PID = acProcess.Id;
		}

		private Process FindACProcess()
		{
			foreach (var proc in Process.GetProcessesByName("ac_client"))
			{
				if (proc.MainWindowTitle == "AssaultCube")
				{
					return proc;
				}
			}
			return null;
		}

		private void SetFormState(int _state)
		{
			switch (_state)
			{
				case 0: //Waiting ac_client
					statusLabel.Text = "Waiting Assult Cube...";
					SetFormComponentState(_state == 1);
					hackCore.SetPid(0);
					break;
				case 1: //Process found
					statusLabel.Text = acProcess.ProcessName  + ".exe(" + acProcess.Id.ToString() + ")";
					SetFormComponentState(_state == 1);
					hackCore.SetPid(acProcess.Id);
					break;
				default:
					break;
			}
		}
		private void SetFormComponentState(bool state)
		{
			checkBoxInfAmmo.Enabled = state;

			if (!state)
			{
				checkBoxInfAmmo.Checked = false;
			}
		}

		private void checkBoxInfAmmo_CheckedChanged(object sender, EventArgs e)
		{
			if(acProcess != null && !acProcess.HasExited && acProcess.Id == hackCore.PID)
			{
				if (((MaterialCheckBox)sender).Checked)
				{
					hackCore.EnableInfAmmo();
				}
				else
				{
					hackCore.DisableInfAmmo();
				}
			}
		}

		private void checkBoxInfHealth_CheckedChanged(object sender, EventArgs e)
		{
			if (acProcess != null && !acProcess.HasExited && acProcess.Id == hackCore.PID)
			{
				if (((MaterialCheckBox)sender).Checked)
				{
					hackCore.EnableInfHealth();
				}
				else
				{
					hackCore.DisableInfHealth();
				}
			}
		}

		private void checkBoxInfArmor_CheckedChanged(object sender, EventArgs e)
		{
			if (acProcess != null && !acProcess.HasExited && acProcess.Id == hackCore.PID)
			{
				if (((MaterialCheckBox)sender).Checked)
				{
					hackCore.EnableInfArmor();
				}
				else
				{
					hackCore.DisableInfArmor();
				}
			}
		}
	}
}
