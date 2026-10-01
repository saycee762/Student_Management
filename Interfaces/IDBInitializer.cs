// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : Interface that defines the contract for creating and seeding the database.

namespace BoardAppDB.Interfaces
{
    public interface IDBInitializer
    {
        //
        // Name             : void Initialize()
        // Purpose          : Creates the database if it does not exist and seeds it when the table is empty
        // Re-use           : None
        // Method Parameters: None
        // Output Type      : None
        //
        void Initialize(); // end method Initialize
    } // end interface IDBInitializer
} // end namespace BoardAppDB.Interfaces
