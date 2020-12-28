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
    /// Логика взаимодействия для Glavnay.xaml
    /// </summary>
    public partial class Glavnay : Page
    {
        public Glavnay()
        {
            InitializeComponent();
        }

        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" | passwor.Password == "")
            {
                MessageBox.Show("Поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                
                int pass = passwor.Password.GetHashCode();
                Polz UserObject = BaseConnect.BaseModel.Polz.FirstOrDefault(y => y.Login == txtName.Text && y.Password == pass);
                if (UserObject == null)
                {
                    MessageBox.Show("Такого пользователя нет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //MessageBox.Show("Добро пожаловать," + txtName.Text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (UserObject.idRol)
                    {
                        case 1:
                            MessageBox.Show("Вы вошли как администратор" ,"Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            FrameLoad.FrameMain.Navigate(new PageAdmin());
                            break;
                        default:
                            MessageBox.Show("Добро пожаловать," + txtName.Text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                    }

                }
            }
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.FrameMain.Navigate(new Registration());
        }
    }
}
