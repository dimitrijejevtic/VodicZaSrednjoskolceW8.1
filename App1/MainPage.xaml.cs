using App1.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        Button trenutni = new Button();
        string currentTab = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FakultetiflipView.Visibility = Visibility.Collapsed;
            hideGrids();
            btnFakulteti.Background = new SolidColorBrush(Windows.UI.Colors.Green);

            Button asd = sender as Button;
            #region popravi
            switch ((string)asd.Content)
            {
                case "Fakulteti":
                    list.ItemsSource = Data.Fakulteti;
                    currentTab = "Fakulteti";
                    if (list.SelectedIndex != -1)
                        gridFakulteti.Visibility = Visibility.Visible;
                    else infoGridFakulteti.Visibility = Visibility.Visible;
                    break;
                case "Domovi":
                    list.ItemsSource = Data.Domovi;
                    currentTab = "Domovi";
                    if (list.SelectedIndex != -1)
                        gridDomovi.Visibility = Visibility.Visible;
                    else infoGridDomovi.Visibility = Visibility.Visible;
                    break;
                case "Menze":
                    list.ItemsSource = Data.Menze;
                    currentTab = "Menze";
                    if (list.SelectedIndex != -1)
                        gridMenze.Visibility = Visibility.Visible;
                    else infoGridMenze.Visibility = Visibility.Visible;
                    break;
                case "Rečnik za brucoše":
                    list.ItemsSource = null;
                    currentTab = "Rečnik za brucoše";
                    gridRecnik.Visibility = Visibility.Visible;
                    break;
                case "Informacije":
                    list.ItemsSource = null;
                    currentTab = "Informacije";
                    gridInformacije.Visibility = Visibility.Visible;
                    break;
                default:
                    list.ItemsSource = null;
                    currentTab = "";
                    break;
            }
            #endregion

            if (list.Visibility == Visibility.Visible && asd.Content.Equals(trenutni.Content))
            {
                krajSpiska.Begin();
                wait(250);
                FakultetiflipView.Margin = new Thickness(-100, -100, 0, 0);
            }
            else
            {
                list.Visibility = Visibility.Collapsed;
                trenutni.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                if (!asd.Content.Equals("Informacije") && !asd.Content.Equals("Rečnik za brucoše"))
                {
                    pojavi(100);
                    pojavaSpiska.Begin();
                }
                asd.Background = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
                FakultetiflipView.Margin = new Thickness(-400, -100, 0, 0);
            }
            if (asd.Content.Equals("Informacije") || asd.Content.Equals("Rečnik za brucoše"))
            {
                list.Visibility = Visibility.Collapsed;
                pojavaVesti.Begin();
            }
            trenutni = asd;
        }

        private async void pojavi(int time)
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(time));
            list.Visibility = Visibility.Visible;
        }

        private async void wait(int time)
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(time));
            list.Visibility = Visibility.Collapsed;
        }

        private void hideGrids()
        {
            gridDomovi.Visibility = Visibility.Collapsed;
            gridFakulteti.Visibility = Visibility.Collapsed;
            gridMenze.Visibility = Visibility.Collapsed;
            gridRecnik.Visibility = Visibility.Collapsed;
            gridInformacije.Visibility = Visibility.Collapsed;

            infoGridFakulteti.Visibility = Visibility.Collapsed;
            infoGridDomovi.Visibility = Visibility.Collapsed;
            infoGridMenze.Visibility = Visibility.Collapsed;
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FakultetiflipView.Visibility = Visibility.Visible;
            FakultetiflipView.SelectedIndex = ((GridView)sender).SelectedIndex;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FakultetigridView.SelectedIndex = -1;
            FakultetiflipView.Visibility = Visibility.Collapsed;

            DomovigridView.SelectedIndex = -1;

        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FakultetiflipView.Visibility = Visibility.Collapsed;
            if (list.SelectedIndex != -1)
            {
                if (currentTab == "Fakulteti")
                {
                    infoGridFakulteti.Visibility = Visibility.Collapsed;
                    gridFakulteti.Visibility = Visibility.Visible;
                    if (Data.Fakulteti[list.SelectedIndex].Naziv.Length > 50)
                        naziv.FontSize = 20;
                    else if (Data.Fakulteti[list.SelectedIndex].Naziv.Length > 40)
                        naziv.FontSize = 25;
                    else if (Data.Fakulteti[list.SelectedIndex].Naziv.Length > 30)
                        naziv.FontSize = 30;
                    else naziv.FontSize = 35;
                    if (Data.Fakulteti[list.SelectedIndex].Naziv.Contains("isoka") || Data.Fakulteti[list.SelectedIndex].Naziv.Contains("eogradska po"))
                    {
                        tbOpis.Visibility = Visibility.Collapsed;
                        tbSmerovi.Visibility = Visibility.Collapsed;
                        tbZvanja.Visibility = Visibility.Collapsed;
                        tbUslovi.Visibility = Visibility.Collapsed;
                        tbEmail.Visibility = Visibility.Collapsed;
                        tbDekan.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        tbOpis.Visibility = Visibility.Visible;
                        tbSmerovi.Visibility = Visibility.Visible;
                        tbZvanja.Visibility = Visibility.Visible;
                        tbUslovi.Visibility = Visibility.Visible;
                        tbEmail.Visibility = Visibility.Visible;
                        tbDekan.Visibility = Visibility.Visible;
                    }
                }
                else if (currentTab == "Domovi")
                {
                    infoGridDomovi.Visibility = Visibility.Collapsed;
                    gridDomovi.Visibility = Visibility.Visible;
                }
                else if (currentTab == "Menze")
                {
                    infoGridMenze.Visibility = Visibility.Collapsed;
                    gridMenze.Visibility = Visibility.Visible;
                }
                else if (currentTab == "Recnik")
                {
                    gridMenze.Visibility = Visibility.Visible;
                }
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            searchBox.Margin = new Thickness(this.ActualWidth - 250, -this.ActualHeight + 100, 0, 0);
            lbVesti.MaxWidth = this.ActualHeight / 2;
            radio1.IsChecked = true;
            infoGridFakulteti.Visibility = Visibility.Visible;
            list.Visibility = Visibility.Visible;
            list.ItemsSource = Data.Fakulteti;
            btnFakulteti.Background = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
            trenutni.Content = "Fakulteti";
            currentTab = "Fakulteti";
        }

        #region search

        private void SearchBoxEventsQuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            string result = args.QueryText.ToLower();
            for (int i = 0; i < Data.Fakulteti.Count; i++)
            {
                if (Data.Fakulteti[i].Naziv.ToLower() == result)
                {
                    hideGrids();
                    currentTab = "Fakulteti";
                    trenutni.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    btnFakulteti.Background = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
                    trenutni = btnFakulteti;
                    list.ItemsSource = Data.Fakulteti;
                    gridFakulteti.Visibility = Visibility.Visible;
                    list.Visibility = Visibility.Visible;
                    list.SelectedIndex = i;
                    searchBox.QueryText = "";
                    var manager = new Windows.ApplicationModel.Search.Core.SearchSuggestionManager();
                    manager.ClearHistory();
                }
            }
        }

        private void searchBox_SuggestionsRequested(SearchBox sender, SearchBoxSuggestionsRequestedEventArgs args)
        {
            var manager = new Windows.ApplicationModel.Search.Core.SearchSuggestionManager();
            manager.ClearHistory();

            var queryText = args.QueryText != null ? args.QueryText.Trim() : null;
            if (string.IsNullOrEmpty(queryText)) return;
            var deferral = args.Request.GetDeferral();

            int MaxNumberOfSuggestions = 5;

            try
            {
                var suggestionCollection = args.Request.SearchSuggestionCollection;

                var querySuggestions = Data.GetSearchSuggestions(queryText);
                if (querySuggestions != null && querySuggestions.Count > 0)
                {
                    var querySuggestionCount = 0;
                    foreach (string suggestion in querySuggestions)
                    {
                        querySuggestionCount++;

                        suggestionCollection.AppendQuerySuggestion(suggestion);

                        if (querySuggestionCount >= MaxNumberOfSuggestions)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            deferral.Complete();
        }

        #endregion

        private async void lbVest_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbVesti.SelectedIndex != -1)
            {
                Vest v = lbVesti.SelectedItem as Vest;
                await Launcher.LaunchUriAsync(new Uri(v.Url));
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            lbVesti.SelectedIndex = -1;
            string kategorija = ((RadioButton)sender).Content.ToString();
            Data.prilagodi(kategorija);
            lbVesti.ItemsSource = Data.Vesti1;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ring.IsActive = true;
            ringtext.Visibility = Visibility.Visible;
            page.IsEnabled = false;
            ((Button)sender).IsEnabled = false;
            await Data.update();
            ((Button)sender).IsEnabled = true;
            ringtext.Visibility = Visibility.Collapsed;
            ring.IsActive = false;
            page.IsEnabled = true;
        }

        private async void AppBarButton1_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog m = new MessageDialog("FONIS");
            await m.ShowAsync();
        }
    }
}
