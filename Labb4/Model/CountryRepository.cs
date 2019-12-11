using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Labb4.ViewModel;
using Newtonsoft.Json;

namespace Labb4.Model
{
    public class CountryRepository
    {
        public List<Country> Countries { get; set; }

        public List<Country> GetCountries()
        {
            GetJsonData();
            return Countries;
        }
    

        public void GetJsonData()
        {
        var assembly = typeof(MainViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{"rawData.json"}");
            using (var reader = new StreamReader(stream))
            {
                //Converting JSON Array Objects into generic list  
                var JsonData = JsonConvert.DeserializeObject<CountryRepository>(reader.ReadToEnd());
                Debug.WriteLine("Calling Method GetJsonData");
                Countries = JsonData.Countries;
            }
        }
    }
}

  