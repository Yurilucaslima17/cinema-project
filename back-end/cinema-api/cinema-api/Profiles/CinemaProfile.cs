using AutoMapper;
using cinema_api.Dtos;
using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Film, FilmReadDto>();
            CreateMap<FilmCreateDto, Film>();
            CreateMap<FilmUpdateDto, Film>();

            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<Section, SectionReadDto>();
            CreateMap<SectionCreateDto, Section>();
            CreateMap<SectionUpdateDto, Section>();

            CreateMap<Room, UserReadDto>();

        }
    }
}
