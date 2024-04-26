using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Lab5UI.Models
{
    class Cours
    {
        [JsonProperty(PropertyName = "sigleCours")]
        public string? SigleCours { get; set; }


        [JsonProperty(PropertyName = "titreCours")]
        public string? TitreCours { get; set; }


        [JsonProperty(PropertyName = "dureeCours")]
        public int DureeCours { get; set; }

        public string? Resultat { get; set; } 

        public Cours(string sigle, string titre, int duree, string resultat)
        {
            SigleCours = sigle;
            TitreCours = titre;
            DureeCours = duree;
            Resultat = resultat ?? "pas affiché!";    
        }
    }
}
