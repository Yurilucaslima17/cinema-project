using AutoMapper;
using cinema_api.Data;
using cinema_api.Dtos;
using cinema_api.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace cinema_api.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepo _repository;
        private readonly IMapper _mapper;

        public FilmController(IFilmRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FilmReadDto>> GetAllFilms()
        {
            var filmes = _repository.GetAllFilms();

            return Ok(_mapper.Map<IEnumerable<FilmReadDto>>(filmes));
        }

        [HttpGet("{id}", Name ="GetFilmById")]
        public ActionResult<FilmReadDto> GetFilmById(int id)
        {
            var filme = _repository.GetFilmById(id);
            if(filme != null)
            {
                return Ok(_mapper.Map<FilmReadDto>(filme));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<FilmReadDto> CreateFilm(FilmCreateDto filmCreateDto)
        {
            var filmeModel = _mapper.Map<Film>(filmCreateDto);
            if(_repository.GetFilmByName(filmeModel.Title) != null)
            {
                return Forbid("Film Title already exists");
            }
            _repository.CreateFilm(filmeModel);
            _repository.SaveChanges();

            var filmReadDto = _mapper.Map<FilmReadDto>(filmeModel);

            return CreatedAtRoute(nameof(GetFilmById), new { id = filmReadDto.Id }, filmReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFilm(int id, FilmUpdateDto filmUpdateDto)
        {
            var filmModelFromRepo = _repository.GetFilmById(id);
            if(filmModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(filmUpdateDto, filmModelFromRepo);

            _repository.UpdateFilm(filmModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        [HttpGet("{id}/delete")]
        public ActionResult DeleteFilm(int id)
        {

            var film = _repository.GetFilmById(id);
            if(film == null)
            {
                return NotFound();
            }

            _repository.DeleteFilm(film);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
