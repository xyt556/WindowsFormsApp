using System;
using System.Windows.Forms;

namespace MatrixTransposeApp
{
    public partial class Form1 : Form
    {
        private TextBox[,] matrixTextBoxes;

        public Form1()
        {
            InitializeComponent();
            matrixTextBoxes = new TextBox[5, 5];
            InitializeMatrixTextBoxes();
        }

        private void InitializeMatrixTextBoxes()
        {
            int textBoxWidth = 20;
            int textBoxHeight = 20;
            int textBoxMargin = 5;
            Random random = new Random();
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrixTextBoxes[i, j] = new TextBox();
                    matrixTextBoxes[i, j].Width = textBoxWidth;
                    matrixTextBoxes[i, j].Height = textBoxHeight;
                    matrixTextBoxes[i, j].Location = new System.Drawing.Point(j * (textBoxWidth + textBoxMargin) + 20, i * (textBoxHeight + textBoxMargin) + 50);
                    matrixTextBoxes[i, j].Text = random.Next(1, 50).ToString(); // 生成1~10之间的随机整数作为矩阵元素的初始值
                    this.Controls.Add(matrixTextBoxes[i, j]);
                }
            }
        }


        private int[,] TransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] transposedMatrix = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposedMatrix[j, i] = matrix[i, j];
                }
            }

            return transposedMatrix;
        }

        private void btnTranspose_Click_1(object sender, EventArgs e)
        {
            int[,] matrix = new int[4, 4];

            // 从文本框中获取矩阵元素的值
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int value;
                    if (int.TryParse(matrixTextBoxes[i, j].Text, out value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        MessageBox.Show("请输入有效的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // 执行矩阵转置
            int[,] transposedMatrix = TransposeMatrix(matrix);

            // 将转置后的矩阵元素的值显示在文本框中
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrixTextBoxes[i, j].Text = transposedMatrix[i, j].ToString();
                }
            }
        }
    }
}
