using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace TicTacToeGameWebService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(dest =>
                    dest.GameStatus,
                    opt => opt.MapFrom(src => src.GameStatus.GameStatusName)
                )
                .ForMember(dest =>
                    dest.CrossesPlayerName,
                    opt => opt.MapFrom(src => src.CrossesPlayer.Name)
                )
                .ForMember(dest =>
                    dest.NoughtsPlayerName,
                    opt => opt.MapFrom(src => src.NoughtsPlayer.Name)
                )
                .ForMember(dest =>
                    dest.WinnerPlayerName,
                    opt => opt.MapFrom(src => src.WinnerPlayer != null ? src.WinnerPlayer.Name : "No one")
                );

            CreateMap<Point, PointDto>()
                .ForMember(dest =>
                    dest.GameSide,
                    opt => opt.MapFrom(src => src.GameSide.SideName)
                );
        }
    }
}
