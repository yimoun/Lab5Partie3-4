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
using Lab5UI.ViewModel;

namespace Lab5UI.View
{
    /// <summary>
    /// Logique d'interaction pour VueAjoutModifEtudiant.xaml
    /// </summary>
    public partial class VueAjoutModifEtudiant : Page
    {
        public VueAjoutModifEtudiant()
        {
            InitializeComponent();
            this.DataContext = new VMAjoutModifEtudiant();
        }
    }
}
