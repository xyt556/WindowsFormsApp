using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private int count;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000; // 设置定时器间隔为 1 秒
            timer1.Tick += Timer_Tick; // 绑定 Tick 事件处理方法
            count = 0;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 每秒钟执行的操作
            count++;
            lblCount.Text = $"计数：{count}";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 设置进度条的最小值和最大值
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            // 启动一个后台线程进行耗时操作
            // 这里使用一个简单的循环来模拟耗时的操作
            // 在耗时操作中，不要使用主线程，以保持 UI 的响应性
            for (int i = 0; i <= 100; i++)
            {
                // 更新进度条的当前值
                progressBar1.Value = i;

                // 模拟耗时操作
                System.Threading.Thread.Sleep(50);
            }

            MessageBox.Show("耗时操作已完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // 重置进度条的当前值
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 启动定时器
            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 停止定时器
            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
