using CommunityToolkit.Mvvm.ComponentModel;
using Lab5UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab5UI.Models;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace Lab5UI.ViewModel
{
    internal class VMListeEtudiants : ObservableObject
    {
        private String dateDiplome;

        public String DateDiplome
        {
            get { return dateDiplome;}
            set
            {
                dateDiplome = value;
                OnPropertyChanged(nameof(DateDiplome));
            }
        }

        private List<Etudiant> _lesEtudiants;
        public List<Etudiant> LesEtudiants
        {
            get { return _lesEtudiants; }
            set
            {
                _lesEtudiants = value;
                OnPropertyChanged(nameof(LesEtudiants));
            }
        }
        public VMListeEtudiants()
        {
            _lesEtudiants = new List<Etudiant>() { };
            AfficherEtudiantsDiplomes = new RelayCommand(AfficherEtudiantsDiplomes_Execute);
        }

        public ICommand AfficherEtudiantsDiplomes { get; set; }
        private async void AfficherEtudiantsDiplomes_Execute( )
        {
            List<Etudiant> listEtudiantsProcessor = await EtudiantProcessor.GetListEtudiantsSelonDateDiplome(DateDiplome);

            LesEtudiants.Clear();   //On la vide d'abord avant de possiblement la remplir pour l'afficher !
            if (listEtudiantsProcessor[0].etu_code_permanent == "\"Le format de la date n'est pas bon.\"" ||
                listEtudiantsProcessor[0].etu_code_permanent == "\"Il n'y a pas de finissants pour cette année.\"" ||
                listEtudiantsProcessor[0].etu_code_permanent == "Veuillez entrer la date de diplome!" ||
                listEtudiantsProcessor[0].etu_code_permanent == "Aucune connexion n’a pu être établie")
            {
                MessageBoxResult result = MessageBox.Show(listEtudiantsProcessor[0].etu_code_permanent, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                LesEtudiants = listEtudiantsProcessor;
        }
    }
}
