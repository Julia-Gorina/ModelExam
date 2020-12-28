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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModelExam
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" | famil.Text == "" | telephone.Text == "" | login.Text == "" | password.Password == "")
            {

                MessageBox.Show("Поля не могут оставаться пустыми", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (login.Text == password.Password & login.Text != "" & password.Password != "")
                {
                    MessageBox.Show("Пароль и логин не могут совпадать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int pass = password.Password.GetHashCode();
                    Polz UseObject = BaseConnect.BaseModel.Polz.FirstOrDefault(c => c.Login == login.Text && c.Password == pass);
                    if (UseObject == null)
                    {
                        Polz UserObject = new Polz()
                        {
                            Name = name.Text,
                            Famil = famil.Text,
                            Telephone = telephone.Text,
                            Login = login.Text,
                            Password = password.Password.GetHashCode(),
                            idRol = 2,
                        };
                        BaseConnect.BaseModel.Polz.Add(UserObject);
                        BaseConnect.BaseModel.SaveChanges();
                        FrameLoad.FrameMain.Navigate(new Glavnay());
                    }
                    else
                    {
                        MessageBox.Show("Такой пользователь уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
