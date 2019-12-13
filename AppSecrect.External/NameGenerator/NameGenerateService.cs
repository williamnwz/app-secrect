namespace AppSecrect.External.NameGenerator
{
    using AppSecrect.CrossCutting.Settings;
    using AppSecrect.External.NameGenerator.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    public class NameGenerateService : INameGenerate
    {
        private readonly HttpClient httpClient;
        private readonly AppSettings appSettings;

        public NameGenerateService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
            this.httpClient = HttpClientFactory.Create();
        }
        public async Task<string> Generate(GenderEnum gender, CountryEnum country)
        {
            var response = this.httpClient.GetAsync(appSettings.NameGeneratorUrl);

            string nameGenerated = await response.Result.Content.ReadAsStringAsync();

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(nameGenerated);

            return string.Format("{0} {1}", result.name, result.surname);
        }

        private string BuildUrlByParams(GenderEnum gender, CountryEnum country, string url)
        {
            string genderValue = gender.ToString();

            return string.Format("{0}/gender={1}&region={2}", url, genderValue, "portugal");
            //return string.Format("{0}/gender={1}&region={2}", url, genderValue, "portugal");
        
        }

    }
}
