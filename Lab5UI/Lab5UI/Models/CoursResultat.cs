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
        [JsonProperty(PropertyName = "sigleCours")]
        public Cours? Cours { get; set; }

        public string? Resultat { get; set; }

        public CoursResultat(Cours cours, string resultat)
        {
            Cours = cours;
            Resultat = resultat;
        }
    }
}
