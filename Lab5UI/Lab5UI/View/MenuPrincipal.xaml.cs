using Lab5UI.View;
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

namespace Lab5UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VueListeCoursBulletins vueListeCoursBulletins;
        private VueAjoutModifSupprCours vueAjoutModifSupprCours;
        private VueListeEtudiants vueListeEtudiants;
        private VueAjoutModifEtudiant vueAjoutModifEtudiant;
        public MainWindow()
        {
            InitializeComponent();

            vueListeCoursBulletins = new VueListeCoursBulletins();
            vueAjoutModifSupprCours = new VueAjoutModifSupprCours();
            vueListeEtudiants = new VueListeEtudiants();
            vueAjoutModifEtudiant = new VueAjoutModifEtudiant();
        }

        /// <summary>
        /// Validation de la clé d'API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validation_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Affichage de la page "Afficher une liste de cours"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListCoursBulletins_Click(object sender, RoutedEventArgs e)
        {
            frameCentral.Navigate(vueListeCoursBulletins);

        }
        /// <summary>
        /// Affichage de la page "Modification dans un cours"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjoutModifSupprDansCours_Click(object sender, RoutedEventArgs e)
        {
            frameCentral.Navigate(vueAjoutModifSupprCours);

        }

        /// <summary>
        /// Affichage de la page "Afficher une lsite d'étudiants"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listEtudiants_Click(object sender, RoutedEventArgs e)
        {
            frameCentral.Navigate(vueListeEtudiants);

        }
        /// <summary>
        /// Affichage de la page "Ajout\Modification d'un étudiant"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjoutModifEtudiant_Click(object sender, RoutedEventArgs e)
        {
            frameCentral.Navigate(vueAjoutModifEtudiant);

        }
    }
}
