using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    class BeverageCollection : IBeverageCollection
    {
        // Private Variables
        //private Beverage[] beverages;
        private BeverageKNallyEntities beverages;
        private int beverageLength;

        // Constructor. Must pass the size of the collection.
        public BeverageCollection(int size)
        {
            this.beverages = new BeverageKNallyEntities();
            this.beverageLength = 0;
        }

        // Add a new item to the collection
        public void AddNewItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            // Add a new Beverage to the collection. Increase the Length variable.
            Beverage beverageToAdd = new Beverage();
            beverageToAdd.id = id;
            beverageToAdd.name = name;
            beverageToAdd.pack = pack;
            beverageToAdd.price = price;
            beverageToAdd.active = active;

            try
            {
                beverages.Beverages.Add(beverageToAdd);
                beverages.SaveChanges();
            }
            catch (Exception e)
            {
                beverages.Beverages.Remove(beverageToAdd);
                Console.WriteLine("Cannot add a new item because an exception occurred.");
            }
        }

        // ToString override method to convert the collection to a string
        public override string ToString()
        {
            // Declare a return string
            string returnString = "";

            // Loop through all of the beverages
            foreach (Beverage beverage in beverages.Beverages)
            {
                // If the current beverage is not null, concat it to the return string
                if (beverage != null)
                {
                    returnString += beverage.id + " " 
                                    + beverage.name + " " 
                                    + beverage.pack + " " 
                                    + beverage.price + " " 
                                    + beverage.active 
                                    + Environment.NewLine;
                }
            }
            // Return the return string
            return returnString;
        }

        // Find an item by it's Id
        public string FindById(string id)
        {
            try
            {
                Beverage beverageToFind = beverages.Beverages.Where(beverages => beverages.id == id).First();
                string returnString = null;

                // For each Beverage in beverages
                foreach (Beverage beverage in beverages.Beverages)
                {
                    // If the beverage is not null
                    if (beverage != null)
                    {
                        // If the beverage Id is the same as the search Id
                        if (beverage.id == id)
                        {
                            // Set the return string to the result
                            // of the beverage's ToString method.
                            returnString += beverage.id + " "
                                                        + beverage.name + " "
                                                        + beverage.pack + " "
                                                        + beverage.price + " "
                                                        + beverage.active
                                                        + Environment.NewLine;
                        }
                    }
                }

                // Return the returnString
                return returnString;
            }
            catch (Exception e)
            {
                return null;
            }
            //List<Beverage> resultBeverage = beverages.Beverages.Where(beverages => beverages.id == id).ToList();
            // Declare return string for the possible found item
            
        }
    }
}
