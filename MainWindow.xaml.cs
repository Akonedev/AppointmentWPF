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

namespace AppointmentWPF2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int updatingCustId = 0;
        AppointmentWPFEntities db = new AppointmentWPFEntities();
        public MainWindow()
        {
            InitializeComponent();
            AppointmentWPFEntities db = new AppointmentWPFEntities();
            this.grCustomers.ItemsSource = db.Customers.ToList();

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AppointmentWPFEntities db = new AppointmentWPFEntities();
            //Customers customers = (Customers)sender;
            if (txtLastName.Text != ""
               && txtFirstName.Text != ""
               && txtEmail.Text != ""
               && txtPhone.Text != ""
               && txtBudget.Text != "")
            {
                Customers customers = new Customers()
                {
                    LastName = txtLastName.Text,
                    FirstName = txtFirstName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Budget = Int32.Parse(txtBudget.Text)
                };
                db.Customers.Add(customers);
                db.SaveChanges();

                txtLastName.Text = "";
                txtFirstName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtBudget.Text = "0";
                Button_Click_Show(sender, e);
            }
            else
            {
                MessageBox.Show("Vous devez remplir tousles champs svp.");
            };

        }

        private void Button_Click_Show(object sender, RoutedEventArgs e)
        {
           // AppointmentWPFEntities db = new AppointmentWPFEntities();
            /*  var custs = from c in db.Customers
                          select new
                          {
                              c.FirstName,
                              c.LastName,
                              c.Email,
                              c.Phone,
                              c.Budget
                          };

              foreach (var c in custs)
              {
                  Console.WriteLine(c.FirstName);
              }
              this.grCustomers.ItemsSource = custs.ToList();*/

            this.grCustomers.ItemsSource = db.Customers.ToList();
        }

        private void grCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  AppointmentWPFEntities db = new AppointmentWPFEntities();
            if (this.grCustomers.SelectedIndex >= 0)
            {
                if (this.grCustomers.SelectedItems.Count >= 0)
                {
                    /* if (this.grCustomers.SelectedItems[0].GetType() == typeof(Customers))
                     {*/
                    Customers custSelected = (Customers)this.grCustomers.SelectedItems[0];

                    this.updatingCustId = custSelected.Id;
                    this.txtLastNameEdit.Text = custSelected.LastName;
                    this.txtFirstNameEdit.Text = custSelected.FirstName;
                    this.txtEmailEdit.Text = custSelected.Email;
                    this.txtPhoneEdit.Text = custSelected.Phone;
                    this.txtBudgetEdit.Text = custSelected.Budget.ToString();

                    //}
                    db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
           // AppointmentWPFEntities db = new AppointmentWPFEntities();
            var customer = from c in db.Customers
                           where c.Id == updatingCustId
                           select c;
            Customers cust = customer.SingleOrDefault();

            if (cust != null)
            {
                //cust.Id = updatingCustId;
                cust.LastName = this.txtLastNameEdit.Text;
                cust.FirstName = this.txtFirstNameEdit.Text;
                cust.Email = this.txtEmailEdit.Text;
                cust.Phone = this.txtPhoneEdit.Text;
                cust.Budget = int.Parse(this.txtBudgetEdit.Text);

                db.SaveChanges();
                txtLastNameEdit.Text = "";
                txtFirstNameEdit.Text = "";
                txtEmailEdit.Text = "";
                txtPhoneEdit.Text = "";
                txtBudgetEdit.Text = "0";
                Button_Click_Show(sender, e);
            }

        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult = MessageBox.Show("Confirmation de la Suppresion", "Suppresion du Client",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
                );

            if (msgBoxResult == MessageBoxResult.Yes)
            {
                //
                var customer = from c in db.Customers
                               where c.Id == updatingCustId
                               select c;
                Customers cust = customer.SingleOrDefault();

                if (cust != null)
                {
                    db.Customers.Remove(cust);
                    db.SaveChanges();
                    Button_Click_Show(sender, e);
                }
            }

        }
    }
}
