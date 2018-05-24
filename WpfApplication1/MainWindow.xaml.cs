﻿using System;
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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            
            // 建立元件
            TodoItem item = new TodoItem();

            // 放入到 StackPanel
            TodoItemList.Children.Add(item);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            string data = "";

            foreach (TodoItem item in TodoItemList.Children)
            {
                data += "|"+item.ItemName + "\r\n";
            }

            // 存檔
            System.IO.File.WriteAllText(@"C:\temp\data.txt", data);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 讀檔
            string[] lines = System.IO.File.ReadAllLines(@"C:\temp\data.txt");

            // 逐行產生元件
            foreach (string line in lines)
            {
                // 用符號分隔
                string[] parts = line.Split('|');

                // 建立元件
                TodoItem item = new TodoItem();
                item.ItemName = parts[1];

                if (parts[0] == "+")
                    item.IsChecked = true;
                else
                    item.IsChecked = false;

                // 放入到 StackPanel
                TodoItemList.Children.Add(item);
            }
        }
    }
}
