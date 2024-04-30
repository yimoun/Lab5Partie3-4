using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                    if (codePermanent == null) 
                    {
                        string json = "Veuillez saisir le code permanent";
                        _lesCours.Clear();
                        _lesCours.Add(new Cours(json, json, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCours;
                    }
                    if (test.StatusCode == System.Net.HttpStatusCode.NotFound) //statut 404
                    {
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCours.Clear();
                        _lesCours.Add(new Cours(json, json, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCours;
                    }
                    else  //statut 200
                    {
                        //Il faut gerer le cas où: "L'étudiant n'a aucun cours dans la session actuel."
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCours.Clear();
                        _lesCours = JsonConvert.DeserializeObject<List<Cours>>(json);

                        return _lesCours;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message; //statut 500
                _lesCours.Clear();
                _lesCours.Add(new Cours(message, message, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                return _lesCours;
            }
        }


        public static async Task<List<Cours>> GetListCoursActuel(string codePermanent)
        {
            return await LoadListCoursActuel(codePermanent);
        }


        private static async Task<List<Cours>> LoadHistoriqueCours(string codePermanent)
        {
            try
            {
                String url = "https://localhost:7100/Cours/GetHistoriqueCoursEtudiant?codePermanent=" + codePermanent;
                using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
                {
                    if (codePermanent == null) //statut 404
                    {
                        string json = "Veuillez saisir le code permanent";
                        _lesCours.Clear();
                        _lesCours.Add(new Cours(json, json, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCours;
                    }
                    if (test.StatusCode == System.Net.HttpStatusCode.NotFound)  //statut 404
                    {
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCours.Clear();
                        _lesCours.Add(new Cours(json, json, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCours;

                    }
                    else //statut 200
                    {
                        //Il faut gerer le cas où: "L'étudiant n'a aucun cours dans la session actuel."
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCours.Clear();
                        _lesCours = JsonConvert.DeserializeObject<List<Cours>>(json);

                        return _lesCours;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message; //statut 500
                _lesCours.Clear();
                _lesCours.Add(new Cours(message, message, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                return _lesCours;
            }
        }


        public static async Task<List<Cours>> GetHistoriqueCours(string codePermanent)
        {
            return await LoadHistoriqueCours(codePermanent);
        }


        private static async Task<List<Cours>> LoadListCoursEnseignant(int idProf)
        {
            try
            {
                String url = "https://localhost:7100/Cours/GetListCoursSelonEnseignant?idProf=" + idProf;
                using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
                {
                    if(idProf == 0 )
                    {
                        string json = "Veuillez saisir l'id du prof";
                        _lesCours.Clear();
                        _lesCours.Add(new Cours(json, json, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCours;
                    }
                    if (test.StatusCode == System.Net.HttpStatusCode.NotFound)  //statut 404
                    {
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCours.Clear();
                        _lesCours.Add(new Cours(json, json, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCours;

                    }
                    else //statut 200
                    {
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCours.Clear();
                        _lesCours = JsonConvert.DeserializeObject<List<Cours>>(json);

                        return _lesCours;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message; //statut 500
                _lesCours.Clear();
                _lesCours.Add(new Cours(message, message, 0, "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                return _lesCours;
            }
        }


        public static async Task<List<Cours>> GetListCoursEnseignant(int idProf)
        {
            return await LoadListCoursEnseignant(idProf);
        }

        private static async Task<string> AjouterUnCours(string sigle, string titre, int duree, int idProf)
        {
            try
            {
                string url = "Cours/AjouterUnCours?sigle=" + sigle + "&titre=" + titre + "&duree=" + duree + "&idProf=" + idProf;
                using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
                {
                    HttpStatusCode statutCode = test.StatusCode;

                      string json = await test.Content.ReadAsStringAsync();
                        return json;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message; //statut 500
                return message;
            }

        }

        public static async Task<string> GetResponseAjouterCours(string sigle, string titre, int duree, int idProf)
        {
            return await AjouterUnCours(sigle, titre, duree, idProf);
        }
    }
}
