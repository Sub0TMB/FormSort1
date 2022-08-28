using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FormSort1
{
    public partial class FormSort : Form
    {
        static char[,] m_Arr1;// Значния присвоены в методе ArrayRestart

        public FormSort()
        {
            InitializeComponent();
            ArrayRestart();
        }

        #region "Buttons"
        // Не уверен в контороле времени выполнения, поискал бы другой метод
        private void MySort1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, m_Arr1.GetLength(0), i=> MySortParallel(m_Arr1, i));
            stopwatch.Stop();
            MessageBox.Show(StringArray<char>(m_Arr1) + (char) 13 + "Время сортировки тактов таймера " + stopwatch.ElapsedTicks);
            ArrayRestart();
        }
        private void bttnCountingSort_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, m_Arr1.GetLength(0), i => SimpleCountingSort(ref m_Arr1, i));
            stopwatch.Stop();
            MessageBox.Show(StringArray<char>(m_Arr1) + (char)13 + "Время сортировки тактов таймера " + stopwatch.ElapsedTicks);
            ArrayRestart();
        }
        #endregion

        #region "Sort methods"
        /// <summary>
        /// Сортирует массив с меньшим количеством перезаписей, хотя итоговое время сопоставимо
        /// не уверен что в данном случае в несколько потоков работает быстрее, сделал чтоб было
        /// </summary>
        /// <param name="p_Array">
        /// Массив из задания
        /// </param>
        /// <param name="p_NumbString">
        /// номер строки для сортировки
        /// </param>
        private static void MySortParallel(char[,] p_Array, int p_NumbString)
        {
            int arrLength1 = p_Array.GetLength(1);
            if (Convert.ToBoolean(arrLength1 % 2))
            {
                int iCenter = arrLength1 / 2;
                int iArr1 = iCenter;
                int i = 0;
                int jStart = 0;
                int iArr2Start = 0;
                while (iArr1 < arrLength1)//Обходим строку от центра
                {
                    if (p_Array[p_NumbString, iArr1] > '*')//проверяем не стоит ли '*' на своём месте
                    {
                        int j;
                        int iArr2;
                        if (jStart == 0)
                        {
                            j = i;
                            iArr2 = iArr1;
                        }
                        else
                        {
                            j = jStart;
                            iArr2 = iArr2Start;
                        }
                        while (iArr2 > 0)//ищем снежинку и записываем где остановились
                        {
                            j *= -1;
                            if (j > -1) { j += 1; }
                            iArr2 = iCenter + j;
                            if (p_Array[p_NumbString, iArr2] < '-')
                            {
                                Replace<char>(ref p_Array[p_NumbString, iArr1], ref p_Array[p_NumbString, iArr2]);
                                jStart = j;
                                iArr2Start = iArr2;
                                //фиксирует все совершенные перестановки
                                Console.WriteLine($" {p_NumbString}{ iArr2} >> {p_NumbString}{iArr1}");
                                break;
                            }
                        }
                    }
                    i *= -1;
                    if (i > -1) { i += 1; }
                    iArr1 = iCenter + i;
                }
                
            }
            else
            {
                MessageBox.Show("Алгоритм не работает для строк чётной длинны");
            }
        }
        /// <summary>
        /// Упрощённая сортировка подсчётом
        /// наиболее подходила по условиям задачи(малое количество значений O(n+2))
        /// больше перезаписей массива
        /// </summary>
        /// <param name="p_Array">
        /// Массив из задания
        /// </param>
        /// <param name="p_NumbString">
        /// номер строки для сортировки
        /// </param>
        private static void SimpleCountingSort(ref char[,] p_Array, int p_NumbString)
        {
            int arrLength1 = p_Array.GetLength(1);
            int quantitySnowflake = 0;
            for (int j = 0; j < arrLength1; j++)//считаем снежинки
            {
                if (p_Array[p_NumbString, j] < '-')
                {
                    quantitySnowflake++;
                }
            }
            int iCenter = arrLength1 / 2;
            int iArr1 = iCenter;
            int i = 0;
            while (iArr1 < arrLength1)//Обходим строку от центра
            {
                if (quantitySnowflake > 0)
                {
                    p_Array[p_NumbString, iArr1] = '*';
                    quantitySnowflake--;
                }
                else
                {
                    p_Array[p_NumbString, iArr1] = '-';
                }
                i *= -1;
                if (i > -1) { i += 1; }
                iArr1 = iCenter + i;
            }
        }
       
        #endregion

        //Массив расположен тут
        #region "Utilities"
        /// <summary>
        /// Меняет значения двух переменных местами
        /// </summary>
        private static void Replace<T>(ref T var1, ref T var2)
        {
            T temp = var1;
            var1 = var2;
            var2 = temp;
        }
        /// <summary>
        /// Записывает двумерный массив многострочным текстом
        /// </summary>
        private static string StringArray<T>(T[,] p_Array)
        {
            string strArray = "";
            for (int i = 0; i < p_Array.GetLength(0); i++)
            {
                for (int j = 0; j < p_Array.GetLength(1); j++)
                {
                    strArray += p_Array[i, j] + " ";
                }
                strArray += (char)13;
            }
            return strArray;
        }
        /// <summary>
        /// Заполняет массив значениями из задания
        /// </summary>
        private static void ArrayRestart()
        {
            m_Arr1 = new char[,] {{ '-', '*', '-', '-', '-', '-', '-', '-', '-' },
            { '*', '-', '-', '-', '*', '-', '*', '-', '-' },
            { '-', '*', '-', '-', '*', '*', '*', '-', '*' },
            { '*', '*', '-', '*', '*', '*', '*', '-', '*' }};
        }
        #endregion

    }
}

