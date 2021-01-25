using cinema_api.Model;
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
            if(DateTime.Now.AddDays(10) <= section.Date || DateTime.Now > section.Date)
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
            return _context.Sections.ToList().OrderBy(p => p.Date);
        }

        public Section GetSectionById(int Id)
        {
            return _context.Sections.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSection(Section section)
        {
            
        }
    }
}
