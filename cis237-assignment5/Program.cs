/****************************************************************************************
*
* Kyle Nally
* CIS237 T/Th 3:30pm Assignment 5 - Databases and the Entity Framework: Beverages Redux
* 11/18/2018
*
*****************************************************************************************/

using System;

namespace cis237_assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 200;

            // Set a constant for the size of the collection
            const int beverageCollectionSize = 4000;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the BeverageCollection class
            BeverageCollection beverageCollection = new BeverageCollection(beverageCollectionSize);

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
                        // Print all items
                        string allItemsString = beverageCollection.ToString();
                        if (!String.IsNullOrWhiteSpace(allItemsString))
                        {
                            userInterface.DisplayAllItems(allItemsString);
                        }
                        else
                        {
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                    case 2:
                        // Search For An Item by its id (provided by the user)
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
                            if (beverageCollection.AddNewItem(
                                newItemInformation[0],
                                newItemInformation[1],
                                newItemInformation[2],
                                decimal.Parse(newItemInformation[3]),
                                (newItemInformation[4] == "True")
                            )) userInterface.DisplayAddWineItemSuccess();
                            else userInterface.DisplayAddWineItemFailure();
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
                    case 5:
                        // delete an existing item
                        string deleteQuery = userInterface.GetDeletionQuery();
                        string itemToDeleteInformation = beverageCollection.FindById(deleteQuery);
                        if (itemToDeleteInformation != null)
                        {
                            userInterface.ItemIsCorrectForDeletion(itemToDeleteInformation);
                            bool deleteChoice = userInterface.GetBoolOption(userInterface.GetSelection());
                            if (deleteChoice)
                            {
                                if (beverageCollection.DeleteById(deleteQuery))
                                {
                                    userInterface.DisplayDeletionSuccess();
                                }
                                else
                                {
                                    userInterface.DisplayDeletionError();
                                }
                            }
                            else
                            {
                                userInterface.GetDeletionQuery();
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
