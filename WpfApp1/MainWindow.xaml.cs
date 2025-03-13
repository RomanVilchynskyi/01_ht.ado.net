using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string connectionString = ConfigurationManager.ConnectionStrings["Librarydb"].ConnectionString;
    private DataTable table = new DataTable();

    public MainWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        string query = "select b.Id, b.Title as BookTitle, a.Name as Author, c.Name as Category " +
                       "from Books b " +
                       "join BookAuthors ba on b.Id = ba.BookId " +
                       "join Authors a on ba.AuthorId = a.Id " +
                       "join Categories c on b.CategoryId = c.Id";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        table.Clear();
        connection.Open();
        adapter.Fill(table);
        connection.Close();
        datagrid.ItemsSource = table.DefaultView;
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        string title = FilterTextBox.Text;
        if (string.IsNullOrEmpty(title)) return;

        string query = "insert into Books (Title) values (@Title)";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.Add(new SqlParameter("@Title", title));

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
        LoadData();
    }

    private void Delete(object sender, RoutedEventArgs e)
    {
        if (datagrid.SelectedIndex == -1) return; 

        DataRow selectedRow = table.Rows[datagrid.SelectedIndex];
        int bookId = (int)selectedRow["Id"];

        string query = "delete from Books where Id = @BookId";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.Add(new SqlParameter("@BookId", bookId));

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
        LoadData();
    }

    private void Update(object sender, RoutedEventArgs e)
    {

        DataRow selectedRow = table.Rows[datagrid.SelectedIndex];
        int bookId = (int)selectedRow["Id"];
        string newTitle = FilterTextBox.Text;

        if (string.IsNullOrEmpty(newTitle)) return;

        string query = "update Books set Title = @Title where Id = @BookId";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.Add(new SqlParameter("@Title", newTitle));
        cmd.Parameters.Add(new SqlParameter("@BookId", bookId));

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
        LoadData();
    }
}