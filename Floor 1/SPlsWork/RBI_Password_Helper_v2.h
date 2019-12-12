namespace RBI_Password_Helper_v2;
        // class declarations
         class UserListEventArgs;
         class UsernameHelper;
         class LoginResult;
         class UsernameInfo;
     class UserListEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER ListCount;
    };

     class UsernameHelper 
    {
        // class delegates

        // class events
        EventHandler OnListUpdate ( UsernameHelper sender, UserListEventArgs e );

        // class functions
        SIGNED_INTEGER_FUNCTION InitToken ( STRING userName , STRING pass );
        FUNCTION Initialize ( INTEGER save );
        STRING_FUNCTION ReturnUser ( INTEGER num );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class LoginResult // enum
    {
        static SIGNED_LONG_INTEGER LoginSuccess;
        static SIGNED_LONG_INTEGER Error;
        static SIGNED_LONG_INTEGER NullInput;
        static SIGNED_LONG_INTEGER NoAccess;
        static SIGNED_LONG_INTEGER InvalidAccess;
        static SIGNED_LONG_INTEGER LoginIncorrect;
        static SIGNED_LONG_INTEGER AuthDisabled;
    };

     class UsernameInfo 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace password_helper;
        // class declarations
         class PWchecker;
         class LoginResult;
     class PWchecker 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_INTEGER_FUNCTION login ( STRING username , STRING password , STRING device );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class LoginResult // enum
    {
        static SIGNED_LONG_INTEGER NoAccess;
        static SIGNED_LONG_INTEGER Connect;
        static SIGNED_LONG_INTEGER User;
        static SIGNED_LONG_INTEGER Other;
        static SIGNED_LONG_INTEGER Operator;
        static SIGNED_LONG_INTEGER Programmer;
        static SIGNED_LONG_INTEGER Administrator;
        static SIGNED_LONG_INTEGER UnknownError;
        static SIGNED_LONG_INTEGER AuthNotEnabled;
        static SIGNED_LONG_INTEGER NullLogin;
        static SIGNED_LONG_INTEGER Incorrect;
    };

