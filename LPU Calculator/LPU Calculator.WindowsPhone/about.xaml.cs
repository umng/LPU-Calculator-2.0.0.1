using Microsoft.Advertising.Mobile.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

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
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                return;
            }
            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
        }

        private void bt_phone_Click(object sender, RoutedEventArgs e)
        {
            rec_back.Opacity = 100;

            bt_phone.IsHitTestVisible = false;
            bt_mail.IsHitTestVisible = true;
            bt_facebook.IsHitTestVisible = true;

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

            bt_mail.IsHitTestVisible = false;
            bt_phone.IsHitTestVisible = true;
            bt_facebook.IsHitTestVisible = true;

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

            bt_facebook.IsHitTestVisible = false;
            bt_phone.IsHitTestVisible = true;
            bt_mail.IsHitTestVisible = true;

            tb_facebook.Text = "Facebook";
            tb_phone.Text = "";
            tb_mail.Text = "";

            tb_final.Text = "www.facebook.com/onecorpindia";

            rec_facebook.Opacity = 100;
            rec_phone.Opacity = 0;
            rec_mail.Opacity = 0;
        }

        private void OnAdError(object sender, Microsoft.Advertising.Mobile.Common.AdErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("AdControl error (" + ((AdControl)sender).Name + "): " + e.Error + " ErrorCode: " + e.ErrorCode.ToString());
        }
    }
}
