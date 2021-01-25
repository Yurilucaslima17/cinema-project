using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public interface IFilmRepo
    {
        bool SaveChanges();
        IEnumerable<Film> GetAllFilms();
        Film GetFilmById(int Id);
        Film GetFilmByName(string title);
        void CreateFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(Film film);
    }
}
