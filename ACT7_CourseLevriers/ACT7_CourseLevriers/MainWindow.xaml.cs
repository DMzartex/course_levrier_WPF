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

namespace ACT7_CourseLevriers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setupPlateau();
        }

        public void setupPlateau()
        {
            // Création d'un bitmapImage
            BitmapImage imagePlateau = new BitmapImage();
            imagePlateau.BeginInit();
            imagePlateau.UriSource = new Uri("C:\\Users\\Doria\\Desktop\\Cours\\Programmation\\Programmation_6TI\\WPF\\ACT7_CourseLevriers\\ACT7_CourseLevriers\\racetrack.png", UriKind.Relative);
            imagePlateau.EndInit();

            // création d'une image de fond
            ImageBrush brushFond = new ImageBrush(imagePlateau);

            // Création du canvas
            Canvas canvasPrincipal = new Canvas();
            canvasPrincipal.Background = brushFond;
            
            // Positionnement et ajout du canvas dans la grid
            Grid.SetRow(canvasPrincipal, 0);
            grdMain.Children.Add(canvasPrincipal);


        }
    }
}
