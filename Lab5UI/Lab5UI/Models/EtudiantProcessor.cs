using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab5UI.Models
{
    class EtudiantProcessor
    {
        private static List<Etudiant> _lesEtudiants = new List<Etudiant> { };

        //Les inputs ici sont à revoir !
        private static async Task<List<Etudiant>> LoadListEtudiantsCours(int idCours)
        {
            String url = " https://localhost:7100/Etudiant/GetListEtudiantCours?idCours=" + idCours;
            using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
            {
                if (test.IsSuccessStatusCode)
                {
                    string json = await test.Content.ReadAsStringAsync();
                    _lesEtudiants = JsonConvert.DeserializeObject<List<Etudiant>>(json);

                    return _lesEtudiants;

                }
                else
                {
                    throw new Exception(test.ReasonPhrase);
                }
            }
        }


        public static async Task<List<Etudiant>> GetListEtudiantsCours(int idCours)
        {
            return await LoadListEtudiantsCours(idCours);
        }

        private static async Task<List<Etudiant>> LoadListDiplomes(string dateDiplome)
        {
            String url = "https://localhost:7100/Etudiant/GetEtudiantSelonDateDiplome?DateDiplome=2008-06-15%20" + dateDiplome;
            using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
            {
                if (test.IsSuccessStatusCode)
                {
                    string json = await test.Content.ReadAsStringAsync();
                    _lesEtudiants = JsonConvert.DeserializeObject<List<Etudiant>>(json);

                    return _lesEtudiants;

                }
                else
                {
                    throw new Exception(test.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Etudiant>> GetListDiplomes(string dateDiplome)
        {
            return await LoadListDiplomes(dateDiplome);
        }
    }
}
