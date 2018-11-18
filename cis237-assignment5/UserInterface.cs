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
    class UserInterface
    {
        const int MAX_MENU_CHOICES = 6;

        /*
        |----------------------------------------------------------------------
        | Public Methods
        |----------------------------------------------------------------------
        */

        /// <summary>
        /// Display Welcome Greeting to the user.
        /// </summary>
        public void DisplayWelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the wine program!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Menu And Get Response
        /// </summary>
        /// <returns>int</returns>
        public int DisplayMenuAndGetResponse()
        {
            // Declare variable to hold the selection
            string selection;

            // Display menu, and prompt
            this.DisplayMenu();
            this.DisplayPrompt();

            // Get the selection they enter
            selection = this.GetSelection();

            // While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                // Display error message
                this.DisplayErrorMessage();

                // Display the prompt again
                this.DisplayPrompt();

                // Get the selection again
                selection = this.GetSelection();
            }
            // Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        /// <summary>
        /// Get the search query from the user
        /// </summary>
        /// <returns>string</returns>
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Get the id of the item to update from the user
        /// </summary>
        /// <returns>string</returns>
        public string GetUpdateQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What is the Id of the item you wish to update?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Get the id of the item to delete from the user
        /// </summary>
        /// <returns></returns>
        public string GetDeletionQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What is the Id of the item you wish to delete?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Get New Item Information From The User
        /// </summary>
        /// <returns>string[]</returns>
        public string[] GetNewItemInformation()
        {
            string id = this.GetStringField("Id");
            string name = this.GetStringField("Name");
            string pack = this.GetStringField("Pack");
            string price = this.GetDecimalField("Price");
            string active = this.GetBoolField("Active");

            return new string[] { id, name, pack, price, active };
        }

        /// <summary>
        /// Get updated Item Information From The User
        /// </summary>
        /// <returns>string[]</returns>
        public string[] GetUpdatedItemInformation()
        {
            string name = this.GetStringField("Name");
            string pack = this.GetStringField("Pack");
            string price = this.GetDecimalField("Price");
            string active = this.GetBoolField("Active");

            return new string[] { name, pack, price, active };
        }

        /// <summary>
        /// Display Import Success
        /// </summary>
        public void DisplayUpdateSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database updated successfully.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Import Error
        /// </summary>
        public void DisplayUpdateError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There was an error updating the database.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Deletion Success
        /// </summary>
        public void DisplayDeletionSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database item deleted successfully.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display deletion error
        /// </summary>
        public void DisplayDeletionError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There was an error deleting the item from the database.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display All Items
        /// </summary>
        /// <param name="allItemsOutput"></param>
        public void DisplayAllItems(string allItemsOutput)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing List");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(allItemsOutput);
        }

        /// <summary>
        /// Display All Items Error
        /// </summary>
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no items in the list to print");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Item Found Success
        /// </summary>
        /// <param name="itemInformation"></param>
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item Found!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(itemInformation);
        }

        /// <summary>
        /// Verify the item displayed is the one the user wants to update
        /// </summary>
        /// <param name="itemInformation"></param>
        public void ItemIsCorrectForUpdating(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Is this the item you wish to update (Y/N)? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(itemInformation);
        }

        /// <summary>
        /// Verify the item displayed is the one the user wants to delete
        /// </summary>
        /// <param name="itemInformation"></param>
        public void ItemIsCorrectForDeletion(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Is this the item you wish to delete (Y/N)? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(itemInformation);
        }

        /// <summary>
        /// Asks the user yes or no and returns their decision
        /// </summary>
        /// <param name="userChoiceBoolean"></param>
        /// <returns>bool</returns>
        public bool GetBoolOption(string userChoiceBoolean)
        {
            bool choice;
            if (userChoiceBoolean.ToUpper() == "Y") return choice = true;
            else if (userChoiceBoolean.ToUpper() == "N") return choice = false;
            else
            {
                DisplayErrorMessage();
                return false;
            }
        }

        /// <summary>
        /// Display Item match not Found Error
        /// </summary>
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A Match was not found");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Add Wine Item Success
        /// </summary>
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully added.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Add Wine Item failure
        /// </summary>
        public void DisplayAddWineItemFailure()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Item was not successfully added.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Display Item Already Exists Error
        /// </summary>
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Item With That Id Already Exists.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Get the selection from the user
        /// </summary>
        /// <returns></returns>
        public string GetSelection()
        {
            return Console.ReadLine();
        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        /// <summary>
        /// Display the Menu
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print The Entire Database Of Items");
            Console.WriteLine("2. Search For An Item");
            Console.WriteLine("3. Add New Item To The Database");
            Console.WriteLine("4. Update an existing Item in the Database");
            Console.WriteLine("5. Delete an Item from the Database");
            Console.WriteLine("6. Exit Program");
        }

        /// <summary>
        /// Display the Prompt
        /// </summary>
        private void DisplayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        /// <summary>
        /// Display the Error Message
        /// </summary>
        private void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid option. Please make a valid choice");
            Console.ResetColor();
        }

        /// <summary>
        /// Verify that a selection from the main menu is valid
        /// </summary>
        /// <param name="selection"></param>
        /// <returns>bool</returns>
        private bool VerifySelectionIsValid(string selection)
        {
            // Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                // If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= MAX_MENU_CHOICES)
                {
                    // Set the return value to true
                    returnValue = true;
                }
            }
            // If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                // Set return value to false even though it should already be false
                returnValue = false;
            }

            // Return the reutrnValue
            return returnValue;
        }

        /// <summary>
        /// Get a valid string field from the console
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>string</returns>
        private string GetStringField(string fieldName)
        {
            Console.WriteLine("What is the new Item's {0}", fieldName);
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a value.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        /// <summary>
        /// Get a valid decimal field from the console
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>string</returns>
        private string GetDecimalField(string fieldName)
        {
            Console.WriteLine("What is the new Item's {0}", fieldName);
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Item's {0}", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        /// <summary>
        /// Get a valid bool field from the console
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns>string</returns>
        private string GetBoolField(string fieldName)
        {
            Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Should the Item be {0} (y/n)", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        /// <summary>
        /// Get a string formatted as a header for items
        /// </summary>
        /// <returns>string</returns>
        private string GetItemHeader()
        {
            return String.Format(
                "{0,-5} {1,-100} {2,-20} {3,-7} {4,-6}",
                "Id",
                "Name",
                "Pack",
                "Price",
                "Active"
            ) +
            Environment.NewLine +
            String.Format(
                "{0,-5} {1,-100} {2,-20} {3,-7} {4,-6}",
                new String('-', 5),
                new String('-', 100),
                new String('-', 20),
                new String('-', 7),
                new String('-', 6)
            );
        }
    }
}
