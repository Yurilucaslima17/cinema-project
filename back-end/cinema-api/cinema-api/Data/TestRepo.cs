using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public class TestRepo : IFilmRepo
    {
        public Film GetFilmById(int Id)
        {
            return new Film { Id = 0, Description = "teste", Duration = "22:15", Image = "null", Title = "teste" };
        }

        public IEnumerable<Film> GetAllFilms()
        {
            var films = new List<Film>
            {
                new Film { Id = 0, Description = "teste", Duration = "22:15", Image = "null", Title = "teste" },
                new Film { Id = 1, Description = "teste1", Duration = "22:20", Image = "null", Title = "teste1" },
                new Film { Id = 2, Description = "teste2", Duration = "22:30", Image = "null", Title = "teste2" }
            };

            return films;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateFilm(Film film)
        {
            throw new NotImplementedException();
        }

        public void UpdateFilm(Film film)
        {
            throw new NotImplementedException();
        }
    }
}
