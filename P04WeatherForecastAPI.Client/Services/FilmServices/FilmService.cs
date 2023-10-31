using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Configuration;
using P06.Shared;
using P06.Shared.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using P06.Shared.Films;
using P06.Shared.Services.FilmService;

namespace P04WeatherForecastAPI.Client.Services.FilmServices
{
    internal class FilmService : IFilmService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public FilmService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient= httpClient;
            _appSettings= appSettings.Value;
        }

        public async Task<ServiceResponse<List<Film>>> CreateFilmAsync(Film film)
        {
            JsonContent content = JsonContent.Create(film);
            var response = await _httpClient.PostAsync(_appSettings.BaseFilmEndpoint.AddFilmAsync, content);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Film>>>(json);
            return result;
        }


        public async Task<ServiceResponse<List<Film>>> DeleteFilmAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_appSettings.BaseFilmEndpoint.DeleteFilmAsync + "/" + id.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Film>>>(json);
            return result;
        }

        public async Task<ServiceResponse<List<Film>>> ReadFilmAsync()
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseFilmEndpoint.GetFilmAsync);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Film>>>(json);
            return result;
        }

        public async Task<ServiceResponse<List<Film>>> UpdateFilmAsync(int id, Film film)
        {
            JsonContent content = JsonContent.Create(film);
            var response = await _httpClient.PutAsync(_appSettings.BaseFilmEndpoint.UpdateFilmAsync + "/" + id.ToString(), content);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Film>>>(json);
            return result;
        }
    }
}
