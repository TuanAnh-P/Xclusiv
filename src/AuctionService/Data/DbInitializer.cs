using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app){
        using var scope = app.Services.CreateScope();
        
        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        // Fashion Auction Seed Data
        var auctions = new List<Auction>
        {
            // 1 Nike Air Jordan
            new Auction
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Live,
                ReservePrice = 200,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Item = new Item
                {
                    Brand = "Nike",
                    Name = "Air Jordan 1 Retro High",
                    Category = ItemCategory.Shoes,
                    ShoeType = ShoeType.Sneakers,
                    Color = "Red and Black",
                    Size = SizeType.US11,
                    Condition = ConditionType.Good,
                    Gender = GenderType.Male,
                    Description = "Classic Air Jordan 1 in the iconic Chicago colorway",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2020/04/14/09/43/nike-5041718_960_720.jpg" }
                }
            },
            // 2 Gucci Belt
            new Auction
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Live,
                ReservePrice = 350,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(60),
                Item = new Item
                {
                    Brand = "Gucci",
                    Name = "GG Marmont Belt",
                    Category = ItemCategory.Accessories,
                    AccessoryType = AccessoryType.Belt,
                    Color = "Black",
                    Size = SizeType.Medium,
                    Condition = ConditionType.LikeNew,
                    Gender = GenderType.Unisex,
                    Description = "Authentic Gucci belt with double G buckle",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2017/08/05/00/12/people-2581913_960_720.jpg" }
                }
            },
            // 3 Levi's Jeans
            new Auction
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(4),
                Item = new Item
                {
                    Brand = "Levi's",
                    Name = "501 Original Fit",
                    Category = ItemCategory.Clothing,
                    ClothingType = ClothingType.Jeans,
                    Color = "Dark Blue",
                    Size = SizeType.M,
                    Condition = ConditionType.Good,
                    Gender = GenderType.Male,
                    Description = "Classic straight leg denim jeans",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2017/08/01/11/48/blue-2564660_960_720.jpg" }
                }
            },
            // 4 Ray-Ban Sunglasses
            new Auction
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReserveNotMet,
                ReservePrice = 120,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Item = new Item
                {
                    Brand = "Ray-Ban",
                    Name = "Wayfarer Classic",
                    Category = ItemCategory.Accessories,
                    AccessoryType = AccessoryType.Eyewear,
                    Color = "Black",
                    Size = SizeType.Medium,
                    Condition = ConditionType.Good,
                    Gender = GenderType.Unisex,
                    Description = "Iconic Ray-Ban Wayfarer sunglasses, polarized lenses",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2016/11/29/13/39/glasses-1869984_960_720.jpg" }
                }
            },
            // 5 Adidas Hoodie
            new Auction
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Live,
                ReservePrice = 60,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(30),
                Item = new Item
                {
                    Brand = "Adidas",
                    Name = "Trefoil Hoodie",
                    Category = ItemCategory.Clothing,
                    ClothingType = ClothingType.Hoodie,
                    Color = "Grey",
                    Size = SizeType.L,
                    Condition = ConditionType.Good,
                    Gender = GenderType.Unisex,
                    Description = "Comfortable cotton blend hoodie with iconic Adidas trefoil logo",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2016/11/23/14/37/blur-1853262_960_720.jpg" }
                }
            },
            // 6 Louis Vuitton Bag
            new Auction
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Live,
                ReservePrice = 1500,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(45),
                Item = new Item
                {
                    Brand = "Louis Vuitton",
                    Name = "Neverfull MM",
                    Category = ItemCategory.Accessories,
                    AccessoryType = AccessoryType.Bag,
                    Color = "Brown",
                    Size = SizeType.Medium,
                    Condition = ConditionType.Good,
                    Gender = GenderType.Female,
                    Description = "Classic Louis Vuitton tote bag with monogram canvas",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2019/07/28/08/39/bag-4368369_960_720.jpg" }
                }
            },
            // 7 Christian Louboutin Heels
            new Auction
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Live,
                ReservePrice = 600,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(13),
                Item = new Item
                {
                    Brand = "Christian Louboutin",
                    Name = "So Kate",
                    Category = ItemCategory.Shoes,
                    ShoeType = ShoeType.Heels,
                    Color = "Black",
                    Size = SizeType.US7,
                    Condition = ConditionType.LikeNew,
                    Gender = GenderType.Female,
                    Description = "Iconic red-bottom pointy toe pumps, 120mm heel",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2016/11/19/11/33/footwear-1838767_960_720.jpg" }
                }
            },
            // 8 Rolex Watch
            new Auction
            {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Status = Status.Live,
                ReservePrice = 8000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(19),
                Item = new Item
                {
                    Brand = "Rolex",
                    Name = "Submariner Date",
                    Category = ItemCategory.Accessories,
                    AccessoryType = AccessoryType.Watch,
                    Color = "Silver/Blue",
                    Size = SizeType.Medium,
                    Condition = ConditionType.LikeNew,
                    Gender = GenderType.Male,
                    Description = "Luxury diving watch with blue bezel and date function",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2017/03/20/15/13/wrist-watch-2159785_960_720.jpg" }
                }
            },
            // 9 Supreme T-Shirt
            new Auction
            {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                Status = Status.Live,
                ReservePrice = 100,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(20),
                Item = new Item
                {
                    Brand = "Supreme",
                    Name = "Box Logo Tee",
                    Category = ItemCategory.Clothing,
                    ClothingType = ClothingType.TShirt,
                    Color = "White",
                    Size = SizeType.L,
                    Condition = ConditionType.Good,
                    Gender = GenderType.Unisex,
                    Description = "Classic Supreme box logo t-shirt, limited edition",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2017/01/13/04/28/blank-1976334_960_720.jpg" }
                }
            },
            // 10 Vintage Cowboy Hat
            new Auction
            {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Status = Status.Live,
                ReservePrice = 250,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(48),
                Item = new Item
                {
                    Brand = "Stetson",
                    Name = "Vintage Western Hat",
                    Category = ItemCategory.Accessories,
                    AccessoryType = AccessoryType.Hat,
                    Color = "Brown",
                    Size = SizeType.Large,
                    Condition = ConditionType.Good,
                    Gender = GenderType.Unisex,
                    Description = "Authentic vintage leather cowboy hat from the 1970s",
                    ImageUrls = new List<string> { "https://cdn.pixabay.com/photo/2017/08/25/18/48/cowboy-hat-2681060_960_720.jpg" }
                }
            }
        };

        context.AddRange(auctions);

        context.SaveChanges();
    }
}