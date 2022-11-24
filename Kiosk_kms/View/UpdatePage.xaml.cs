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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiosk_kms.View
{
    /// <summary>
    /// UpdatePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UpdatePage : Page
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private void Product_Update(object sender, RoutedEventArgs e)
        {

            string id = productId.Text;
            string name = productName.Text;
            string image = productImage.Text;
            string category = productCategory.Text;
            int price = int.Parse(productPrice.Text);

            
            System.Data.SqlClient.SqlConnection sqlcon = new SqlConnection("Server=127.0.0.1; Database=KioskDB; uid=root; pwd=1234");

            sqlcon.Open();

            string strSql_Update = "insert into Kiosk_TB(id, name, image, category, price) values(" + id + ","+ "'" + name + "'" +  ","+ "'" + image + "'" + ","+ "'" + category + "'" +  ","+  price + ")";

            SqlCommand cmd_Insert = new SqlCommand(strSql_Update, sqlcon);

            cmd_Insert.ExecuteNonQuery();

            sqlcon.Close();

        }


        private void Product_Delete(object sender, RoutedEventArgs e)
        {


            string names = productName.Text;
           

            System.Data.SqlClient.SqlConnection sqlcon = new SqlConnection("Server=127.0.0.1; Database=KioskDB; uid=root; pwd=1234");

            sqlcon.Open();

            string strSql_Del = "delete from Kiosk_TB where name=" + "'" + names + "'";

            SqlCommand cmd_Del= new SqlCommand(strSql_Del, sqlcon);

            cmd_Del.ExecuteNonQuery();

            sqlcon.Close();

        }
    }
}
