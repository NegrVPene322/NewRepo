
using Microsoft.Win32;
using System.Data;
using System.IO;

namespace LibMas
{
      public static class ClassMas
    {
        /// <summary>
        /// Отображение матрицы на таблице
        /// </summary>
        /// <typeparam name="T"> Тип входящей матрицы</typeparam>
        /// <param name="matrix"> Входящая матрица</param>
        /// <returns> Возвращаемый обьект класса DataTable </returns>
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
        /// <summary>
        /// Сохранение матрицы
        /// </summary>
        /// <param name="mas"> Входящая матрица</param>
        public static void Func_Save(in int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "All files (*.*) | *.* | Text files | *.txt";
            save.FilterIndex = 2;
            save.Title = "Save Table";
            
            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(mas.GetLength(0));
                file.WriteLine(mas.GetLength(1));
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for(int j = 0;j < mas.GetLength(1); j++)
                    {
                        file.WriteLine(mas[i, j]);
                    }
                }
                file.Close();
            }
        }
        /// <summary>
        /// Открытие матрицы
        /// </summary>
        /// <returns> Возвращаемая матрица</returns>
        public static int[,] Func_Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "All files (*.*) | *.* | Text files | *.txt";
            open.FilterIndex = 2;
            open.Title = "Open Table";
            int[,] mas;
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int str = Convert.ToInt32(file.ReadLine());
                
                int col = Convert.ToInt32(file.ReadLine());
                mas = new int[str, col];
               
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        mas[i,j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
            }
            else mas = null;
            return mas;

        }
    }

}
