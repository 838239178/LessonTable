using LessonTable.Dao;
using LessonTable.Model;
using LessonTable.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LessonTable.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LessonService lsService;

        public MainWindow()
        {
            InitializeComponent();
            lsService = LessonService.Instance;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height / 2;
            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width / 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int week = 8;
            if (SingleCheck.IsChecked.GetValueOrDefault())
            {
                week = 7;
            }
            Result.Dispatcher.BeginInvoke(new Action(delegate
            {
                lesson ls = lsService.GetValidLesson(int.Parse(DayText.Text), int.Parse(TimeText.Text), week);
                if (ls.id > 0)
                {
                    Result.Text = ls.name;
                } 
                else
                {
                    Result.Text = "没课！！";
                }
            }));
        }

        private void OpenTableWin(object sender, RoutedEventArgs e)
        {
            TableWin win = new TableWin();
        }
    }
}
