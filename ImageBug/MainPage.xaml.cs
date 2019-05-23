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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ImageBug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainPage_Loaded;

            var source =  new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                source.Add("https://images.unsplash.com/photo-1558525231-069834d4c006?ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80");
            }

            xamlGridView.ItemsSource = source;
        }


        private GridViewItem _currentItem;

        private void XamlGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Layer1.Visibility = Visibility.Visible;

            var item = xamlGridView.ContainerFromItem(e.ClickedItem);
            _currentItem = item as GridViewItem;
            _currentItem.Visibility = Visibility.Collapsed;

            xamlGridView.Visibility = Visibility.Collapsed;
        }

        private void Goback_Item(object sender, RoutedEventArgs e)
        {
            Layer1.Visibility = Visibility.Collapsed;

            if (_currentItem != null)
            {
                _currentItem.Visibility = Visibility.Visible;
            }

            xamlGridView.Visibility = Visibility.Visible;
        }
    }
}
