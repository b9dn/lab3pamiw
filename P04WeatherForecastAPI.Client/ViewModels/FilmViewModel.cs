using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06.Shared.Services.FilmService;
using P06.Shared.Films;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using P06.Shared.Shop;

namespace P04WeatherForecastAPI.Client.ViewModels {
    public partial class FilmViewModel : ObservableObject {
        private readonly IFilmService _filmService;

        public ObservableCollection<Film> Films { get; set; }

        private int filmToDeleteId;
        private Film filmToCreate;
        private Film filmToUpdate;
        private int filmToUpdateId;

        public FilmViewModel(IFilmService filmService) {
            _filmService = filmService;
            Films = new ObservableCollection<Film>();

            filmToDeleteId = 11;
            filmToCreate = new Film { Id = 12, Director = "Creator", Title = "Created film" };
            filmToUpdate = new Film { Id = 5, Director = "Updatator", Title = "Updated film" };
            filmToUpdateId = 5;
        }

        public async void CreateFilms() {
            var filmsResult = await _filmService.CreateFilmAsync(filmToCreate);
            if (filmsResult.Success) {
                Films.Clear();
                foreach (var f in filmsResult.Data) {
                    Films.Add(f);
                }
            }
        }

        public async void ReadFilms() {
            var filmsResult = await _filmService.ReadFilmAsync();
            if (filmsResult.Success) {
                Films.Clear();
                foreach (var f in filmsResult.Data) {
                    Films.Add(f);
                }
            }
        }

        public async void UpdateFilms() {
            var filmsResult = await _filmService.UpdateFilmAsync(filmToUpdateId, filmToUpdate);
            if (filmsResult.Success) {
                Films.Clear();
                foreach (var f in filmsResult.Data) {
                    Films.Add(f);
                }
            }
        }

        public async void DeleteFilms() {
            var filmsResult = await _filmService.DeleteFilmAsync(filmToDeleteId);
            if (filmsResult.Success) {
                Films.Clear();
                foreach (var f in filmsResult.Data) {
                    Films.Add(f);
                }
            }
        }

    }
}
