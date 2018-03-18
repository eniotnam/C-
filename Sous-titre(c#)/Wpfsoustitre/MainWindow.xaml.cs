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

namespace Wpfsoustitre
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            film.LoadedBehavior = MediaState.Manual;
            film.Source = new Uri(@"C:\Users\Antoine\Desktop\film\Le Seigneur des anneaux 1\Les.mkv");
            film.Play();
            TextBlock T = this.Textbox;
            Tri tr = new Tri(T);
           
        }
       
    }
}
