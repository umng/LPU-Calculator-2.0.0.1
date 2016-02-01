using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class atd : Page
    {
        public atd()
        {
            this.InitializeComponent();
            bt_atd.Width = 400;
        }

        private void tb_help_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(help));
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
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(help));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(about));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void bt_reset_Click(object sender, RoutedEventArgs e)
        {
            tb_ttl.Text = "";
            tb_dlv.Text = "";
            tb_att.Text = "";
            rec_ban.Opacity = 0;
            rec_result1.Opacity = 0;
            rec_result2.Opacity = 0;

        }

        private async void bt_calculate_Click(object sender, RoutedEventArgs e)
        {
            Int16 ttl = 0, dlv = 0, att = 0;


            try
            {
                if (tb_ttl.Text == "" || tb_dlv.Text == "" || tb_att.Text == "")
                {
                    var dialog = new MessageDialog("Enter Total Lectures, Delivered Lectures and Attended Lectures in the given fields.");
                    dialog.Title = "INVALID INPUT";
                    await dialog.ShowAsync();
                }

                else
                {
                    if (tb_ttl.Text == "")
                    {
                        tb_ttl.Text = "00";
                    }
                    if (tb_dlv.Text == "")
                    {
                        tb_dlv.Text = "00";
                    }
                    if (tb_att.Text == "")
                    {
                        tb_att.Text = "00";
                    }

                    ttl = Convert.ToInt16(tb_ttl.Text);
                    dlv = Convert.ToInt16(tb_dlv.Text);
                    att = Convert.ToInt16(tb_att.Text);

                    if (ttl < dlv || ttl < att || dlv < att)
                    {
                        var dialog = new MessageDialog("You have entered invalid no.of Lectures.\n\nInstructions:\n1.TOTAL Lectures can't be less than DELIVERED Lectues and ATTENDED Lectures.\n2.DELIVERED Lectures always greater than ATTENDED Lectures.");
                        dialog.Title = "INVALID INPUT";
                        await dialog.ShowAsync();
                    }

                    else
                    {

                        Int16 left = Convert.ToInt16(ttl - dlv);
                        float req = Convert.ToInt16(ttl * 0.75);

                        if ((att + left) >= req)
                        {
                            float available = req - att;
                            available = Convert.ToInt16(available);

                            if (available > 0)
                            {
                                //shows answer
                                rec_ban.Opacity = 100;
                                tb_ban.Text = "You Need";
                                rec_result1.Opacity = 100;
                                rec_result2.Opacity = 100;
                                tb_result.Text = Convert.ToString(available);

                                var dialog = new MessageDialog("You need to attend " + available + " Lectures out of next " + left + " Lectures.\n\n\nYou can BUNK " + (left - available) + " Lectures now.");
                                dialog.Title = "RESULT";
                                await dialog.ShowAsync();
                            }
                            else
                            {
                                tb_ban.Text = "";
                                tb_result.Text = "";
                                var dialog = new MessageDialog("You do not need to attend any Lecture out of next " + left + " Lectures.\n\n\nYou can BUNK all the Lectures now.");
                                dialog.Title = "RESULT";
                                await dialog.ShowAsync();
                            }
                        }

                        else
                        {
                            var dialog = new MessageDialog("You will not have attendance greater than 75% even if you attend next all the lectures.");
                            dialog.Title = "NOT ELIGIBLE";
                            await dialog.ShowAsync();
                        }
                    }

                }

            }
            catch
            {
                Frame.Navigate(typeof(atd));
            }
        }
    }
}
