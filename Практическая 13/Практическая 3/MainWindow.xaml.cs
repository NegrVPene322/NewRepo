using Lib_9;
using LibMas;
using Microsoft.Web.Mvc.Controls;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Lib_9.Class_9;
using static LibMas.ClassMas;
namespace Практическая_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
        }
        int[,] mas = new int[0,0];

        
        void LoadSettings()
        {
            if (File.Exists("config.ini"))
            {
                var content = File.ReadAllText("config.ini").Split(',');
                if (int.TryParse(content[0], out int rows) && int.TryParse(content[1], out int cols))
                {
                    tb_in_n.Text = rows.ToString();
                    tb_in_m.Text = cols.ToString();
                }
            }
            
        }
        private void bt_input_Click(object sender, RoutedEventArgs e)
        {
            bool f1,f2;
            int n,m;
            f1 = Int32.TryParse(tb_in_n.Text, out n);
            f2 = Int32.TryParse(tb_in_m.Text, out m);
            if (f1 && f2)
            {
                Class_9 aaa = new Class_9();
                mas = aaa.Func_Input(n,m);
                dtgrid.ItemsSource = ClassMas.ToDataTable(mas).DefaultView;
                string row = mas.GetLength(0).ToString();
                string col = mas.GetLength(1).ToString();
                inf.Text = "Кол-во строк: " + row + "\n Кол-во столбцов: " + col;
            }
            else MessageBox.Show("Input correct data");
        }

        private void bt_calc_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Class1 aaa = new Class1();
                int rez;
                rez = aaa.Func_Calc(mas);
                tb_rez_2.Text = rez.ToString();


            }
            else MessageBox.Show("Mas is null");
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Func_Save(mas);
            }
            else MessageBox.Show("Mas is null");

        }

        private void bt_open_Click(object sender, RoutedEventArgs e)
        {
            mas = Func_Open();
            dtgrid.ItemsSource = ClassMas.ToDataTable(mas).DefaultView;
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            mas = null;
            dtgrid.ItemsSource = null;
        }

        private void bt_cl_Click(object sender, RoutedEventArgs e)
        {
            tb_in_n.Clear();
            tb_in_m.Clear();
            
            tb_rez_2.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разраб Карпушин А.Д ИСП-31 \n вариант 9, практическая №3 \n Дана матрица размера M × N. Найти номер ее строки с наибольшей суммой \r\nэлементов и вывести данный номер, а также значение наибольшей суммы.  ", "Информация о программе");
        }

        private void bt_esc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;
            int indexRow = e.Row.GetIndex();
            mas[indexColumn, indexRow] = Convert.ToInt32(((System.Windows.Controls.TextBox)e.EditingElement).Text);
            string col = indexColumn.ToString();
            string row = indexRow.ToString();
            data.Text = row + " X " + col;
        }

        private void dtgrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Password pas = new Password();
            pas.Owner = this;
            pas.ShowDialog();
        }

        private void dtgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cellInfo = dtgrid.SelectedCells[0];
            var selectedItem = cellInfo.Item; // это объект строки
            var selectedColumn = cellInfo.Column; // это объект столбца

            // Получаем индекс строки
            int rowIndex = dtgrid.Items.IndexOf(selectedItem);
            // Получаем заголовок столбца
            string columnHeader = selectedColumn.Header.ToString();

            data.Text = "Строка: " + Convert.ToString(rowIndex + 1) + "\n " + columnHeader;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        

    }
}