using AutoMapper;
using cinema_api.Data;
using cinema_api.Dtos;
using cinema_api.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Controllers
{
    [Route("api/sessoes")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepo _repository;
        private readonly IMapper _mapper;

        public SectionController(ISectionRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SectionReadDto>> GetAllSections()
        {
            var sections = _repository.GetAllSections();

            return Ok(_mapper.Map<SectionReadDto>(sections));
        }

        [HttpGet("{id}", Name = "GetSectionById")]
        public ActionResult<SectionReadDto> GetSectionById(int id)
        {
            var section = _repository.GetSectionById(id);
            if (section != null)
            {
                return Ok(_mapper.Map<SectionReadDto>(section));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<SectionReadDto> CreateSection(SectionCreateDto sectionCreateDto)
        {
            var sectionModel = _mapper.Map<Section>(sectionCreateDto);

            _repository.CreateSection(sectionModel);
            _repository.SaveChanges();

            var filmReadDto = _mapper.Map<SectionReadDto>(sectionModel);

            return CreatedAtRoute(nameof(GetSectionById), new { id = filmReadDto.Id }, filmReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSection(int id, SectionUpdateDto SectionUpdateDto)
        {
            var sectionModelFromRepo = _repository.GetSectionById(id);
            if (sectionModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(SectionUpdateDto, sectionModelFromRepo);

            _repository.UpdateSection(sectionModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        [HttpGet("{id}/delete")]
        public ActionResult DeleteSection(int id)
        {

            var section = _repository.GetSectionById(id);
            if (section == null)
            {
                return NotFound();
            }

            _repository.DeleteSection(section);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
