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
using Zone_Control_Helper;

namespace UserModule_RBI_SINGLE_ZONE_CONTROL_SPLUS_V5B
{
    public class UserModuleClass_RBI_SINGLE_ZONE_CONTROL_SPLUS_V5B : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ZONEON;
        Crestron.Logos.SplusObjects.DigitalInput ZONEOFF;
        Crestron.Logos.SplusObjects.DigitalInput ZONEONOFF;
        Crestron.Logos.SplusObjects.DigitalInput SAVEONLVL;
        Crestron.Logos.SplusObjects.DigitalInput SAVEOFFLVL;
        Crestron.Logos.SplusObjects.DigitalInput ZONEONFB;
        Crestron.Logos.SplusObjects.AnalogInput TRUEFB;
        Crestron.Logos.SplusObjects.StringInput FRIENDLYNAMEUPDATE;
        Crestron.Logos.SplusObjects.DigitalOutput DALIFB;
        Crestron.Logos.SplusObjects.DigitalOutput DIMMABLEFB;
        Crestron.Logos.SplusObjects.DigitalOutput INUSEFB;
        Crestron.Logos.SplusObjects.DigitalOutput RGBFB;
        Crestron.Logos.SplusObjects.DigitalOutput HARVESTEDFB;
        Crestron.Logos.SplusObjects.DigitalOutput HARVESTENABLEFB;
        Crestron.Logos.SplusObjects.DigitalOutput ONLVLSAVED;
        Crestron.Logos.SplusObjects.DigitalOutput OFFLVLSAVED;
        Crestron.Logos.SplusObjects.DigitalOutput RAISEFROMOFF;
        Crestron.Logos.SplusObjects.DigitalOutput FRIENDLYNAMESAVED;
        Crestron.Logos.SplusObjects.DigitalOutput INITIALIZED;
        Crestron.Logos.SplusObjects.AnalogOutput ZONELEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput SLEWRATE;
        Crestron.Logos.SplusObjects.AnalogOutput RAMPTIME;
        Crestron.Logos.SplusObjects.AnalogOutput WATTAGE;
        Crestron.Logos.SplusObjects.AnalogOutput OFFLEVEL;
        Crestron.Logos.SplusObjects.StringOutput FRIENDLYNAME;
        StringParameter ZONEID;
        ushort LOWERBOUND = 0;
        ushort UPPERBOUND = 0;
        ushort ONLEVEL = 0;
        ushort PULSETIME = 0;
        Zone_Control_Helper.ZoneHelper ZHELP;
        RAMP_INFO PRESETRAMP;
        public void HANDLEDATACHANGE ( object __sender__ /*Zone_Control_Helper.ZoneHelper Z */, Zone_Control_Helper.ZoneEventArgs ARGS ) 
            { 
            ZoneHelper  Z  = (ZoneHelper )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 46;
                INITIALIZED  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 48;
                DALIFB  .Value = (ushort) ( ARGS.zoneSettings.daliFB ) ; 
                __context__.SourceCodeLine = 49;
                DIMMABLEFB  .Value = (ushort) ( ARGS.zoneSettings.dimmableFB ) ; 
                __context__.SourceCodeLine = 50;
                INUSEFB  .Value = (ushort) ( ARGS.zoneSettings.inUseFB ) ; 
                __context__.SourceCodeLine = 51;
                RGBFB  .Value = (ushort) ( ARGS.zoneSettings.rgbFB ) ; 
                __context__.SourceCodeLine = 52;
                HARVESTEDFB  .Value = (ushort) ( ARGS.zoneSettings.harvestedFB ) ; 
                __context__.SourceCodeLine = 53;
                HARVESTENABLEFB  .Value = (ushort) ( ARGS.zoneSettings.harvestEnableFB ) ; 
                __context__.SourceCodeLine = 54;
                SLEWRATE  .Value = (ushort) ( ARGS.zoneSettings.slewRate ) ; 
                __context__.SourceCodeLine = 55;
                RAMPTIME  .Value = (ushort) ( ARGS.zoneSettings.rampTime ) ; 
                __context__.SourceCodeLine = 56;
                LOWERBOUND = (ushort) ( ARGS.zoneSettings.lowerBound ) ; 
                __context__.SourceCodeLine = 57;
                UPPERBOUND = (ushort) ( ARGS.zoneSettings.upperBound ) ; 
                __context__.SourceCodeLine = 58;
                FRIENDLYNAME  .UpdateValue ( ARGS . zoneSettings . friendlyName  ) ; 
                __context__.SourceCodeLine = 59;
                ONLEVEL = (ushort) ( ARGS.zoneSettings.onLevel ) ; 
                __context__.SourceCodeLine = 60;
                OFFLEVEL  .Value = (ushort) ( ARGS.zoneSettings.offLevel ) ; 
                __context__.SourceCodeLine = 61;
                RAISEFROMOFF  .Value = (ushort) ( ARGS.zoneSettings.raiseFromOff ) ; 
                __context__.SourceCodeLine = 63;
                PRESETRAMP .  rampLowerBound = (int) ( LOWERBOUND ) ; 
                __context__.SourceCodeLine = 64;
                PRESETRAMP .  rampUpperBound = (int) ( UPPERBOUND ) ; 
                __context__.SourceCodeLine = 66;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DALIFB  .Value == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (DIMMABLEFB  .Value == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 68;
                    PRESETRAMP .  rampTransitionTime = (uint) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 73;
                    PRESETRAMP .  rampTransitionTime = (uint) ( (SLEWRATE  .Value * 100) ) ; 
                    } 
                
                __context__.SourceCodeLine = 76;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HARVESTEDFB  .Value == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 78;
                    HARVESTENABLEFB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        private void LIGHTSPRESET (  SplusExecutionContext __context__, ushort LVL ) 
            { 
            
            __context__.SourceCodeLine = 85;
            PRESETRAMP .  rampTargetValue = (int) ( LVL ) ; 
            __context__.SourceCodeLine = 86;
            CreateRamp ( ZONELEVEL ,  ref PRESETRAMP ) ; 
            
            }
            
        object ZONEON_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 91;
                LIGHTSPRESET (  __context__ , (ushort)( ONLEVEL )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ZONEOFF_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 96;
            LIGHTSPRESET (  __context__ , (ushort)( OFFLEVEL  .Value )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ZONEONOFF_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 101;
        if ( Functions.TestForTrue  ( ( ZONEONFB  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 103;
            LIGHTSPRESET (  __context__ , (ushort)( OFFLEVEL  .Value )) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 108;
            LIGHTSPRESET (  __context__ , (ushort)( ONLEVEL )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SAVEONLVL_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort STATUS = 0;
        
        
        __context__.SourceCodeLine = 115;
        ONLEVEL = (ushort) ( TRUEFB  .UshortValue ) ; 
        __context__.SourceCodeLine = 117;
        STATUS = (ushort) ( ZHELP.SaveOnLevel( (ushort)( TRUEFB  .UshortValue ) , ZONEID  .ToString() ) ) ; 
        __context__.SourceCodeLine = 119;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STATUS == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 121;
            Functions.Pulse ( 200, ONLVLSAVED ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SAVEOFFLVL_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort STATUS = 0;
        
        
        __context__.SourceCodeLine = 128;
        OFFLEVEL  .Value = (ushort) ( TRUEFB  .UshortValue ) ; 
        __context__.SourceCodeLine = 130;
        STATUS = (ushort) ( ZHELP.SaveOffLevel( (ushort)( TRUEFB  .UshortValue ) , ZONEID  .ToString() ) ) ; 
        __context__.SourceCodeLine = 132;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STATUS == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 134;
            Functions.Pulse ( 200, OFFLVLSAVED ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FRIENDLYNAMEUPDATE_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort STATUS = 0;
        
        
        __context__.SourceCodeLine = 141;
        STATUS = (ushort) ( ZHELP.SaveName( FRIENDLYNAMEUPDATE .ToString() , ZONEID  .ToString() ) ) ; 
        __context__.SourceCodeLine = 143;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STATUS == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 145;
            Functions.Pulse ( 200, FRIENDLYNAMESAVED ) ; 
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
        
        __context__.SourceCodeLine = 157;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 159;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_17__" , 500 , __SPLS_TMPVAR__WAITLABEL_17___Callback ) ;
        __context__.SourceCodeLine = 165;
        PULSETIME = (ushort) ( 25 ) ; 
        __context__.SourceCodeLine = 166;
        ONLEVEL = (ushort) ( 65535 ) ; 
        __context__.SourceCodeLine = 167;
        PRESETRAMP .  rampIsAbsolute = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    
public void __SPLS_TMPVAR__WAITLABEL_17___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 161;
            // RegisterEvent( ZHELP , ONDATACHANGE , HANDLEDATACHANGE ) 
            try { g_criticalSection.Enter(); ZHELP .OnDataChange  += HANDLEDATACHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 162;
            ZHELP . Initialize ( ZONEID  .ToString()) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    PRESETRAMP  = new RAMP_INFO();
    PRESETRAMP .PopulateDefaults();
    
    ZONEON = new Crestron.Logos.SplusObjects.DigitalInput( ZONEON__DigitalInput__, this );
    m_DigitalInputList.Add( ZONEON__DigitalInput__, ZONEON );
    
    ZONEOFF = new Crestron.Logos.SplusObjects.DigitalInput( ZONEOFF__DigitalInput__, this );
    m_DigitalInputList.Add( ZONEOFF__DigitalInput__, ZONEOFF );
    
    ZONEONOFF = new Crestron.Logos.SplusObjects.DigitalInput( ZONEONOFF__DigitalInput__, this );
    m_DigitalInputList.Add( ZONEONOFF__DigitalInput__, ZONEONOFF );
    
    SAVEONLVL = new Crestron.Logos.SplusObjects.DigitalInput( SAVEONLVL__DigitalInput__, this );
    m_DigitalInputList.Add( SAVEONLVL__DigitalInput__, SAVEONLVL );
    
    SAVEOFFLVL = new Crestron.Logos.SplusObjects.DigitalInput( SAVEOFFLVL__DigitalInput__, this );
    m_DigitalInputList.Add( SAVEOFFLVL__DigitalInput__, SAVEOFFLVL );
    
    ZONEONFB = new Crestron.Logos.SplusObjects.DigitalInput( ZONEONFB__DigitalInput__, this );
    m_DigitalInputList.Add( ZONEONFB__DigitalInput__, ZONEONFB );
    
    DALIFB = new Crestron.Logos.SplusObjects.DigitalOutput( DALIFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DALIFB__DigitalOutput__, DALIFB );
    
    DIMMABLEFB = new Crestron.Logos.SplusObjects.DigitalOutput( DIMMABLEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DIMMABLEFB__DigitalOutput__, DIMMABLEFB );
    
    INUSEFB = new Crestron.Logos.SplusObjects.DigitalOutput( INUSEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( INUSEFB__DigitalOutput__, INUSEFB );
    
    RGBFB = new Crestron.Logos.SplusObjects.DigitalOutput( RGBFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( RGBFB__DigitalOutput__, RGBFB );
    
    HARVESTEDFB = new Crestron.Logos.SplusObjects.DigitalOutput( HARVESTEDFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( HARVESTEDFB__DigitalOutput__, HARVESTEDFB );
    
    HARVESTENABLEFB = new Crestron.Logos.SplusObjects.DigitalOutput( HARVESTENABLEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( HARVESTENABLEFB__DigitalOutput__, HARVESTENABLEFB );
    
    ONLVLSAVED = new Crestron.Logos.SplusObjects.DigitalOutput( ONLVLSAVED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ONLVLSAVED__DigitalOutput__, ONLVLSAVED );
    
    OFFLVLSAVED = new Crestron.Logos.SplusObjects.DigitalOutput( OFFLVLSAVED__DigitalOutput__, this );
    m_DigitalOutputList.Add( OFFLVLSAVED__DigitalOutput__, OFFLVLSAVED );
    
    RAISEFROMOFF = new Crestron.Logos.SplusObjects.DigitalOutput( RAISEFROMOFF__DigitalOutput__, this );
    m_DigitalOutputList.Add( RAISEFROMOFF__DigitalOutput__, RAISEFROMOFF );
    
    FRIENDLYNAMESAVED = new Crestron.Logos.SplusObjects.DigitalOutput( FRIENDLYNAMESAVED__DigitalOutput__, this );
    m_DigitalOutputList.Add( FRIENDLYNAMESAVED__DigitalOutput__, FRIENDLYNAMESAVED );
    
    INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITIALIZED__DigitalOutput__, INITIALIZED );
    
    TRUEFB = new Crestron.Logos.SplusObjects.AnalogInput( TRUEFB__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TRUEFB__AnalogSerialInput__, TRUEFB );
    
    ZONELEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( ZONELEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ZONELEVEL__AnalogSerialOutput__, ZONELEVEL );
    
    SLEWRATE = new Crestron.Logos.SplusObjects.AnalogOutput( SLEWRATE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SLEWRATE__AnalogSerialOutput__, SLEWRATE );
    
    RAMPTIME = new Crestron.Logos.SplusObjects.AnalogOutput( RAMPTIME__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RAMPTIME__AnalogSerialOutput__, RAMPTIME );
    
    WATTAGE = new Crestron.Logos.SplusObjects.AnalogOutput( WATTAGE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( WATTAGE__AnalogSerialOutput__, WATTAGE );
    
    OFFLEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( OFFLEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( OFFLEVEL__AnalogSerialOutput__, OFFLEVEL );
    
    FRIENDLYNAMEUPDATE = new Crestron.Logos.SplusObjects.StringInput( FRIENDLYNAMEUPDATE__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( FRIENDLYNAMEUPDATE__AnalogSerialInput__, FRIENDLYNAMEUPDATE );
    
    FRIENDLYNAME = new Crestron.Logos.SplusObjects.StringOutput( FRIENDLYNAME__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRIENDLYNAME__AnalogSerialOutput__, FRIENDLYNAME );
    
    ZONEID = new StringParameter( ZONEID__Parameter__, this );
    m_ParameterList.Add( ZONEID__Parameter__, ZONEID );
    
    __SPLS_TMPVAR__WAITLABEL_17___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_17___CallbackFn );
    
    ZONEON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZONEON_OnPush_0, false ) );
    ZONEOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZONEOFF_OnPush_1, false ) );
    ZONEONOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZONEONOFF_OnPush_2, false ) );
    SAVEONLVL.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVEONLVL_OnPush_3, false ) );
    SAVEOFFLVL.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVEOFFLVL_OnPush_4, false ) );
    FRIENDLYNAMEUPDATE.OnSerialChange.Add( new InputChangeHandlerWrapper( FRIENDLYNAMEUPDATE_OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    ZHELP  = new Zone_Control_Helper.ZoneHelper();
    
    
}

public UserModuleClass_RBI_SINGLE_ZONE_CONTROL_SPLUS_V5B ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_17___Callback;


const uint ZONEON__DigitalInput__ = 0;
const uint ZONEOFF__DigitalInput__ = 1;
const uint ZONEONOFF__DigitalInput__ = 2;
const uint SAVEONLVL__DigitalInput__ = 3;
const uint SAVEOFFLVL__DigitalInput__ = 4;
const uint ZONEONFB__DigitalInput__ = 5;
const uint TRUEFB__AnalogSerialInput__ = 0;
const uint FRIENDLYNAMEUPDATE__AnalogSerialInput__ = 1;
const uint DALIFB__DigitalOutput__ = 0;
const uint DIMMABLEFB__DigitalOutput__ = 1;
const uint INUSEFB__DigitalOutput__ = 2;
const uint RGBFB__DigitalOutput__ = 3;
const uint HARVESTEDFB__DigitalOutput__ = 4;
const uint HARVESTENABLEFB__DigitalOutput__ = 5;
const uint ONLVLSAVED__DigitalOutput__ = 6;
const uint OFFLVLSAVED__DigitalOutput__ = 7;
const uint RAISEFROMOFF__DigitalOutput__ = 8;
const uint FRIENDLYNAMESAVED__DigitalOutput__ = 9;
const uint INITIALIZED__DigitalOutput__ = 10;
const uint ZONELEVEL__AnalogSerialOutput__ = 0;
const uint SLEWRATE__AnalogSerialOutput__ = 1;
const uint RAMPTIME__AnalogSerialOutput__ = 2;
const uint WATTAGE__AnalogSerialOutput__ = 3;
const uint OFFLEVEL__AnalogSerialOutput__ = 4;
const uint FRIENDLYNAME__AnalogSerialOutput__ = 5;
const uint ZONEID__Parameter__ = 10;

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
