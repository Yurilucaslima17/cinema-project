using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public interface ISectionRepo
    {
        bool SaveChanges();
        IEnumerable<Section> GetAllSections();
        Section GetSectionById(int Id);
        void CreateSection(Section section);
        void UpdateSection(Section section);
        void DeleteSection(Section section);
        bool ValidateSection(Section sectionModel);
    }
}
