using System.Drawing;

namespace AssultCubeRader
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.statusLabel = new MaterialSkin.Controls.MaterialLabel();
			this.statusCheckTimer = new System.Windows.Forms.Timer(this.components);
			this.checkBoxInfAmmo = new MaterialSkin.Controls.MaterialCheckBox();
			this.SuspendLayout();
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Depth = 0;
			this.statusLabel.Font = new System.Drawing.Font("Roboto", 11F);
			this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.statusLabel.Location = new System.Drawing.Point(3, 66);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(3, 56, 3, 0);
			this.statusLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(143, 18);
			this.statusLabel.TabIndex = 2;
			this.statusLabel.Text = "Waiting Assult Cube";
			// 
			// statusCheckTimer
			// 
			this.statusCheckTimer.Enabled = true;
			this.statusCheckTimer.Interval = 250;
			this.statusCheckTimer.Tick += new System.EventHandler(this.statusCheckTimer_Tick);
			// 
			// checkBoxInfAmmo
			// 
			this.checkBoxInfAmmo.AutoSize = true;
			this.checkBoxInfAmmo.Depth = 0;
			this.checkBoxInfAmmo.Enabled = false;
			this.checkBoxInfAmmo.Font = new System.Drawing.Font("Roboto", 10F);
			this.checkBoxInfAmmo.Location = new System.Drawing.Point(6, 84);
			this.checkBoxInfAmmo.Margin = new System.Windows.Forms.Padding(0);
			this.checkBoxInfAmmo.MouseLocation = new System.Drawing.Point(-1, -1);
			this.checkBoxInfAmmo.MouseState = MaterialSkin.MouseState.HOVER;
			this.checkBoxInfAmmo.Name = "checkBoxInfAmmo";
			this.checkBoxInfAmmo.Ripple = true;
			this.checkBoxInfAmmo.Size = new System.Drawing.Size(117, 30);
			this.checkBoxInfAmmo.TabIndex = 3;
			this.checkBoxInfAmmo.Text = "Infinity Ammo";
			this.checkBoxInfAmmo.UseVisualStyleBackColor = true;
			this.checkBoxInfAmmo.CheckedChanged += new System.EventHandler(this.checkBoxInfAmmo_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 293);
			this.Controls.Add(this.checkBoxInfAmmo);
			this.Controls.Add(this.statusLabel);
			this.Name = "Form1";
			this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.ShowIcon = false;
			this.Text = "ACRader";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MaterialSkin.Controls.MaterialLabel statusLabel;
		private System.Windows.Forms.Timer statusCheckTimer;
		private MaterialSkin.Controls.MaterialCheckBox checkBoxInfAmmo;
	}
}

