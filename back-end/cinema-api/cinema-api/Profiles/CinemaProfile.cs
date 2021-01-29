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
            CreateMap<Film, FilmUpdateDto>();

            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();

            CreateMap<Section, SectionReadDto>();
            CreateMap<SectionCreateDto, Section>();
            CreateMap<SectionUpdateDto, Section>();
            CreateMap<Section, SectionUpdateDto>();

            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomUpdateDto, Room>();
            CreateMap<Room, RoomUpdateDto>();
        }
    }
}
