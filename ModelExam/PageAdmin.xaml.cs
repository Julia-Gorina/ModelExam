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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            dtg.ItemsSource = BaseConnect.BaseModel.Polz.ToList();
        }

       

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text == "")
            {
                MessageBox.Show("Необходимо выбрать клиента, которого нужно удалить", "Удаление клиента", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Polz polzovatel = BaseConnect.BaseModel.Polz.FirstOrDefault(c => c.Name == log.Text);
                BaseConnect.BaseModel.Polz.Remove(polzovatel);
                BaseConnect.BaseModel.SaveChanges();
                MessageBox.Show("Пользователь удален", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                dtg.ItemsSource = BaseConnect.BaseModel.Polz.ToList();
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.FrameMain.Navigate(new Glavnay());
        }
        private void soxr_Click(object sender, RoutedEventArgs e)
        {
            BaseConnect.BaseModel.SaveChanges();
            MessageBox.Show("Изменения успешно сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
