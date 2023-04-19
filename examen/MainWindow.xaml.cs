using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCheckButtonClick(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string phone = phoneTextBox.Text;

            // Валидация поля "Имя"
            if (string.IsNullOrWhiteSpace(firstName))
            {
                validationResultLabel.Content = "Имя не может быть пустым!";
                return;
            }
            else if (firstName.Length < 3 || firstName.Length > 15)
            {
                validationResultLabel.Content = "Имя должно содержать от 3 до 15 смиволов!";
                return;
            }

            // Валидация поля "Фамилия"
            if (string.IsNullOrWhiteSpace(lastName))
            {
                validationResultLabel.Content = "Фамилия не может быть пустой!";
                return;
            }
            else if (lastName.Length < 2 || lastName.Length > 25)
            {
                validationResultLabel.Content = "Фамилия должна содержать от 2 до 25 символов!";
                return;
            }

            // Валидация поля "Номер телефона"
            Regex phoneRegex = new Regex(@"^\+\d-\d{3}-\d{3}-\d{2}-\d{2}$");
            if (!phoneRegex.IsMatch(phone))
            {
                validationResultLabel.Content = "Номер телефона должен быть в формате +X-XXX-XXX-XX-XX!";
                return;
            }

            // Все поля валидны
            validationResultLabel.Content = "Введенные данные корректны!";
        }
    }
}
