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

namespace UserModule_SIMPL__PROGRAM_COMMENTS_AND_UPTIME
{
    public class UserModuleClass_SIMPL__PROGRAM_COMMENTS_AND_UPTIME : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput TRIG;
        Crestron.Logos.SplusObjects.BufferInput CON_RX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput CON_TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PGM_BOOT_DIR__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SOURCE_FILE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PROGRAM_FILE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SYSTEM_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PROGRAMMER__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput COMPILED_ON__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput COMPILER_REV__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SYMLIB_REV__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput IOLIB_REV__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput IOPCFG__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput CRESTRONDB__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SOURCE_ENV__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TARGET_RACK__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput CONFIG_REV__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput INCLUDE4__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput UPTIME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SYSTEM_STARTED__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PROG_UPTIME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput PROG_STARTED__DOLLAR__;
        UShortParameter PROGSLOT;
        ushort [] START_POS;
        ushort [] STR_LEN;
        ushort I = 0;
        ushort [] START_POS_UP;
        ushort [] STR_LEN_UP;
        ushort [] START_POS_PROG;
        ushort [] STR_LEN_PROG;
        CrestronString [] PARSE__DOLLAR__;
        CrestronString [] PARSE_UP__DOLLAR__;
        CrestronString [] PARSE_PROG__DOLLAR__;
        private void PARSE_COMMENTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 76;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)14; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 78;
                START_POS [ I] = (ushort) ( (Functions.Find( PARSE__DOLLAR__[ I ] , CON_RX__DOLLAR__ ) + Functions.Length( PARSE__DOLLAR__[ I ] )) ) ; 
                __context__.SourceCodeLine = 79;
                STR_LEN [ I] = (ushort) ( (Functions.Find( "\r\n" , Functions.Mid( CON_RX__DOLLAR__ , (int)( START_POS[ I ] ) , (int)( ((Functions.Length( CON_RX__DOLLAR__ ) - START_POS[ I ]) - 3) ) ) ) - 1) ) ; 
                __context__.SourceCodeLine = 76;
                } 
            
            __context__.SourceCodeLine = 82;
            PGM_BOOT_DIR__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 0 ] ) ,  (int) ( STR_LEN[ 0 ] ) )  ) ; 
            __context__.SourceCodeLine = 83;
            SOURCE_FILE__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 1 ] ) ,  (int) ( STR_LEN[ 1 ] ) )  ) ; 
            __context__.SourceCodeLine = 84;
            PROGRAM_FILE__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 2 ] ) ,  (int) ( STR_LEN[ 2 ] ) )  ) ; 
            __context__.SourceCodeLine = 85;
            SYSTEM_NAME__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 3 ] ) ,  (int) ( STR_LEN[ 3 ] ) )  ) ; 
            __context__.SourceCodeLine = 86;
            PROGRAMMER__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 4 ] ) ,  (int) ( STR_LEN[ 4 ] ) )  ) ; 
            __context__.SourceCodeLine = 87;
            COMPILED_ON__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 5 ] ) ,  (int) ( STR_LEN[ 5 ] ) )  ) ; 
            __context__.SourceCodeLine = 88;
            COMPILER_REV__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 6 ] ) ,  (int) ( STR_LEN[ 6 ] ) )  ) ; 
            __context__.SourceCodeLine = 89;
            SYMLIB_REV__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 7 ] ) ,  (int) ( STR_LEN[ 7 ] ) )  ) ; 
            __context__.SourceCodeLine = 90;
            IOLIB_REV__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 8 ] ) ,  (int) ( STR_LEN[ 8 ] ) )  ) ; 
            __context__.SourceCodeLine = 91;
            IOPCFG__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 9 ] ) ,  (int) ( STR_LEN[ 9 ] ) )  ) ; 
            __context__.SourceCodeLine = 92;
            CRESTRONDB__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 10 ] ) ,  (int) ( STR_LEN[ 10 ] ) )  ) ; 
            __context__.SourceCodeLine = 93;
            SOURCE_ENV__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 11 ] ) ,  (int) ( STR_LEN[ 11 ] ) )  ) ; 
            __context__.SourceCodeLine = 94;
            TARGET_RACK__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 12 ] ) ,  (int) ( STR_LEN[ 12 ] ) )  ) ; 
            __context__.SourceCodeLine = 95;
            CONFIG_REV__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 13 ] ) ,  (int) ( STR_LEN[ 13 ] ) )  ) ; 
            __context__.SourceCodeLine = 96;
            INCLUDE4__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS[ 14 ] ) ,  (int) ( STR_LEN[ 14 ] ) )  ) ; 
            
            }
            
        private void PARSE_UPTIME (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 102;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 104;
                START_POS_UP [ I] = (ushort) ( (Functions.Find( PARSE_UP__DOLLAR__[ I ] , CON_RX__DOLLAR__ ) + Functions.Length( PARSE_UP__DOLLAR__[ I ] )) ) ; 
                __context__.SourceCodeLine = 105;
                STR_LEN_UP [ I] = (ushort) ( (Functions.Find( "\r\n" , Functions.Mid( CON_RX__DOLLAR__ , (int)( START_POS_UP[ I ] ) , (int)( ((Functions.Length( CON_RX__DOLLAR__ ) - START_POS_UP[ I ]) - 3) ) ) ) - 1) ) ; 
                __context__.SourceCodeLine = 102;
                } 
            
            __context__.SourceCodeLine = 108;
            UPTIME__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS_UP[ 0 ] ) ,  (int) ( STR_LEN_UP[ 0 ] ) )  ) ; 
            __context__.SourceCodeLine = 109;
            SYSTEM_STARTED__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS_UP[ 1 ] ) ,  (int) ( STR_LEN_UP[ 1 ] ) )  ) ; 
            
            }
            
        private void PARSE_PROGUPTIME (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 117;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)2; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 120;
                START_POS_PROG [ I] = (ushort) ( (Functions.Find( PARSE_PROG__DOLLAR__[ I ] , CON_RX__DOLLAR__ ) + Functions.Length( PARSE_PROG__DOLLAR__[ I ] )) ) ; 
                __context__.SourceCodeLine = 121;
                STR_LEN_PROG [ I] = (ushort) ( (Functions.Find( "\r\n" , Functions.Mid( CON_RX__DOLLAR__ , (int)( START_POS_PROG[ I ] ) , (int)( ((Functions.Length( CON_RX__DOLLAR__ ) - START_POS_PROG[ I ]) - 3) ) ) ) - 1) ) ; 
                __context__.SourceCodeLine = 117;
                } 
            
            __context__.SourceCodeLine = 125;
            PROG_UPTIME__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS_PROG[ 0 ] ) ,  (int) ( STR_LEN_PROG[ 0 ] ) )  ) ; 
            __context__.SourceCodeLine = 126;
            PROG_STARTED__DOLLAR__  .UpdateValue ( Functions.Mid ( CON_RX__DOLLAR__ ,  (int) ( START_POS_PROG[ 1 ] ) ,  (int) ( STR_LEN_PROG[ 1 ] ) )  ) ; 
            
            }
            
        object TRIG_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 136;
                Functions.ClearBuffer ( CON_RX__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 137;
                MakeString ( CON_TX__DOLLAR__ , "PROGCOMMENTS:{0:d}\r\n", (ushort)PROGSLOT  .Value) ; 
                __context__.SourceCodeLine = 138;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 139;
                PARSE_COMMENTS (  __context__  ) ; 
                __context__.SourceCodeLine = 141;
                Functions.ClearBuffer ( CON_RX__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 143;
                CON_TX__DOLLAR__  .UpdateValue ( "UPTIME\r\n"  ) ; 
                __context__.SourceCodeLine = 143;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 144;
                PARSE_UPTIME (  __context__  ) ; 
                __context__.SourceCodeLine = 146;
                Functions.ClearBuffer ( CON_RX__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 148;
                MakeString ( CON_TX__DOLLAR__ , "PROGUPTIME:{0:d}\r\n", (ushort)PROGSLOT  .Value) ; 
                __context__.SourceCodeLine = 149;
                PARSE_PROGUPTIME (  __context__  ) ; 
                __context__.SourceCodeLine = 151;
                Functions.ClearBuffer ( CON_RX__DOLLAR__ ) ; 
                
                
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
            PARSE__DOLLAR__ [ 0 ]  .UpdateValue ( "Program Boot Directory: "  ) ; 
            __context__.SourceCodeLine = 160;
            PARSE__DOLLAR__ [ 1 ]  .UpdateValue ( "Source File:  "  ) ; 
            __context__.SourceCodeLine = 161;
            PARSE__DOLLAR__ [ 2 ]  .UpdateValue ( "Program File: "  ) ; 
            __context__.SourceCodeLine = 162;
            PARSE__DOLLAR__ [ 3 ]  .UpdateValue ( "System Name:  "  ) ; 
            __context__.SourceCodeLine = 163;
            PARSE__DOLLAR__ [ 4 ]  .UpdateValue ( "Programmer:   "  ) ; 
            __context__.SourceCodeLine = 164;
            PARSE__DOLLAR__ [ 5 ]  .UpdateValue ( "Compiled On:  "  ) ; 
            __context__.SourceCodeLine = 165;
            PARSE__DOLLAR__ [ 6 ]  .UpdateValue ( "Compiler Rev: "  ) ; 
            __context__.SourceCodeLine = 166;
            PARSE__DOLLAR__ [ 7 ]  .UpdateValue ( "SYMLIB Rev:   "  ) ; 
            __context__.SourceCodeLine = 167;
            PARSE__DOLLAR__ [ 8 ]  .UpdateValue ( "IOLIB Rev:    "  ) ; 
            __context__.SourceCodeLine = 168;
            PARSE__DOLLAR__ [ 9 ]  .UpdateValue ( "IOPCFG Rev:   "  ) ; 
            __context__.SourceCodeLine = 169;
            PARSE__DOLLAR__ [ 10 ]  .UpdateValue ( "CrestronDB:   "  ) ; 
            __context__.SourceCodeLine = 170;
            PARSE__DOLLAR__ [ 11 ]  .UpdateValue ( "Source Env:   "  ) ; 
            __context__.SourceCodeLine = 171;
            PARSE__DOLLAR__ [ 12 ]  .UpdateValue ( "Target Rack:  "  ) ; 
            __context__.SourceCodeLine = 172;
            PARSE__DOLLAR__ [ 13 ]  .UpdateValue ( "Config Rev:   "  ) ; 
            __context__.SourceCodeLine = 173;
            PARSE__DOLLAR__ [ 14 ]  .UpdateValue ( "Include4.dat: "  ) ; 
            __context__.SourceCodeLine = 175;
            PARSE_UP__DOLLAR__ [ 0 ]  .UpdateValue ( "The system has been running for "  ) ; 
            __context__.SourceCodeLine = 176;
            PARSE_UP__DOLLAR__ [ 1 ]  .UpdateValue ( "The system last started on: "  ) ; 
            __context__.SourceCodeLine = 179;
            PARSE_PROG__DOLLAR__ [ 0 ]  .UpdateValue ( "The program has been running for "  ) ; 
            __context__.SourceCodeLine = 180;
            PARSE_PROG__DOLLAR__ [ 1 ]  .UpdateValue ( "The program last started on: "  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        START_POS  = new ushort[ 15 ];
        STR_LEN  = new ushort[ 15 ];
        START_POS_UP  = new ushort[ 3 ];
        STR_LEN_UP  = new ushort[ 3 ];
        START_POS_PROG  = new ushort[ 3 ];
        STR_LEN_PROG  = new ushort[ 3 ];
        PARSE__DOLLAR__  = new CrestronString[ 15 ];
        for( uint i = 0; i < 15; i++ )
            PARSE__DOLLAR__ [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 24, this );
        PARSE_UP__DOLLAR__  = new CrestronString[ 3 ];
        for( uint i = 0; i < 3; i++ )
            PARSE_UP__DOLLAR__ [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        PARSE_PROG__DOLLAR__  = new CrestronString[ 3 ];
        for( uint i = 0; i < 3; i++ )
            PARSE_PROG__DOLLAR__ [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        
        TRIG = new Crestron.Logos.SplusObjects.DigitalInput( TRIG__DigitalInput__, this );
        m_DigitalInputList.Add( TRIG__DigitalInput__, TRIG );
        
        CON_TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CON_TX__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( CON_TX__DOLLAR____AnalogSerialOutput__, CON_TX__DOLLAR__ );
        
        PGM_BOOT_DIR__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PGM_BOOT_DIR__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( PGM_BOOT_DIR__DOLLAR____AnalogSerialOutput__, PGM_BOOT_DIR__DOLLAR__ );
        
        SOURCE_FILE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SOURCE_FILE__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( SOURCE_FILE__DOLLAR____AnalogSerialOutput__, SOURCE_FILE__DOLLAR__ );
        
        PROGRAM_FILE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PROGRAM_FILE__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( PROGRAM_FILE__DOLLAR____AnalogSerialOutput__, PROGRAM_FILE__DOLLAR__ );
        
        SYSTEM_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SYSTEM_NAME__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( SYSTEM_NAME__DOLLAR____AnalogSerialOutput__, SYSTEM_NAME__DOLLAR__ );
        
        PROGRAMMER__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PROGRAMMER__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( PROGRAMMER__DOLLAR____AnalogSerialOutput__, PROGRAMMER__DOLLAR__ );
        
        COMPILED_ON__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( COMPILED_ON__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( COMPILED_ON__DOLLAR____AnalogSerialOutput__, COMPILED_ON__DOLLAR__ );
        
        COMPILER_REV__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( COMPILER_REV__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( COMPILER_REV__DOLLAR____AnalogSerialOutput__, COMPILER_REV__DOLLAR__ );
        
        SYMLIB_REV__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SYMLIB_REV__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( SYMLIB_REV__DOLLAR____AnalogSerialOutput__, SYMLIB_REV__DOLLAR__ );
        
        IOLIB_REV__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( IOLIB_REV__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( IOLIB_REV__DOLLAR____AnalogSerialOutput__, IOLIB_REV__DOLLAR__ );
        
        IOPCFG__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( IOPCFG__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( IOPCFG__DOLLAR____AnalogSerialOutput__, IOPCFG__DOLLAR__ );
        
        CRESTRONDB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CRESTRONDB__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( CRESTRONDB__DOLLAR____AnalogSerialOutput__, CRESTRONDB__DOLLAR__ );
        
        SOURCE_ENV__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SOURCE_ENV__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( SOURCE_ENV__DOLLAR____AnalogSerialOutput__, SOURCE_ENV__DOLLAR__ );
        
        TARGET_RACK__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TARGET_RACK__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TARGET_RACK__DOLLAR____AnalogSerialOutput__, TARGET_RACK__DOLLAR__ );
        
        CONFIG_REV__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( CONFIG_REV__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( CONFIG_REV__DOLLAR____AnalogSerialOutput__, CONFIG_REV__DOLLAR__ );
        
        INCLUDE4__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( INCLUDE4__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( INCLUDE4__DOLLAR____AnalogSerialOutput__, INCLUDE4__DOLLAR__ );
        
        UPTIME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( UPTIME__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( UPTIME__DOLLAR____AnalogSerialOutput__, UPTIME__DOLLAR__ );
        
        SYSTEM_STARTED__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SYSTEM_STARTED__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( SYSTEM_STARTED__DOLLAR____AnalogSerialOutput__, SYSTEM_STARTED__DOLLAR__ );
        
        PROG_UPTIME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PROG_UPTIME__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( PROG_UPTIME__DOLLAR____AnalogSerialOutput__, PROG_UPTIME__DOLLAR__ );
        
        PROG_STARTED__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PROG_STARTED__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( PROG_STARTED__DOLLAR____AnalogSerialOutput__, PROG_STARTED__DOLLAR__ );
        
        CON_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( CON_RX__DOLLAR____AnalogSerialInput__, 2048, this );
        m_StringInputList.Add( CON_RX__DOLLAR____AnalogSerialInput__, CON_RX__DOLLAR__ );
        
        PROGSLOT = new UShortParameter( PROGSLOT__Parameter__, this );
        m_ParameterList.Add( PROGSLOT__Parameter__, PROGSLOT );
        
        
        TRIG.OnDigitalPush.Add( new InputChangeHandlerWrapper( TRIG_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_SIMPL__PROGRAM_COMMENTS_AND_UPTIME ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint TRIG__DigitalInput__ = 0;
    const uint CON_RX__DOLLAR____AnalogSerialInput__ = 0;
    const uint CON_TX__DOLLAR____AnalogSerialOutput__ = 0;
    const uint PGM_BOOT_DIR__DOLLAR____AnalogSerialOutput__ = 1;
    const uint SOURCE_FILE__DOLLAR____AnalogSerialOutput__ = 2;
    const uint PROGRAM_FILE__DOLLAR____AnalogSerialOutput__ = 3;
    const uint SYSTEM_NAME__DOLLAR____AnalogSerialOutput__ = 4;
    const uint PROGRAMMER__DOLLAR____AnalogSerialOutput__ = 5;
    const uint COMPILED_ON__DOLLAR____AnalogSerialOutput__ = 6;
    const uint COMPILER_REV__DOLLAR____AnalogSerialOutput__ = 7;
    const uint SYMLIB_REV__DOLLAR____AnalogSerialOutput__ = 8;
    const uint IOLIB_REV__DOLLAR____AnalogSerialOutput__ = 9;
    const uint IOPCFG__DOLLAR____AnalogSerialOutput__ = 10;
    const uint CRESTRONDB__DOLLAR____AnalogSerialOutput__ = 11;
    const uint SOURCE_ENV__DOLLAR____AnalogSerialOutput__ = 12;
    const uint TARGET_RACK__DOLLAR____AnalogSerialOutput__ = 13;
    const uint CONFIG_REV__DOLLAR____AnalogSerialOutput__ = 14;
    const uint INCLUDE4__DOLLAR____AnalogSerialOutput__ = 15;
    const uint UPTIME__DOLLAR____AnalogSerialOutput__ = 16;
    const uint SYSTEM_STARTED__DOLLAR____AnalogSerialOutput__ = 17;
    const uint PROG_UPTIME__DOLLAR____AnalogSerialOutput__ = 18;
    const uint PROG_STARTED__DOLLAR____AnalogSerialOutput__ = 19;
    const uint PROGSLOT__Parameter__ = 10;
    
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
