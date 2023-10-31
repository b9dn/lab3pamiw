using P06.Shared;
using P06.Shared.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Shared.Services.FilmService
{
    public interface IFilmService
    {
        Task<ServiceResponse<List<Film>>> ReadFilmAsync();
        Task<ServiceResponse<List<Film>>> CreateFilmAsync(Film film);
        Task<ServiceResponse<List<Film>>> DeleteFilmAsync(int id);
        Task<ServiceResponse<List<Film>>> UpdateFilmAsync(int id, Film film);

    }
}
