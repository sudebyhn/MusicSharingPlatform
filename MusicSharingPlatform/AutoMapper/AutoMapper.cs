using AutoMapper;
using MusicSharingPlatform.DTO;
using MusicSharingPlatform.Models;
using System.Runtime.CompilerServices;

namespace MusicSharingPlatform.AutoMapper
{
    public sealed class AutoMapper : Profile
    {
        public AutoMapper() {//song databse verisi


            CreateMap<CreateSongRequestDto, Song>();
            CreateMap<UpdateSongRequestDto, Song>();
            CreateMap<Song, GetSearchResponseDto>();
            CreateMap<User,GetSearchResponseDto>();
            CreateMap<SearchRequestDto, User>();
            CreateMap<SearchRequestDto, Song>();
            CreateMap<SearchUserRequestDto, User>();
            CreateMap<User,SearchUserResponseDto>();

        }



    }
}
