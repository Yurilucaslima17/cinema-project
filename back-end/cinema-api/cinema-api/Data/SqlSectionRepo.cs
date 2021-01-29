using cinema_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public class SqlSectionRepo : ISectionRepo
    {
        private readonly CinemaContext _context;

        public SqlSectionRepo(CinemaContext context)
        {
            _context = context;
        }
        public void CreateSection(Section section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            _context.Sections.Add(section);
        }

        public void DeleteSection(Section section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (DateTime.Now.AddDays(10) <= section.Date || DateTime.Now > section.Date)
            {
                _context.Sections.Remove(section);
            }
            else
            {
                throw new ArgumentException("Section cannot be deleted, it will take place soon ");
            }

        }

        public IEnumerable<Section> GetAllSections()
        {
            return _context.Sections.Include(p => p.Film).Include(p=> p.Room).ToList().OrderBy(p => p.Date);
        }

        public Section GetSectionById(int Id)
        {
            return _context.Sections.Include(p => p.Film).Include(p => p.Room)
                .FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSection(Section section)
        {
            
        }

        public bool ValidateSection(Section sectionModel)
        {
            var sections = _context.Sections.ToList();

            foreach (var section in sections)
            {
                if(section.Room == sectionModel.Room)
                {
                    var a = section.Film.Duration.Split(':');
                    var b = sectionModel.Film.Duration.Split(':');

                    var aux1 = (Convert.ToInt32(a[0]) * 60) + Convert.ToInt32(a[1]);
                    var aux2 = (Convert.ToInt32(b[0]) * 60) + Convert.ToInt32(b[1]);
                    if (section.Date.AddMinutes(aux1) >= sectionModel.Date || sectionModel.Date.AddMinutes(aux2) >= section.Date)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
