
using System.Windows.Media;

namespace Lib_9
{
    public class Class_9
    {
        /// <summary>
        /// ���������� ������������ ����� � ������ ������ � ���� ������
        /// </summary>
        /// <param name="mas"> �������� �������</param>
        /// <param name="maxSum"> ��������� ������������ �����</param>
        /// <param name="maxRow"> ��������� ����� ������ � ����.������</param>
        public  int Func_Calc(in int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);
            int[] maxInColumns = new int[n];

            // ������������� ������� ��� ���������
            for (int j = 0; j < n; j++)
            {
                maxInColumns[j] = int.MinValue;
            }

            // ����� ������������ ��������� � ������ �������
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

            // ������ ������� ����������� ������� ����� ������������ �� ��������
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
        /// ���������� �������
        /// </summary>
        /// <param name="n"> �������� ����� �����</param>
        /// <param name="m"> �������� ����� ��������</param>
        /// <returns> ������������ ������</returns>
        public  int[,] Func_Input(in int n, in int m)
        {
            Random rnd = new Random();
            int[,] mas = new int[n,m];
            
            for(int i = 0;i < mas.GetLength(0); i++)
            {
                for(int j = 0;j < mas.GetLength(1); j++)
                {
                    int a = rnd.Next(1,10);
                    mas[i,j] = a;
                }
            }
            return mas;
        }
    }

}
