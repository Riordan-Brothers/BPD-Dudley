namespace Room_Control_Helper;
        // class declarations
         class RoomHelper;
         class RoomSettingsStruct;
         class RoomEventArgs;
         class RoomControlFileOps;
         class RoomListHelper;
         class RoomEvents;
     class RoomHelper 
    {
        // class delegates

        // class events
        EventHandler OnDataChange ( RoomHelper sender, RoomEventArgs e );

        // class functions
        SIGNED_INTEGER_FUNCTION Initialize ( STRING roomID );
        INTEGER_FUNCTION UpdateAnalog ( STRING attribute , INTEGER newSetting );
        INTEGER_FUNCTION UpdateSerial ( STRING attribute , STRING newSetting );
        STRING_FUNCTION GetName ( STRING attribute , INTEGER index );
        FUNCTION MakeBlankFile ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING RoomId[];

        // class properties
    };

     class RoomSettingsStruct 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING roomId[];
        STRING roomName[];
        INTEGER roomNum;
        INTEGER equipID;
        INTEGER usesPresets;
        INTEGER hasShades;
        INTEGER numZones;
        INTEGER numShades;
        INTEGER numPresets;
        INTEGER occTimeout;
        INTEGER occMode;
        INTEGER vacMode;
        STRING allOffName[];
        STRING allOnName[];
        STRING presetName[][];
        INTEGER genericDigital[];
        INTEGER genericAnalog[];
        STRING genericSerial[][];

        // class properties
    };

     class RoomEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING roomID[];
        RoomSettingsStruct roomSettings;
    };

    static class RoomControlFileOps 
    {
        // class delegates

        // class events

        // class functions
        static SIGNED_INTEGER_FUNCTION parseXML ( STRING FileName );
        static FUNCTION FireRoomUpdate ( STRING id );
        static FUNCTION MakeBlankFile ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class RoomListHelper 
    {
        // class delegates

        // class events
        EventHandler RoomListChange ( RoomListHelper sender, EventArgs e );

        // class functions
        STRING_FUNCTION GetRoomName ( INTEGER r );
        STRING_FUNCTION GetRoomId ( INTEGER r );
        INTEGER_FUNCTION GetRoomEquipId ( INTEGER r );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class RoomEvents 
    {
        // class delegates

        // class events
        EventHandler OnDataChange ( RoomEvents sender, RoomEventArgs e );

        // class functions
        FUNCTION FireDataChange ( RoomEventArgs e );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

