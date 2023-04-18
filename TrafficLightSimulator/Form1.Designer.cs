namespace TrafficLightSimulator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxGreen = new System.Windows.Forms.PictureBox();
            this.pictureBoxYellow = new System.Windows.Forms.PictureBox();
            this.pictureBoxRed = new System.Windows.Forms.PictureBox();
            this.txtRedDelay = new System.Windows.Forms.TextBox();
            this.txtYellowDelay = new System.Windows.Forms.TextBox();
            this.txtGreenDelay = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBoxGreen
            // 
            this.pictureBoxGreen.Image = global::TrafficLightSimulator.Properties.Resources.GreenLighton;
            this.pictureBoxGreen.Location = new System.Drawing.Point(21, 276);
            this.pictureBoxGreen.Name = "pictureBoxGreen";
            this.pictureBoxGreen.Size = new System.Drawing.Size(100, 95);
            this.pictureBoxGreen.TabIndex = 2;
            this.pictureBoxGreen.TabStop = false;
            // 
            // pictureBoxYellow
            // 
            this.pictureBoxYellow.Image = global::TrafficLightSimulator.Properties.Resources.YellowLightOff;
            this.pictureBoxYellow.Location = new System.Drawing.Point(21, 150);
            this.pictureBoxYellow.Name = "pictureBoxYellow";
            this.pictureBoxYellow.Size = new System.Drawing.Size(100, 95);
            this.pictureBoxYellow.TabIndex = 1;
            this.pictureBoxYellow.TabStop = false;
            // 
            // pictureBoxRed
            // 
            this.pictureBoxRed.Image = global::TrafficLightSimulator.Properties.Resources.RedLightOn;
            this.pictureBoxRed.Location = new System.Drawing.Point(21, 24);
            this.pictureBoxRed.Name = "pictureBoxRed";
            this.pictureBoxRed.Size = new System.Drawing.Size(100, 95);
            this.pictureBoxRed.TabIndex = 0;
            this.pictureBoxRed.TabStop = false;
            // 
            // txtRedDelay
            // 
            this.txtRedDelay.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRedDelay.ForeColor = System.Drawing.Color.Red;
            this.txtRedDelay.Location = new System.Drawing.Point(148, 50);
            this.txtRedDelay.Name = "txtRedDelay";
            this.txtRedDelay.Size = new System.Drawing.Size(100, 41);
            this.txtRedDelay.TabIndex = 3;
            this.txtRedDelay.Text = "5";
            // 
            // txtYellowDelay
            // 
            this.txtYellowDelay.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYellowDelay.ForeColor = System.Drawing.Color.Yellow;
            this.txtYellowDelay.Location = new System.Drawing.Point(148, 175);
            this.txtYellowDelay.Name = "txtYellowDelay";
            this.txtYellowDelay.Size = new System.Drawing.Size(100, 41);
            this.txtYellowDelay.TabIndex = 3;
            this.txtYellowDelay.Text = "2";
            // 
            // txtGreenDelay
            // 
            this.txtGreenDelay.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGreenDelay.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtGreenDelay.Location = new System.Drawing.Point(148, 303);
            this.txtGreenDelay.Name = "txtGreenDelay";
            this.txtGreenDelay.Size = new System.Drawing.Size(100, 41);
            this.txtGreenDelay.TabIndex = 3;
            this.txtGreenDelay.Text = "10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "模拟";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(409, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtGreenDelay);
            this.Controls.Add(this.txtYellowDelay);
            this.Controls.Add(this.txtRedDelay);
            this.Controls.Add(this.pictureBoxGreen);
            this.Controls.Add(this.pictureBoxYellow);
            this.Controls.Add(this.pictureBoxRed);
            this.Name = "Form1";
            this.Text = "红绿灯模拟";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxRed;
        private System.Windows.Forms.PictureBox pictureBoxYellow;
        private System.Windows.Forms.PictureBox pictureBoxGreen;
        private System.Windows.Forms.TextBox txtRedDelay;
        private System.Windows.Forms.TextBox txtYellowDelay;
        private System.Windows.Forms.TextBox txtGreenDelay;
        private System.Windows.Forms.Button button1;
    }
}

