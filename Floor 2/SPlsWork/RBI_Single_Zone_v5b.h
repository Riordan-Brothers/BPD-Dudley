namespace Zone_Control_Helper;
        // class declarations
         class PcListHelper;
         class ZoneSettingsStruct;
         class ZoneEventArgs;
         class ZoneControlFileOps;
         class CustomEventArgs;
         class ZoneHelper;
         class ZoneEvents;
     class PcListHelper 
    {
        // class delegates

        // class events
        EventHandler PcListChange ( PcListHelper sender, EventArgs e );

        // class functions
        STRING_FUNCTION GetPcName ( INTEGER r );
        STRING_FUNCTION GetZoneId ( INTEGER r );
        INTEGER_FUNCTION GetPcEquipId ( INTEGER r );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class ZoneSettingsStruct 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING zoneId[];
        INTEGER daliFB;
        INTEGER dimmableFB;
        INTEGER inUseFB;
        INTEGER slewRate;
        INTEGER rampTime;
        INTEGER lowerBound;
        INTEGER upperBound;
        STRING friendlyName[];
        STRING pcName[];
        INTEGER pcEquipId;
        INTEGER pcNum;
        INTEGER onLevel;
        INTEGER offLevel;
        INTEGER raiseFromOff;
        INTEGER rgbFB;
        INTEGER harvestedFB;
        INTEGER harvestEnableFB;
        INTEGER maxWattage;

        // class properties
    };

     class ZoneEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING zoneID[];
        ZoneSettingsStruct zoneSettings;
    };

    static class ZoneControlFileOps 
    {
        // class delegates

        // class events

        // class functions
        static SIGNED_INTEGER_FUNCTION parseXML ( STRING FileName );
        static FUNCTION ZoneUpdate ( STRING id );
        static FUNCTION MakeBlankFile ();
        static INTEGER_FUNCTION SaveLevel ( INTEGER levelType , INTEGER levelIn , STRING zoneID );
        static INTEGER_FUNCTION SaveHarvest ( INTEGER enableDisable , STRING zoneID );
        static INTEGER_FUNCTION SaveName ( STRING newName , STRING zoneID );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class CustomEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER daliFB;
        INTEGER dimmableFB;
        INTEGER inUseFB;
        INTEGER slewRate;
        INTEGER rampTime;
        INTEGER lowerBound;
        INTEGER upperBound;
        STRING friendlyName[];
        INTEGER onLevel;
        INTEGER offLevel;
        INTEGER raiseFromOff;

        // class properties
    };

     class ZoneHelper 
    {
        // class delegates

        // class events
        EventHandler OnDataChange ( ZoneHelper sender, ZoneEventArgs e );

        // class functions
        FUNCTION Initialize ( STRING zoneID );
        FUNCTION MakeBlankFile ();
        INTEGER_FUNCTION SaveOnLevel ( INTEGER newLevel , STRING zoneID );
        INTEGER_FUNCTION SaveOffLevel ( INTEGER newLevel , STRING zoneID );
        INTEGER_FUNCTION PhotocellEnableDisable ( INTEGER enableDisable , STRING zoneID );
        INTEGER_FUNCTION SaveName ( STRING newName , STRING zoneID );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING ZoneId[];

        // class properties
    };

     class ZoneEvents 
    {
        // class delegates

        // class events
        EventHandler OnDataChange ( ZoneEvents sender, ZoneEventArgs e );

        // class functions
        FUNCTION FireDataChange ( ZoneEventArgs e );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

