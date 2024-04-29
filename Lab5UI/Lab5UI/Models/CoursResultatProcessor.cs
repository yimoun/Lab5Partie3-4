using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab5UI.Models
{
    internal class CoursResultatProcessor
    {
        private static List<CoursResultat> _lesCoursResultat = new List<CoursResultat> { };

        private static async Task<List<CoursResultat>> LoadListBulletins(string codePermanent)
        {
            try
            { 
                string url = "Etudiant/GetBulletin?codePermanent=" + codePermanent;
                using HttpResponseMessage test = await APIHelper.APIClient.GetAsync(url);
                {
                    if (codePermanent == null) //statut 404
                    {
                        string json = "Veuillez saisir le code permanent";
                        _lesCoursResultat.Clear();
                        _lesCoursResultat.Add(new CoursResultat(new Cours(json, json, 0, "pas affiché!"), "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCoursResultat;
                    }
                    if (test.StatusCode == System.Net.HttpStatusCode.NotFound) //statut 404
                    {
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCoursResultat.Clear();
                        _lesCoursResultat.Add(new CoursResultat(new Cours(json, json, 0, "pas affiché!"), "pas affiché!")); //Juste pour savoir à quoi m'attendre;

                        return _lesCoursResultat;
                    }
                    else  //statut 200
                    {
                        //Il faut gerer le cas où: "L'étudiant n'a aucun cours dans la session actuel."
                        string json = await test.Content.ReadAsStringAsync();
                        _lesCoursResultat.Clear();
                        _lesCoursResultat = JsonConvert.DeserializeObject<List<CoursResultat>>(json);

                        return _lesCoursResultat;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message; //statut 500
                _lesCoursResultat.Clear();
                _lesCoursResultat.Add(new CoursResultat(new Cours(message, message, 0, "pas affiché!"), "pas affiché!")); //Juste pour savoir à quoi m'attendre;


                return _lesCoursResultat;
            }
        }

        public static async Task<List<CoursResultat>> GetListBulletins(string codePermanent)
        {
            return await LoadListBulletins(codePermanent);
        }
    }
}
