// Student nr      : 224079871;225044710;224092435;225016174;223020311;224020707
// Programmer name : M Dyantyi;W Khoza;U Theku;SG Thela;LS Maroga;B Mtimkulu;
// Assignment nr   : Practical Assessment 2
// Purpose         : View model class used by the Error view to display the identifier
//                   

namespace BoardAppDB.Models
{
    public class ErrorViewModel
    {
        //
        // Name             : property string? RequestId
        // Purpose          : Public property giving access to the identifier of the request that failed
        // Re-use           : None
        // Input Parameter  : string? value
        //                    - new value for the request identifier
        // Output Type      : string?
        //                    - the identifier of the request that failed
        //

        public string? RequestId { get; set; }
        // Name             : property bool ShowRequestId
        // Purpose          : Read-only property indicating whether a request identifier is available
        // Re-use           : None
        // Input Parameter  : bool value
        //                    - read-only property; no value is assigned
        // Output Type      : bool
        //                    - true when a request identifier is available, otherwise false
        //

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
