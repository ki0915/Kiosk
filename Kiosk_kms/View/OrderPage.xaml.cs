using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class OrderPage : Page
    {


        private int sumPrice = 0;
        private string menulist ="";
        private string cate;
        private string url = "http://localhost:3000/";


        public OrderPage()
        {
            InitializeComponent();
            this.Loaded += OrderPage_Loaded;
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;
           
            if (lbCategory.SelectedIndex == 0) cate = "BURGER";
            else if (lbCategory.SelectedIndex == 1) cate ="DRINK";
            else if(lbCategory.SelectedIndex == 2)
            {
                AdminPage adminPage = new AdminPage();
                NavigationService.Navigate(adminPage);
            }
            lbMenus.ItemsSource = listFood.Where(x => x.category == cate).ToList();
        }


        private void lbMenus_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbMenus.SelectedIndex == -1) return;

            Food food = (Food)lbMenus.SelectedItem;
            
            sumPrice += food.price;

            Price.Text = sumPrice.ToString();

            menulist += food.name;
             menulist += " ";
            MenuList.Text = menulist;
        }


        private void OrderPage_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("Server=127.0.0.1; Database=KioskDB; uid=root; pwd=1234");

            sqlcon.Open();

            string strSql_Select = "select id,name,image, category, price from Kiosk_TB";
            SqlCommand cmd_Select = new SqlCommand(strSql_Select, sqlcon);

            SqlDataReader rd = cmd_Select.ExecuteReader();

            
            while (rd.Read())
            {
                View.Food fd = new View.Food
                {
                    name = (string)rd["name"],
                    imagePath = (string)rd["image"],
                    category = (string)rd["category"],
                    price = (int)rd["price"]
                   };

                listFood.Add(fd);

        }

        lbMenus.ItemsSource = listFood.Where(x => x.category == "BURGER").ToList();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json; utf-8";

            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream())) //전송
            {
                string json = "{ price: " + sumPrice.ToString() + "}";
                streamWriter.Write(json);
            }

        }
        
        
        private List<View.Food> listFood = new List<View.Food>();

       

        
    }
}
