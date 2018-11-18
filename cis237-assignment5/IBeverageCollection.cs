/****************************************************************************************
*
* Kyle Nally
* CIS237 T/Th 3:30pm Assignment 5 - Databases and the Entity Framework: Beverages Redux
* 11/18/2018
*
*****************************************************************************************/


namespace cis237_assignment5
{
    interface IBeverageCollection
    {
        string FindById(string id);
        bool AddNewItem(string id, string name, string pack, decimal price, bool active);
        bool UpdateById(string id, string[] updatedInformation);
        bool DeleteById(string id);
    }
}
