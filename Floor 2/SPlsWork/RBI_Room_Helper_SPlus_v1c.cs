using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using Room_Control_Helper;

namespace UserModule_RBI_ROOM_HELPER_SPLUS_V1C
{
    public class UserModuleClass_RBI_ROOM_HELPER_SPLUS_V1C : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.AnalogInput NUM_ZONES_IN;
        Crestron.Logos.SplusObjects.AnalogInput NUM_PRESETS_IN;
        Crestron.Logos.SplusObjects.AnalogInput NUM_SHADES_IN;
        Crestron.Logos.SplusObjects.AnalogInput TIMEOUT_IN;
        Crestron.Logos.SplusObjects.StringInput ROOMNAMEUPDATE;
        Crestron.Logos.SplusObjects.StringInput ALLOFFNAMEUPDATE;
        Crestron.Logos.SplusObjects.StringInput ALLONNAMEUPDATE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> PRESETNAMEUPDATE;
        Crestron.Logos.SplusObjects.DigitalOutput USESPRESETS;
        Crestron.Logos.SplusObjects.DigitalOutput HASSHADES;
        Crestron.Logos.SplusObjects.DigitalOutput ROOMINITIALIZED;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> GENDIGITAL;
        Crestron.Logos.SplusObjects.AnalogOutput NUMZONES;
        Crestron.Logos.SplusObjects.AnalogOutput NUMSHADES;
        Crestron.Logos.SplusObjects.AnalogOutput NUMPRESETS;
        Crestron.Logos.SplusObjects.AnalogOutput TIMEOUT_OUT;
        Crestron.Logos.SplusObjects.AnalogOutput OCC_MODE;
        Crestron.Logos.SplusObjects.AnalogOutput VAC_MODE;
        Crestron.Logos.SplusObjects.StringOutput ROOMNAME;
        Crestron.Logos.SplusObjects.StringOutput ALLOFFNAME;
        Crestron.Logos.SplusObjects.StringOutput ALLONNAME;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> GENANALOG;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> PRESETNAME;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> GENSERIAL;
        StringParameter ROOMID;
        ushort I = 0;
        short STATUS = 0;
        Room_Control_Helper.RoomHelper RHELP;
        private void INITIALIZE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 44;
            STATUS = (short) ( RHELP.Initialize( ROOMID  .ToString() ) ) ; 
            __context__.SourceCodeLine = 45;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STATUS > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 47;
                ROOMINITIALIZED  .Value = (ushort) ( 1 ) ; 
                } 
            
            
            }
            
        public void HANDLEDATACHANGE ( object __sender__ /*Room_Control_Helper.RoomHelper R */, Room_Control_Helper.RoomEventArgs ARGS ) 
            { 
            RoomHelper  R  = (RoomHelper )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 55;
                ROOMINITIALIZED  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 57;
                USESPRESETS  .Value = (ushort) ( ARGS.roomSettings.usesPresets ) ; 
                __context__.SourceCodeLine = 58;
                NUMZONES  .Value = (ushort) ( ARGS.roomSettings.numZones ) ; 
                __context__.SourceCodeLine = 59;
                NUMPRESETS  .Value = (ushort) ( ARGS.roomSettings.numPresets ) ; 
                __context__.SourceCodeLine = 60;
                HASSHADES  .Value = (ushort) ( ARGS.roomSettings.hasShades ) ; 
                __context__.SourceCodeLine = 61;
                NUMSHADES  .Value = (ushort) ( ARGS.roomSettings.numShades ) ; 
                __context__.SourceCodeLine = 62;
                ROOMNAME  .UpdateValue ( ARGS . roomSettings . roomName  ) ; 
                __context__.SourceCodeLine = 63;
                ALLOFFNAME  .UpdateValue ( ARGS . roomSettings . allOffName  ) ; 
                __context__.SourceCodeLine = 64;
                ALLONNAME  .UpdateValue ( ARGS . roomSettings . allOnName  ) ; 
                __context__.SourceCodeLine = 66;
                TIMEOUT_OUT  .Value = (ushort) ( ARGS.roomSettings.occTimeout ) ; 
                __context__.SourceCodeLine = 67;
                OCC_MODE  .Value = (ushort) ( ARGS.roomSettings.occMode ) ; 
                __context__.SourceCodeLine = 68;
                VAC_MODE  .Value = (ushort) ( ARGS.roomSettings.vacMode ) ; 
                __context__.SourceCodeLine = 70;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)8; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 72;
                    PRESETNAME [ I]  .UpdateValue ( ARGS . roomSettings . presetName [ (I - 1) ]  ) ; 
                    __context__.SourceCodeLine = 70;
                    } 
                
                __context__.SourceCodeLine = 75;
                ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__2 = (ushort)8; 
                int __FN_FORSTEP_VAL__2 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                    { 
                    __context__.SourceCodeLine = 77;
                    GENDIGITAL [ I]  .Value = (ushort) ( ARGS.roomSettings.genericDigital[ (I - 1) ] ) ; 
                    __context__.SourceCodeLine = 75;
                    } 
                
                __context__.SourceCodeLine = 79;
                ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__3 = (ushort)8; 
                int __FN_FORSTEP_VAL__3 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                    { 
                    __context__.SourceCodeLine = 81;
                    GENANALOG [ I]  .Value = (ushort) ( ARGS.roomSettings.genericAnalog[ (I - 1) ] ) ; 
                    __context__.SourceCodeLine = 79;
                    } 
                
                __context__.SourceCodeLine = 84;
                ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__4 = (ushort)8; 
                int __FN_FORSTEP_VAL__4 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                    { 
                    __context__.SourceCodeLine = 86;
                    GENSERIAL [ I]  .UpdateValue ( ARGS . roomSettings . genericSerial [ (I - 1) ]  ) ; 
                    __context__.SourceCodeLine = 84;
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object NUM_ZONES_IN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 92;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NUM_ZONES_IN  .UshortValue > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 94;
                    RHELP . UpdateAnalog ( "num_zones", (ushort)( NUM_ZONES_IN  .UshortValue )) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object NUM_PRESETS_IN_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 100;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NUM_PRESETS_IN  .UshortValue > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 102;
                RHELP . UpdateAnalog ( "num_presets", (ushort)( NUM_PRESETS_IN  .UshortValue )) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object NUM_SHADES_IN_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 108;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NUM_SHADES_IN  .UshortValue > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 110;
            RHELP . UpdateAnalog ( "num_shades", (ushort)( NUM_SHADES_IN  .UshortValue )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TIMEOUT_IN_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 117;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TIMEOUT_IN  .UshortValue > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 119;
            RHELP . UpdateAnalog ( "occ_timeout", (ushort)( TIMEOUT_IN  .UshortValue )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOMNAMEUPDATE_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 125;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ROOMNAMEUPDATE != RHELP.GetName( "room_name" , (ushort)( 0 ) )))  ) ) 
            { 
            __context__.SourceCodeLine = 127;
            RHELP . UpdateSerial ( "room_name", ROOMNAMEUPDATE .ToString()) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLOFFNAMEUPDATE_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 133;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ALLOFFNAMEUPDATE != RHELP.GetName( "all_off_name" , (ushort)( 0 ) )))  ) ) 
            { 
            __context__.SourceCodeLine = 135;
            RHELP . UpdateSerial ( "all_off_name", ALLOFFNAMEUPDATE .ToString()) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLONNAMEUPDATE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 141;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ALLONNAMEUPDATE != RHELP.GetName( "all_on_name" , (ushort)( 0 ) )))  ) ) 
            { 
            __context__.SourceCodeLine = 143;
            RHELP . UpdateSerial ( "all_on_name", ALLONNAMEUPDATE .ToString()) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PRESETNAMEUPDATE_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        CrestronString ATTRIBUTE;
        ATTRIBUTE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        
        
        __context__.SourceCodeLine = 152;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 154;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESETNAMEUPDATE[ I ] != RHELP.GetName( "preset" , (ushort)( (I - 1) ) )))  ) ) 
            { 
            __context__.SourceCodeLine = 156;
            MakeString ( ATTRIBUTE , "preset{0:d2}_name", (ushort)I) ; 
            __context__.SourceCodeLine = 157;
            RHELP . UpdateSerial ( ATTRIBUTE .ToString(), PRESETNAMEUPDATE[ I ] .ToString()) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 169;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 171;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_16__" , 500 , __SPLS_TMPVAR__WAITLABEL_16___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    
public void __SPLS_TMPVAR__WAITLABEL_16___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 173;
            // RegisterEvent( RHELP , ONDATACHANGE , HANDLEDATACHANGE ) 
            try { g_criticalSection.Enter(); RHELP .OnDataChange  += HANDLEDATACHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 174;
            INITIALIZE (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    USESPRESETS = new Crestron.Logos.SplusObjects.DigitalOutput( USESPRESETS__DigitalOutput__, this );
    m_DigitalOutputList.Add( USESPRESETS__DigitalOutput__, USESPRESETS );
    
    HASSHADES = new Crestron.Logos.SplusObjects.DigitalOutput( HASSHADES__DigitalOutput__, this );
    m_DigitalOutputList.Add( HASSHADES__DigitalOutput__, HASSHADES );
    
    ROOMINITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( ROOMINITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOMINITIALIZED__DigitalOutput__, ROOMINITIALIZED );
    
    GENDIGITAL = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        GENDIGITAL[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( GENDIGITAL__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( GENDIGITAL__DigitalOutput__ + i, GENDIGITAL[i+1] );
    }
    
    NUM_ZONES_IN = new Crestron.Logos.SplusObjects.AnalogInput( NUM_ZONES_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NUM_ZONES_IN__AnalogSerialInput__, NUM_ZONES_IN );
    
    NUM_PRESETS_IN = new Crestron.Logos.SplusObjects.AnalogInput( NUM_PRESETS_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NUM_PRESETS_IN__AnalogSerialInput__, NUM_PRESETS_IN );
    
    NUM_SHADES_IN = new Crestron.Logos.SplusObjects.AnalogInput( NUM_SHADES_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NUM_SHADES_IN__AnalogSerialInput__, NUM_SHADES_IN );
    
    TIMEOUT_IN = new Crestron.Logos.SplusObjects.AnalogInput( TIMEOUT_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TIMEOUT_IN__AnalogSerialInput__, TIMEOUT_IN );
    
    NUMZONES = new Crestron.Logos.SplusObjects.AnalogOutput( NUMZONES__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( NUMZONES__AnalogSerialOutput__, NUMZONES );
    
    NUMSHADES = new Crestron.Logos.SplusObjects.AnalogOutput( NUMSHADES__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( NUMSHADES__AnalogSerialOutput__, NUMSHADES );
    
    NUMPRESETS = new Crestron.Logos.SplusObjects.AnalogOutput( NUMPRESETS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( NUMPRESETS__AnalogSerialOutput__, NUMPRESETS );
    
    TIMEOUT_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( TIMEOUT_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TIMEOUT_OUT__AnalogSerialOutput__, TIMEOUT_OUT );
    
    OCC_MODE = new Crestron.Logos.SplusObjects.AnalogOutput( OCC_MODE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( OCC_MODE__AnalogSerialOutput__, OCC_MODE );
    
    VAC_MODE = new Crestron.Logos.SplusObjects.AnalogOutput( VAC_MODE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VAC_MODE__AnalogSerialOutput__, VAC_MODE );
    
    GENANALOG = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        GENANALOG[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( GENANALOG__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( GENANALOG__AnalogSerialOutput__ + i, GENANALOG[i+1] );
    }
    
    ROOMNAMEUPDATE = new Crestron.Logos.SplusObjects.StringInput( ROOMNAMEUPDATE__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( ROOMNAMEUPDATE__AnalogSerialInput__, ROOMNAMEUPDATE );
    
    ALLOFFNAMEUPDATE = new Crestron.Logos.SplusObjects.StringInput( ALLOFFNAMEUPDATE__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( ALLOFFNAMEUPDATE__AnalogSerialInput__, ALLOFFNAMEUPDATE );
    
    ALLONNAMEUPDATE = new Crestron.Logos.SplusObjects.StringInput( ALLONNAMEUPDATE__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( ALLONNAMEUPDATE__AnalogSerialInput__, ALLONNAMEUPDATE );
    
    PRESETNAMEUPDATE = new InOutArray<StringInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        PRESETNAMEUPDATE[i+1] = new Crestron.Logos.SplusObjects.StringInput( PRESETNAMEUPDATE__AnalogSerialInput__ + i, PRESETNAMEUPDATE__AnalogSerialInput__, 255, this );
        m_StringInputList.Add( PRESETNAMEUPDATE__AnalogSerialInput__ + i, PRESETNAMEUPDATE[i+1] );
    }
    
    ROOMNAME = new Crestron.Logos.SplusObjects.StringOutput( ROOMNAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ROOMNAME__AnalogSerialOutput__, ROOMNAME );
    
    ALLOFFNAME = new Crestron.Logos.SplusObjects.StringOutput( ALLOFFNAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ALLOFFNAME__AnalogSerialOutput__, ALLOFFNAME );
    
    ALLONNAME = new Crestron.Logos.SplusObjects.StringOutput( ALLONNAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ALLONNAME__AnalogSerialOutput__, ALLONNAME );
    
    PRESETNAME = new InOutArray<StringOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        PRESETNAME[i+1] = new Crestron.Logos.SplusObjects.StringOutput( PRESETNAME__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( PRESETNAME__AnalogSerialOutput__ + i, PRESETNAME[i+1] );
    }
    
    GENSERIAL = new InOutArray<StringOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        GENSERIAL[i+1] = new Crestron.Logos.SplusObjects.StringOutput( GENSERIAL__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( GENSERIAL__AnalogSerialOutput__ + i, GENSERIAL[i+1] );
    }
    
    ROOMID = new StringParameter( ROOMID__Parameter__, this );
    m_ParameterList.Add( ROOMID__Parameter__, ROOMID );
    
    __SPLS_TMPVAR__WAITLABEL_16___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_16___CallbackFn );
    
    NUM_ZONES_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( NUM_ZONES_IN_OnChange_0, false ) );
    NUM_PRESETS_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( NUM_PRESETS_IN_OnChange_1, false ) );
    NUM_SHADES_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( NUM_SHADES_IN_OnChange_2, false ) );
    TIMEOUT_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( TIMEOUT_IN_OnChange_3, false ) );
    ROOMNAMEUPDATE.OnSerialChange.Add( new InputChangeHandlerWrapper( ROOMNAMEUPDATE_OnChange_4, false ) );
    ALLOFFNAMEUPDATE.OnSerialChange.Add( new InputChangeHandlerWrapper( ALLOFFNAMEUPDATE_OnChange_5, false ) );
    ALLONNAMEUPDATE.OnSerialChange.Add( new InputChangeHandlerWrapper( ALLONNAMEUPDATE_OnChange_6, false ) );
    for( uint i = 0; i < 8; i++ )
        PRESETNAMEUPDATE[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( PRESETNAMEUPDATE_OnChange_7, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    RHELP  = new Room_Control_Helper.RoomHelper();
    
    
}

public UserModuleClass_RBI_ROOM_HELPER_SPLUS_V1C ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_16___Callback;


const uint NUM_ZONES_IN__AnalogSerialInput__ = 0;
const uint NUM_PRESETS_IN__AnalogSerialInput__ = 1;
const uint NUM_SHADES_IN__AnalogSerialInput__ = 2;
const uint TIMEOUT_IN__AnalogSerialInput__ = 3;
const uint ROOMNAMEUPDATE__AnalogSerialInput__ = 4;
const uint ALLOFFNAMEUPDATE__AnalogSerialInput__ = 5;
const uint ALLONNAMEUPDATE__AnalogSerialInput__ = 6;
const uint PRESETNAMEUPDATE__AnalogSerialInput__ = 7;
const uint USESPRESETS__DigitalOutput__ = 0;
const uint HASSHADES__DigitalOutput__ = 1;
const uint ROOMINITIALIZED__DigitalOutput__ = 2;
const uint GENDIGITAL__DigitalOutput__ = 3;
const uint NUMZONES__AnalogSerialOutput__ = 0;
const uint NUMSHADES__AnalogSerialOutput__ = 1;
const uint NUMPRESETS__AnalogSerialOutput__ = 2;
const uint TIMEOUT_OUT__AnalogSerialOutput__ = 3;
const uint OCC_MODE__AnalogSerialOutput__ = 4;
const uint VAC_MODE__AnalogSerialOutput__ = 5;
const uint ROOMNAME__AnalogSerialOutput__ = 6;
const uint ALLOFFNAME__AnalogSerialOutput__ = 7;
const uint ALLONNAME__AnalogSerialOutput__ = 8;
const uint GENANALOG__AnalogSerialOutput__ = 9;
const uint PRESETNAME__AnalogSerialOutput__ = 17;
const uint GENSERIAL__AnalogSerialOutput__ = 25;
const uint ROOMID__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
