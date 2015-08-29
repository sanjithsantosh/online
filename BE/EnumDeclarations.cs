// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       :  : 


namespace BE
{
    /// <summary>
    /// Filter Type
    /// </summary>
    public enum FilterType
    {
        Numeric = 0,
        Date = 1
    }

    /// <summary>
    /// OperationType
    /// </summary>
    public enum OperationType
    {
        None = 0,
        Add = 1,
        Edit = 2,
        Delete = 3,
        Auto = 4
    }

    /// <summary>
    /// Message Type
    /// </summary>
    public enum MessageType
    {
        Error = 0,
        Information,
        Warning,
        Success
    }

 }

