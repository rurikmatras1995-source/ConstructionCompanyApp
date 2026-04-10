using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace ConstructionCompanyApp
{
    public partial class OrdersPage : Page
    {
        public OrdersPage()
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
                    var orders = await db.orders
                        .Include(o => o.customers)
                        .Include(o => o.projects)
                        .Include(o => o.employees)
                        .ToListAsync();
                    dgOrders.ItemsSource = orders;
                }
            }
            catch (Exception)
            {
                dgOrders.ItemsSource = null;
            }
        }

        private async void cbStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var db = new СтройКомпанияEntities())
                {
                    var selected = (cbStatusFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
                    var query = db.orders.Include(o => o.customers).Include(o => o.projects).AsQueryable();

                    if (selected != "Все")
                        query = query.Where(o => o.status == selected);

                    var orders = await query.ToListAsync();
                    dgOrders.ItemsSource = orders;
                }
            }
            catch (Exception)
            {
                dgOrders.ItemsSource = null;
            }
        }
    }
}