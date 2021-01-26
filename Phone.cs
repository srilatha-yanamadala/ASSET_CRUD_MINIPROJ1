
using System;

namespace AssetTracking.Domain
{
    public class Phone : Asset
    {
        public Phone()
        {


        }

        public Phone(string brand, string model, DateTime purchaseDate,Office office, double purchasePrice, string currency, string assetType)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            Currency = currency;
            Office = office;
            AssetType = assetType;
        }


        public int PhoneId { get; set; }

    }


    
}