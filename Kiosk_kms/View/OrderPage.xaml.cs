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



            Category category = (Category)lbCategory.SelectedIndex;
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
            dr = cmd.ExecuteReader();
            lbMenus.ItemsSource = listFood.Where(x => x.category == Category.BURGER).ToList();
        }

        /*private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            PlacePage placePage = new PlacePage();
            NavigationService.Navigate(placePage);
        }
        */

        private List<View.Food> listFood = new List<View.Food>()
        {
            new View.Food() { category = View.Category.BURGER, name = "불고기 버거",
            imagePath = @"/images/불고기 버거.png", price = 10000 },
            new View.Food() { category = View.Category.BURGER,
            name = "핫크리스피 버거", imagePath = @"/images/핫크리스피 버거.png", price = 10000},
             new View.Food() { category = View.Category.BURGER,
            name = "더블 한우불고기", imagePath = @"/images/더블 한우불고기.png" , price = 10000},

             new View.Food() { category = View.Category.BURGER,
            name = "클래식 치즈버거", imagePath = @"/images/클래식 치즈버거.png" , price = 10000},
                new View.Food() { category = View.Category.BURGER,
            name = "새우 버거", imagePath = @"/images/새우 버거.png" , price = 10000},
            new View.Food() { category = View.Category.BURGER,
            name = "힙&핫치킨버거", imagePath = @"/images/힙&핫치킨버거.png", price = 10000},
            new View.Food() { category = View.Category.BURGER,
            name = "리아미라클버거", imagePath = @"/images/클래식 치즈버거.png" , price = 10000},
            new View.Food() { category = View.Category.BURGER,
            name = "더블X2", imagePath = @"/images/더블X2.png", price = 10000 },

             new View.Food() { category = View.Category.DRINK,
             name = "코카콜라", imagePath = @"/images/코카콜라.png" , price = 10000},

             new View.Food() { category = View.Category.DRINK,
             name = "스프라이트", imagePath = @"/images/스프라이트.png", price = 10000 },
        };

        
    }
}
