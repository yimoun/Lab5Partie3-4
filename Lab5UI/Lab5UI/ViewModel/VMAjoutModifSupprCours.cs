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
    internal class VMAjoutModifSupprCours : ObservableObject
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

        private string? _titre;
        public string Titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                OnPropertyChanged(nameof(Titre));
            }
        }

        private int _duree;
        public int Duree
        {
            get { return _duree; }
            set
            {
                _duree = value;
                OnPropertyChanged(nameof(Duree));
            }
        }

        private int _idProf_0;
        public int IdProf_0
        {
            get { return _idProf_0; }
            set
            {
                _idProf_0 = value;
                OnPropertyChanged(nameof(IdProf_0));
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

        private int _idSessionCoursProf;
        public int IdSessionCoursProf
        {
            get { return _idSessionCoursProf; }
            set
            {
                _idSessionCoursProf = value;
                OnPropertyChanged(nameof(IdSessionCoursProf));
            }
        }

        private int _idProfActuel;
        public int IdProfActuel
        {
            get { return _idProfActuel; }
            set
            {
                _idProfActuel = value;
                OnPropertyChanged(nameof(IdProfActuel));
            }
        }

        private int _idProfNouveau;
        public int IdProfNouveau
        {
            get { return _idProfNouveau; }
            set
            {
                _idProfNouveau = value;
                OnPropertyChanged(nameof(IdProfNouveau));
            }
        }

        private string _codePermanent;
        public string CodePermanent
        {
            get { return _codePermanent; }
            set
            {
                _codePermanent = value;
                OnPropertyChanged(nameof(CodePermanent));
            }
        }

        private string _sigleCours3;
        public string SigleCours3
        {
            get { return _sigleCours3; }
            set
            {
                _sigleCours3 = value;
                OnPropertyChanged(nameof(SigleCours3));
            }
        }

        private int _idSessionCoursEtudiant;
        public int IdSessionCoursEtudiant
        {
            get { return _idSessionCoursEtudiant; }
            set
            {
                _idSessionCoursEtudiant = value;
                OnPropertyChanged(nameof(IdSessionCoursEtudiant));
            }
        }



        public ICommand AjouterCours { get; }

        public async void AjouterCours_Execute()
        {
            string Response = await CoursProcessor.GetResponseAjouterCours(SigleCours1, Titre, Duree, IdProf_0);

            MessageBoxResult result = MessageBox.Show(Response, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);


            if (Response == "Le cours a été ajouté avec succès.")
            {
                 result = MessageBox.Show(Response, "Confirmation",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        public ICommand ModifierEnseignantCours { get; }

        public async void ModifierEnseignantCours_Execute()
        {

        }

        public ICommand SupprimerEtudiant {  get; }

        public async void SupprimerEtudiant_Execute()
        {

        }

        public VMAjoutModifSupprCours()
        {
            AjouterCours = new RelayCommand(AjouterCours_Execute);
            ModifierEnseignantCours = new RelayCommand(ModifierEnseignantCours_Execute);
        }
    }
}
