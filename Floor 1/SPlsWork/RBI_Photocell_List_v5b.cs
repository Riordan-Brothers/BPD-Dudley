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

namespace UserModule_RBI_PHOTOCELL_LIST_V5B
{
    public class UserModuleClass_RBI_PHOTOCELL_LIST_V5B : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PCSELECT;
        Crestron.Logos.SplusObjects.AnalogOutput EQUIPMENT_ID;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> PCNAMES;
        Zone_Control_Helper.PcListHelper ZHELP;
        private void GETPCNAMES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 43;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)60; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( _SplusNVRAM.I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (_SplusNVRAM.I  >= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  <= __FN_FOREND_VAL__1) ) : ( (_SplusNVRAM.I  <= __FN_FORSTART_VAL__1) && (_SplusNVRAM.I  >= __FN_FOREND_VAL__1) ) ; _SplusNVRAM.I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 45;
                if ( Functions.TestForTrue  ( ( IsSignalDefined( PCNAMES[ _SplusNVRAM.I ] ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 47;
                    PCNAMES [ _SplusNVRAM.I]  .UpdateValue ( ZHELP . GetPcName ( (ushort)( _SplusNVRAM.I ))  ) ; 
                    } 
                
                __context__.SourceCodeLine = 43;
                } 
            
            
            }
            
        private void FIREGETPCNAMES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 54;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.ISRUNNING == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 57;
                _SplusNVRAM.ISRUNNING = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 58;
                CreateWait ( "LISTCHANGEWAIT" , _SplusNVRAM.WAITTIME , LISTCHANGEWAIT_Callback ) ;
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 67;
                RetimeWait ( (int)_SplusNVRAM.WAITTIME, "LISTCHANGEWAIT" ) ; 
                } 
            
            
            }
            
        public void LISTCHANGEWAIT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 60;
            GETPCNAMES (  __context__  ) ; 
            __context__.SourceCodeLine = 61;
            _SplusNVRAM.ISRUNNING = (ushort) ( 0 ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    public void HANDLEDATACHANGE ( object __sender__ /*Zone_Control_Helper.PcListHelper Z */, EventArgs ARGS ) 
        { 
        PcListHelper  Z  = (PcListHelper )__sender__;
        try
        {
            SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
            
            __context__.SourceCodeLine = 77;
            FIREGETPCNAMES (  __context__  ) ; 
            
            
        }
        finally { ObjectFinallyHandler(); }
        }
        
    object PCSELECT_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 82;
            EQUIPMENT_ID  .Value = (ushort) ( ZHELP.GetPcEquipId( (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ) ) ; 
            
            
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
        
        __context__.SourceCodeLine = 93;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 94;
        _SplusNVRAM.WAITTIME = (ushort) ( 100 ) ; 
        __context__.SourceCodeLine = 96;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_55__" , 200 , __SPLS_TMPVAR__WAITLABEL_55___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    
public void __SPLS_TMPVAR__WAITLABEL_55___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 98;
            // RegisterEvent( ZHELP , PCLISTCHANGE , HANDLEDATACHANGE ) 
            try { g_criticalSection.Enter(); ZHELP .PcListChange  += HANDLEDATACHANGE; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 99;
            FIREGETPCNAMES (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    PCSELECT = new InOutArray<DigitalInput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        PCSELECT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PCSELECT__DigitalInput__ + i, PCSELECT__DigitalInput__, this );
        m_DigitalInputList.Add( PCSELECT__DigitalInput__ + i, PCSELECT[i+1] );
    }
    
    EQUIPMENT_ID = new Crestron.Logos.SplusObjects.AnalogOutput( EQUIPMENT_ID__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EQUIPMENT_ID__AnalogSerialOutput__, EQUIPMENT_ID );
    
    PCNAMES = new InOutArray<StringOutput>( 60, this );
    for( uint i = 0; i < 60; i++ )
    {
        PCNAMES[i+1] = new Crestron.Logos.SplusObjects.StringOutput( PCNAMES__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( PCNAMES__AnalogSerialOutput__ + i, PCNAMES[i+1] );
    }
    
    LISTCHANGEWAIT_Callback = new WaitFunction( LISTCHANGEWAIT_CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_55___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_55___CallbackFn );
    
    for( uint i = 0; i < 60; i++ )
        PCSELECT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PCSELECT_OnPush_0, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    ZHELP  = new Zone_Control_Helper.PcListHelper();
    
    
}

public UserModuleClass_RBI_PHOTOCELL_LIST_V5B ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction LISTCHANGEWAIT_Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_55___Callback;


const uint PCSELECT__DigitalInput__ = 0;
const uint EQUIPMENT_ID__AnalogSerialOutput__ = 0;
const uint PCNAMES__AnalogSerialOutput__ = 1;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort I = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort WAITTIME = 0;
            [SplusStructAttribute(2, false, true)]
            public ushort ISRUNNING = 0;
            
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
