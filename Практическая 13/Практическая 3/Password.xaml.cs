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
using System.Windows.Shapes;

namespace Практическая_3
{
    /// <summary>
    /// Логика взаимодействия для Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "123")
            {
                this.DialogResult = true; // Устанавливаем результат как true
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль. Попробуйте снова.", "Ошибка");
            }
        }

        // Обработка закрытия окна
        private void PasswordWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.DialogResult != true)
            {
                // Если окно закрывается не через правильный ввод пароля,
                // закрываем основное окно
                Application.Current.Shutdown();
            }
        }
    }
}
