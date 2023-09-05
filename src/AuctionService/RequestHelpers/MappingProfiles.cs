using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(x => x.Item, o => o.MapFrom(s => s));
        CreateMap<CreateAuctionDto, Item>();

        //create a mapper to connect to exchange bus as a publisher
        CreateMap<AuctionDto, AuctionCreated>();

        //MassTransit Update Function for message bus
        CreateMap<Auction, AuctionUpdated>().IncludeMembers(a => a.Item);
        CreateMap<Item, AuctionUpdated>();
    }
}