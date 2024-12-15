using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_3
{
    internal class Class1
    {
        public int Func_Calc(in int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);
            int[] maxInColumns = new int[n];

            // Инициализация массива для максимума
            for (int j = 0; j < n; j++)
            {
                maxInColumns[j] = int.MinValue;
            }

            // Поиск максимальных элементов в каждом столбце
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    if (mas[i, j] > maxInColumns[j])
                    {
                        maxInColumns[j] = mas[i, j];
                    }
                }
            }

            // Теперь находим минимальный элемент среди максимальных из столбцов
            int minOfMax = maxInColumns[0];
            for (int j = 1; j < n; j++)
            {
                if (maxInColumns[j] < minOfMax)
                {
                    minOfMax = maxInColumns[j];
                }
            }
            return minOfMax;
        }
        /// <summary>
        /// Заполнение матрицы
        /// </summary>
        /// <param name="n"> Входящее число строк</param>
        /// <param name="m"> Входящее число столбцов</param>
        /// <returns> Возвращаемый массив</returns>
        public int[,] Func_Input(in int n, in int m)
        {
            Random rnd = new Random();
            int[,] mas = new int[n, m];

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    int a = rnd.Next(1, 10);
                    mas[i, j] = a;
                }
            }
            return mas;
        }
    }
}
