﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainViewModelV4 : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private readonly IAccuWeatherService _accuWeatherService;
        //public ICommand LoadCitiesCommand { get;  }
        private readonly IServiceProvider _serviceProvider;

       

        public MainViewModelV4(IAccuWeatherService accuWeatherService, IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;

                // _serviceProvider= serviceProvider; 
                //LoadCitiesCommand = new RelayCommand(x => LoadCities(x as string));
                _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); // podejście nr 2 


        }

        [ObservableProperty]
        private WeatherViewModel weatherView;


        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }

         
        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key); 
                WeatherView = new WeatherViewModel(_weather);
            }
        } 

        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            // podejście nr 2:
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities) 
                Cities.Add(new CityViewModel(city));
        }

        [RelayCommand]
        public void OpenFilmWindowCreate()
        {
            FilmView filmView = _serviceProvider.GetService<FilmView>();
            FilmViewModel filmViewModel = _serviceProvider.GetService<FilmViewModel>();

            filmView.Show();
            filmViewModel.CreateFilms();
        }

        [RelayCommand]
        public void OpenFilmWindowRead() {
            FilmView filmView = _serviceProvider.GetService<FilmView>();
            FilmViewModel filmViewModel = _serviceProvider.GetService<FilmViewModel>();

            filmView.Show();
            filmViewModel.ReadFilms();
        }

        [RelayCommand]
        public void OpenFilmWindowUpdate() {
            FilmView filmView = _serviceProvider.GetService<FilmView>();
            FilmViewModel filmViewModel = _serviceProvider.GetService<FilmViewModel>();

            filmView.Show();
            filmViewModel.UpdateFilms();
        }

        [RelayCommand]
        public void OpenFilmWindowDelete() {
            FilmView filmView = _serviceProvider.GetService<FilmView>();
            FilmViewModel filmViewModel = _serviceProvider.GetService<FilmViewModel>();

            filmView.Show();
            filmViewModel.DeleteFilms();
        }


        [RelayCommand]
        public void OpenShopWindow()
        {
            ShopProductsView shopProductsView = _serviceProvider.GetService<ShopProductsView>();
            ProductsViewModel productsViewModel = _serviceProvider.GetService<ProductsViewModel>();

            shopProductsView.Show();
            productsViewModel.GetProducts();
        }
    }
}
