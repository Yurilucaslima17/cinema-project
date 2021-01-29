using AutoMapper;
using cinema_api.Data;
using cinema_api.Dtos;
using cinema_api.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
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

            return Ok(_mapper.Map<IEnumerable<SectionReadDto>>(sections));
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

            if (!_repository.ValidateSection(sectionModel))
            {
                return Forbid("Room already in use on this time");
            }

            _repository.CreateSection(sectionModel);
            _repository.SaveChanges();

            var sectionReadDto = _mapper.Map<SectionReadDto>(sectionModel);

            return CreatedAtRoute(nameof(GetSectionById), new { id = sectionReadDto.Id }, sectionReadDto);
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
        [HttpDelete("{id}")]
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

        [HttpPatch("{id}")]
        public ActionResult PartialSectionUpdate(int id, JsonPatchDocument<SectionUpdateDto> patchDocument)
        {
            var sectionModelFromRepo = _repository.GetSectionById(id);
            if (sectionModelFromRepo == null)
            {
                return NotFound();
            }

            var sectionToPatch = _mapper.Map<SectionUpdateDto>(sectionModelFromRepo);
            patchDocument.ApplyTo(sectionToPatch, ModelState);

            if (!TryValidateModel(sectionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(sectionToPatch, sectionModelFromRepo);

            _repository.UpdateSection(sectionModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
