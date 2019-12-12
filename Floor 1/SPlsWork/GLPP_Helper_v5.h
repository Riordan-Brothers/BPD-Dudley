namespace GLPP_Helper;
        // class declarations
         class XML_Helper;
         class GLPPEvents;
         class GLPPEventArgs;
         class GLPPFileOps;
         class GLPPSettingsClass;
     class XML_Helper 
    {
        // class delegates

        // class events
        EventHandler OnDataChange ( XML_Helper sender, GLPPEventArgs e );

        // class functions
        SIGNED_INTEGER_FUNCTION Initialize ( STRING glppID );
        FUNCTION updateXML ();
        FUNCTION setName ( STRING newName );
        FUNCTION setZoneName ( INTEGER index , STRING newName );
        FUNCTION setLocalMotion ( INTEGER newMotion );
        FUNCTION enableMotion ();
        FUNCTION disableMotion ();
        FUNCTION enablePC ();
        FUNCTION disablePC ();
        FUNCTION setTimeout ( INTEGER newTimeout );
        FUNCTION setOccupancyAction ( INTEGER newAction );
        FUNCTION setVacatingAction ( INTEGER newAction );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING glppID[];
        GLPPSettingsClass myGLPP;

        // class properties
    };

     class GLPPEvents 
    {
        // class delegates

        // class events
        EventHandler OnDataChange ( GLPPEvents sender, GLPPEventArgs e );

        // class functions
        FUNCTION FireDataChange ( GLPPEventArgs e );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GLPPEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING glppID[];
        GLPPSettingsClass glppSettings;
    };

    static class GLPPFileOps 
    {
        // class delegates

        // class events
        static EventHandler OnDataSave ( GLPPFileOps sender, EventArgs e );

        // class functions
        static SIGNED_INTEGER_FUNCTION parseXML ( STRING FileName );
        static FUNCTION FireGlppUpdate ( STRING id );
        static FUNCTION MakeBlankFile ();
        static FUNCTION GenerateSaveFile ();
        static FUNCTION updateRoomName ( STRING glppID , STRING newName );
        static FUNCTION updateZoneName ( STRING glppID , INTEGER index , STRING newName );
        static FUNCTION updateTimeout ( STRING glppID , INTEGER timeout );
        static FUNCTION updateMotionLogic ( STRING glppID , INTEGER status );
        static FUNCTION updatePcLogic ( STRING glppID , INTEGER status );
        static FUNCTION updateOccAction ( STRING glppID , INTEGER action );
        static FUNCTION updateVacAction ( STRING glppID , INTEGER action );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class GLPPSettingsClass 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION UpdateRoomName ( STRING name );
        FUNCTION UpdateZoneName ( INTEGER index , STRING name );
        FUNCTION UpdateLocalMotion ( INTEGER state );
        FUNCTION UpdateLocalPC ( INTEGER state );
        FUNCTION UpdateTimeout ( INTEGER timeout );
        FUNCTION UpdateOccAction ( INTEGER action );
        FUNCTION UpdateVacAction ( INTEGER action );
        FUNCTION UpdateNumZones ( INTEGER num );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER DefeatLocalMotion;
        INTEGER DefeatLocalPC;
        INTEGER SetTimeout;
        INTEGER OccupancyAction;
        INTEGER VacatingAction;
        INTEGER NumZones;
        STRING RoomName[];
        STRING ZoneNames[][];
    };

