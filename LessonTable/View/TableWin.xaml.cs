using LessonTable.Model;
using LessonTable.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LessonTable.View
{
    /// <summary>
    /// TableWin.xaml 的交互逻辑
    /// </summary>
    public partial class TableWin : Window
    {

        public TableWin()
        {
            InitializeComponent();
        }

        private List<TextBlock> GetBlocks() 
        {
            List<TextBlock> blocks = new List<TextBlock>();
            TextBlock[] array = new TextBlock[Form.Children.Count];
            Regex regex1 = new Regex("星期.*");
            Regex regex2 = new Regex(".*节");
            Form.Children.CopyTo(array, 0);
            foreach (var i in array)
            {
                if (!regex1.IsMatch(i.Text) && !regex2.IsMatch(i.Text) && i.Text != "")
                {
                    i.SetResourceReference(BackgroundProperty, "LessonBackColor");
                    blocks.Add(i);
                }
            }
            return blocks;
        }

        private int GetWeekNow()
        {
            DateTime dateSchool = new DateTime(2021, 3, 1);
            DateTime dateNow = DateTime.Now.Date;
            TimeSpan span1 = new TimeSpan(dateNow.Ticks);
            TimeSpan span2 = new TimeSpan(dateSchool.Ticks);
            TimeSpan span = span1.Subtract(span2).Duration();
            double d = span.Days * 1.0 / 7;
            return Convert.ToInt32(Math.Floor(d));
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            int week = GetWeekNow();
            bool noLesson = true;
            foreach(var i in GetBlocks())
            {
                int text = int.Parse(i.Text);
                int day = text / 100;
                int time = text % 100;        
                lesson ls = LessonService.Instance.GetValidLesson(day, time, week);
                if (ls.id > 0)
                {
                    i.Text = ls.name + '\n' + ls.teacher + '\n' + ls.location;
                    noLesson = false;
                }  
            }
            if (noLesson)
            {
                MessageBox.Show("这周没课！！", "皆大欢喜");
                this.Close();
            }
            else
            {
                this.Show();
            }
        }
    }
}
