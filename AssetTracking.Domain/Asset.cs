using System;


namespace AssetTracking.Domain
{
  
    public class Asset
    {
       
        public Asset()
        {

        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Office Office { get; set; }
        public double PurchasePrice { get; set; }
        public string Currency { get; set; }
        public string AssetType { get; set; }
        public string OfficeLocation { get; }
    }
}
