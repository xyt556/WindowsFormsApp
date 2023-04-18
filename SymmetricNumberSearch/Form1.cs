using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace SymmetricNumberSearch
{
    public partial class MainForm : Form
    {
        // 定义搜索结果的列表
        //private List<ulong> searchResults = new List<ulong>();

        public MainForm()
        {
            InitializeComponent();
        }

        // 将文本内容保存到文本文件
        private void SaveToFile(string content)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "文本文件|*.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDialog.FileName;
                // 指定编码为 UTF-8
                File.WriteAllText(fileName, content, Encoding.UTF8);
            }
        }
        // 判断一个无符号整数是否是对称数
        private bool IsSymmetricNumber(uint num)
        {
            string numStr = num.ToString();
            int i = 0;
            int j = numStr.Length - 1;
            while (i < j)
            {
                if (numStr[i++] != numStr[j--])
                {
                    return false;
                }
            }
            return true;
        }

        // 判断一个无符号整数是否是质数
        private bool IsPrimeNumber(uint num)
        {
            if (num <= 1)
            {
                return false;
            }

            for (uint i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 获取搜索范围的起始和结束值
            uint start = Convert.ToUInt32(txtStart.Text);
            uint end = Convert.ToUInt32(txtEnd.Text);

            // 检查输入的起始和结束值是否合法
            if (start > end)
            {
                MessageBox.Show("搜索范围起始值应小于等于结束值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 清空文本框
            txtResults.Clear();
            // 清空进度条
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)(end - start + 1);
            // 搜索对称数并将结果显示在文本框中
            StringBuilder sb = new StringBuilder();
            int count = 0; // 用于计数每行已经输出的对称数个数
            for (uint i = start; i <= end; i++)
            {
                if (IsSymmetricNumber(i))
                {
                    sb.Append(i.ToString());
                    count++;
                    if (count % 10 == 0)
                    {
                        sb.Append(Environment.NewLine);
                        count = 0;
                    }
                    else
                    {
                        sb.Append(",");
                    }
                }
                progressBar1.Value++;
            }

            // 移除最后一行末尾的逗号
            if (sb.Length > 0 && sb[sb.Length - 1] == ',')
            {
                sb.Length--;
            }

            txtResults.Text = sb.ToString();
            
            MessageBox.Show("搜索完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            // 获取搜索范围的起始和结束值
            uint start = Convert.ToUInt32(txtStart.Text);
            uint end = Convert.ToUInt32(txtEnd.Text);

            // 检查输入的起始和结束值是否合法
            if (start > end)
            {
                MessageBox.Show("搜索范围起始值应小于等于结束值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 清空文本框
            txtResults.Clear();
            // 清空进度条
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)(end - start + 1);

            // 搜索对称数并将结果显示在文本框中
            StringBuilder sb = new StringBuilder();
            int count = 0; // 用于计数每行已经输出的对称数个数
            for (uint i = start; i <= end; i++)
            {
                if (IsPrimeNumber(i))
                {
                    sb.Append(i.ToString());
                    count++;
                    if (count % 10 == 0)
                    {
                        sb.Append(Environment.NewLine);
                        count = 0;
                    }
                    else
                    {
                        sb.Append(",");
                    }
                }
                progressBar1.Value++;
            }

            // 移除最后一行末尾的逗号
            if (sb.Length > 0 && sb[sb.Length - 1] == ',')
            {
                sb.Length--;
            }

            txtResults.Text = sb.ToString();
            
            MessageBox.Show("搜索完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 保存文本框内容到文本文件
            SaveToFile(txtResults.Text);
            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveword_Click(object sender, EventArgs e)
        {
            // 创建一个新的 Word 应用程序实例
            Word.Application wordApp = new Word.Application();
            // 创建一个新的 Word 文档
            Word.Document doc = wordApp.Documents.Add();

            // 将文本框的内容添加到 Word 文档中
            string content = txtResults.Text;

            // 添加一级标题
            Word.Paragraph title = doc.Content.Paragraphs.Add();
            title.Range.Text = "搜索结果是：";
            title.Range.set_Style(Word.WdBuiltinStyle.wdStyleHeading1);
            title.Range.InsertParagraphAfter();

            // 添加正文
            Word.Paragraph paragraph = doc.Content.Paragraphs.Add();
            paragraph.Range.Text = content;


            // 保存 Word 文档
            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Word 文档|*.docx";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDialog.FileName;
                doc.SaveAs2(fileName);
                MessageBox.Show("文本框的内容已保存到 Word 文档中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 关闭 Word 文档和应用程序实例
            doc.Close();
            wordApp.Quit();
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            // 从文本框中获取搜索结果
            string[] results = txtResults.Lines;

            // 创建一个新的 Excel 应用程序实例
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            // 创建一个新的 Excel 工作簿
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet sheet = workbook.ActiveSheet;

            // 将搜索结果按每行 10 个数字以逗号隔开的形式写入 Excel 工作簿的单元格中
            int row = 1;
            int col = 1;
            for (int i = 0; i < results.Length; i++)
            {
                string[] numbers = results[i].Split(',');
                for (int j = 0; j < numbers.Length; j++)
                {
                    sheet.Cells[row, col].Value = numbers[j].Trim();
                    col++;
                    if (col > 10)
                    {
                        row++;
                        col = 1;
                    }
                }
            }

            // 保存 Excel 文件
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel 文件|*.xlsx";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDialog.FileName;
                workbook.SaveAs(fileName);
                MessageBox.Show("搜索结果已保存到 Excel 文件中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 关闭 Excel 文件和应用程序实例
            workbook.Close();
            excelApp.Quit();
        }
    }
}

