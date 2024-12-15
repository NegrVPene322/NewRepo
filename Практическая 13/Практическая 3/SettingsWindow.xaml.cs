using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Практическая_3
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbRows.Text, out int rows) && int.TryParse(tbCols.Text, out int cols))
            {
                // Сохранение настроек в config.ini
                File.WriteAllText("config.ini", $"{rows},{cols}");
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные значения.", "Ошибка");
            }
        }
    }
}
