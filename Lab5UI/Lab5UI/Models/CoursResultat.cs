using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5UI.Models
{
    internal class CoursResultat
    {
        [JsonProperty(PropertyName = "cours")]
        public Cours? Cours { get; set; }

        [JsonProperty(PropertyName = "resultat")]
        public string? Resultat { get; set; }

        public CoursResultat(Cours cours, string resultat)
        {
            Cours = cours;
            Resultat = resultat;
        }
    }
}
