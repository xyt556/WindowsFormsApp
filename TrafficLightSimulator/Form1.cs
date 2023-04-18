using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightSimulator
{
    public partial class Form1 : Form
    {
        private int currentLightIndex; // 当前灯的索引
        private int[] lightDelays = { 5, 2, 5 }; // 每个灯的延迟时间（单位：秒）

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化红绿灯状态和定时器
            currentLightIndex = 0;
            timer1.Interval = lightDelays[currentLightIndex] * 1000;
            timer1.Start();
            pictureBoxRed.Image = Properties.Resources.lightoff;
            pictureBoxYellow.Image = Properties.Resources.lightoff;
            pictureBoxGreen.Image = Properties.Resources.lightoff;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 切换红绿灯状态
            currentLightIndex = (currentLightIndex + 1) % 3;

            // 更新定时器的间隔时间
            timer1.Interval = lightDelays[currentLightIndex] * 1000;

            // 更新红绿灯图像
            UpdateTrafficLight();
        }
        private void UpdateTrafficLight()
        {
            // 根据当前灯的索引更新红绿灯图像
            switch (currentLightIndex)
            {
                case 0: // 红灯
                    pictureBoxRed.Image = Properties.Resources.RedLightOn;
                    pictureBoxYellow.Image = Properties.Resources.lightoff;
                    pictureBoxGreen.Image = Properties.Resources.lightoff;
                    break;
                case 1: // 黄灯
                    pictureBoxRed.Image = Properties.Resources.lightoff;
                    pictureBoxYellow.Image = Properties.Resources.YellowLighton;
                    pictureBoxGreen.Image = Properties.Resources.lightoff;
                    break;
                case 2: // 绿灯
                    pictureBoxRed.Image = Properties.Resources.lightoff;
                    pictureBoxYellow.Image = Properties.Resources.lightoff;
                    pictureBoxGreen.Image = Properties.Resources.GreenLighton;
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 设置红绿灯延迟时间
            currentLightIndex = 0;
            int redDelay, yellowDelay, greenDelay;
            if (int.TryParse(txtRedDelay.Text, out redDelay) &&
                int.TryParse(txtYellowDelay.Text, out yellowDelay) &&
                int.TryParse(txtGreenDelay.Text, out greenDelay))
            {
                lightDelays[0] = redDelay;
                lightDelays[1] = yellowDelay;
                lightDelays[2] = greenDelay;
            }
            else
            {
                MessageBox.Show("请输入有效的延迟时间（单位：秒）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
