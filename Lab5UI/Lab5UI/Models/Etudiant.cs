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
    }
}
