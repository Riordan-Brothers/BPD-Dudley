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

namespace UserModule_RBI_MOTION_LOGIC_SPLUS_V1D
{
    public class UserModuleClass_RBI_MOTION_LOGIC_SPLUS_V1D : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SENSORIN;
        Crestron.Logos.SplusObjects.DigitalInput FORCEOCCUPANCY;
        Crestron.Logos.SplusObjects.DigitalInput FORCEVACANCY;
        Crestron.Logos.SplusObjects.DigitalInput TESTMODEHELD;
        Crestron.Logos.SplusObjects.AnalogInput TIMEOUTSECONDS;
        Crestron.Logos.SplusObjects.AnalogInput TIMEOUTTENTHS;
        Crestron.Logos.SplusObjects.AnalogInput OCCENABLEDISABLE;
        Crestron.Logos.SplusObjects.AnalogInput VACENABLEDISABLE;
        Crestron.Logos.SplusObjects.DigitalOutput OCCUPIEDHELD;
        Crestron.Logos.SplusObjects.DigitalOutput OCCUPANCYENABLEFB;
        Crestron.Logos.SplusObjects.DigitalOutput OCCUPANCYDISABLEFB;
        Crestron.Logos.SplusObjects.DigitalOutput VACANCYENABLEFB;
        Crestron.Logos.SplusObjects.DigitalOutput VACANCYDISABLEFB;
        Crestron.Logos.SplusObjects.DigitalOutput OCCUPIEDP;
        Crestron.Logos.SplusObjects.DigitalOutput VACANTP;
        Crestron.Logos.SplusObjects.AnalogOutput TIMEOUTSECONDSFB;
        Crestron.Logos.SplusObjects.AnalogOutput TIMEOUTTENTHSFB;
        UShortParameter TIMEOUTTYPE;
        ushort OCCSAVE = 0;
        ushort VACSAVE = 0;
        ushort PULSETIME = 0;
        uint TIMEOUTSAVE = 0;
        uint TRUETIMEOUT = 0;
        object OCCENABLEDISABLE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 29;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (OCCENABLEDISABLE  .UshortValue == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 31;
                    OCCUPANCYENABLEFB  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 32;
                    OCCUPANCYDISABLEFB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 34;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (OCCSAVE == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 36;
                        Functions.Pulse ( PULSETIME, OCCUPIEDP ) ; 
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 42;
                    OCCUPANCYENABLEFB  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 43;
                    OCCUPANCYDISABLEFB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object VACENABLEDISABLE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 49;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VACENABLEDISABLE  .UshortValue == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 51;
                VACANCYENABLEFB  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 52;
                VACANCYDISABLEFB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 54;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VACSAVE == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 56;
                    Functions.Pulse ( PULSETIME, VACANTP ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 62;
                VACANCYENABLEFB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 63;
                VACANCYDISABLEFB  .Value = (ushort) ( 1 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object FORCEOCCUPANCY_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 69;
        CancelAllWait ( ) ; 
        __context__.SourceCodeLine = 71;
        OCCUPIEDHELD  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 72;
        OCCSAVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 73;
        VACSAVE = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FORCEVACANCY_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 78;
        CancelAllWait ( ) ; 
        __context__.SourceCodeLine = 80;
        OCCUPIEDHELD  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 81;
        OCCSAVE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 82;
        VACSAVE = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SENSORIN_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 87;
        OCCUPIEDHELD  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 88;
        OCCSAVE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 89;
        VACSAVE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 91;
        CancelAllWait ( ) ; 
        __context__.SourceCodeLine = 93;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (OCCUPANCYENABLEFB  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 95;
            Functions.Pulse ( PULSETIME, OCCUPIEDP ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SENSORIN_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 101;
        CreateWait ( "VACWAIT" , TRUETIMEOUT , VACWAIT_Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void VACWAIT_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 103;
            OCCUPIEDHELD  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 104;
            OCCSAVE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 105;
            VACSAVE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 107;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VACANCYENABLEFB  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 109;
                Functions.Pulse ( PULSETIME, VACANTP ) ; 
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object TESTMODEHELD_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 116;
        TIMEOUTSAVE = (uint) ( TRUETIMEOUT ) ; 
        __context__.SourceCodeLine = 117;
        TRUETIMEOUT = (uint) ( 0 ) ; 
        __context__.SourceCodeLine = 118;
        TIMEOUTSECONDSFB  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TESTMODEHELD_OnRelease_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 123;
        TRUETIMEOUT = (uint) ( TIMEOUTSAVE ) ; 
        __context__.SourceCodeLine = 125;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIMEOUTTYPE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 127;
            TIMEOUTSECONDSFB  .Value = (ushort) ( TIMEOUTSECONDS  .UshortValue ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 130;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIMEOUTTYPE  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 132;
                TIMEOUTTENTHSFB  .Value = (ushort) ( TIMEOUTTENTHS  .UshortValue ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TIMEOUTSECONDS_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 140;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (TIMEOUTTYPE  .Value == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( TIMEOUTSECONDS  .UshortValue > 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 142;
            TRUETIMEOUT = (uint) ( (TIMEOUTSECONDS  .UintValue * 100) ) ; 
            __context__.SourceCodeLine = 143;
            TIMEOUTSECONDSFB  .Value = (ushort) ( TIMEOUTSECONDS  .UshortValue ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TIMEOUTTENTHS_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 149;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (TIMEOUTTYPE  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( TIMEOUTTENTHS  .UshortValue > 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 151;
            TRUETIMEOUT = (uint) ( (TIMEOUTTENTHS  .UintValue * 10) ) ; 
            __context__.SourceCodeLine = 152;
            TIMEOUTTENTHSFB  .Value = (ushort) ( TIMEOUTTENTHS  .UshortValue ) ; 
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
        
        __context__.SourceCodeLine = 159;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 160;
        PULSETIME = (ushort) ( 25 ) ; 
        __context__.SourceCodeLine = 162;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIMEOUTTYPE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 164;
            TRUETIMEOUT = (uint) ( (TIMEOUTSECONDS  .UintValue * 100) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 169;
            TRUETIMEOUT = (uint) ( (TIMEOUTTENTHS  .UintValue * 10) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    SENSORIN = new Crestron.Logos.SplusObjects.DigitalInput( SENSORIN__DigitalInput__, this );
    m_DigitalInputList.Add( SENSORIN__DigitalInput__, SENSORIN );
    
    FORCEOCCUPANCY = new Crestron.Logos.SplusObjects.DigitalInput( FORCEOCCUPANCY__DigitalInput__, this );
    m_DigitalInputList.Add( FORCEOCCUPANCY__DigitalInput__, FORCEOCCUPANCY );
    
    FORCEVACANCY = new Crestron.Logos.SplusObjects.DigitalInput( FORCEVACANCY__DigitalInput__, this );
    m_DigitalInputList.Add( FORCEVACANCY__DigitalInput__, FORCEVACANCY );
    
    TESTMODEHELD = new Crestron.Logos.SplusObjects.DigitalInput( TESTMODEHELD__DigitalInput__, this );
    m_DigitalInputList.Add( TESTMODEHELD__DigitalInput__, TESTMODEHELD );
    
    OCCUPIEDHELD = new Crestron.Logos.SplusObjects.DigitalOutput( OCCUPIEDHELD__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCCUPIEDHELD__DigitalOutput__, OCCUPIEDHELD );
    
    OCCUPANCYENABLEFB = new Crestron.Logos.SplusObjects.DigitalOutput( OCCUPANCYENABLEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCCUPANCYENABLEFB__DigitalOutput__, OCCUPANCYENABLEFB );
    
    OCCUPANCYDISABLEFB = new Crestron.Logos.SplusObjects.DigitalOutput( OCCUPANCYDISABLEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCCUPANCYDISABLEFB__DigitalOutput__, OCCUPANCYDISABLEFB );
    
    VACANCYENABLEFB = new Crestron.Logos.SplusObjects.DigitalOutput( VACANCYENABLEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( VACANCYENABLEFB__DigitalOutput__, VACANCYENABLEFB );
    
    VACANCYDISABLEFB = new Crestron.Logos.SplusObjects.DigitalOutput( VACANCYDISABLEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( VACANCYDISABLEFB__DigitalOutput__, VACANCYDISABLEFB );
    
    OCCUPIEDP = new Crestron.Logos.SplusObjects.DigitalOutput( OCCUPIEDP__DigitalOutput__, this );
    m_DigitalOutputList.Add( OCCUPIEDP__DigitalOutput__, OCCUPIEDP );
    
    VACANTP = new Crestron.Logos.SplusObjects.DigitalOutput( VACANTP__DigitalOutput__, this );
    m_DigitalOutputList.Add( VACANTP__DigitalOutput__, VACANTP );
    
    TIMEOUTSECONDS = new Crestron.Logos.SplusObjects.AnalogInput( TIMEOUTSECONDS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TIMEOUTSECONDS__AnalogSerialInput__, TIMEOUTSECONDS );
    
    TIMEOUTTENTHS = new Crestron.Logos.SplusObjects.AnalogInput( TIMEOUTTENTHS__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TIMEOUTTENTHS__AnalogSerialInput__, TIMEOUTTENTHS );
    
    OCCENABLEDISABLE = new Crestron.Logos.SplusObjects.AnalogInput( OCCENABLEDISABLE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( OCCENABLEDISABLE__AnalogSerialInput__, OCCENABLEDISABLE );
    
    VACENABLEDISABLE = new Crestron.Logos.SplusObjects.AnalogInput( VACENABLEDISABLE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VACENABLEDISABLE__AnalogSerialInput__, VACENABLEDISABLE );
    
    TIMEOUTSECONDSFB = new Crestron.Logos.SplusObjects.AnalogOutput( TIMEOUTSECONDSFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TIMEOUTSECONDSFB__AnalogSerialOutput__, TIMEOUTSECONDSFB );
    
    TIMEOUTTENTHSFB = new Crestron.Logos.SplusObjects.AnalogOutput( TIMEOUTTENTHSFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( TIMEOUTTENTHSFB__AnalogSerialOutput__, TIMEOUTTENTHSFB );
    
    TIMEOUTTYPE = new UShortParameter( TIMEOUTTYPE__Parameter__, this );
    m_ParameterList.Add( TIMEOUTTYPE__Parameter__, TIMEOUTTYPE );
    
    VACWAIT_Callback = new WaitFunction( VACWAIT_CallbackFn );
    
    OCCENABLEDISABLE.OnAnalogChange.Add( new InputChangeHandlerWrapper( OCCENABLEDISABLE_OnChange_0, false ) );
    VACENABLEDISABLE.OnAnalogChange.Add( new InputChangeHandlerWrapper( VACENABLEDISABLE_OnChange_1, false ) );
    FORCEOCCUPANCY.OnDigitalPush.Add( new InputChangeHandlerWrapper( FORCEOCCUPANCY_OnPush_2, false ) );
    FORCEVACANCY.OnDigitalPush.Add( new InputChangeHandlerWrapper( FORCEVACANCY_OnPush_3, false ) );
    SENSORIN.OnDigitalPush.Add( new InputChangeHandlerWrapper( SENSORIN_OnPush_4, false ) );
    SENSORIN.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SENSORIN_OnRelease_5, false ) );
    TESTMODEHELD.OnDigitalPush.Add( new InputChangeHandlerWrapper( TESTMODEHELD_OnPush_6, false ) );
    TESTMODEHELD.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TESTMODEHELD_OnRelease_7, false ) );
    TIMEOUTSECONDS.OnAnalogChange.Add( new InputChangeHandlerWrapper( TIMEOUTSECONDS_OnChange_8, false ) );
    TIMEOUTTENTHS.OnAnalogChange.Add( new InputChangeHandlerWrapper( TIMEOUTTENTHS_OnChange_9, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_RBI_MOTION_LOGIC_SPLUS_V1D ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction VACWAIT_Callback;


const uint SENSORIN__DigitalInput__ = 0;
const uint FORCEOCCUPANCY__DigitalInput__ = 1;
const uint FORCEVACANCY__DigitalInput__ = 2;
const uint TESTMODEHELD__DigitalInput__ = 3;
const uint TIMEOUTSECONDS__AnalogSerialInput__ = 0;
const uint TIMEOUTTENTHS__AnalogSerialInput__ = 1;
const uint OCCENABLEDISABLE__AnalogSerialInput__ = 2;
const uint VACENABLEDISABLE__AnalogSerialInput__ = 3;
const uint OCCUPIEDHELD__DigitalOutput__ = 0;
const uint OCCUPANCYENABLEFB__DigitalOutput__ = 1;
const uint OCCUPANCYDISABLEFB__DigitalOutput__ = 2;
const uint VACANCYENABLEFB__DigitalOutput__ = 3;
const uint VACANCYDISABLEFB__DigitalOutput__ = 4;
const uint OCCUPIEDP__DigitalOutput__ = 5;
const uint VACANTP__DigitalOutput__ = 6;
const uint TIMEOUTSECONDSFB__AnalogSerialOutput__ = 0;
const uint TIMEOUTTENTHSFB__AnalogSerialOutput__ = 1;
const uint TIMEOUTTYPE__Parameter__ = 10;

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
