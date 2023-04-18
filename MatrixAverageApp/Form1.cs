using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MatrixAverageApp
{
    public partial class Form1 : Form
    {
        private TextBox[,] matrixTextBoxes;

        public Form1()
        {
            InitializeComponent();
            matrixTextBoxes = new TextBox[6, 6];
            InitializeMatrixTextBoxes();
        }

        private void InitializeMatrixTextBoxes()
        {
            int textBoxWidth = 40;
            int textBoxHeight = 20;
            int textBoxMargin = 5;

            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    matrixTextBoxes[i, j] = new TextBox();
                    matrixTextBoxes[i, j].Width = textBoxWidth;
                    matrixTextBoxes[i, j].Height = textBoxHeight;
                    matrixTextBoxes[i, j].Location = new System.Drawing.Point(j * (textBoxWidth + textBoxMargin) + 20, i * (textBoxHeight + textBoxMargin) + 50);
                    matrixTextBoxes[i, j].Text = random.Next(1, 101).ToString(); // 生成1~100之间的随机整数作为矩阵元素的初始值
                    this.Controls.Add(matrixTextBoxes[i, j]);
                }
            }
        }

       

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            List<int> elements = new List<int>();
            int sum = 0;

            // 从文本框中获取矩阵元素的值，并计算总和
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int value;
                    if (int.TryParse(matrixTextBoxes[i, j].Text, out value))
                    {
                        elements.Add(value);
                        sum += value;
                    }
                    else
                    {
                        MessageBox.Show("请输入有效的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            double average = (double)sum / (6 * 6); // 计算平均值
            List<Tuple<int, int>> aboveAverageElements = new List<Tuple<int, int>>();

            // 查找高于平均值的元素以及它们的行号和列号
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int value;
                    if (int.TryParse(matrixTextBoxes[i, j].Text, out value))
                    {
                        if (value > average)
                        {
                            aboveAverageElements.Add(new Tuple<int, int>(i + 1, j + 1)); // 行号和列号从1开始
                        }
                    }
                }
            }

            // 将结果输出到文本框中
            txtAverage.Text = average.ToString();
            txtAboveAverageElements.Text = string.Join(",", aboveAverageElements.Select(t => $"({t.Item1}, {t.Item2})"));
        }
    }
}
