using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities;

public enum ItemCategory
{
    Clothing,
    Shoes,
    Accessories
}

public enum ClothingType
{
    TShirt,
    Shirt,
    Hoodie,
    Sweater,
    Jacket,
    Coat,
    Pants,
    Jeans,
    Sweatpants,
    Shorts,
    Dress,
    Skirt,
    Other
}

public enum ShoeType
{
    Sneakers,
    Boots,
    DressShoes,
    Heels,
    Flats,
    Sandals,
    Slippers,
    Other
}

public enum AccessoryType
{
    Belt,
    Hat,
    Scarf,
    Gloves,
    Jewelry,
    Watch,
    Bag,
    Wallet,
    Eyewear,
    Keychain,
    PhoneCase,
    Other
}

public enum SizeType
{
    // Apparel sizes
    XXS, XS, S, M, L, XL, XXL, XXXL,

    // Shoe sizes (US)
    US4, US5, US6, US7, US8, US9, US10, US11, US12, US13, US14,

    // Accessory / general fit
    Small,
    Medium,
    Large,
    OneSize,
    NotApplicable
}

// Condition of the item
public enum ConditionType
{
    New,
    LikeNew,
    Good,
    Fair
}

// Gender targeting
public enum GenderType
{
    Male,
    Female,
    Unisex
}

// Main item entity
[Table("Items")]
public class Item
{
    public Guid Id { get; set; }

    // Core identifying fields
    public string Brand { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    public ItemCategory Category { get; set; }

    // Specific type depending on category
    public ClothingType? ClothingType { get; set; }
    public ShoeType? ShoeType { get; set; }
    public AccessoryType? AccessoryType { get; set; }

    public string Color { get; set; } = string.Empty;
    public SizeType Size { get; set; }
    public ConditionType Condition { get; set; }
    public GenderType Gender { get; set; }
    public string Description { get; set; } = string.Empty;

    public List<string> ImageUrls { get; set; } = new();

    // Linking to auction
    public Guid AuctionId { get; set; }
    public Auction Auction { get; set; }
}
