using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Windows.Forms;

namespace Font_set
{
    public partial class Form1 : Form
    {
        private Font defaultFont; // 默认字体
        private Font currentFont; // 当前字体
        public Form1()
        {
            InitializeComponent();
            defaultFont = new Font("宋体", 11); // 设置默认字体
            currentFont = defaultFont; // 初始化当前字体为默认字体

            // 设置文本框的字体和大小为默认字体
            textBox.Font = currentFont;
            //触发事件修改样式
            checkBoxCu.CheckedChanged += CheckBox_CheckedChanged;
            checkBoxShan.CheckedChanged += CheckBox_CheckedChanged;
            checkXie.CheckedChanged += CheckBox_CheckedChanged;
            checkxia.CheckedChanged += CheckBox_CheckedChanged;
            //触发事件修改字体类型
            radioHei.CheckedChanged += radio1_CheckedChanged;
            radioLi.CheckedChanged += radio1_CheckedChanged;
            radioYou.CheckedChanged += radio1_CheckedChanged;
            //触发事件修改字体大小
            radio9.CheckedChanged += radio2_CheckedChanged;
            radio12.CheckedChanged += radio2_CheckedChanged;
            radio18.CheckedChanged += radio2_CheckedChanged;
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            // 单选按钮的选中状态改变时，更新当前字体和大小
            currentFont = new Font(
                radioHei.Checked ? "黑体" : (radioYou.Checked ? "幼圆" : (radioLi.Checked ? "隶书" : "宋体"))
                , currentFont.Size, currentFont.Style);

            // 更新文本框的字体
            textBox.Font = currentFont;
        }
        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            // 单选按钮的选中状态改变时，更新当前字体和大小
            currentFont = new Font(currentFont.FontFamily,
                (radio9.Checked ? 9 : 11) |
                (radio12.Checked ? 12 : 11) |
                (radio18.Checked ? 18 : 11)
                , currentFont.Style);
            // 更新文本框的字体
            textBox.Font = currentFont;
        }
        
        
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // 复选框按钮的选中状态改变时，更新当前字体的样式
            currentFont = new Font(currentFont.FontFamily, currentFont.Size,
            (checkBoxCu.Checked ? FontStyle.Bold : FontStyle.Regular) |
            (checkXie.Checked ? FontStyle.Italic : FontStyle.Regular) |
            (checkxia.Checked ? FontStyle.Underline : FontStyle.Regular) |
            (checkBoxShan.Checked ? FontStyle.Strikeout : FontStyle.Regular));

            // 更新文本框的字体
            textBox.Font = currentFont;
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            // 还原文本框字体和字号为默认值
            textBox.Font = defaultFont;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
