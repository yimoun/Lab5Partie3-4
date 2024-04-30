
﻿using CommunityToolkit.Mvvm.ComponentModel;
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

        private List<Cours> lesCours = new List<Cours>();

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
            List<Cours> ListCoursProcessor = await CoursProcessor.GetListCoursActuel(CodePermanent);

            if (ListCoursProcessor[0].SigleCours == "\"L'étudiant n'existe pas.\"" ||
                ListCoursProcessor[0].SigleCours == "Veuillez saisir le code permanent" ||
                 ListCoursProcessor[0].SigleCours.StartsWith("Aucune connexion n’a pu être établie"))
            {
                //MessageBox messageBox = null;
                MessageBoxResult result = MessageBox.Show(ListCoursProcessor[0].SigleCours, "Erreur",
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
            List<Cours> ListCoursProcessor = await CoursProcessor.GetListCoursEnseignant(IdProf);

            if (ListCoursProcessor[0].SigleCours == "\"L'enseignant n'existe pas.\"" ||
                ListCoursProcessor[0].SigleCours == "Veuillez saisir l'id du prof" ||
                 ListCoursProcessor[0].SigleCours.StartsWith("Aucune connexion n’a pu être établie"))
            {
                //MessageBox messageBox = null;
                MessageBoxResult result = MessageBox.Show(ListCoursProcessor[0].SigleCours, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                LesCours = ListCoursProcessor;
            }
        }
        public ICommand AfficherHistorique { get; }
        private async void AfficherHistorique_Execute()
        {
            List<Cours> ListCoursProcessor = await CoursProcessor.GetHistoriqueCours(CodePermanent);

            if (ListCoursProcessor[0].SigleCours == "\"L'étudiant n'existe pas.\"" ||
                 ListCoursProcessor[0].SigleCours == "Veuillez saisir le code permanent" ||
                 ListCoursProcessor[0].SigleCours.StartsWith("Aucune connexion n’a pu être établie"))
            {
                //MessageBox messageBox = null;
                MessageBoxResult result = MessageBox.Show(ListCoursProcessor[0].SigleCours, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                LesCours = ListCoursProcessor;
            }
        } 

        public ICommand AfficherBulletins { get; }
        private async void AfficherBulletins_Execute()
        {
            List<CoursResultat> ListBulletins = await CoursResultatProcessor.GetListBulletins(CodePermanent);

            if (ListBulletins[0].Cours.SigleCours == "\"L'étudiant n'existe pas.\"" ||
                 ListBulletins[0].Cours.SigleCours == "Veuillez saisir le code permanent" ||
                 ListBulletins[0].Cours.SigleCours.StartsWith("Aucune connexion n’a pu être établie"))
            {
               
                MessageBoxResult result = MessageBox.Show(ListBulletins[0].Cours.SigleCours, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                List<Cours> ListCoursTest = new List<Cours>();

                for(int i = 0; i < ListBulletins.Count(); i++)
                {
                    CoursResultat BulletinTest = ListBulletins[i];  
                    Cours CoursTest = BulletinTest.Cours;

                    //TODO: à demander au prof pourquoi ca fonctionne mtn
                    ListCoursTest.Add(new Cours(CoursTest.SigleCours, CoursTest.TitreCours, CoursTest.DureeCours, BulletinTest.Resultat));
                }

                //TODO: Pourquoi ai-je été obligé d'utiliser une "ListCoursTest" pourque le résultat s'affiche ?
                LesCours = ListCoursTest;
            }
        }

    }
}
