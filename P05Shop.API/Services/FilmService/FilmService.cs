using P06.Shared;
using P06.Shared.Services.FilmService;
using P06.Shared.Films;
using P07Film.DataSeeder;

namespace P05Shop.API.Services.FilmService {
    public class FilmService : IFilmService {
        public async Task<ServiceResponse<List<Film>>> CreateFilmAsync(Film film) {
            try {
                List<Film> filmList = FilmSeeder.GenerateFilmData();
                filmList.Add(film);

                var response = new ServiceResponse<List<Film>>() {
                    Data = filmList,
                    Message = "Ok",
                    Success = true
                };

                return response;
            } catch (Exception) {
                return new ServiceResponse<List<Film>>() {
                    Data = null,
                    Message = "Problem with creating new film",
                    Success = false,
                };
            }
        }

        public async Task<ServiceResponse<List<Film>>> ReadFilmAsync() {
            try {
                List<Film> filmList = FilmSeeder.GenerateFilmData();

                var response = new ServiceResponse<List<Film>>() {
                    Data = filmList,
                    Message = "Ok",
                    Success = true
                };

                return response;
            } catch (Exception) {
                return new ServiceResponse<List<Film>>() {
                    Data = null,
                    Message = "Problem with creating new film",
                    Success = false,
                };
            }
        }

        public async Task<ServiceResponse<List<Film>>> DeleteFilmAsync(int id) {
            try {
                List<Film> filmList = FilmSeeder.GenerateFilmData();
                var filmToDelete = filmList.SingleOrDefault(x => x.Id == id);
                if (filmToDelete != null) {
                    filmList.Remove(filmToDelete);
                }
                else {
                    throw new Exception("Zle id");
                }

                var response = new ServiceResponse<List<Film>>() {
                    Data = filmList,
                    Message = "Ok",
                    Success = true
                };

                return response;
            } catch (Exception) {
                return new ServiceResponse<List<Film>>() {
                    Data = null,
                    Message = "Problem with creating new film",
                    Success = false,
                };
            }
        }


        public async Task<ServiceResponse<List<Film>>> UpdateFilmAsync(int id, Film film) {
            try {
                List<Film> filmList = FilmSeeder.GenerateFilmData();
                var filmIndexToUpdate = filmList.FindIndex(x => x.Id == id);
                if (filmIndexToUpdate != -1) {
                    filmList[filmIndexToUpdate] = film;
                }
                else {
                    throw new Exception("Zle id");
                }

                var response = new ServiceResponse<List<Film>>() {
                    Data = filmList,
                    Message = "Ok",
                    Success = true
                };

                return response;
            } catch (Exception) {
                return new ServiceResponse<List<Film>>() {
                    Data = null,
                    Message = "Problem with creating new film",
                    Success = false,
                };
            }
        }
    }
}
