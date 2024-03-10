using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Register2
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegbtnSubmit(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            User newUser = new User
            {
                Username = username,
                Password = password
            };

            newUser.Register();
            Hide();
        }
    }
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void Register()
        {
            string conStr = "Data Source=localhost\\SQLEXPRESS; Initial Catalog = RegSystem; Integrated Security = True;";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "INSERT INTO USERS (Username, Password, CreatedDate, RoleId) VALUES (@Username, @Password, @CreatedDate, @RoleId)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@RoleId", 2);
                cmd.ExecuteNonQuery();

            }
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class UserRole
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class sp_helpdiagrams_Result
    {
    }

    public class sp_helpdiagramdefinition_Result
    {
    }
}
