using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5UI.Models
{
    internal class Etudiant
    {
        [JsonProperty(PropertyName = "etu_code_permanent")]
        public string? etu_code_permanent { get; set; }


        [JsonProperty(PropertyName = "etu_nom")]
        public string? etu_nom { get; set; }


        [JsonProperty(PropertyName = "etu_prenom")]
        public string? etu_prenom { get; set; }


        [JsonProperty(PropertyName = "etu_date_naissance")]
        public string? etu_date_naissance { get; set; }


        [JsonProperty(PropertyName = "etu_date_inscription")]
        public string? etu_date_inscription { get; set; }


        [JsonProperty(PropertyName = "etu_date_diplome")]
        public string? etu_date_diplome { get; set; }


        [JsonProperty(PropertyName = "etu_num_da")]
        public int etu_num_da { get; set; }

        public Etudiant(string? etu_code_permanent, string? etu_nom, string? etu_prenom, string? etu_date_naissance, string? etu_date_inscription, string? etu_date_diplome, int etu_num_da)
        {
            this.etu_code_permanent = etu_code_permanent;
            this.etu_nom = etu_nom;
            this.etu_prenom = etu_prenom;
            this.etu_date_naissance = etu_date_naissance;
            this.etu_date_inscription = etu_date_inscription;
            this.etu_date_diplome = etu_date_diplome;
            this.etu_num_da = etu_num_da;
        }
    }
}
