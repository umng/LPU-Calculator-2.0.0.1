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
    public sealed partial class ete : Page
    {
        public ete()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed+=HardwareButtons_BackPressed;
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
           
           if(frame.CanGoBack)
           {
               frame.GoBack();
               e.Handled = true;
               
           }
        }
       private void Button_Click(object sender, RoutedEventArgs e)
       {
           Int16 ca1=0, ca2=0, mte=0, w=0; int answer;
           ca1 = Convert.ToInt16(tb_ca1.Text);
           ca2 = Convert.ToInt16(tb_ca2.Text);
           mte = Convert.ToInt16(tb_mte.Text);
           w = Convert.ToInt16(tb_atd.Text);
           answer = calculate(ca1, ca2, mte, w);
           text_start.Text = "You Need:        Marks";
           ans.Text = Convert.ToString(answer);
          
           
           
       }
       private int calculate(Int16 x, Int16 y, Int16 z, Int16 w)
       {
           int a=0, ans;
           {

               if (w >= 90)
               {
                   a = 5;
               }
               if (w >= 85 & w < 90)
               {
                   a = 4;
               }
               if (w >= 80 & w < 85)
               {
                   a = 3;
               }
               if (w >= 75 & w < 80)
               {
                   a = 2;
               }

           }
           ans =( 40 - ( ((x + y) / 3) + (z / 2) + a )) * 2 ;
           return ans;
       }
    }
}
