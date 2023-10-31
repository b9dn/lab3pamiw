using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P06.Shared.Films;

namespace P07Film.DataSeeder
{
    public class FilmSeeder
    {
        public static List<Film> GenerateFilmData()
        {
            int filmId = 1;
            var filmFaker = new Faker<Film>()
                .RuleFor(x => x.Title, x => x.Lorem.Word())
                .RuleFor(x => x.Director, x => x.Name.FullName())
                .RuleFor(x => x.Id, x => filmId++);

            return filmFaker.Generate(11).ToList();

        }
    }
}
