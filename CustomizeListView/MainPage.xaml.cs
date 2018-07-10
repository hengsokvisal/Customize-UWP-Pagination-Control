using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace CustomizeListView
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<ImageModel> image = new ObservableCollection<ImageModel>();
        ObservableCollection<ImageModel> Display = new ObservableCollection<ImageModel>();
        int total;
        Double lastPage;
        int pageItem = 2;
        int index = 0;
        int count = 0;
        int limit;
     
      
        public MainPage()
        {
            this.InitializeComponent();
            image = ImageModel.getImage();

            PreparePagina();
            this.DataContext = Display;
         
          
        }


        public void PreparePagina()
        {
            total = image.Count();
            lastPage = (Math.Ceiling((double)image.Count / pageItem)) - 1;

            limit = pageItem;
            for (int i = index; i < total; i++)
            {
                if (limit == 0)
                {
                    break;
                }
                Display.Add(image[i]);
                index++;
                limit--;
               
            }
           
        }

        private void NextItem_Click(object sender, RoutedEventArgs e)
        {
            if (count != lastPage)
            {
                limit = pageItem;
                Display.Clear();
                for (int i = index; i < total; i++)
                {
                    if (limit == 0)
                    {
                        break;
                    }
                    Display.Add(image[i]);
                    limit--;
                    index++;
                }
                count++;
            }
            Debug.WriteLine(index);
        }

        private void BackItem_Click(object sender, RoutedEventArgs e)
        {
            // Check if first page
            if (count != 0)
            {
                // Minus Remain Item at last page
                if (index == image.Count)
                {
                    index += limit;
                }

                limit = pageItem;
                Display.Clear();

                for (int i = index - (pageItem * 2); i < total; i++)
                {
                    if (limit == 0)
                    {
                        break;
                    }
                    Display.Add(image[i]);
                    limit--;
                    index--;
                }

                Debug.WriteLine("zero" + index);
                count--;
            }
        }
    }



    public class ImageModel
    {
        public string Image { get; set; }
        public static ObservableCollection<ImageModel> getImage()
        {
            var image = new ObservableCollection<ImageModel>();
            for(int i=1;i<11;i++)
            {
                image.Add(new ImageModel {  Image = "Assets/" + i + ".jpg"});
            }

            return image;
        }
    }
}
