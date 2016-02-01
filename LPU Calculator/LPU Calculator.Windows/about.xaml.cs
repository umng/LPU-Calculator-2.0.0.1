using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LPU_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class about : Page
    {
        public about()
        {
            this.InitializeComponent();
            bt_about.Width = 400;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ete));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(etp));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ete_re));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(etp_re));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(atd));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(help));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

              private void bt_phone_Click(object sender, RoutedEventArgs e)
        {
            rec_back.Opacity = 100;


            tb_phone.Text = "Phone";
            tb_mail.Text = "";
            tb_facebook.Text = "";

            tb_final.Text = "+91 8195875260";

            rec_phone.Opacity = 100;
            rec_mail.Opacity = 0;
            rec_facebook.Opacity = 0;


        }

        private void bt_mail_Click(object sender, RoutedEventArgs e)
        {
            rec_back.Opacity = 100;


            tb_mail.Text = "Mail";
            tb_phone.Text = "";
            tb_facebook.Text = "";

            tb_final.Text = "onecorporation@hotmail.com";

            rec_mail.Opacity = 100;
            rec_phone.Opacity = 0;
            rec_facebook.Opacity = 0;
        }

        private void bt_facebook_Click(object sender, RoutedEventArgs e)
        {
            rec_back.Opacity = 100;


            tb_facebook.Text = "Facebook";
            tb_phone.Text = "";
            tb_mail.Text = "";

            tb_final.Text = "www.facebook.com/onecorpindia";

            rec_facebook.Opacity = 100;
            rec_phone.Opacity = 0;
            rec_mail.Opacity = 0;
        }
    }
}