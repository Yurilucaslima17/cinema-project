using AutoMapper;
using cinema_api.Data;
using cinema_api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Controllers
{
    [Route("api/salas")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo _repository;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomReadDto>> GetAllRooms()
        {
            var rooms = _repository.GetAllRooms();

            return Ok(_mapper.Map<RoomReadDto>(rooms));
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public ActionResult<RoomReadDto> GetRoomById(int id)
        {
            var room = _repository.GetRoomById(id);
            if (room != null)
            {
                return Ok(_mapper.Map<RoomReadDto>(room));
            }
            return NotFound();
        }

        [HttpGet("{id}/allsections")]
        public ActionResult<SectionReadDto> GetAllSectionsOnRoom(int id)
        {
            var sections = _repository.GetAllSectionsOnRoom(id);
            
            return Ok(_mapper.Map<SectionReadDto>(sections));
        }
    }
}
