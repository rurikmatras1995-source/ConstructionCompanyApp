using System.Windows;

namespace ConstructionCompanyApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new CustomersPage());
            StatusText.Text = "✅ Загружена страница заказчиков";
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CustomersPage());
            StatusText.Text = "🏠 Показаны заказчики";
        }

        private void btnProjects_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProjectsPage());
            StatusText.Text = "📐 Показаны проекты домов";
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
            StatusText.Text = "📋 Показаны заказы";
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeesPage());
            StatusText.Text = "👷 Показаны сотрудники";
        }
    }
}