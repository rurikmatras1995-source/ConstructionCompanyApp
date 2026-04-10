using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace ConstructionCompanyApp
{
    public partial class ProjectsPage : Page
    {
        public ProjectsPage()
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
                    var projects = await db.projects
                        .Include(p => p.house_types)
                        .ToListAsync();
                    dgProjects.ItemsSource = projects;
                }
            }
            catch (Exception)
            {
                dgProjects.ItemsSource = null;
            }
        }
    }
}