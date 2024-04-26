using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab5UI.Models;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Lab5UI.ViewModel
{
    internal class VMListeCoursBulletins : ObservableObject
    {
        private string etu_code_permanent;

        public string CodePermanent
        {
            get { return etu_code_permanent; }
            set
            {
                etu_code_permanent = value;
                OnPropertyChanged(nameof(CodePermanent));
            }
        }

        private int idProf;
        public int IdProf
        {
            get { return idProf; }
            set
            {
                idProf = value;
                OnPropertyChanged(nameof(IdProf));
            }
        }

        private List<Cours> lesCours;

        public List<Cours> LesCours
        {
            get { return lesCours; }
            set
            {
                lesCours = value;
                OnPropertyChanged(nameof(LesCours));
            }
        }

        public VMListeCoursBulletins()
        {
            AfficherCoursEtudiant = new RelayCommand(AfficherCoursEtudiant_Execute);
            AfficherCoursEnseignant = new RelayCommand(AfficherCoursEnseignant_execute);
            AfficherHistorique = new RelayCommand(AfficherHistorique_Execute);
            AfficherBulletins = new RelayCommand(AfficherBulletins_Execute);
        }

        public ICommand AfficherCoursEtudiant { get; }

        private async void AfficherCoursEtudiant_Execute()
        {
            List<Cours> ListCoursProcessor = await Lab5Processor.GetListCoursActuel(CodePermanent);

            if (ListCoursProcessor[0].SigleCours == "\"L'étudiant n'existe pas.\"" ||
                 ListCoursProcessor[0].SigleCours.StartsWith("\"Une erreur s'est produite lors de l'ajout de l'étudiant à un cours\""))
            {
                //MessageBox messageBox = null;
                MessageBoxResult result = MessageBox.Show(ListCoursProcessor[0].SigleCours, "Information",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                LesCours = ListCoursProcessor;
            }
        }
        public ICommand AfficherCoursEnseignant { get; }
        private async void AfficherCoursEnseignant_execute()
        {
            LesCours = await Lab5Processor.GetListCoursEnseignant(IdProf);
        }
        public ICommand AfficherHistorique { get; }
        private async void AfficherHistorique_Execute()
        {
            LesCours = await Lab5Processor.GetHistoriqueCours(CodePermanent);
        } 

        public ICommand AfficherBulletins { get; }
        private async void AfficherBulletins_Execute()
        {
            //LesCours = await Lab5Processor.
        }

    }
}
