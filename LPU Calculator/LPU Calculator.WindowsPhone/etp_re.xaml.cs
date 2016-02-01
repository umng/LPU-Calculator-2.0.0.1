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
    public sealed partial class etp_re : Page
    {
        public etp_re()
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
            tb_p1.Text = "";
            tb_p2.Text = "";
            tb_p3.Text = "";
            tb_p4.Text = "";
            tb_p5.Text = "";
            tb_p6.Text = "";
            tb_p7.Text = "";
            tb_p8.Text = "";
            tb_p9.Text = "";
            tb_p10.Text = "";
            tb_atd.Text = "";
            tb_ban.Text = "";
            tb_result.Text = "";

        }

        private async void bt_calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int16 p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0, p10 = 0, atd = 0;

                if (tb_p1.Text == "" && tb_p2.Text == "" && tb_p3.Text == "" && tb_p4.Text == "" && tb_p5.Text == "" && tb_p6.Text == "" && tb_p7.Text == "" && tb_p8.Text == "" && tb_p9.Text == "" && tb_p10.Text == "" && tb_atd.Text == "")
                {
                    var dialog = new MessageDialog("Please enter marks for Practical Evaluations and ATTENDANCE % in given fields.");
                    dialog.Title = "INVALID INPUT";
                    await dialog.ShowAsync();
                }




                else
                {
                    if (tb_p1.Text == "")
                    {
                        tb_p1.Text = "00";
                    }
                    if (tb_p2.Text == "")
                    {
                        tb_p2.Text = "00";
                    }
                    if (tb_p3.Text == "")
                    {
                        tb_p3.Text = "00";
                    }
                    if (tb_p4.Text == "")
                    {
                        tb_p4.Text = "00";
                    }
                    if (tb_p5.Text == "")
                    {
                        tb_p5.Text = "00";
                    }
                    if (tb_p6.Text == "")
                    {
                        tb_p6.Text = "00";
                    }
                    if (tb_p7.Text == "")
                    {
                        tb_p7.Text = "00";
                    }
                    if (tb_p8.Text == "")
                    {
                        tb_p8.Text = "00";
                    }
                    if (tb_p9.Text == "")
                    {
                        tb_p9.Text = "00";
                    }
                    if (tb_p10.Text == "")
                    {
                        tb_p10.Text = "00";
                    }
                    if (tb_atd.Text == "")
                    {
                        tb_atd.Text = "00";
                    }



                    //input data
                    p1 = Convert.ToInt16(tb_p1.Text);
                    p2 = Convert.ToInt16(tb_p2.Text);
                    p3 = Convert.ToInt16(tb_p3.Text);
                    p4 = Convert.ToInt16(tb_p4.Text);
                    p5 = Convert.ToInt16(tb_p5.Text);
                    p6 = Convert.ToInt16(tb_p6.Text);
                    p7 = Convert.ToInt16(tb_p7.Text);
                    p8 = Convert.ToInt16(tb_p8.Text);
                    p9 = Convert.ToInt16(tb_p9.Text);
                    p10 = Convert.ToInt16(tb_p10.Text);
                    atd = Convert.ToInt16(tb_atd.Text);





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
                    Int16[] a = new Int16[10] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
                    for (i = 0; i < 10; i++)
                    {
                        for (j = Convert.ToInt16(i + 1); j < 10; j++)
                        {
                            if (a[j] > a[i])
                            {
                                Int16 temp = a[j];
                                a[j] = a[i];
                                a[i] = temp;
                            }
                        }
                    }



                    float p = 0;
                    for (i = 0; i < 8; i++)
                    {
                        p += Convert.ToInt16(a[i]);
                    }
                    float ptl = (25 * p) / 400;
                    Int16 pt = Convert.ToInt16(ptl);
                    //calculating answer

                    float answer = (40 - (pt + atd)) * 100/70;
                    Int16 ans = Convert.ToInt16(answer);

                    string fail_cond = "PRACTICAL-I";
                    string fail_marks = "50";
                    if (p1 <= 50)
                    {
                        p1 += 0;
                        fail_cond = "PRACTICAL-II";
                        fail_marks = "50";
                        if (p2 <= 50)
                        {
                            fail_cond = "PRACTICAL-III";
                            fail_marks = "50";
                            if (p3 <= 50)
                            {
                                fail_cond = "PRACTICAL-IV";
                                fail_marks = "50";
                                if (p4 <= 50)
                                {
                                    fail_cond = "PRACTICAL-V";
                                    fail_marks = "50";
                                    if (p5 <= 50)
                                    {
                                        fail_cond = "PRACTICAL-VI";
                                        fail_marks = "50";
                                        if (p6 <= 50)
                                        {
                                            fail_cond = "PRACTICAL-VII";
                                            fail_marks = "50";
                                            if (p7 <= 50)
                                            {
                                                fail_cond = "PRACTICAL-VIII";
                                                fail_marks = "50";
                                                if (p8 <= 50)
                                                {
                                                    fail_cond = "PRACTICAL-IX";
                                                    fail_marks = "50";
                                                    if (p9 <= 50)
                                                    {
                                                        fail_cond = "PRACTICAL-X";
                                                        fail_marks = "50";
                                                        if (p10 <= 50)
                                                        {

                                                                    fail_cond = "ATTENDANCE";
                                                                    fail_marks = "100";
                                                                    if (atd <= 100)
                                                                    {
                                                                        if (answer > 0)
                                                                        {

                                                                            //shows answer
                                                                            tb_ban.Text = "You Need :";
                                                                            tb_result.Text = Convert.ToString(ans);


                                                                            //resut dialog
                                                                            var dialog = new MessageDialog("Re-ETP = " + ans + " MARKS needed." + "\n\nYou need " + answer + " Marks in the Re-Appear End Term Practicals (ETP) to pass the course/subject." + "\n" + "\nBut MAKE SURE that you have entered:" + "\nPRACTICAL-I  = " + tb_p1.Text + " Marks" + "\nPRACTICAL-II = " + tb_p2.Text + " Marks" + "\nPRACTICAL-III= " + tb_p3.Text + " Marks" + "\nPRACTICAL-IV  = " + tb_p4.Text + " Marks" + "\nPRACTICAL-V = " + tb_p5.Text + " Marks" + "\nPRACTICAL-VI = " + tb_p6.Text + " Marks" + "\nPRACTICAL-VII  = " + tb_p7.Text + " Marks" + "\nPRACTICAL-VIII = " + tb_p8.Text + " Marks" + "\nPRACTICAL-IX= " + tb_p9.Text + " Marks" + "\nPRACTICAL-X= " + tb_p10.Text + " Marks" + "\n\nATTENDANCE = " + tb_atd.Text + " %");
                                                                            dialog.Title = "RESULT";
                                                                            dialog.Options = MessageDialogOptions.AcceptUserInputAfterDelay;
                                                                            await dialog.ShowAsync();


                                                                        }
                                                                        else
                                                                        {
                                                                            var dialog = new MessageDialog("You do not need  any marks in the Re-Appear End Term Practical (Re-ETP) to pass the course/subject." + "\n" + "\nBut MAKE SURE that you have entered:" + "\nPRACTICAL-I  = " + tb_p1.Text + " Marks" + "\nPRACTICAL-II = " + tb_p2.Text + " Marks" + "\nPRACTICAL-III= " + tb_p3.Text + " Marks" + "\nPRACTICAL-IV  = " + tb_p4.Text + " Marks" + "\nPRACTICAL-V = " + tb_p5.Text + " Marks" + "\nPRACTICAL-VI = " + tb_p6.Text + " Marks" + "\nPRACTICAL-VII  = " + tb_p7.Text + " Marks" + "\nPRACTICAL-VIII = " + tb_p8.Text + " Marks" + "\nPRACTICAL-IX= " + tb_p9.Text + " Marks" + "\nPRACTICAL-X= " + tb_p10.Text + " Marks" + "\n\nATTENDANCE = " + tb_atd.Text + " %");
                                                                            dialog.Title = "RESULT";
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
                Frame.Navigate(typeof(etp_re));
            }

        }

        private void tb_help_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(help));
        }
    }
}
