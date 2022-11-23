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
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class OrderPage : Page
    {


        private int sumPrice = 0;
        private string menulist ="";
        public OrderPage()
        {
            InitializeComponent();
            this.Loaded += OrderPage_Loaded;
        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategory.SelectedIndex == -1) return;



            Category category = (Food)lbCategory.SelectedIndex;
            lbMenus.ItemsSource = listFood.Where(x => x.category == category).ToList();
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
                listFood.Add
            }

            lbMenus.ItemsSource = listFood.Where(x => x.category == "BURGER").ToList();
        }

        /*private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            PlacePage placePage = new PlacePage();
            NavigationService.Navigate(placePage);
        }
        */

        private List<View.Food> listFood = new List<View.Food>();

       

        
    }
}
