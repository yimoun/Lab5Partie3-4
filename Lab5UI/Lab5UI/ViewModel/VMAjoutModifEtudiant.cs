using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5UI.Models;

namespace Lab5UI.ViewModel 
{
    internal class VMAjoutModifEtudiant : ObservableObject
    {
        private string _sigleCours1;
        public string SigleCours1
        {
            get { return _sigleCours1; }
            set
            {
                _sigleCours1 = value;
                OnPropertyChanged(nameof(SigleCours1));
            }
        }

        private int _idProfCours;
        public int IdProfCours
        {
            get { return _idProfCours;}
            set
            {
                _idProfCours = value;
                OnPropertyChanged(nameof(IdProfCours));
            }
        }

        private int _noGroupe;
        public int NoGroupe
        {
            get { return _noGroupe; }
            set
            {
                _noGroupe = value;
                OnPropertyChanged(nameof(NoGroupe));
            }
        }

       private string _codePermanent1;
       public string CodePermanent1
        {
            get { return _codePermanent1; }
            set
            {
                _codePermanent1 = value;
                OnPropertyChanged(nameof(CodePermanent1));
            }
        }

        private string _resultat;
        public string Resultat
        {
            get { return _resultat; }
            set
            {
                _resultat = value;
                OnPropertyChanged(nameof(Resultat));
            }
        }

        private string _codePermanent2;
        public string CodePermanent2
        {
            get { return _codePermanent2; }
            set
            {
                _codePermanent2 = value;
                OnPropertyChanged(nameof(CodePermanent2));
            }
        }

        private string _sigleCours2;
        public string SigleCours2
        {
            get { return _sigleCours2; }
            set
            {
                _sigleCours2 = value;
                OnPropertyChanged(nameof(SigleCours2));
            }
        }

        private int _idSession;
        public int IdSession
        {
            get { return _idSession; }

            set
            {
                _idSession = value;
                OnPropertyChanged(nameof(IdSession));
            }
        }


        public ICommand AjouterEtudiant { get; }

        public async void AjouterEtudiant_Execute()
        {

        }

        public ICommand ModifierResultat { get; }   

        public async void ModifierResultat_Execute()
        {

        }

        public VMAjoutModifEtudiant()
        {
            AjouterEtudiant = new RelayCommand(AjouterEtudiant_Execute);
            ModifierResultat = new RelayCommand(ModifierResultat_Execute);
        }
    }
}
