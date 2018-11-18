/****************************************************************************************
*
* Kyle Nally
* CIS237 T/Th 3:30pm Assignment 5 - Databases and the Entity Framework: Beverages Redux
* 11/18/2018
*
*****************************************************************************************/

using System;
using System.Linq;

namespace cis237_assignment5
{
    class BeverageCollection : IBeverageCollection
    {
        // Private Variables
        private BeverageKNallyEntities beverages;
        private int beverageLength;

        /// <summary>
        /// BeverageCollection constructor. 
        /// </summary>
        /// <param name="size"></param>
        public BeverageCollection(int size)
        {
            this.beverages = new BeverageKNallyEntities();
            this.beverageLength = 0;
        }

        /// <summary>
        /// Method to add a new item to the collection.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="pack"></param>
        /// <param name="price"></param>
        /// <param name="active"></param>
        /// <returns>bool</returns>
        public bool AddNewItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            Beverage beverageToAdd = new Beverage();
            try
            {
                beverageToAdd.id = id;
                beverageToAdd.name = name;
                beverageToAdd.pack = pack;
                beverageToAdd.price = price;
                beverageToAdd.active = active;
                beverages.Beverages.Add(beverageToAdd);
                beverages.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                beverages.Beverages.Remove(beverageToAdd);
                Console.WriteLine("Cannot add a new item because an exception occurred.");
                return false;
            }
        }

        /// <summary>
        /// ToString override method to convert the collection to a string.
        /// </summary>
        /// <returns>string</returns>
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
                                    + $"{beverage.price:0.00}" + " " 
                                    + beverage.active 
                                    + Environment.NewLine;
                }
            }
            // Return the return string
            return returnString;
        }

        /// <summary>
        /// Performs a database lookup by id and returns a matching item if found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
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
                                                        + $"{beverage.price:0.00}" + " "
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
        }

        /// <summary>
        /// Performs a database lookup by id and attempts to update its other information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedInformation"></param>
        /// <returns>bool</returns>
        public bool UpdateById(string id, string[] updatedInformation)
        {
            try
            {
                Beverage beverageToUpdate = beverages.Beverages.Where(beverages => beverages.id == id).First();
                beverageToUpdate.name = updatedInformation[0];
                beverageToUpdate.pack = updatedInformation[1];
                beverageToUpdate.price = decimal.Parse(updatedInformation[2]);
                beverageToUpdate.active = bool.Parse(updatedInformation[3]);
                beverages.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occurred.");
                return false;
            }
        }

        /// <summary>
        /// Performs a database lookup of a beverage by its id and attempts to delete it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool DeleteById(string id)
        {
            Beverage beverageToDelete = beverages.Beverages.Where(beverages => beverages.id == id).First();
            try
            {
                beverages.Beverages.Remove(beverageToDelete);
                beverages.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has ocurred.");
                return false;
            }
        }
    }
}
