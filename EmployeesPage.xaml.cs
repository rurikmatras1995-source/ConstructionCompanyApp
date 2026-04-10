using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace ConstructionCompanyApp
{
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
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
                    var employees = await db.employees.ToListAsync();
                    dgEmployees.ItemsSource = employees;
                }
            }
            catch (Exception)
            {
                dgEmployees.ItemsSource = null;
            }
        }
    }
}