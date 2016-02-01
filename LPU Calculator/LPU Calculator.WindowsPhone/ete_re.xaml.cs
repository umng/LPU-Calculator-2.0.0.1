using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
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
    public sealed partial class ete_re : Page
    {
        public ete_re()
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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void bt_reset_Click(object sender, RoutedEventArgs e)
        {
            tb_ca1.Text = "";
            tb_ca2.Text = "";
            tb_ca3.Text = "";
            tb_atd.Text = "";
            tb_ban.Text = "";
            tb_result.Text = "";

        }

        private async void bt_calculate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Int16 ca1 = 0, ca2 = 0, ca3 = 0, atd = 0;

                if (tb_ca1.Text == "" && tb_ca2.Text == "" && tb_ca3.Text == "" && tb_atd.Text == "")
                {
                    var dialog = new MessageDialog("Please enter marks for Continuous Assessments and ATTENDANCE % in given fields.");
                    dialog.Title = "INVALID INPUT";
                    await dialog.ShowAsync();
                }




                else
                {
                    if (tb_ca1.Text == "")
                    {
                        tb_ca1.Text = "00";
                    }
                    if (tb_ca2.Text == "")
                    {
                        tb_ca2.Text = "00";
                    }
                    if (tb_ca3.Text == "")
                    {
                        tb_ca3.Text = "00";
                    }
                    if (tb_atd.Text == "")
                    {
                        tb_atd.Text = "00";
                    }



                    //input data
                    ca1 = Convert.ToInt16(tb_ca1.Text);
                    ca2 = Convert.ToInt16(tb_ca2.Text);
                    ca3 = Convert.ToInt16(tb_ca3.Text);
                    atd = Convert.ToInt16(tb_atd.Text);



                    Int16[] x = new Int16[10] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29 };



                    //attendance marks
                    if (atd < 75)
                    {
                        atd = 0;
                    }
                    if ((atd >= 90) && (atd <= 100))
                    {
                        atd = 5;
                    }
                    if ((atd >= 85) && (atd < 90))
                    {
                        atd = 4;
                    }
                    if ((atd >= 80) && (atd < 85))
                    {
                        atd = 3;
                    }
                    if ((atd >= 75) && (atd < 80))
                    {
                        atd = 2;
                    }




                    //sorting CA
                    Int16 i, j;
                    Int16[] a = new Int16[3] { ca1, ca2, ca3 };
                    for (i = 0; i < 2; i++)
                    {
                        for (j = Convert.ToInt16(i + 1); j < 3; j++)
                        {
                            if (a[j] > a[i])
                            {
                                Int16 temp = a[j];
                                a[j] = a[i];
                                a[i] = temp;
                            }
                        }
                    }



                    for (Int16 m = 0; m < 10; m++)
                    {
                        if (a[0] == x[m])
                        {
                            a[0] += 1;
                        }
                        if (a[1] == x[m])
                        {
                            a[1] += 1;
                        }
                    }


                    float ca = (Convert.ToInt16(a[0]) / 3) + (Convert.ToInt16(a[1]) / 3);


                    //calculating answer

                    float answer = Convert.ToInt16((40 - (ca + atd))*4/3);





                    string fail_cond = "CA-I";
                    string fail_marks = "30";
                    if (ca1 <= 30)
                    {
                        ca1 += 0;
                        fail_cond = "CA-II";
                        fail_marks = "30";
                        if (ca2 <= 30)
                        {
                            fail_cond = "CA-III";
                            fail_marks = "30";
                            if (ca3 <= 30)
                            {
                                    fail_cond = "ATTENDANCE";
                                    fail_marks = "100";
                                    if (atd <= 100)
                                    {
                                        if (answer > 0)
                                        {
                                            //shows answer
                                            tb_ban.Text = "You Need :";
                                            tb_result.Text = Convert.ToString(answer);


                                            //resut dialog
                                            var dialog = new MessageDialog("Re-ETE = " + answer + " MARKS needed." + "\n\nYou need " + answer + " Marks in the Re-Appear End Term Exam (Re-ETE) to pass the course/subject." + "\n" + "\nBut MAKE SURE that you have entered:" + "\nCA-I  = " + tb_ca1.Text + " Marks" + "\nCA-II = " + tb_ca2.Text + " Marks" + "\nCA-III= " + tb_ca3.Text + " Marks" + "\n\nATTENDANCE = " + tb_atd.Text + " %");
                                            dialog.Title = "RESULT";
                                            dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
                                            await dialog.ShowAsync();


                                        }
                                        else
                                        {
                                            var dialog = new MessageDialog("You do not need  any marks in the Re-Appear End Term Exam (Re-ETE) to pass the course/subject." + "\n" + "\nBut MAKE SURE that you have entered:" + "\nCA-I  = " + tb_ca1.Text + " Marks" + "\nCA-II = " + tb_ca2.Text + " Marks" + "\nCA-III= " + tb_ca3.Text + " Marks" + "\n\nATTENDANCE = " + tb_atd.Text + " %");
                                            dialog.Title = "RESULT";
                                            dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
                                            await dialog.ShowAsync();
                                        }

                                    }
                                    else
                                    {
                                        var dialog = new MessageDialog("Oops, You have entered invalid input for ATTENDANCE percentage." + "\nENTER ATTENDENCE PERCENTAGE(%)");

                                        dialog.Title = "INVALID INPUT";
                                        dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
                                        await dialog.ShowAsync();
                                    }
                            }
                            else
                            {
                                var dialog = new MessageDialog("Oops, You have entered wrong marks for " + fail_cond + "." + "\nPlease enter marks less than or equals " + fail_marks + ".");

                                dialog.Title = "INVALID INPUT";
                                dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
                                await dialog.ShowAsync();
                            }

                        }
                        else
                        {
                            var dialog = new MessageDialog("Oops, You have entered wrong marks for " + fail_cond + "." + "\nPlease enter marks less than or equals " + fail_marks + ".");

                            dialog.Title = "INVALID INPUT";
                            dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
                            await dialog.ShowAsync();
                        }

                    }
                    else
                    {
                        var dialog = new MessageDialog("Oops, You have entered wrong marks for " + fail_cond + "." + "\nPlease enter marks less than or equals " + fail_marks + ".");

                        dialog.Title = "INVALID INPUT";
                        dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;

                        await dialog.ShowAsync();
                    }

                }
            }
            catch
            {
                Frame.Navigate(typeof(ete_re));
            }
        }

        private void tb_help_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(help));

        }
    }
}