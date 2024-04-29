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
        /* API DOC:
         */

        private static List<Etudiant> _lesEtudiants = new List<Etudiant> { };


        private static async Task<List<Etudiant>> LoadListEtudiantsSelonDateDiplome(string DateDiplome)
        {
            try
            {
                string url = "Etudiant/GetEtudiantSelonDateDiplome?DateDiplome=" + DateDiplome;
                using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
                {
                    if (DateDiplome == null) //statut 401(format de la date!)
                    {
                        string json = "Veuillez entrer la date de diplome!";
                        _lesEtudiants.Clear();
                        _lesEtudiants.Add(new Etudiant(json, json, json, json, json, json, 0)); //Juste pour savoir à quoi m'attendre;

                        return _lesEtudiants;
                    }
                    else if (test.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                        test.StatusCode == System.Net.HttpStatusCode.NotFound) //statut 404(pas d'étudiants pour cette date)
                    {
                        string json = await test.Content.ReadAsStringAsync();
                        _lesEtudiants.Clear();
                        _lesEtudiants.Add(new Etudiant(json, json, json, json, json, json, 0));

                        return _lesEtudiants;
                    }
                    else  //statut 200
                    {
                        string json = await test.Content.ReadAsStringAsync();
                        _lesEtudiants.Clear();
                        _lesEtudiants = JsonConvert.DeserializeObject<List<Etudiant>>(json);

                        return _lesEtudiants;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message; //statut 500
                _lesEtudiants.Add(new Etudiant(message, message, message, message, message, message, 0)); //Juste pour savoir à quoi m'attendre;

                return _lesEtudiants;
            }


        }


        public static async Task<List<Etudiant>> GetListEtudiantsSelonDateDiplome(string dateDiplome)
        {
            return await LoadListEtudiantsSelonDateDiplome(dateDiplome);
        }

        //private static async Task<List<Etudiant>> LoadListDiplomes(string dateDiplome)
        //{
        //    String url = "https://localhost:7100/Etudiant/GetEtudiantSelonDateDiplome?DateDiplome=2008-06-15%20" + dateDiplome;
        //    using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
        //    {
        //        if (test.IsSuccessStatusCode)
        //        {
        //            string json = await test.Content.ReadAsStringAsync();
        //            _lesEtudiants = JsonConvert.DeserializeObject<List<Etudiant>>(json);

        //            return _lesEtudiants;

        //        }
        //        else
        //        {
        //            throw new Exception(test.ReasonPhrase);
        //        }
        //    }
        //}

        //public static async Task<List<Etudiant>> GetListDiplomes(string dateDiplome)
        //{
        //    return await LoadListDiplomes(dateDiplome);
        //}
    }
}
