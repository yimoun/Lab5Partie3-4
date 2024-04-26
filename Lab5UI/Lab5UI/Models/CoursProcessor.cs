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
    static class CoursProcessor
    {
        /* API DOC:
         */

        private static List<Cours> _lesCours = new List<Cours> { };
       

        private static async Task<List<Cours>> LoadListCoursActuel(string codePermanent)
        {
            try
            {
                String url = "Cours/GetListCoursActuelEtudiant?codePermanent=" + codePermanent;
                using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
                {
                    //if (test.StatusCode == System.Net.HttpStatusCode.InternalServerError)   
                    //{
                    //    string json = await test.Content.ReadAsStringAsync();
                    //    _lesCours.Add(new Cours(json, json, 0)); //Juste pour savoir à quoi m'attendre;

                    //    return _lesCours;

                    //}
                   if (test.StatusCode == System.Net.HttpStatusCode.NotFound) //statut 404
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
            catch (Exception ex)
            {
                string message = ex.Message; //statut 500
                _lesCours.Add(new Cours(message, message, 0)); //Juste pour savoir à quoi m'attendre;

                return _lesCours;
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

    }
}
