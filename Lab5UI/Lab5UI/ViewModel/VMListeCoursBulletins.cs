using CommunityToolkit.Mvvm.ComponentModel;
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
            AfficherCours = new RelayCommand(AfficherCours_Execute);

        }

        public ICommand AfficherCours { get; }

        private async void AfficherCours_Execute()
        {
            LesCours = await Lab5Processor.GetListCoursActuel(CodePermanent);
        }

    }
}
