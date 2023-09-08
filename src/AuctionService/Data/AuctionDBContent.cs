using AuctionService.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class AuctionDBContext: DbContext{

    public AuctionDBContext(DbContextOptions options): base(options){

    }

    public DbSet<Auction> Auctions {get; set;}

     //To Create an Outbox for MassTransit, adds three tables to database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }

}