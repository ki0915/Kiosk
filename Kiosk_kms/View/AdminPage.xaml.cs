﻿using System;
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

namespace Kiosk_kms.View
{
    /// <summary>
    /// AdminPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        
        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            string id = AdminId.Text;
            string pw = AdminPw.Text;

            if(id == "root" && pw == "1234")
            {
       
               UpdatePage updatePage = new UpdatePage();
                 NavigationService.Navigate(updatePage);
      
            }
        }
        
    }
}
