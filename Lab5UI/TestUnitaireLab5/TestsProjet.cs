using Lab5UI;
using Lab5UI.Models;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace TestUnitaireLab5
{
    public class TestsProjet
    {
        private string codePermanent = "ABCD11111111";

        private readonly ITestOutputHelper output;
        public TestsProjet(ITestOutputHelper output)
        {
            this.output = output;
        }
        /* Exemple de ce qu'il faut faire <---------------
        //private int IdProf = 1;
        //[Fact]
        //public async void TestApiKeyReussi()
        //{
        //    APIHelper.InitializeClient(); 
        //   
        //    string json = "";
        //    List<Cours> LesCoursAttendu;
        //    string _filePath = "CoursEnseignant.json";// fichier avec résultat attendu
        //    List<Cours> LesCours = await CoursProcessor.GetListCoursEnseignant(IdProf);// get le résultat

        //    if (File.Exists(_filePath))
        //    {
        //        using (StreamReader file = new StreamReader(_filePath))
        //        {
        //            string line;
        //            while ((line = file.ReadLine()) != null)
        //            {
        //                json += line; // concaténé les lignes des résultats attendus
        //            }
        //                 LesCoursAttendu = JsonConvert.DeserializeObject<List<Cours>>(json);//Deserialiser le fichier JSON pour la comparaison
        //        }
        //        Assert.Equal(LesCoursAttendu, LesCours); // regarde si les résultats correspondents
        //    }
        //    else Assert.True(false); // si ne peut pas trouver le fichier attendu
        //}*/
        [Fact]
        public void TestApiKeyReussi()
        {

        }
        [Fact]
        public async void TestApiKeyEchoue()
        {
            //APIHelper.InitializeClient();
            //   
            //    string json = "";
            //    List<Cours> LesCoursAttendu;
            //    string _filePath = "CoursEnseignant.json";// fichier avec résultat attendu
            //    List<Cours> LesCours = await CoursProcessor.GetListCoursEnseignant(IdProf);// get le résultat

            //    if (File.Exists(_filePath))
            //    {
            //        using (StreamReader file = new StreamReader(_filePath))
            //        {
            //            string line;
            //            while ((line = file.ReadLine()) != null)
            //            {
            //                json += line; // concaténé les lignes des résultats attendus
            //            }
            //                 LesCoursAttendu = JsonConvert.DeserializeObject<List<Cours>>(json);//Deserialiser le fichier JSON pour la comparaison
            //        }
            //        Assert.Equal(LesCoursAttendu, LesCours); // regarde si les résultats correspondents
            //    }
            //    else Assert.True(false); // si ne peut pas trouver le fichier attendu
        }
        [Fact]
        public async void TestGetCoursEtudiantReussi()
        {
            APIHelper.InitializeClient();

            string json = "";
            List<Cours> LesCoursAttendu;
            string _filePath = "GetCoursEtudiantReussi.json";// fichier avec résultat attendu
            List<Cours> LesCours = await CoursProcessor.GetListCoursActuel(codePermanent);// get le résultat

            if (File.Exists(_filePath))
            {
                using (StreamReader file = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        json += line; // concaténé les lignes des résultats attendus
                        output.WriteLine("Line content: {0}", line);
                    }
                    LesCoursAttendu = JsonConvert.DeserializeObject<List<Cours>>(json);//Deserialiser le fichier JSON pour la comparaison
                    file.Close();
                }
                Assert.Equal(LesCoursAttendu, LesCours); // regarde si les résultats correspondents
            }
            else
            {
                output.WriteLine($"{_filePath}");
                Assert.True(false); // si ne peut pas trouver le fichier attendu
            }
        }
        [Fact]
        public void TestGetCoursEtudiantVide()
        {

        }
        [Fact]
        public void TestGetCoursEtudiantEchoue()
        {

        }
        [Fact]
        public void TestGetHistoriqueCoursEtudiantReussi()
        {

        }
        [Fact]
        public void TestGetHistoriqueCoursEtudiantEchoue()
        {

        }
        [Fact]
        public void TestGetEtudiantsDansCoursReussi()
        {

        }
        [Fact]
        public void TestGetEtudiantsDansCoursVide()
        {

        }
        [Fact]
        public void TestGetEtudiantsDansCoursEchoueSigle()
        {

        }
        [Fact]
        public void TestGetEtudiantsDansCoursEchoueIdSession()
        {

        }
        [Fact]
        public void TestGetCoursEnseignantReussi()
        {

        }
        [Fact]
        public void TestGetCoursEnseignantVide()
        {

        }
        [Fact]
        public void TestGetCoursEnseignantEchoue()
        {

        }
        [Fact]
        public void TestGetBulletinCoursEtudiantReussi()
        {

        }
        [Fact]
        public void TestGetBulletinCoursEtudiantVide()
        {

        }
        [Fact]
        public void TestGetBulletinCoursEtudiantEchoue()
        {

        }
        [Fact]
        public void TestGetFinissantsReussi()
        {

        }
        [Fact]
        public void TestGetFinissantsVide()
        {

        }
        [Fact]
        public void TestGetFinissantEchoue()
        {

        }
        [Fact]
        public void TestPostNouveauCoursReussi()
        {

        }
        [Fact]
        public void TestPostNouveauCoursEchoueSigle()
        {

        }
        [Fact]
        public void TestPostNouveauCoursEchoueTitre()
        {

        }
        [Fact]
        public void TestPostNouveauCoursEchoueDuree()
        {

        }
        [Fact]
        public void TestPostNouveauCoursEchoueIdprof()
        {

        }
        [Fact]
        public void TestPostEtudiantDansCoursReussi()
        {

        }
        [Fact]
        public void TestPostEtudiantDansCoursEchoueSigle()
        {

        }
        [Fact]
        public void TestPostEtudiantDansCoursEchoueIdsession()
        {

        }
        [Fact]
        public void TestPostEtudiantDansCoursEchouecodePermanent()
        {

        }
        [Fact]
        public void TestPutModifierEnseignantCoursReussi()
        {

        }
        [Fact]
        public void TestPutModifierEnseignantCoursEchoueSigle()
        {

        }
        [Fact]
        public void TestPutModifierEnseignantCoursEchoueIdsession()
        {

        }
        [Fact]
        public void TestPutModifierEnseignantCoursEchouecodePermanent()
        {

        }
        [Fact]
        public void TestPutEnleverEtudiantCoursReussi()
        {

        }
        [Fact]
        public void TestPutEnleverEtudiantCoursEchoueSigle()
        {

        }
        [Fact]
        public void TestPutEnleverEtudiantCoursEchoueIdSession()
        {

        }
        [Fact]
        public void TestPutEnleverEtudiantCoursEchouecodePermanent()
        {

        }
    }
}