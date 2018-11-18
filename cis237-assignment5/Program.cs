using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;

            // Set a constant for the size of the collection
            const int beverageCollectionSize = 4000;

            // Set a constant for the path to the CSV File
            const string pathToCSVFile = "../../../datafiles/beverage_list.csv";

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the BeverageCollection class
            BeverageCollection beverageCollection = new BeverageCollection(beverageCollectionSize);

            // Create an instance of the CSVProcessor class
            //CSVProcessor csvProcessor = new CSVProcessor();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print Entire List Of Items
                        string allItemsString = beverageCollection.ToString();
                        if (!String.IsNullOrWhiteSpace(allItemsString))
                        {
                            // Display all of the items
                            userInterface.DisplayAllItems(allItemsString);
                        }
                        else
                        {
                            // Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                    case 2:
                        // Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = beverageCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 3:
                        // Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (beverageCollection.FindById(newItemInformation[0]) == null)
                        {
                            beverageCollection.AddNewItem(
                                newItemInformation[0],
                                newItemInformation[1],
                                newItemInformation[2],
                                decimal.Parse(newItemInformation[3]),
                                (newItemInformation[4] == "True")
                            );
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 4:
                        //// update an existing item

                        string updateQuery = userInterface.GetUpdateQuery();
                        string itemToUpdateInformation = beverageCollection.FindById(updateQuery);
                        if (itemToUpdateInformation != null)
                        {
                            //userInterface.DisplayItemFound(itemToUpdateInformation);
                            userInterface.ItemIsCorrectForUpdating(itemToUpdateInformation);
                            bool updateChoice = userInterface.GetBoolOption(userInterface.GetSelection());
                            if (updateChoice)
                            {
                                string[] updatedItemInformation = userInterface.GetUpdatedItemInformation();
                                if (beverageCollection.UpdateById(updateQuery, updatedItemInformation))
                                {
                                    userInterface.DisplayUpdateSuccess();
                                }
                                else
                                {
                                    userInterface.DisplayUpdateError();
                                }
                            }
                            else
                            {
                                userInterface.GetUpdateQuery();
                            }
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
