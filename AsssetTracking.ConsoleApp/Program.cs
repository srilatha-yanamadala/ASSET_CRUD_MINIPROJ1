using System;
using System.Linq;
using AssetTracking.Data;
using AssetTracking.Domain;
using System.Collections.Generic;

namespace AsssetTracking.ConsoleApp
{
    class Program
    {
        public static AssetTrackingContext _AssetTrackingContext = new AssetTrackingContext();
        static void Main(string[] args)
        {
            //DATABASE INITIALIZATION.. based on DOMAIN classes
            _AssetTrackingContext.Database.EnsureCreated();
            Console.WriteLine("AssetTracking Database created!");
            
            //GETTING INPUT FROM USER
            string Assettype = "";
            List<Asset> computerList = new List<Asset>();
            List<Asset> phoneList = new List<Asset>();
            String BrandName;
            while (!Assettype.Trim().ToUpper().Equals("Q"))
            {
                Console.WriteLine("\n Please enter your Asset type (laptop/mobile)::press q for exit.");
                Assettype = Console.ReadLine();
                if (!Assettype.Trim().ToUpper().Equals("Q") &&
                   (Assettype.Trim().ToUpper().Equals("LAPTOP") || Assettype.Trim().ToUpper().Equals("MOBILE")))
                {
                    Console.WriteLine("\n You entered valid asset type, now give us some more details!!");

                    string Model = "";
                    while (!Model.Trim().ToUpper().Equals("Q"))
                    {
                        Console.WriteLine("\t");
                        Console.WriteLine("Please enter the Model NAME of your " + Assettype);
                        Model = Console.ReadLine();

                        if (!Model.Trim().ToUpper().Equals("Q"))
                        {
                           Console.WriteLine($"Enter the {Model} PRICE in USD $ : (ex: 345.75) ");
                           double  PurchasePrice = double.Parse(Console.ReadLine());
                           Console.WriteLine($"Enter the {Model} PURCHASE DATE (yyyy-mm-dd) : (ex: 2019-01-12) ");
                           String purchaseDateStr = Console.ReadLine();
                           DateTime PurchaseDate = GetDate(purchaseDateStr); // Convert.ToDateTime(purchaseDateStr);

                           Console.WriteLine($"Enter your reporting OFFICE location (Sweden/India/USA):");
                           String officeLocation = Console.ReadLine();
                           Office office = new Office(officeLocation);
                           String currency = getCurrencyByOfficeLocation(officeLocation);
                           double exchangeRate = getXchnageRateByOfficeLocation(officeLocation);
                           if (Assettype.ToUpper().Equals("LAPTOP") || Assettype.ToUpper().Equals("MOBILE"))
                           {
                               Console.WriteLine(" GOING TO PERSIST IN THE DB ");
                                if (Assettype.ToUpper().Equals("LAPTOP"))
                                    BrandName = "DELL";
                                else
                                    BrandName = "APPLE";
                               AddAsset(Assettype,BrandName, Model, PurchaseDate, office, PurchasePrice, currency, exchangeRate);
                           }                                
                           else
                               Console.WriteLine(" Please enter proper asset type. (laptop or mobile are only allowed) ");
                        }
                    }
                }
            } //End of first While

            //READ THE DB AND PRINT
            printAssetDetails();

            //TODO: UPDATE
            //Console.WriteLine("Please enter U for updating a record or D for deleting a record ");

            /*string userInput = "";
            while (!userInput.Trim().ToUpper().Equals("Q"))
            {
                Console.WriteLine("\n Please enter U for updating a record or D for deleting a record ::press q for exit.");
                userInput = Console.ReadLine();
                if (!userInput.Trim().ToUpper().Equals("Q") &&
                   (userInput.Trim().ToUpper().Equals("U") || userInput.Trim().ToUpper().Equals("D")))
                {
                    Console.WriteLine("\n You entered valid input!!");
                    string userConcern = "";
                    while (!userConcern.Trim().ToUpper().Equals("Q"))
                    {
                        Console.WriteLine("\t");
                        Console.WriteLine("Please enter U for update, D for delete ");
                        userConcern = Console.ReadLine();
                        //UPDATE RECORDS
                        if (!userConcern.Trim().ToUpper().Equals("U"))
                        {
                            //Ask the user, which Id to update and what to update

                        }
                        //DELETE RECORDS
                        if (!userConcern.Trim().ToUpper().Equals("U"))
                        {
                            //Ask the user, which Id to delete
                            //GET ASSET TYPE (laptop or mobile) first, then the ID (1 or 2 etc..)
                            //Initialize the asset based on type and then delete it.
                            Computer computer = _AssetTrackingContext.Computer.First(c => c.ComputerId == 2);
                            computer = null;
                        }
                    }//

                }
            } */

            //KEEP THE COMMAND WINDOW OPEN
            Console.ReadLine();

        } //END of MAIN


        //UTILITY FUNCTIONS

        //Adds a computer to database
        public static void AddAsset(String AssetType,String brandName, String modelName,DateTime dateOfPurchase,
            Office office,double purchasePrice,String currency,double exchangeRate)
        {
            Asset myAsset = new Asset();
            if (AssetType.ToUpper().Equals("LAPTOP"))
            {
                myAsset = new Computer(brandName, modelName, dateOfPurchase, office, purchasePrice, currency, AssetType);
                _AssetTrackingContext.Add(myAsset);
                _AssetTrackingContext.SaveChanges();
            }
            else
            {
                myAsset = new Phone(brandName, modelName, dateOfPurchase, office, purchasePrice, currency, AssetType);
                _AssetTrackingContext.Add(myAsset);
                _AssetTrackingContext.SaveChanges(); 
            }
        }

        // Converts date from string to DateTime
        static DateTime GetDate(string date)
        {
             return DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        }

        //Get Currency by office location
        static String getCurrencyByOfficeLocation(String officeLocation)
        {
            if (officeLocation.ToUpper().Equals("INDIA"))
                return "INR";
            else if (officeLocation.ToUpper().Equals("SWEDEN"))
                return "SEK";
            else if (officeLocation.ToUpper().Equals("USA"))
                return "USD";
            else if (officeLocation.ToUpper().Equals("AUSTRALIA"))
                return "AED";
            else if (officeLocation.ToUpper().Equals("JAPAN"))
                return "YEN";

            return "USD";
        }

        static double getXchnageRateByOfficeLocation(String officeLocation)
        {
            double exchangeRate = 1;
            if (officeLocation.ToUpper().Equals("INDIA"))
                exchangeRate = 70;
            else if (officeLocation.ToUpper().Equals("SWEDEN"))
                exchangeRate = 10;
            else if (officeLocation.ToUpper().Equals("USA"))
                exchangeRate = 1;
            else if (officeLocation.ToUpper().Equals("AUSTRALIA"))
                exchangeRate =1.4;
            else if (officeLocation.ToUpper().Equals("JAPAN"))
                exchangeRate = 90;

            return exchangeRate;
        }

        static void printAssetDetails()
        {
            Console.WriteLine("\n\n\t YOUR ASSETS ARE..");
            var computers = _AssetTrackingContext.Computer.ToList();
            if (computers != null)
            {

                Console.WriteLine("\n\n\n\n\t --------------- Deleting the Computer with ID 2 ");
                //delete code
               /* Computer comp = _AssetTrackingContext.Computer.First(c => c.ComputerId == 2);
                _AssetTrackingContext.Remove(comp);
                _AssetTrackingContext.SaveChanges();*/

                foreach (Computer c in computers)
                {   
                    printDetails(c, c.ComputerId);
                  
                }
            }

            var phones = _AssetTrackingContext.Phone.ToList();
            if (phones != null)
            {
                foreach (Phone p in phones)
                {
                    printDetails(p,p.PhoneId);
                }
            }

        }

        static void printDetails(Asset a,int Id)
        {
            Console.WriteLine("\n\t YOUR ASSET ID IS::" + Id);
            Console.WriteLine("\t YOUR ASSET TYPE IS::" + a.AssetType);
            Console.WriteLine("\t YOUR BRAND NAME IS::" + a.Brand.ToString());
            Console.WriteLine("\t YOUR MODEL NAME IS::" + a.Model.ToString());
            Console.WriteLine("\t YOUR PURCHASE DATE IS::" + a.PurchaseDate.ToString());
            Console.WriteLine("\t YOUR PURCHASE PRICE IS::" + a.PurchasePrice.ToString()+" "+a.Currency);
            //_AssetTrackingContext.Entry(a).Reference(a => a.Office).Load();
            //Console.WriteLine("\t YOUR OFFICE LOCATION IS::" + a.Office.Name);
        }


    }
}



//SAMPLE TEST DATA
//laptop
// Model:  Inspiron (Note that the Brand name is hard coded to DELL for  quick testing, this can be changed)
// Purchase date: 2020-01-01
// Purchase Price: 650.99

//mobile
// Model:  iPhone10 (Note that the Brand name is hard coded to APPLE for quick testing, this can be changed)
// Purchase date: 2020-01-01
// Purchase Price: 650.99