using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper;
    public AuctionCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IMapper Mapper { get; }

    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("--> Consuming Auction Created: " + context.Message.Id);
        var item = _mapper.Map<Item>(context.Message);

        // To handle Fault queues example
        if(item.Model == "Foo") throw new ArgumentException("Cannot Sell cars of Model Foo");

        await item.SaveAsync();
    }

}
