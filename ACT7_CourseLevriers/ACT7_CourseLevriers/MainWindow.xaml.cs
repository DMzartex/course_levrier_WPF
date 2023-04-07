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
using System.Diagnostics;
using System.Windows.Threading;




namespace ACT7_CourseLevriers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // tableau des chiens participant à la course
        Chien[] chienPlateau = new Chien[4];
        // tableau des images de chiens sur le plateau
        Image[] plateauImageChien = new Image[4];
        // tableau des joueurs participant à la course
        User[] Players = new User[3];
        // TextBlock contenant les informations pour les radioButton
        TextBlock[] txtBinfoPlayer = new TextBlock[3];
        // TextBlock pour l'affichage du nom du joueur selectionné
        TextBlock txtBNameUser = new TextBlock();
        // numéro du joueur séléctionné
        int numberPlayerSelect;
        // Textbox pour la mise 
        TextBox txtMise = new TextBox();
        // TextBlock du numéro du chien du pari
        TextBox txtNmbrChien = new TextBox();
        // Tableau des paris sur la course
        Pari[] parisEnJeu = new Pari[3];
        // Tableau des informations sur le placement des paris
        TextBlock[] infosPlacementParis = new TextBlock[3];

        public MainWindow()
        {
            InitializeComponent();
            CreatePlayer();
            setupPlateau();
        }

        public void CreatePlayer()
        {
            for(int p = 0; p < Players.Length; p++)
            {
                Players[p] = new User("Player_"+ p.ToString(),500);
            }
        }

        public void setupPlateau()
        {
            // Création d'un bitmapImage
            BitmapImage imagePlateau = new BitmapImage();
            imagePlateau.BeginInit();
            imagePlateau.UriSource = new Uri("C:\\Users\\Doria\\Desktop\\Cours\\Programmation\\Programmation_6TI\\WPF\\course_levrier_WPF\\ACT7_CourseLevriers\\ACT7_CourseLevriers\\racetrack.png", UriKind.Relative);
            imagePlateau.EndInit();

            // création d'une image de fond
            ImageBrush brushFond = new ImageBrush(imagePlateau);

            // Création du canvas
            Canvas canvasPrincipal = new Canvas();
            canvasPrincipal.Background = brushFond;

            int positionLeft = 60;
            int positionTop = 20;

            for(int i = 0; i < 4; i++)
            {
                if(i > 0)
                {
                    positionTop = positionTop + 90;
                }
                chienPlateau[i] = new Chien(i,positionTop,positionLeft);
                BitmapImage imageChien = new BitmapImage();
                imageChien.BeginInit();
                imageChien.UriSource = new Uri("C:\\Users\\Doria\\Desktop\\Cours\\Programmation\\Programmation_6TI\\WPF\\course_levrier_WPF\\ACT7_CourseLevriers\\ACT7_CourseLevriers\\dog.png", UriKind.RelativeOrAbsolute);
                imageChien.EndInit();
                plateauImageChien[i] = new Image();
                plateauImageChien[i].Source = imageChien;
                plateauImageChien[i].Stretch = System.Windows.Media.Stretch.None;
                Canvas.SetLeft(plateauImageChien[i], chienPlateau[i].PositionLeft);
                Canvas.SetTop(plateauImageChien[i], chienPlateau[i].PositionTop);
                canvasPrincipal.Children.Add(plateauImageChien[i]);
            }


            // Positionnement et ajout du canvas dans la grid
            Grid.SetRow(canvasPrincipal, 0);
            grdMain.Children.Add(canvasPrincipal);

            // création de la grid pour les boutons du jeu
            Grid gridJeu = new Grid();
            gridJeu.Name = "gridJeu";

            // division en colonne et en ligne de la gridJeu
            ColumnDefinition[] columnGridjeu = new ColumnDefinition[2];
            RowDefinition[] rowGridJeu = new RowDefinition[2];
            for(int i = 0; i < columnGridjeu.Length; i++)
            {
                columnGridjeu[i] = new ColumnDefinition();
                rowGridJeu[i] = new RowDefinition();
                gridJeu.ColumnDefinitions.Add(columnGridjeu[i]);
                gridJeu.RowDefinitions.Add(rowGridJeu[i]);
            }

            // ajout de la gridJeu dans la grdMain
            Grid.SetRow(gridJeu, 1);
            grdMain.Children.Add(gridJeu);  

            // création du groupBox
            GroupBox grBJeu = new GroupBox();
            grBJeu.Header = "Salle des paris";

            // Positionnement du groupBox dans la gridJeu
            Grid.SetColumn(grBJeu, 0);
            Grid.SetRow(grBJeu, 0);  
            Grid.SetColumnSpan(grBJeu, 2);
            Grid.SetRowSpan(grBJeu, 2);
            gridJeu.Children.Add(grBJeu);

            // création du stackPanel pour les boutons radios
            StackPanel stackSelectPlayer = new StackPanel();
            stackSelectPlayer.Orientation = Orientation.Vertical;
            stackSelectPlayer.Margin = new Thickness(10,20,0,0);

            TextBlock txtBInfoMise = new TextBlock();
            txtBInfoMise.Text = "Pari minimum : 5 écus";
            txtBInfoMise.FontWeight= FontWeights.Bold;
            txtBInfoMise.FontSize = 24;
            txtBInfoMise.Margin = new Thickness(0, 0, 0, 10);

            stackSelectPlayer.Children.Add(txtBInfoMise);
            
            RadioButton[] radioButtonPlayer = new RadioButton[3];
            
            for(int i = 0; i < 3; i++)
            {
                radioButtonPlayer[i] = new RadioButton();
                radioButtonPlayer[i].Name = "rB_"+i.ToString();
                radioButtonPlayer[i].Checked += new RoutedEventHandler(namePlayer_Check);
                txtBinfoPlayer[i] = new TextBlock();
                txtBinfoPlayer[i].Text = Players[i].Name + " possède " + Players[i].Monnaie;
                txtBinfoPlayer[i].FontSize = 20;
                radioButtonPlayer[i].Content = txtBinfoPlayer[i];
                stackSelectPlayer.Children.Add(radioButtonPlayer[i]);
            }

            Grid.SetColumn(stackSelectPlayer, 0);
            Grid.SetRow(stackSelectPlayer, 0);
            gridJeu.Children.Add(stackSelectPlayer);

            StackPanel stackInfoPari = new StackPanel();
            stackInfoPari.Orientation = Orientation.Vertical;
            stackInfoPari.Margin = new Thickness(10, 20, 0, 0);

            TextBlock txtBParis = new TextBlock();
            txtBParis.Text = "Paris";
            txtBParis.FontSize = 24;
            txtBParis.FontWeight= FontWeights.Bold;
            txtBParis.Margin = new Thickness(0, 0, 0, 10);

            stackInfoPari.Children.Add(txtBParis);


            for(int i = 0; i < infosPlacementParis.Length; i++)
            {
                infosPlacementParis[i] = new TextBlock();
                infosPlacementParis[i].FontSize = 20;
                stackInfoPari.Children.Add(infosPlacementParis[i]);
            }

            Grid.SetColumn(stackInfoPari, 1);
            Grid.SetRow(stackInfoPari, 0);
            gridJeu.Children.Add(stackInfoPari);

            StackPanel stackStartPari = new StackPanel();
            stackStartPari.Orientation= Orientation.Horizontal;
            stackStartPari.Margin = new Thickness(10, 20, 0, 0);

            
            txtBNameUser.FontWeight= FontWeights.Bold;
            txtBNameUser.FontSize = 20;
            txtBNameUser.Margin = new Thickness(10,0,0,0);

            Button startParis = new Button();
            startParis.Content = "Parie";
            startParis.FontSize = 20;
            startParis.Width = 70;
            startParis.Height = 30;
            startParis.VerticalAlignment = VerticalAlignment.Top;
            startParis.Margin = new Thickness(20, 0, 0, 0);
            startParis.Click += StartParis_Click;

            
            txtMise.VerticalAlignment= VerticalAlignment.Top;
            txtMise.Height= 30;
            txtMise.Width= 50;
            txtMise.FontSize= 20;
            txtMise.Margin = new Thickness(20,0,0,0);

            TextBlock txtBTextmiseChien = new TextBlock();
            txtBTextmiseChien.Text = "écus sur le chien numéro";
            txtBTextmiseChien.FontSize= 20;
            txtBTextmiseChien.FontWeight= FontWeights.Bold;
            txtBTextmiseChien.Margin = new Thickness(20, 0, 0, 0);

            txtNmbrChien.VerticalAlignment= VerticalAlignment.Top;
            txtNmbrChien.Margin = new Thickness(20,0,0,0);
            txtNmbrChien.Height= 30;
            txtNmbrChien.Width= 50;
            txtNmbrChien.FontSize= 20;
          
            Button startRace = new Button();
            startRace.Content = "LANCER LA COURSE !";
            startRace.FontSize = 20;
            startRace.Margin = new Thickness(20,0,0,0);
            startRace.VerticalAlignment= VerticalAlignment.Top;
            startRace.Width = 200;
            startRace.Height= 30;
            startRace.Name = "btnPlay";
            startRace.Click += new RoutedEventHandler(BtnPlay_click);
            stackStartPari.Children.Add(txtBNameUser);
            stackStartPari.Children.Add(startParis);
            stackStartPari.Children.Add(txtMise);
            stackStartPari.Children.Add(txtBTextmiseChien);
            stackStartPari.Children.Add(txtNmbrChien);
            stackStartPari.Children.Add(startRace);

            Grid.SetColumnSpan(stackStartPari, 2);
            Grid.SetRow(stackStartPari, 1);
            gridJeu.Children.Add(stackStartPari);

          
            Button btnReset = new Button();
            btnReset.Content= "RESET";
            btnReset.FontSize = 20;
            btnReset.Height= 40;
            btnReset.Margin = new Thickness(0,20,0,0);

            Grid.SetColumnSpan(btnReset,2);
            Grid.SetRow(btnReset, 1);

            gridJeu.Children.Add(btnReset);


        }

      
        private void BtnPlay_click(object sender, RoutedEventArgs e)
        {
            
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Start();
            timer.Interval = 1000; // une seconde
            timer.Elapsed += (sender, args) =>
            {
                // Modifier la position de l'image
                Dispatcher.Invoke(() =>
                {
                    for(int i = 0; i < plateauImageChien.Length; i++)
                    {
                        Random random = new Random();
                        // Vitesse du chien
                        int vitesseChien = random.Next(3,5) * 10;
                        double currentLeft = Canvas.GetLeft(plateauImageChien[i]);
                        //Changer la position de l'image
                        Canvas.SetLeft(plateauImageChien[i], currentLeft + vitesseChien);
                        // Changer la position du chien
                        chienPlateau[i].PositionLeft += vitesseChien;
                        for (int y = 0; y < chienPlateau.Length; y++)
                        {
                            // Verifier si le chien passe la ligne d'arrivé
                            if (chienPlateau[y].PositionLeft >= 690)
                            {
                                timer.Stop();
                            }
                        }
                    }
                });
            };
           
        }

        private void namePlayer_Check(object sender, EventArgs e)
        {
            string nameRB = ((RadioButton)(sender)).Name;
            string[] tabNumRB = new string[2];
            tabNumRB = nameRB.Split("_");
            txtBNameUser.Text = Players[int.Parse(tabNumRB[1])].Name;
            numberPlayerSelect = int.Parse(tabNumRB[1]);
        }

        private void StartParis_Click(object sender, RoutedEventArgs e)
        {
            if (txtBNameUser.Text != "")
            {
                if (Int32.TryParse(txtMise.Text, out int sommeMise))
                {
                    if (Players[numberPlayerSelect].Monnaie > sommeMise)
                    {
                        for (int p = 0; p < chienPlateau.Length; p++)
                        {
                            if (chienPlateau[p].Number == int.Parse(txtNmbrChien.Text))
                            {
                                parisEnJeu[numberPlayerSelect] = new Pari(sommeMise, Players[numberPlayerSelect].Name, chienPlateau[p].Number);
                                infosPlacementParis[numberPlayerSelect].Text = Players[numberPlayerSelect].Name + " à parier sur le chien " + txtNmbrChien;
                            }
                        }
                    }
                }
            }
        }
    }
}
