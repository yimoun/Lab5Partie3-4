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

namespace Lab5UI.ViewModel
{
    internal class VMListeEtudiants : ObservableObject
    {
        private DateTime dateDiplome;

        public DateTime DateDiplome
        {
            get { return dateDiplome;}
            set
            {
                dateDiplome = value;
                OnPropertyChanged(nameof(DateDiplome));
            }
        }

        private List<Etudiant> lesEtudiants;
        public List<Etudiant> LesEtudiants
        {
            get { return lesEtudiants; }
            set
            {
                lesEtudiants = value;
                OnPropertyChanged(nameof(LesEtudiants));
            }
        }
        public VMListeEtudiants()
        {
            AfficherEtudiantsDiplomes = new RelayCommand(AfficherEtudiantsDiplomes_Execute);
        }

        public ICommand AfficherEtudiantsDiplomes { get; set; }
        private async void AfficherEtudiantsDiplomes_Execute()
        {
            LesEtudiants = await EtudiantProcessor.GetListDiplomes(DateDiplome.ToString());
        }
    }
}
