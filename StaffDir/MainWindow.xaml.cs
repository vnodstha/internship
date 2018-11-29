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
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

using System.ComponentModel;

namespace StaffDir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        wc tbl = new wc();


        public wc newColumn { get; set; }


        WCSEntities context = new WCSEntities();


        CollectionViewSource wcs_testViewSource;

        public static DataGrid datagrid;



        public MainWindow()
        {
            InitializeComponent();
            newColumn = new wc();



            wcs_testViewSource = ((CollectionViewSource)
                (FindResource("wcs_testViewSource")));




            DataContext = this;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // Load is an extension method on IQueryable,    
            // defined in the System.Data.Entity namespace.   
            // This method enumerates the results of the query,    
            // similar to ToList but without creating a list.   
            // When used with Linq to Entities this method    
            // creates entity objects and adds them to the context.   
            context.wcs.Load();




            //// After the data is loaded call the DbSet<T>.Local property    
            //// to use the DbSet<T> as a binding source.   

            wcs_testViewSource.Source = context.wcs.Local;


        }


        // refressh

        private void refersh_Click(object sender, RoutedEventArgs e)
        {
          
            textBox_PreName.Clear();
            textBox_LastName.Clear();
            textBox_ManagerName.Clear();
            textBox_Pos.Clear();
            textBox_location.Clear();
            //context.wcs.Load();
            
            wcs_testDataGrid.SelectedItem = null;
            //wcs_testViewSource.View.Refresh();

            //wcs_testViewSource.Source = context.wcs.Local;
            wcs_testDataGrid.ItemsSource = context.wcs.ToList();
            MessageBox.Show("Refreshed");
        }

        //search funtions
        //frist name seacrh
        private void textBox_PreName_TextChanged(object sender, TextChangedEventArgs e)
        {

            // preferred name search
            if ((comboBox.SelectedItem == PreName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // d
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // c and d and e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Preferred_Name.Contains(textBox_PreName.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

            }

            // first name selected
            if ((comboBox.SelectedItem == FirName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // d
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // c and d and e
                else if ((textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.First_Name.Contains(textBox_PreName.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

            }






        }

        //last name search

        private void textBox_LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // preferred name selected

            if ((comboBox.SelectedItem == PreName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Surname.Contains(textBox_LastName.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
            }

            //first name selected
            if ((comboBox.SelectedItem == FirName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Surname.Contains(textBox_LastName.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
            }





        }

        // manager serach
        private void textBox_ManagerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((comboBox.SelectedItem == PreName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Managers_Number.Contains(textBox_ManagerName.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
            }

            //first name selected
            if ((comboBox.SelectedItem == FirName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_Pos.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Managers_Number.Contains(textBox_ManagerName.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

            }

        }

        private void textBox_Pos_TextChanged(object sender, TextChangedEventArgs e)
        {

            // preferred name selected
            if ((comboBox.SelectedItem == PreName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Position_Number.Contains(textBox_Pos.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
            }

            // first name selected
            if ((comboBox.SelectedItem == FirName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Position_Number.Contains(textBox_Pos.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_location.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Position_Number.Contains(textBox_Pos.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

            }
        }


        // search by location

        private void textBox_location_TextChanged(object sender, TextChangedEventArgs e)
        {
            // preferred name selected
            if ((comboBox.SelectedItem == PreName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.Preferred_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.Preferred_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Position_Number.Contains(textBox_Pos.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
            }

            // first name selected
            if ((comboBox.SelectedItem == FirName) || (comboBox.SelectedItem == null))
            {
                // b
                if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();



                }
                //c
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();
                }
                // d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.First_Name.Contains(textBox_PreName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Location.Contains(textBox_location.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text == null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text == null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // c and d and e
                else if ((textBox_PreName.Text == null) && (textBox_LastName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Surname.Contains(textBox_LastName.Text) & x.Location.Contains(textBox_location.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                //b and d and e
                else if ((textBox_PreName.Text != null) && (textBox_LastName.Text == null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null))
                {

                    var data = from x in context.wcs where x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Location.Contains(textBox_location.Text) & x.First_Name.Contains(textBox_PreName.Text) & x.Position_Number.Contains(textBox_Pos.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
                // b and c and d and e
                else if ((textBox_PreName.Text != null) && (textBox_ManagerName.Text != null) && (textBox_Pos.Text != null) && (textBox_location.Text != null))
                {

                    var data = from x in context.wcs where x.First_Name.Contains(textBox_PreName.Text) & x.Surname.Contains(textBox_LastName.Text) & x.Managers_Number.Contains(textBox_ManagerName.Text) & x.Position_Number.Contains(textBox_Pos.Text) & x.Location.Contains(textBox_location.Text) select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }

                // null
                else
                {
                    var data = from x in context.wcs
                               where x.Position_Number.Contains(textBox_Pos.Text)
                               select x;
                    wcs_testDataGrid.ItemsSource = data.ToList();

                }
            }

        }

    }
}
