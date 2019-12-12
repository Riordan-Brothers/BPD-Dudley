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

namespace UserModule_SIMPLSHARP_SCHEDULERSPACE
{
    public class UserModuleClass_SIMPLSHARP_SCHEDULERSPACE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput REGISTERSPACE;
        Crestron.Logos.SplusObjects.DigitalInput SUPPORTSKEYPADACTIONS;
        Crestron.Logos.SplusObjects.DigitalInput SUPPORTSOCCUPANCYACTIONS;
        Crestron.Logos.SplusObjects.DigitalInput SUPPORTSPHOTOCELLACTIONS;
        Crestron.Logos.SplusObjects.StringInput SPACEID_OVERRIDE;
        Crestron.Logos.SplusObjects.StringInput SPACENAME_OVERRIDE;
        Crestron.Logos.SplusObjects.StringInput SCENENAME0_OVERRIDE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> SCENENAME_OVERRIDE;
        Crestron.Logos.SplusObjects.DigitalOutput KEYPAD_ENABLE;
        Crestron.Logos.SplusObjects.DigitalOutput KEYPAD_DISABLE;
        Crestron.Logos.SplusObjects.DigitalOutput OCCUPANCY_SETOCCUPANCY;
        Crestron.Logos.SplusObjects.DigitalOutput OCCUPANCY_SETVACANCY;
        Crestron.Logos.SplusObjects.DigitalOutput OCCUPANCY_SETDISABLED;
        Crestron.Logos.SplusObjects.DigitalOutput PHOTOCELL_ENABLE;
        Crestron.Logos.SplusObjects.DigitalOutput PHOTOCELL_DISABLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> LOCALACTION;
        Crestron.Logos.SplusObjects.AnalogOutput RECALLSCENE__POUND__;
        StringParameter SPACEID;
        StringParameter SPACENAME;
        StringParameter SCENENAME0;
        InOutArray<StringParameter> SCENENAME;
        InOutArray<StringParameter> LOCALACTIONNAME;
        ClcScheduler.Space SP;
        CrestronString _SPACEID;
        CrestronString _SPACENAME;
        ushort STARTED = 0;
        public void HANDLESPACEACTION ( object __sender__ /*ClcScheduler.Space SENDER */, ClcScheduler.SpaceActionEventArgs ARGS ) 
            { 
            Space  SENDER  = (Space )__sender__;
            ushort DISCRETEACTIONCOUNT = 0;
            ushort I = 0;
            ushort DISCRETEACTION = 0;
            
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 113;
                if ( Functions.TestForTrue  ( ( SUPPORTSKEYPADACTIONS  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 114;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Actions.KeypadAction == eSpaceKeypadAction.Enable))  ) ) 
                        {
                        __context__.SourceCodeLine = 115;
                        Functions.Pulse ( 1, KEYPAD_ENABLE ) ; 
                        }
                    
                    __context__.SourceCodeLine = 116;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Actions.KeypadAction == eSpaceKeypadAction.Disable))  ) ) 
                        {
                        __context__.SourceCodeLine = 117;
                        Functions.Pulse ( 1, KEYPAD_DISABLE ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 119;
                if ( Functions.TestForTrue  ( ( SUPPORTSOCCUPANCYACTIONS  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 120;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Actions.OccupancyAction == eSpaceOccupancyAction.Occupancy))  ) ) 
                        {
                        __context__.SourceCodeLine = 121;
                        Functions.Pulse ( 1, OCCUPANCY_SETOCCUPANCY ) ; 
                        }
                    
                    __context__.SourceCodeLine = 122;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Actions.OccupancyAction == eSpaceOccupancyAction.Vacancy))  ) ) 
                        {
                        __context__.SourceCodeLine = 123;
                        Functions.Pulse ( 1, OCCUPANCY_SETVACANCY ) ; 
                        }
                    
                    __context__.SourceCodeLine = 124;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Actions.OccupancyAction == eSpaceOccupancyAction.Disable))  ) ) 
                        {
                        __context__.SourceCodeLine = 125;
                        Functions.Pulse ( 1, OCCUPANCY_SETDISABLED ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 127;
                if ( Functions.TestForTrue  ( ( SUPPORTSPHOTOCELLACTIONS  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 128;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Actions.PhotocellAction == eSpacePhotocellAction.Enable))  ) ) 
                        {
                        __context__.SourceCodeLine = 129;
                        Functions.Pulse ( 1, PHOTOCELL_ENABLE ) ; 
                        }
                    
                    __context__.SourceCodeLine = 130;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.Actions.PhotocellAction == eSpacePhotocellAction.Disable))  ) ) 
                        {
                        __context__.SourceCodeLine = 131;
                        Functions.Pulse ( 1, PHOTOCELL_DISABLE ) ; 
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 133;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ARGS.Actions.RecallScene >= 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 134;
                    RECALLSCENE__POUND__  .Value = (ushort) ( ARGS.Actions.RecallScene ) ; 
                    }
                
                __context__.SourceCodeLine = 135;
                DISCRETEACTIONCOUNT = (ushort) ( ARGS.Actions.DiscreteActionsCount ) ; 
                __context__.SourceCodeLine = 136;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DISCRETEACTIONCOUNT > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 137;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)(DISCRETEACTIONCOUNT - 1); 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 138;
                        DISCRETEACTION = (ushort) ( ARGS.Actions.DiscreteActions[ I ] ) ; 
                        __context__.SourceCodeLine = 139;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DISCRETEACTION > 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 140;
                            if ( Functions.TestForTrue  ( ( IsSignalDefined( LOCALACTION[ DISCRETEACTION ] ))  ) ) 
                                {
                                __context__.SourceCodeLine = 141;
                                Functions.Pulse ( 1, LOCALACTION [ DISCRETEACTION] ) ; 
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 137;
                        } 
                    
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        private void REGISTER (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 147;
            SP . Register ( _SPACEID .ToString(), _SPACENAME .ToString()) ; 
            
            }
            
        object REGISTERSPACE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 154;
                if ( Functions.TestForTrue  ( ( STARTED)  ) ) 
                    {
                    __context__.SourceCodeLine = 154;
                    REGISTER (  __context__  ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SPACEID_OVERRIDE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 156;
            _SPACEID  .UpdateValue ( SPACEID_OVERRIDE  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SPACENAME_OVERRIDE_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 159;
        _SPACENAME  .UpdateValue ( SPACENAME_OVERRIDE  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SCENENAME0_OVERRIDE_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 161;
        SP . RegisterSceneName ( (ushort)( 0 ), SCENENAME0  .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SCENENAME_OVERRIDE_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 164;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 165;
        SP . RegisterSceneName ( (ushort)( I ), SCENENAME_OVERRIDE[ I ] .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 177;
        // RegisterEvent( SP , ONSPACEACTION , HANDLESPACEACTION ) 
        try { g_criticalSection.Enter(); SP .OnSpaceAction  += HANDLESPACEACTION; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 178;
        SP . RegisterSceneName ( (ushort)( 0 ), SCENENAME0  .ToString()) ; 
        __context__.SourceCodeLine = 179;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)10; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 180;
            SP . RegisterSceneName ( (ushort)( I ), SCENENAME[ I ] .ToString()) ; 
            __context__.SourceCodeLine = 179;
            }
        
        __context__.SourceCodeLine = 181;
        SP . UpdateSupportedActions ( (ushort)( SUPPORTSKEYPADACTIONS  .Value ), (ushort)( SUPPORTSOCCUPANCYACTIONS  .Value ), (ushort)( SUPPORTSPHOTOCELLACTIONS  .Value )) ; 
        __context__.SourceCodeLine = 182;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)50; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            {
            __context__.SourceCodeLine = 183;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( LOCALACTION[ I ] ))  ) ) 
                {
                __context__.SourceCodeLine = 184;
                SP . RegisterDiscreteAction ( (ushort)( I ), LOCALACTIONNAME[ I ] .ToString()) ; 
                }
            
            __context__.SourceCodeLine = 182;
            }
        
        __context__.SourceCodeLine = 185;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 186;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( IsSignalDefined( SPACEID_OVERRIDE ) ) ) && Functions.TestForTrue ( Functions.Not( IsSignalDefined( SPACENAME_OVERRIDE ) ) )) ) ) && Functions.TestForTrue ( REGISTERSPACE  .Value )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 187;
            _SPACEID  .UpdateValue ( SPACEID  ) ; 
            __context__.SourceCodeLine = 188;
            _SPACENAME  .UpdateValue ( SPACENAME  ) ; 
            __context__.SourceCodeLine = 189;
            REGISTER (  __context__  ) ; 
            } 
        
        __context__.SourceCodeLine = 191;
        STARTED = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _SPACEID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    _SPACENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    
    REGISTERSPACE = new Crestron.Logos.SplusObjects.DigitalInput( REGISTERSPACE__DigitalInput__, this );
    m_DigitalInputList.Add( REGISTERSPACE__DigitalInput__, REGISTERSPACE );
    
    SUPPORTSKEYPADACTIONS = new Crestron.Logos.SplusObjects.DigitalInput( SUPPORTSKEYPADACTIONS__DigitalInput__, this );
    m_DigitalInputList.Add( SUPPORTSKEYPADACTIONS__DigitalInput__, SUPPORTSKEYPADACTIONS );
    
    SUPPORTSOCCUPANCYACTIONS = new Crestron.Logos.SplusObjects.DigitalInput( SUPPORTSOCCUPANCYACTIONS__DigitalInput__, this );
    m_DigitalInputList.Add( SUPPORTSOCCUPANCYACTIONS__DigitalInput__, SUPPORTSOCCUPANCYACTIONS );
    
    SUPPORTSPHOTOCELLACTIONS = new Crestron.Logos.SplusObjects.DigitalInput( SUPPORTSPHOTOCELLACTIONS__DigitalInput__, this );
    m_DigitalInputList.Add( SUPPORTSPHOTOCELLACTIONS__DigitalInput__, SUPPORTSPHOTOCELLACTIONS );
    
    KEYPAD_ENABLE = new Crestron.Logos.SplusObjects.DigitalOutput( KEYPAD_ENABLE__DigitalOutput__, this );
    m_DigitalOutputList.Add( KEYPAD_ENABLE__DigitalOutput__, KEYPAD_ENABLE );
    
    KEYPAD_DISABLE = new Crestron.Logos.SplusObjects.DigitalOutput( KEYPAD_DISABLE__DigitalOutput__, this );
    m_DigitalOutputList.Add( KEYPAD_DISABLE__DigitalOutput__, KEYPAD_DISABLE );
    
    OCCUPANCY_SETOCCUPANCY = new Crestron.Logos.SplusObjects.DigitalOutput( OCCUPANCY_SETOCCUPANCY__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCCUPANCY_SETOCCUPANCY__DigitalOutput__, OCCUPANCY_SETOCCUPANCY );
    
    OCCUPANCY_SETVACANCY = new Crestron.Logos.SplusObjects.DigitalOutput( OCCUPANCY_SETVACANCY__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCCUPANCY_SETVACANCY__DigitalOutput__, OCCUPANCY_SETVACANCY );
    
    OCCUPANCY_SETDISABLED = new Crestron.Logos.SplusObjects.DigitalOutput( OCCUPANCY_SETDISABLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCCUPANCY_SETDISABLED__DigitalOutput__, OCCUPANCY_SETDISABLED );
    
    PHOTOCELL_ENABLE = new Crestron.Logos.SplusObjects.DigitalOutput( PHOTOCELL_ENABLE__DigitalOutput__, this );
    m_DigitalOutputList.Add( PHOTOCELL_ENABLE__DigitalOutput__, PHOTOCELL_ENABLE );
    
    PHOTOCELL_DISABLE = new Crestron.Logos.SplusObjects.DigitalOutput( PHOTOCELL_DISABLE__DigitalOutput__, this );
    m_DigitalOutputList.Add( PHOTOCELL_DISABLE__DigitalOutput__, PHOTOCELL_DISABLE );
    
    LOCALACTION = new InOutArray<DigitalOutput>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        LOCALACTION[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( LOCALACTION__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( LOCALACTION__DigitalOutput__ + i, LOCALACTION[i+1] );
    }
    
    RECALLSCENE__POUND__ = new Crestron.Logos.SplusObjects.AnalogOutput( RECALLSCENE__POUND____AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RECALLSCENE__POUND____AnalogSerialOutput__, RECALLSCENE__POUND__ );
    
    SPACEID_OVERRIDE = new Crestron.Logos.SplusObjects.StringInput( SPACEID_OVERRIDE__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( SPACEID_OVERRIDE__AnalogSerialInput__, SPACEID_OVERRIDE );
    
    SPACENAME_OVERRIDE = new Crestron.Logos.SplusObjects.StringInput( SPACENAME_OVERRIDE__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( SPACENAME_OVERRIDE__AnalogSerialInput__, SPACENAME_OVERRIDE );
    
    SCENENAME0_OVERRIDE = new Crestron.Logos.SplusObjects.StringInput( SCENENAME0_OVERRIDE__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( SCENENAME0_OVERRIDE__AnalogSerialInput__, SCENENAME0_OVERRIDE );
    
    SCENENAME_OVERRIDE = new InOutArray<StringInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SCENENAME_OVERRIDE[i+1] = new Crestron.Logos.SplusObjects.StringInput( SCENENAME_OVERRIDE__AnalogSerialInput__ + i, SCENENAME_OVERRIDE__AnalogSerialInput__, 50, this );
        m_StringInputList.Add( SCENENAME_OVERRIDE__AnalogSerialInput__ + i, SCENENAME_OVERRIDE[i+1] );
    }
    
    SPACEID = new StringParameter( SPACEID__Parameter__, this );
    m_ParameterList.Add( SPACEID__Parameter__, SPACEID );
    
    SPACENAME = new StringParameter( SPACENAME__Parameter__, this );
    m_ParameterList.Add( SPACENAME__Parameter__, SPACENAME );
    
    SCENENAME0 = new StringParameter( SCENENAME0__Parameter__, this );
    m_ParameterList.Add( SCENENAME0__Parameter__, SCENENAME0 );
    
    SCENENAME = new InOutArray<StringParameter>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SCENENAME[i+1] = new StringParameter( SCENENAME__Parameter__ + i, SCENENAME__Parameter__, this );
        m_ParameterList.Add( SCENENAME__Parameter__ + i, SCENENAME[i+1] );
    }
    
    LOCALACTIONNAME = new InOutArray<StringParameter>( 50, this );
    for( uint i = 0; i < 50; i++ )
    {
        LOCALACTIONNAME[i+1] = new StringParameter( LOCALACTIONNAME__Parameter__ + i, LOCALACTIONNAME__Parameter__, this );
        m_ParameterList.Add( LOCALACTIONNAME__Parameter__ + i, LOCALACTIONNAME[i+1] );
    }
    
    
    REGISTERSPACE.OnDigitalPush.Add( new InputChangeHandlerWrapper( REGISTERSPACE_OnPush_0, false ) );
    SPACEID_OVERRIDE.OnSerialChange.Add( new InputChangeHandlerWrapper( SPACEID_OVERRIDE_OnChange_1, false ) );
    SPACENAME_OVERRIDE.OnSerialChange.Add( new InputChangeHandlerWrapper( SPACENAME_OVERRIDE_OnChange_2, false ) );
    SCENENAME0_OVERRIDE.OnSerialChange.Add( new InputChangeHandlerWrapper( SCENENAME0_OVERRIDE_OnChange_3, false ) );
    for( uint i = 0; i < 10; i++ )
        SCENENAME_OVERRIDE[i+1].OnSerialChange.Add( new InputChangeHandlerWrapper( SCENENAME_OVERRIDE_OnChange_4, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    SP  = new ClcScheduler.Space();
    
    
}

public UserModuleClass_SIMPLSHARP_SCHEDULERSPACE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint REGISTERSPACE__DigitalInput__ = 0;
const uint SUPPORTSKEYPADACTIONS__DigitalInput__ = 1;
const uint SUPPORTSOCCUPANCYACTIONS__DigitalInput__ = 2;
const uint SUPPORTSPHOTOCELLACTIONS__DigitalInput__ = 3;
const uint SPACEID_OVERRIDE__AnalogSerialInput__ = 0;
const uint SPACENAME_OVERRIDE__AnalogSerialInput__ = 1;
const uint SCENENAME0_OVERRIDE__AnalogSerialInput__ = 2;
const uint SCENENAME_OVERRIDE__AnalogSerialInput__ = 3;
const uint KEYPAD_ENABLE__DigitalOutput__ = 0;
const uint KEYPAD_DISABLE__DigitalOutput__ = 1;
const uint OCCUPANCY_SETOCCUPANCY__DigitalOutput__ = 2;
const uint OCCUPANCY_SETVACANCY__DigitalOutput__ = 3;
const uint OCCUPANCY_SETDISABLED__DigitalOutput__ = 4;
const uint PHOTOCELL_ENABLE__DigitalOutput__ = 5;
const uint PHOTOCELL_DISABLE__DigitalOutput__ = 6;
const uint LOCALACTION__DigitalOutput__ = 7;
const uint RECALLSCENE__POUND____AnalogSerialOutput__ = 0;
const uint SPACEID__Parameter__ = 10;
const uint SPACENAME__Parameter__ = 11;
const uint SCENENAME0__Parameter__ = 12;
const uint SCENENAME__Parameter__ = 13;
const uint LOCALACTIONNAME__Parameter__ = 23;

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
