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

namespace UserModule_RBI_COLOR_PICKER_HELPER_PANEL_SPLUS_V1
{
    public class UserModuleClass_RBI_COLOR_PICKER_HELPER_PANEL_SPLUS_V1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput UPDATE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SELECTRECENT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> PANELIN;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> PANELOUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> FIRSTOUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> SECONDOUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> THIRDOUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> FOURTHOUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> FIFTHOUT;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> SIXTHOUT;
        ushort [,] SAVEDLEVELS;
        object UPDATE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 44;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (PANELIN[ 1 ] .UshortValue != FIRSTOUT[ 1 ] .Value) ) || Functions.TestForTrue ( Functions.BoolToInt (PANELIN[ 2 ] .UshortValue != FIRSTOUT[ 2 ] .Value) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (PANELIN[ 3 ] .UshortValue != FIRSTOUT[ 3 ] .Value) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 48;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)3; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 50;
                        SIXTHOUT [ I]  .Value = (ushort) ( FIFTHOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 51;
                        SAVEDLEVELS [ 6 , I] = (ushort) ( SIXTHOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 48;
                        } 
                    
                    __context__.SourceCodeLine = 54;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)3; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 56;
                        FIFTHOUT [ I]  .Value = (ushort) ( FOURTHOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 57;
                        SAVEDLEVELS [ 5 , I] = (ushort) ( FIFTHOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 54;
                        } 
                    
                    __context__.SourceCodeLine = 62;
                    ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__3 = (ushort)3; 
                    int __FN_FORSTEP_VAL__3 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                        { 
                        __context__.SourceCodeLine = 64;
                        FOURTHOUT [ I]  .Value = (ushort) ( THIRDOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 65;
                        SAVEDLEVELS [ 4 , I] = (ushort) ( FOURTHOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 62;
                        } 
                    
                    __context__.SourceCodeLine = 69;
                    ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__4 = (ushort)3; 
                    int __FN_FORSTEP_VAL__4 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                        { 
                        __context__.SourceCodeLine = 71;
                        THIRDOUT [ I]  .Value = (ushort) ( SECONDOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 72;
                        SAVEDLEVELS [ 3 , I] = (ushort) ( THIRDOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 69;
                        } 
                    
                    __context__.SourceCodeLine = 75;
                    ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__5 = (ushort)3; 
                    int __FN_FORSTEP_VAL__5 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                        { 
                        __context__.SourceCodeLine = 77;
                        SECONDOUT [ I]  .Value = (ushort) ( FIRSTOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 78;
                        SAVEDLEVELS [ 2 , I] = (ushort) ( SECONDOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 75;
                        } 
                    
                    __context__.SourceCodeLine = 82;
                    ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__6 = (ushort)3; 
                    int __FN_FORSTEP_VAL__6 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                        { 
                        __context__.SourceCodeLine = 84;
                        FIRSTOUT [ I]  .Value = (ushort) ( PANELIN[ I ] .UshortValue ) ; 
                        __context__.SourceCodeLine = 85;
                        SAVEDLEVELS [ 1 , I] = (ushort) ( FIRSTOUT[ I ] .Value ) ; 
                        __context__.SourceCodeLine = 82;
                        } 
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SELECTRECENT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            ushort J = 0;
            
            
            __context__.SourceCodeLine = 98;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 101;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)3; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( J  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (J  >= __FN_FORSTART_VAL__1) && (J  <= __FN_FOREND_VAL__1) ) : ( (J  <= __FN_FORSTART_VAL__1) && (J  >= __FN_FOREND_VAL__1) ) ; J  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 103;
                PANELOUT [ J]  .Value = (ushort) ( SAVEDLEVELS[ I , J ] ) ; 
                __context__.SourceCodeLine = 101;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SAVEDLEVELS  = new ushort[ 7,4 ];
    
    UPDATE = new Crestron.Logos.SplusObjects.DigitalInput( UPDATE__DigitalInput__, this );
    m_DigitalInputList.Add( UPDATE__DigitalInput__, UPDATE );
    
    SELECTRECENT = new InOutArray<DigitalInput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        SELECTRECENT[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SELECTRECENT__DigitalInput__ + i, SELECTRECENT__DigitalInput__, this );
        m_DigitalInputList.Add( SELECTRECENT__DigitalInput__ + i, SELECTRECENT[i+1] );
    }
    
    PANELIN = new InOutArray<AnalogInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        PANELIN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( PANELIN__AnalogSerialInput__ + i, PANELIN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( PANELIN__AnalogSerialInput__ + i, PANELIN[i+1] );
    }
    
    PANELOUT = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        PANELOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( PANELOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( PANELOUT__AnalogSerialOutput__ + i, PANELOUT[i+1] );
    }
    
    FIRSTOUT = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        FIRSTOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( FIRSTOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( FIRSTOUT__AnalogSerialOutput__ + i, FIRSTOUT[i+1] );
    }
    
    SECONDOUT = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        SECONDOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( SECONDOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( SECONDOUT__AnalogSerialOutput__ + i, SECONDOUT[i+1] );
    }
    
    THIRDOUT = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        THIRDOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( THIRDOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( THIRDOUT__AnalogSerialOutput__ + i, THIRDOUT[i+1] );
    }
    
    FOURTHOUT = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        FOURTHOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( FOURTHOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( FOURTHOUT__AnalogSerialOutput__ + i, FOURTHOUT[i+1] );
    }
    
    FIFTHOUT = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        FIFTHOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( FIFTHOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( FIFTHOUT__AnalogSerialOutput__ + i, FIFTHOUT[i+1] );
    }
    
    SIXTHOUT = new InOutArray<AnalogOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        SIXTHOUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( SIXTHOUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( SIXTHOUT__AnalogSerialOutput__ + i, SIXTHOUT[i+1] );
    }
    
    
    UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( UPDATE_OnPush_0, false ) );
    for( uint i = 0; i < 6; i++ )
        SELECTRECENT[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SELECTRECENT_OnPush_1, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_RBI_COLOR_PICKER_HELPER_PANEL_SPLUS_V1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint UPDATE__DigitalInput__ = 0;
const uint SELECTRECENT__DigitalInput__ = 1;
const uint PANELIN__AnalogSerialInput__ = 0;
const uint PANELOUT__AnalogSerialOutput__ = 0;
const uint FIRSTOUT__AnalogSerialOutput__ = 3;
const uint SECONDOUT__AnalogSerialOutput__ = 6;
const uint THIRDOUT__AnalogSerialOutput__ = 9;
const uint FOURTHOUT__AnalogSerialOutput__ = 12;
const uint FIFTHOUT__AnalogSerialOutput__ = 15;
const uint SIXTHOUT__AnalogSerialOutput__ = 18;

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
