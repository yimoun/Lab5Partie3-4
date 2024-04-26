using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab5UI.Models
{
    internal static class Lab5Processor
    {
        /* API DOC:
         */

        private static List<Cours> _lesCours = new List<Cours> { };
        private static List<Etudiant> _lesEtudiants = new List<Etudiant> { };

        private static async Task<List<Cours>> LoadListCoursActuel(string codePermanent)
        {
            String url = "https://localhost:7100/Cours/GetListCoursActuelEtudiant?codePermanent=" + codePermanent;
            using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
            {
                if (test.StatusCode == System.Net.HttpStatusCode.InternalServerError)   //statut 500
                {
                    string json = await test.Content.ReadAsStringAsync();
                    _lesCours.Add(new Cours(json, json, 0)); //Juste pour savoir à quoi m'attendre;

                    return _lesCours;

                }
                else if (test.StatusCode == System.Net.HttpStatusCode.NotFound) //statut 404
                {
                    string json = await test.Content.ReadAsStringAsync();
                    _lesCours.Add(new Cours(json, json, 0)); //Juste pour savoir à quoi m'attendre;

                    return _lesCours;
                }
                else  //statut 200
                {
                    //Il faut gerer le cas où: "L'étudiant n'a aucun cours dans la session actuel."
                    string json = await test.Content.ReadAsStringAsync();
                    _lesCours = JsonConvert.DeserializeObject<List<Cours>>(json);

                    return _lesCours;
                }
            }
        }


        public static async Task<List<Cours>> GetListCoursActuel(string codePermanent)
        {
            return await LoadListCoursActuel(codePermanent);
        }


        private static async Task<List<Cours>> LoadHistoriqueCours(string codePermanent)
        {
            String url = "https://localhost:7100/Cours/GetHistoriqueCoursEtudiant?codePermanent=" + codePermanent;
            using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
            {
                if (test.IsSuccessStatusCode)
                {
                    string json = await test.Content.ReadAsStringAsync();
                    _lesCours = JsonConvert.DeserializeObject<List<Cours>>(json);

                    return _lesCours;

                }
                else
                {
                    throw new Exception(test.ReasonPhrase);
                }
            }
        }


        public static async Task<List<Cours>> GetHistoriqueCours(string codePermanent)
        {
            return await LoadHistoriqueCours(codePermanent);
        }


        private static async Task<List<Cours>> LoadListCoursEnseignant(int idProf)
        {
            String url = "https://localhost:7100/Cours/GetListCoursSelonEnseignant?idProf=" + idProf;
            using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
            {
                if (test.IsSuccessStatusCode)
                {
                    string json = await test.Content.ReadAsStringAsync();
                    _lesCours = JsonConvert.DeserializeObject<List<Cours>>(json);

                    return _lesCours;

                }
                else
                {
                    throw new Exception(test.ReasonPhrase);
                }
            }
        }


        public static async Task<List<Cours>> GetListCoursEnseignant(int idProf)
        {
            return await LoadListCoursEnseignant(idProf);
        }


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

        public  static async Task<List<Etudiant>> GetListDiplomes(string dateDiplome)
        {
            return await LoadListDiplomes(dateDiplome);
        }

    }
}
