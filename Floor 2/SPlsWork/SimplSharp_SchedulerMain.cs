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
using ClcScheduler;

namespace UserModule_SIMPLSHARP_SCHEDULERMAIN
{
    public class UserModuleClass_SIMPLSHARP_SCHEDULERMAIN : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput DISABLE;
        Crestron.Logos.SplusObjects.DigitalInput ENABLETOGGLE;
        Crestron.Logos.SplusObjects.DigitalInput CONFIGLOAD;
        Crestron.Logos.SplusObjects.DigitalInput CONFIGSAVE;
        Crestron.Logos.SplusObjects.StringInput LATITUDEOVERRIDE;
        Crestron.Logos.SplusObjects.StringInput LONGITUDEOVERRIDE;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLED;
        Crestron.Logos.SplusObjects.DigitalOutput CONFIGLOADED_F;
        Crestron.Logos.SplusObjects.DigitalOutput CONFIGSAVED_F;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> GLOBALACTION;
        StringParameter LATITUDE;
        StringParameter LONGITUDE;
        StringParameter STORAGEBASEDIRECTORY;
        InOutArray<StringParameter> GLOBALACTIONNAME;
        CrestronString LAT;
        CrestronString LON;
        public void HANDLEENABLEDCHG ( object __sender__ /*ClcScheduler.Config SENDER */, EventArgs ARGS ) 
            { 
            Config  SENDER  = (Config )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 126;
                ENABLED  .Value = (ushort) ( CentralScheduler.Config.EnabledSplus ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void HANDLECONFIGLOADED ( object __sender__ /*ClcScheduler.CentralScheduler SENDER */, EventArgs ARGS ) 
            { 
            ClcScheduler.Config CFG;
            CFG  = new ClcScheduler.Config();
            
             CentralScheduler.Config.LatitudeStr  =( LAT )  .ToString()  ;  
 
             CentralScheduler.Config.LongitudeStr  =( LON )  .ToString()  ;  
 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 132;
                CFG =CentralScheduler.Config; 
                __context__.SourceCodeLine = 133;
                // RegisterEvent( CFG , ONENABLEDCHANGE , HANDLEENABLEDCHG ) 
                try { g_criticalSection.Enter(); CFG .OnEnabledChange  += HANDLEENABLEDCHG; } finally { g_criticalSection.Leave(); }
                ; 
                __context__.SourceCodeLine = 134;
                ENABLED  .Value = (ushort) ( CentralScheduler.Config.EnabledSplus ) ; 
                __context__.SourceCodeLine = 135;
                CONFIGLOADED_F  .Value = (ushort) ( 1 ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void HANDLECONFIGSAVED ( object __sender__ /*ClcScheduler.CentralScheduler SENDER */, EventArgs ARGS ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 139;
                Functions.Pulse ( 100, CONFIGSAVED_F ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void HANDLEGLOBALACTIONCHG ( object __sender__ /*ClcScheduler.GlobalActionHelper SENDER */, ClcScheduler.GlobalActionEventArgs ARGS ) 
            { 
            GlobalActionHelper  SENDER  = (GlobalActionHelper )__sender__;
            ushort I = 0;
            ushort ACTIONID = 0;
            
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 144;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(ARGS.ActionsCount - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 145;
                    ACTIONID = (ushort) ( ARGS.Actions[ I ] ) ; 
                    __context__.SourceCodeLine = 146;
                    if ( Functions.TestForTrue  ( ( IsSignalDefined( GLOBALACTION[ ACTIONID ] ))  ) ) 
                        {
                        __context__.SourceCodeLine = 147;
                        Functions.Pulse ( 1, GLOBALACTION [ ACTIONID] ) ; 
                        }
                    
                    __context__.SourceCodeLine = 144;
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        private void LOADCONFIG (  SplusExecutionContext __context__ ) 
            { 
             CentralScheduler.LoadConfig()  ;  
 
            
            
            }
            
        object ENABLE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                 CentralScheduler.Config.EnabledSplus  =  (ushort)( 1 )  ;  
 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DISABLE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
             CentralScheduler.Config.EnabledSplus  =  (ushort)( 0 )  ;  
 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ENABLETOGGLE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
         CentralScheduler.Config.EnabledSplus  =  (ushort)( Functions.Not( CentralScheduler.Config.EnabledSplus ) )  ;  
 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONFIGLOAD_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 163;
        LOADCONFIG (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONFIGSAVE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
         CentralScheduler.SaveConfig()  ;  
 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LATITUDEOVERRIDE_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 165;
        LAT  .UpdateValue ( LATITUDEOVERRIDE  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object LONGITUDEOVERRIDE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 166;
        LON  .UpdateValue ( LONGITUDEOVERRIDE  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    ClcScheduler.GlobalActionHelper HELPER;
    HELPER  = new ClcScheduler.GlobalActionHelper();
    
     CentralScheduler.SetStorageBaseDirectory(  STORAGEBASEDIRECTORY  .ToString() )  ;  
 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 178;
        HELPER =CentralScheduler.GlobalActionHelper; 
        __context__.SourceCodeLine = 179;
        LAT  .UpdateValue ( LATITUDE  ) ; 
        __context__.SourceCodeLine = 180;
        LON  .UpdateValue ( LONGITUDE  ) ; 
        __context__.SourceCodeLine = 181;
        // RegisterEvent( CentralScheduler , ONCONFIGLOADED , HANDLECONFIGLOADED ) 
        try { g_criticalSection.Enter(); CentralScheduler .OnConfigLoaded  += HANDLECONFIGLOADED; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 182;
        // RegisterEvent( CentralScheduler , ONCONFIGSAVED , HANDLECONFIGSAVED ) 
        try { g_criticalSection.Enter(); CentralScheduler .OnConfigSaved  += HANDLECONFIGSAVED; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 183;
        // RegisterEvent( HELPER , ONGLOBALACTION , HANDLEGLOBALACTIONCHG ) 
        try { g_criticalSection.Enter(); HELPER .OnGlobalAction  += HANDLEGLOBALACTIONCHG; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 184;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)50; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 185;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( GLOBALACTION[ I ] ))  ) ) 
                {
                __context__.SourceCodeLine = 186;
                 CentralScheduler.RegisterGlobalAction( (ushort)( I ) ,  GLOBALACTIONNAME[ I ] .ToString() )  ;  
 
                }
            
            __context__.SourceCodeLine = 184;
            }
        
        __context__.SourceCodeLine = 187;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 188;
        Functions.Delay (  (int) ( 2000 ) ) ; 
        __context__.SourceCodeLine = 189;
        if ( Functions.TestForTrue  ( ( CONFIGLOAD  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 190;
            LOADCONFIG (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    LAT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    LON  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    DISABLE = new Crestron.Logos.SplusObjects.DigitalInput( DISABLE__DigitalInput__, this );
    m_DigitalInputList.Add( DISABLE__DigitalInput__, DISABLE );
    
    ENABLETOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLETOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLETOGGLE__DigitalInput__, ENABLETOGGLE );
    
    CONFIGLOAD = new Crestron.Logos.SplusObjects.DigitalInput( CONFIGLOAD__DigitalInput__, this );
    m_DigitalInputList.Add( CONFIGLOAD__DigitalInput__, CONFIGLOAD );
    
    CONFIGSAVE = new Crestron.Logos.SplusObjects.DigitalInput( CONFIGSAVE__DigitalInput__, this );
    m_DigitalInputList.Add( CONFIGSAVE__DigitalInput__, CONFIGSAVE );
    
    ENABLED = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLED__DigitalOutput__, ENABLED );
    
    CONFIGLOADED_F = new Crestron.Logos.SplusObjects.DigitalOutput( CONFIGLOADED_F__DigitalOutput__, this );
    m_DigitalOutputList.Add( CONFIGLOADED_F__DigitalOutput__, CONFIGLOADED_F );
    
    CONFIGSAVED_F = new Crestron.Logos.SplusObjects.DigitalOutput( CONFIGSAVED_F__DigitalOutput__, this );
    m_DigitalOutputList.Add( CONFIGSAVED_F__DigitalOutput__, CONFIGSAVED_F );
    
    GLOBALACTION = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        GLOBALACTION[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( GLOBALACTION__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( GLOBALACTION__DigitalOutput__ + i, GLOBALACTION[i+1] );
    }
    
    LATITUDEOVERRIDE = new Crestron.Logos.SplusObjects.StringInput( LATITUDEOVERRIDE__AnalogSerialInput__, 15, this );
    m_StringInputList.Add( LATITUDEOVERRIDE__AnalogSerialInput__, LATITUDEOVERRIDE );
    
    LONGITUDEOVERRIDE = new Crestron.Logos.SplusObjects.StringInput( LONGITUDEOVERRIDE__AnalogSerialInput__, 15, this );
    m_StringInputList.Add( LONGITUDEOVERRIDE__AnalogSerialInput__, LONGITUDEOVERRIDE );
    
    LATITUDE = new StringParameter( LATITUDE__Parameter__, this );
    m_ParameterList.Add( LATITUDE__Parameter__, LATITUDE );
    
    LONGITUDE = new StringParameter( LONGITUDE__Parameter__, this );
    m_ParameterList.Add( LONGITUDE__Parameter__, LONGITUDE );
    
    STORAGEBASEDIRECTORY = new StringParameter( STORAGEBASEDIRECTORY__Parameter__, this );
    m_ParameterList.Add( STORAGEBASEDIRECTORY__Parameter__, STORAGEBASEDIRECTORY );
    
    GLOBALACTIONNAME = new InOutArray<StringParameter>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        GLOBALACTIONNAME[i+1] = new StringParameter( GLOBALACTIONNAME__Parameter__ + i, GLOBALACTIONNAME__Parameter__, this );
        m_ParameterList.Add( GLOBALACTIONNAME__Parameter__ + i, GLOBALACTIONNAME[i+1] );
    }
    
    
    ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLE_OnPush_0, false ) );
    DISABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISABLE_OnPush_1, false ) );
    ENABLETOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLETOGGLE_OnPush_2, false ) );
    CONFIGLOAD.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONFIGLOAD_OnPush_3, false ) );
    CONFIGSAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONFIGSAVE_OnPush_4, false ) );
    LATITUDEOVERRIDE.OnSerialChange.Add( new InputChangeHandlerWrapper( LATITUDEOVERRIDE_OnChange_5, false ) );
    LONGITUDEOVERRIDE.OnSerialChange.Add( new InputChangeHandlerWrapper( LONGITUDEOVERRIDE_OnChange_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SIMPLSHARP_SCHEDULERMAIN ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ENABLE__DigitalInput__ = 0;
const uint DISABLE__DigitalInput__ = 1;
const uint ENABLETOGGLE__DigitalInput__ = 2;
const uint CONFIGLOAD__DigitalInput__ = 3;
const uint CONFIGSAVE__DigitalInput__ = 4;
const uint LATITUDEOVERRIDE__AnalogSerialInput__ = 0;
const uint LONGITUDEOVERRIDE__AnalogSerialInput__ = 1;
const uint ENABLED__DigitalOutput__ = 0;
const uint CONFIGLOADED_F__DigitalOutput__ = 1;
const uint CONFIGSAVED_F__DigitalOutput__ = 2;
const uint GLOBALACTION__DigitalOutput__ = 3;
const uint LATITUDE__Parameter__ = 10;
const uint LONGITUDE__Parameter__ = 11;
const uint STORAGEBASEDIRECTORY__Parameter__ = 12;
const uint GLOBALACTIONNAME__Parameter__ = 13;

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
