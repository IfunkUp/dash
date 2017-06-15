using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
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
using Timesheeter3._0.Classes;
using Timesheeter3._0.DataAcces;
using Timesheeter3_0.Classes;

namespace Timesheeter3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            StartDate.SelectedDate=DateTime.Now.AddDays(-7);
            EndDate.SelectedDate = DateTime.Now;
        }


        private ObservableCollection<Ticket> m_lijst;

        public  ObservableCollection<Ticket> Lijst
        {
            get { return m_lijst; }
            set { m_lijst = value; }
        }



        public  void test_Click(object sender, RoutedEventArgs e)
        {

            //DataSet set = new DataSet();
            //set.Tables.Add(DaExportDB.UserTable("select * from t_user"));
            //set.Tables.Add(DaExportDB.OrganizationTable("select * from t_organization"));
            //DataTable myusers = set.Tables["Organizations"];
            //DataRow currentRow = null;

            //Dictionary<string, List<Ticket>> companies;
            //List<Ticket> tickets;

            //companies = DaExportDB.FetchTicketsByDate(StartDate.SelectedDate, EndDate.SelectedDate);
            DaMailer mailer = new DaMailer();
            
            string test = mailer.GetTicketOverviewHTML((DateTime)StartDate.SelectedDate, EndDate.SelectedDate.Value.Date);
            
            File.WriteAllText("test.html", test);
            System.Diagnostics.Process.Start("test.html");

            this.Close();
























            //      var list = DaList.GetUserList("select * from t_user");
            //Lijst = DaList.GetTicketList("select * from t_tickets t join t_user u on t.f_tk_ass_id = u.f_us_id");
            //dgList.ItemsSource = Lijst;
            //Lijst.CollectionChanged += Lijst_CollectionChanged;
        }

        private void Lijst_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    





    }
}
