using System;
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
using System.IO;
using MementoPatternTask.Memento;
using MementoPatternTask.ScreenshotService;
using System.Security.RightsManagement;

namespace MementoPatternTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        class Result
        {
            public Result(Originator originator, CareTaker ct)
            {
                this.originator = originator;
                this.ct = ct;
            }

            public Originator originator { get; set; }
            public CareTaker  ct { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {

          
            var result = SCREEN.CaptureDesktop();
            var imageSource = BitmapConverter.ImageSourceFromBitmap(result);
            screenimg.Source = imageSource;
            DataBase.Database.originator.TakeScreenShot(screenimg.Source);
            DataBase.Database.careTaker.Backup();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var imageSource = DataBase.Database.careTaker.Undo();
            if (imageSource != null)
            {

                screenimg.Source = imageSource;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var imageSource = DataBase.Database.careTaker.Redo();
            if (imageSource != null)
            {


                screenimg.Source = imageSource;

            }
        }


    }
}
