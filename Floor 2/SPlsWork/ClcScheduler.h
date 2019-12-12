namespace ClcScheduler;
        // class declarations
         class CentralScheduler;
         class Config;
         class GlobalActionEventArgs;
         class GlobalActionHelper;
         class ScheduleEditor;
         class ScheduledEvent;
         class Space;
         class SpaceActionEventArgs;
         class SpaceActions;
         class SpaceActionsChangeEventArgs;
         class eEventTimeReference;
         class eSpaceActionModified;
         class eSpaceKeypadAction;
         class eSpaceOccupancyAction;
         class eSpacePhotocellAction;
    static class CentralScheduler 
    {
        // class delegates

        // class events
        static EventHandler OnConfigLoaded ( CentralScheduler sender, EventArgs e );
        static EventHandler OnConfigSaved ( CentralScheduler sender, EventArgs e );

        // class functions
        static FUNCTION RegisterGlobalAction ( INTEGER Id , STRING Name );
        static FUNCTION UnregisterGlobalAction ( INTEGER Id );
        static STRING_FUNCTION GetGlobalAction ( INTEGER ActionId );
        static STRING_FUNCTION GetSpaceName ( STRING SpaceId );
        static STRING_FUNCTION GetSpaceIdForIndex ( SIGNED_LONG_INTEGER SpaceIndex );
        static SIGNED_LONG_INTEGER_FUNCTION GetSpaceIndexForId ( STRING SpaceId );
        static FUNCTION LoadConfig ();
        static FUNCTION SaveConfig ();
        static FUNCTION SetStorageBaseDirectory ( STRING Directory );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static GlobalActionHelper GlobalActionHelper;
        static STRING StorageSubPath[];
        static STRING StorageFileFullPath[];
        static Config Config;

        // class properties
        STRING StorageBaseDirectory[];
        INTEGER GlobalActionCount;
        INTEGER SpaceCount;
    };

     class Config 
    {
        // class delegates

        // class events
        EventHandler OnEnabledChange ( Config sender, EventArgs e );
        EventHandler OnEventsListChange ( Config sender, EventArgs e );

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER EnabledSplus;
        STRING LatitudeStr[];
        STRING LongitudeStr[];
    };

     class GlobalActionEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Actions[];
        INTEGER ActionsCount;
    };

     class GlobalActionHelper 
    {
        // class delegates

        // class events
        EventHandler OnGlobalAction ( GlobalActionHelper sender, GlobalActionEventArgs e );

        // class functions
        FUNCTION RaiseEvent ( GlobalActionEventArgs Args );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class ScheduleEditor 
    {
        // class delegates

        // class events
        EventHandler OnEventsListChange ( ScheduleEditor sender, EventArgs e );
        EventHandler OnEventSelect ( ScheduleEditor sender, EventArgs e );
        EventHandler OnEventPropertyChange ( ScheduleEditor sender, EventArgs e );
        EventHandler OnEventGlobalActionChange ( ScheduleEditor sender, EventArgs e );
        EventHandler OnEventSpaceActionAssignmentChange ( ScheduleEditor sender, EventArgs e );
        EventHandler OnEventSpaceActionChange ( ScheduleEditor sender, EventArgs e );

        // class functions
        FUNCTION CreateEvent ();
        INTEGER_FUNCTION SelectEvent ( INTEGER EventIndex );
        FUNCTION DeleteCurrentEvent ();
        INTEGER_FUNCTION IsCurrentEvent ( ScheduledEvent Evt );
        FUNCTION SelectSpace ( INTEGER SpaceIndex );
        FUNCTION GetSpaceForCurrentSpaceActions ( BYREF Space RtnSpace );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        ScheduledEvent Events[];
        INTEGER EventsCount;
        INTEGER CurrentSpaceIndex;
        ScheduledEvent CurrentEvent;
        SpaceActions CurrentSpaceActions;
    };

     class ScheduledEvent 
    {
        // class delegates

        // class events
        EventHandler OnScheduledEventPropertyChange ( ScheduledEvent sender, EventArgs e );
        EventHandler OnGlobalActionsChange ( ScheduledEvent sender, EventArgs e );
        EventHandler OnSpaceActionsChange ( ScheduledEvent sender, EventArgs e );
        EventHandler OnSaved ( ScheduledEvent sender, EventArgs e );

        // class functions
        FUNCTION Schedule ();
        FUNCTION ExecuteEvent ();
        FUNCTION Save ();
        FUNCTION Cancel ();
        FUNCTION InitEdit ();
        FUNCTION ToggleEditActiveState ();
        FUNCTION EditTime ( SIGNED_LONG_INTEGER Minutes );
        FUNCTION ToggleRecurrence ( SIGNED_LONG_INTEGER RecurrenceDays );
        INTEGER_FUNCTION IsRecurrenceSet ( SIGNED_LONG_INTEGER RecurrenceDay );
        FUNCTION SetTimeReference ( eEventTimeReference TimeReference );
        STRING_FUNCTION SchedulerEngineState ();
        INTEGER_FUNCTION IsSpaceActionEnabled ( STRING SpaceId );
        FUNCTION RemoveSpaceAction ( STRING SpaceId );
        INTEGER_FUNCTION IsGlobalActionSet ( INTEGER ActionIndex );
        FUNCTION ToggleGlobalAction ( INTEGER ActionIndex );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static SIGNED_LONG_INTEGER Sunday;
        static SIGNED_LONG_INTEGER Monday;
        static SIGNED_LONG_INTEGER Tuesday;
        static SIGNED_LONG_INTEGER Wednesday;
        static SIGNED_LONG_INTEGER Thursday;
        static SIGNED_LONG_INTEGER Friday;
        static SIGNED_LONG_INTEGER Saturday;

        // class properties
        INTEGER EditActiveSplus;
        STRING Name[];
        STRING EditName[];
        STRING EventTimeStr[];
        eEventTimeReference EventTimeReference;
        eEventTimeReference EditEventTimeReference;
        INTEGER GlobalActions[];
        SpaceActions SpaceActions[];
    };

     class Space 
    {
        // class delegates

        // class events
        EventHandler OnSpaceAction ( Space sender, SpaceActionEventArgs e );

        // class functions
        FUNCTION Register ( STRING Id , STRING Name );
        FUNCTION Unregister ();
        FUNCTION PerformActions ( SpaceActions Actions );
        FUNCTION UpdateSupportedActions ( INTEGER Keypad , INTEGER Occupancy , INTEGER Photocell );
        FUNCTION RegisterDiscreteAction ( INTEGER Id , STRING Name );
        FUNCTION UnregisterDiscreteAction ( INTEGER Id );
        FUNCTION RegisterSceneName ( INTEGER Id , STRING Name );
        FUNCTION UnregisterSceneName ( INTEGER Id );
        STRING_FUNCTION GetSceneName ( INTEGER SceneId );
        STRING_FUNCTION GetSceneNameOrEmpty ( INTEGER SceneId );
        STRING_FUNCTION GetActionName ( INTEGER ActionId );
        INTEGER_FUNCTION GetActionCount ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER RegisteredSplus;
        STRING Id[];
        STRING Name[];
    };

     class SpaceActionEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SpaceActions Actions;
    };

     class SpaceActions 
    {
        // class delegates

        // class events
        EventHandler OnActionChange ( SpaceActions sender, SpaceActionsChangeEventArgs e );

        // class functions
        FUNCTION SetKeypadAction ( eSpaceKeypadAction Action );
        FUNCTION SetOccupancyAction ( eSpaceOccupancyAction Action );
        FUNCTION SetPhotocellAction ( eSpacePhotocellAction Action );
        FUNCTION SetSceneToRecall ( SIGNED_INTEGER SceneId );
        FUNCTION ToggleLocalAction ( INTEGER ActionIndex );
        INTEGER_FUNCTION IsLocalActionActive ( INTEGER ActionIndex );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING SpaceId[];
        eSpaceKeypadAction KeypadAction;
        eSpaceOccupancyAction OccupancyAction;
        eSpacePhotocellAction PhotocellAction;
        SIGNED_INTEGER RecallScene;
        INTEGER DiscreteActionsCount;
        INTEGER DiscreteActions[];
    };

     class SpaceActionsChangeEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eSpaceActionModified ModifiedActions;
    };

    static class eEventTimeReference // enum
    {
        static SIGNED_LONG_INTEGER NotSet;
        static SIGNED_LONG_INTEGER AM;
        static SIGNED_LONG_INTEGER PM;
        static SIGNED_LONG_INTEGER Sunrise;
        static SIGNED_LONG_INTEGER Sunset;
    };

    static class eSpaceActionModified // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER Keypad;
        static SIGNED_LONG_INTEGER LocalActions;
        static SIGNED_LONG_INTEGER Occupancy;
        static SIGNED_LONG_INTEGER Photocell;
        static SIGNED_LONG_INTEGER Scene;
    };

    static class eSpaceKeypadAction // enum
    {
        static SIGNED_LONG_INTEGER NoChange;
        static SIGNED_LONG_INTEGER Disable;
        static SIGNED_LONG_INTEGER Enable;
    };

    static class eSpaceOccupancyAction // enum
    {
        static SIGNED_LONG_INTEGER NoChange;
        static SIGNED_LONG_INTEGER Disable;
        static SIGNED_LONG_INTEGER Vacancy;
        static SIGNED_LONG_INTEGER Occupancy;
    };

    static class eSpacePhotocellAction // enum
    {
        static SIGNED_LONG_INTEGER NoChange;
        static SIGNED_LONG_INTEGER Disable;
        static SIGNED_LONG_INTEGER Enable;
    };

