using System;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Prakt2_Var7
{
    public partial class MainWindow : Window
    {
        int[,] mas;

        public MainWindow()
        {
            InitializeComponent();
        }

        // заполнить
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            int m = Convert.ToInt32(textRow.Text);
            int n = Convert.ToInt32(textCol.Text);
            mas = new int[m, n];

            Random r = new Random();
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    mas[i, j] = r.Next(-10, 10);

            dataGridMatrix.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        // посчитать минимумы
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null) return;

            // считываем если правили руками
            DataView v = dataGridMatrix.ItemsSource as DataView;
            if (v != null)
            {
                for (int i = 0; i < v.Count; i++)
                    for (int j = 0; j < v.Table.Columns.Count; j++)
                        mas[i, j] = Convert.ToInt32(v[i][j]);
            }

            // поиск минимума в строке
            int m = mas.GetLength(0);
            int n = mas.GetLength(1);
            int[] ans = new int[m];

            for (int i = 0; i < m; i++)
            {
                int min = mas[i, 0];
                for (int j = 1; j < n; j++)
                    if (mas[i, j] < min)
                        min = mas[i, j];
                ans[i] = min;
            }

            dataGridResult.ItemsSource = VisualArray.ToDataTable(ans).DefaultView;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null) return;
            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++)
                    mas[i, j] = 0;
            dataGridMatrix.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null) return;
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "txt|*.txt";
            if (s.ShowDialog() == true)
            {
                StreamWriter f = new StreamWriter(s.FileName);
                f.WriteLine(mas.GetLength(0));
                f.WriteLine(mas.GetLength(1));
                foreach (int x in mas)
                    f.WriteLine(x);
                f.Close();
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "txt|*.txt";
            if (o.ShowDialog() == true)
            {
                StreamReader f = new StreamReader(o.FileName);
                int m = Convert.ToInt32(f.ReadLine());
                int n = Convert.ToInt32(f.ReadLine());
                mas = new int[m, n];
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        mas[i, j] = Convert.ToInt32(f.ReadLine());
                f.Close();
                textRow.Text = m.ToString();
                textCol.Text = n.ToString();
                dataGridMatrix.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пр. №2 Вар.7. В каждой строке найти минимум.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}