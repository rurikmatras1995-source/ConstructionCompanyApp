using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConstructionCompanyApp
{
    public partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                using (var db = new СтройКомпанияEntities())
                {
                    var customers = await db.customers.ToListAsync();
                    dgCustomers.ItemsSource = customers;
                }
            }
            catch (Exception)
            {
                dgCustomers.ItemsSource = null;
            }
        }

        private async void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                using (var db = new СтройКомпанияEntities())
                {
                    var searchText = tbSearch.Text.Trim();
                    var customers = await db.customers
                        .Where(c => c.last_name.Contains(searchText) ||
                                    c.first_name.Contains(searchText) ||
                                    c.phone.Contains(searchText))
                        .ToListAsync();
                    dgCustomers.ItemsSource = customers;
                }
            }
            catch (Exception)
            {
                dgCustomers.ItemsSource = null;
            }
        }
    }
}