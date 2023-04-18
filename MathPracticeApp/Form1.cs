using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathPracticeApp
{
    public partial class Form1 : Form
    {
        private Random random;
        private int totalQuestions;
        private int correctAnswers;
        private int score;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            int num1 = random.Next(1, 11); // 生成1~10之间的随机数
            int num2 = random.Next(1, 11);
            int operation = random.Next(1, 4); // 生成1~3之间的随机数，表示加法、减法和乘法

            string operatorString = "";
            int answer = 0;

            switch (operation)
            {
                case 1: // 加法
                    operatorString = "+";
                    answer = num1 + num2;
                    break;
                case 2: // 减法
                    operatorString = "-";
                    answer = num1 - num2;
                    break;
                case 3: // 乘法
                    operatorString = "×";
                    answer = num1 * num2;
                    break;
                default:
                    break;
            }

            lblQuestion.Text = $"{num1} {operatorString} {num2} =";
            txtAnswer.Clear();
            txtAnswer.Focus();
            lblResult.Text = "";
            lblResult.Visible = false;
            lblAnswer.Text = $"答案：{answer}";
            lblAnswer.Visible = false;
        }

        private void EvaluateAnswer()
        {
            int userAnswer;
            
            lblQuestion.Text = lblQuestion.Text + "  " + txtAnswer.Text;
            if (int.TryParse(txtAnswer.Text, out userAnswer))
            {
                int answer = int.Parse(lblAnswer.Text.Substring(3));
                if (userAnswer == answer)
                {
                    lblResult.Text = "√";
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    correctAnswers++;
                }
                else
                {
                    lblResult.Text = "×";
                    lblResult.ForeColor = System.Drawing.Color.Red;
                }
                lblResult.Visible = true;
                totalQuestions++;
            }
            else
            {
                MessageBox.Show("请输入有效的整数答案！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowScore()
        {
            if (totalQuestions > 0)
            {
                score = correctAnswers * 100 / totalQuestions;
            }

            string scoreMessage = $"共做题数：{totalQuestions}\n" +
                                  $"正确数：{correctAnswers}\n" +
                                  $"分数：{score}%";

            MessageBox.Show(scoreMessage, "统计分数", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateQuestion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EvaluateAnswer();
            lblAnswer.Visible = true;
            button3.Enabled = true; 
            button3.Visible = true;
            txtAnswer.Clear();
            txtAnswer.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowScore();
        }

        

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EvaluateAnswer();
                lblAnswer.Visible = true;
                button3.Visible= true;
            }
        }
    }
}
