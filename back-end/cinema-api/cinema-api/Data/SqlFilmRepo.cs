using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public class SqlFilmRepo : IFilmRepo
    {
        private readonly CinemaContext _context;

        public SqlFilmRepo(CinemaContext context)
        {
            _context = context;
        }

        public void CreateFilm(Film film)
        {
            if(film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }

            _context.Films.Add(film);
        }

        public void DeleteFilm(Film film)
        {
            if(_context.Sections.FirstOrDefault(p => p.Film == film) != null)
            {
                throw new ArgumentException("There's a section related to this film");
            }

            _context.Films.Remove(film);
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return _context.Films.ToList();
        }

        public Film GetFilmById(int Id)
        {
            return _context.Films.FirstOrDefault(p => p.Id == Id);
        }

        public Film GetFilmByName(string title)
        {
            return _context.Films.FirstOrDefault(p => p.Title == title);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFilm(Film film)
        {
            
        }
    }
}
