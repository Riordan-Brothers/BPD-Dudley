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

namespace UserModule_RBI_DYNAMIC_PRESETS_HELPER_32_ZONES_V8
{
    public class UserModuleClass_RBI_DYNAMIC_PRESETS_HELPER_32_ZONES_V8 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput PRESET_INIT;
        Crestron.Logos.SplusObjects.DigitalInput PRESET_SAVE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> LEVEL_IN;
        Crestron.Logos.SplusObjects.DigitalOutput PRESET_SAVED_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LEVEL_OUT;
        StringParameter ROOMID;
        StringParameter FILE_PATH;
        StringParameter PRESET_NAME;
        UShortParameter DEFAULT_LEVEL;
        FILE_INFO NFILEINFO;
        short NFILEHANDLE = 0;
        short NFILEFOUND = 0;
        short IERRORCODE = 0;
        ushort THREE_SERIES = 0;
        CrestronString SBUF;
        CrestronString FILE_CONTENTS;
        CrestronString FILE_LINE;
        CrestronString STR;
        private CrestronString GET_FULL_PATH (  SplusExecutionContext __context__, CrestronString PRESET_NAME ) 
            { 
            CrestronString FULL_PATH;
            FULL_PATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 52;
            if ( Functions.TestForTrue  ( ( THREE_SERIES)  ) ) 
                { 
                __context__.SourceCodeLine = 54;
                MakeString ( FULL_PATH , "{0}\\{1}\\{2}.txt", FILE_PATH , ROOMID , PRESET_NAME ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 59;
                MakeString ( FULL_PATH , "{0}\\{1}-{2}.txt", FILE_PATH , ROOMID , PRESET_NAME ) ; 
                } 
            
            __context__.SourceCodeLine = 62;
            return ( FULL_PATH ) ; 
            
            }
            
        private void INIT_PRESET (  SplusExecutionContext __context__, CrestronString PRESET_NAME ) 
            { 
            ushort I = 0;
            
            CrestronString FULL_PATH;
            FULL_PATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 70;
            FULL_PATH  .UpdateValue ( GET_FULL_PATH (  __context__ , PRESET_NAME)  ) ; 
            __context__.SourceCodeLine = 72;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 74;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THREE_SERIES == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 76;
                NFILEFOUND = (short) ( FindFirstShared( FULL_PATH , ref NFILEINFO ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 80;
                NFILEFOUND = (short) ( FindFirst( FULL_PATH , ref NFILEINFO ) ) ; 
                } 
            
            __context__.SourceCodeLine = 83;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEFOUND < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 85;
                GenerateUserNotice ( "Creating New Presets File: {0} \r\n", FULL_PATH ) ; 
                __context__.SourceCodeLine = 87;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THREE_SERIES == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 89;
                    NFILEHANDLE = (short) ( FileOpenShared( FULL_PATH ,(ushort) ((256 | 16384) | 1) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 94;
                    NFILEHANDLE = (short) ( FileOpen( FULL_PATH ,(ushort) ((256 | 16384) | 1) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 97;
                SBUF  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 99;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)32; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 101;
                    LEVEL_OUT [ I]  .Value = (ushort) ( DEFAULT_LEVEL  .Value ) ; 
                    __context__.SourceCodeLine = 102;
                    MakeString ( FILE_LINE , "load{0:d2} = {1:d},\r", (ushort)I, (ushort)DEFAULT_LEVEL  .Value) ; 
                    __context__.SourceCodeLine = 103;
                    SBUF  .UpdateValue ( SBUF + FILE_LINE  ) ; 
                    __context__.SourceCodeLine = 99;
                    } 
                
                __context__.SourceCodeLine = 106;
                FileWrite (  (short) ( NFILEHANDLE ) , SBUF ,  (ushort) ( Functions.Length( SBUF ) ) ) ; 
                __context__.SourceCodeLine = 107;
                FileClose (  (short) ( NFILEHANDLE ) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 112;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THREE_SERIES == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 114;
                    NFILEHANDLE = (short) ( FileOpenShared( FULL_PATH ,(ushort) (16384 | 0) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 119;
                    NFILEHANDLE = (short) ( FileOpen( FULL_PATH ,(ushort) (16384 | 0) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 122;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 124;
                    GenerateUserError ( "Error Opening: {0}, Error Code: {1:d}\r\n", FULL_PATH , (ushort)NFILEHANDLE) ; 
                    __context__.SourceCodeLine = 125;
                    FileClose (  (short) ( NFILEHANDLE ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 131;
                    IERRORCODE = (short) ( FileRead( (short)( NFILEHANDLE ) , FILE_CONTENTS , (ushort)( 2000 ) ) ) ; 
                    __context__.SourceCodeLine = 133;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERRORCODE < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 135;
                        GenerateUserError ( "Error Creating String, Error Code: {0:d}\r\n", (ushort)IERRORCODE) ; 
                        } 
                    
                    __context__.SourceCodeLine = 138;
                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__2 = (ushort)32; 
                    int __FN_FORSTEP_VAL__2 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                        { 
                        __context__.SourceCodeLine = 140;
                        FILE_LINE  .UpdateValue ( Functions.Remove ( "," , FILE_CONTENTS )  ) ; 
                        __context__.SourceCodeLine = 141;
                        STR  .UpdateValue ( Functions.Remove ( "=" , FILE_LINE )  ) ; 
                        __context__.SourceCodeLine = 142;
                        LEVEL_OUT [ I]  .Value = (ushort) ( Functions.Atoi( FILE_LINE ) ) ; 
                        __context__.SourceCodeLine = 138;
                        } 
                    
                    __context__.SourceCodeLine = 146;
                    FileClose (  (short) ( NFILEHANDLE ) ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 152;
            EndFileOperations ( ) ; 
            
            }
            
        private void INVOKE_PRESETS_INIT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 157;
            INIT_PRESET (  __context__ , PRESET_NAME ) ; 
            
            }
            
        object PRESET_SAVE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                CrestronString FULL_PATH;
                FULL_PATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
                
                
                __context__.SourceCodeLine = 164;
                FULL_PATH  .UpdateValue ( GET_FULL_PATH (  __context__ , PRESET_NAME )  ) ; 
                __context__.SourceCodeLine = 166;
                StartFileOperations ( ) ; 
                __context__.SourceCodeLine = 168;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (THREE_SERIES == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 170;
                    NFILEHANDLE = (short) ( FileOpenShared( FULL_PATH ,(ushort) (((16384 | 256) | 1) | 512) ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 175;
                    NFILEHANDLE = (short) ( FileOpen( FULL_PATH ,(ushort) (((16384 | 256) | 1) | 512) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 178;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NFILEHANDLE < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 180;
                    GenerateUserError ( "Error Opening: {0}, Error Code: {1:d} \r\n", FULL_PATH , (ushort)NFILEHANDLE) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 185;
                    SBUF  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 187;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)32; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 189;
                        LEVEL_OUT [ I]  .Value = (ushort) ( LEVEL_IN[ I ] .UshortValue ) ; 
                        __context__.SourceCodeLine = 190;
                        MakeString ( FILE_LINE , "load{0:d2} = {1:d},\r", (ushort)I, (ushort)LEVEL_IN[ I ] .UshortValue) ; 
                        __context__.SourceCodeLine = 191;
                        SBUF  .UpdateValue ( SBUF + FILE_LINE  ) ; 
                        __context__.SourceCodeLine = 187;
                        } 
                    
                    __context__.SourceCodeLine = 194;
                    IERRORCODE = (short) ( FileWrite( (short)( NFILEHANDLE ) , SBUF , (ushort)( Functions.Length( SBUF ) ) ) ) ; 
                    __context__.SourceCodeLine = 196;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERRORCODE < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 198;
                        GenerateUserError ( "Error Saving To: {0}, Error Code: {1:d} \r\n", FULL_PATH , (ushort)NFILEHANDLE) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 202;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERRORCODE >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 204;
                    Functions.Pulse ( 25, PRESET_SAVED_FB ) ; 
                    } 
                
                __context__.SourceCodeLine = 207;
                FileClose (  (short) ( NFILEHANDLE ) ) ; 
                __context__.SourceCodeLine = 208;
                EndFileOperations ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object PRESET_INIT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 213;
            INVOKE_PRESETS_INIT (  __context__  ) ; 
            
            
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
        
        __context__.SourceCodeLine = 218;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 220;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.GetSeries() == 3))  ) ) 
            { 
            __context__.SourceCodeLine = 221;
            THREE_SERIES = (ushort) ( 1 ) ; 
            } 
        
        __context__.SourceCodeLine = 224;
        INVOKE_PRESETS_INIT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
    FILE_CONTENTS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2000, this );
    FILE_LINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    STR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    NFILEINFO  = new FILE_INFO();
    NFILEINFO .PopulateDefaults();
    
    PRESET_INIT = new Crestron.Logos.SplusObjects.DigitalInput( PRESET_INIT__DigitalInput__, this );
    m_DigitalInputList.Add( PRESET_INIT__DigitalInput__, PRESET_INIT );
    
    PRESET_SAVE = new Crestron.Logos.SplusObjects.DigitalInput( PRESET_SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( PRESET_SAVE__DigitalInput__, PRESET_SAVE );
    
    PRESET_SAVED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( PRESET_SAVED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( PRESET_SAVED_FB__DigitalOutput__, PRESET_SAVED_FB );
    
    LEVEL_IN = new InOutArray<AnalogInput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        LEVEL_IN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( LEVEL_IN__AnalogSerialInput__ + i, LEVEL_IN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( LEVEL_IN__AnalogSerialInput__ + i, LEVEL_IN[i+1] );
    }
    
    LEVEL_OUT = new InOutArray<AnalogOutput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        LEVEL_OUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LEVEL_OUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LEVEL_OUT__AnalogSerialOutput__ + i, LEVEL_OUT[i+1] );
    }
    
    DEFAULT_LEVEL = new UShortParameter( DEFAULT_LEVEL__Parameter__, this );
    m_ParameterList.Add( DEFAULT_LEVEL__Parameter__, DEFAULT_LEVEL );
    
    ROOMID = new StringParameter( ROOMID__Parameter__, this );
    m_ParameterList.Add( ROOMID__Parameter__, ROOMID );
    
    FILE_PATH = new StringParameter( FILE_PATH__Parameter__, this );
    m_ParameterList.Add( FILE_PATH__Parameter__, FILE_PATH );
    
    PRESET_NAME = new StringParameter( PRESET_NAME__Parameter__, this );
    m_ParameterList.Add( PRESET_NAME__Parameter__, PRESET_NAME );
    
    
    PRESET_SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESET_SAVE_OnPush_0, false ) );
    PRESET_INIT.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESET_INIT_OnPush_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_RBI_DYNAMIC_PRESETS_HELPER_32_ZONES_V8 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint PRESET_INIT__DigitalInput__ = 0;
const uint PRESET_SAVE__DigitalInput__ = 1;
const uint LEVEL_IN__AnalogSerialInput__ = 0;
const uint PRESET_SAVED_FB__DigitalOutput__ = 0;
const uint LEVEL_OUT__AnalogSerialOutput__ = 0;
const uint ROOMID__Parameter__ = 10;
const uint FILE_PATH__Parameter__ = 11;
const uint PRESET_NAME__Parameter__ = 12;
const uint DEFAULT_LEVEL__Parameter__ = 13;

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
