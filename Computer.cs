using System;
namespace AssetTracking.Domain
{

    public class Computer : Asset
    {


        public Computer()
        {
        }
        public Computer(string brand, string model, DateTime purchaseDate, Office office, double purchasePrice, string currency, String assetType)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            Currency = currency;
            Office = office;
            AssetType = assetType;
        }


        public int ComputerId { get; set; }

    }
       
    
}
