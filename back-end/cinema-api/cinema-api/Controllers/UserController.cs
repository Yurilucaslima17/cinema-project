using AutoMapper;
using cinema_api.Data;
using cinema_api.Dtos;
using cinema_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly Mapper _mapper;

        public UserController(IUserRepo repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*[HttpGet("{email}")]
        public ActionResult GetUserByEmail(string email)
        {
            if(_repository.GetUserByEmail(email) == null)
            {
                return NotFound();
            }

            return NoContent();
        }*/

        [HttpPost]
        public ActionResult CreateUser(UserCreateDto user)
        {
            var userModel = _mapper.Map<User>(user);

            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            return Ok();
        }

        [HttpPut("{email}")]
        public ActionResult UpdateUser(string email ,UserUpdateDto user)
        {
            var userRepo = _repository.GetUserByEmail(email);
            if(userRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(user, userRepo);

            _repository.UpdateUser(userRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        public ActionResult DeleteUser(string email)
        {
            var user = _repository.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(user);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
