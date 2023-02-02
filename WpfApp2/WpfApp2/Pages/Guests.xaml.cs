using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Guests.xaml
    /// </summary>
    public partial class Guests : Page, INotifyPropertyChanged
    {
        private DataTable dt = new DataTable();
        public DataTable items
        {
            get => dt;
            set
            {
                dt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("items"));
            }
        }
        private SqlDataAdapter adapter;
        public Guests()
        {
            InitializeComponent();
            this.DataContext = this;
            adapter = new SqlDataAdapter("SELECT * FROM guests", "Server=DESKTOP-Q5CG15O;Database=Hotel;Trusted_Connection=True;");
            adapter.Fill(items);

            items.PrimaryKey = new DataColumn[1] { items.Columns["ID"] };
            items.Columns["ID"].AutoIncrement = true;
            items.Columns["ID"].AutoIncrementSeed = int.Parse(items.Select().Max(x => x["ID"]).ToString()) + 1;

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataRow newrow = items.NewRow();

            newrow["GuestName"] = "";
            newrow["GuestDocs"] = "";
            newrow["Price"] = 0;
            newrow["Comments"] = "";

            items.Rows.Add(newrow);
            adapter.Update(items);
        }

        private void Button_Click_delete(object sender, System.Windows.RoutedEventArgs e)
        {
            DataRowView deleted = Table.SelectedItem as DataRowView;
            deleted.Delete();
            adapter.Update(items);
        }
        private void Table_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) =>
    new Thread(() => update()).Start();
        private void update()
        {
            Thread.Sleep(30);
            adapter.Update(items);
        }
    }
}
