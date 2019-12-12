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
using RBI_Password_Helper_v2;
using password_helper;

namespace UserModule_RBI_PASSWORD_HELPER_SPLUS_V2
{
    public class UserModuleClass_RBI_PASSWORD_HELPER_SPLUS_V2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput CHECKPASSWORD;
        Crestron.Logos.SplusObjects.StringInput USERNAME;
        Crestron.Logos.SplusObjects.StringInput PASSWORD;
        Crestron.Logos.SplusObjects.DigitalOutput PASSWORDERROR;
        Crestron.Logos.SplusObjects.DigitalOutput PASSWORDINCORRECT;
        Crestron.Logos.SplusObjects.DigitalOutput AUTHADMIN;
        Crestron.Logos.SplusObjects.DigitalOutput AUTHPROGRAMMER;
        Crestron.Logos.SplusObjects.DigitalOutput AUTHOPERATOR;
        Crestron.Logos.SplusObjects.DigitalOutput AUTHUSER;
        Crestron.Logos.SplusObjects.DigitalOutput AUTHCONNECT;
        Crestron.Logos.SplusObjects.DigitalOutput AUTHOTHER;
        Crestron.Logos.SplusObjects.StringOutput PASSWORDOUT;
        StringParameter DEVICE;
        password_helper.PWchecker PCHECK;
        object CHECKPASSWORD_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 28;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (USERNAME == "") ) || Functions.TestForTrue ( Functions.BoolToInt (PASSWORD == "") )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 30;
                    Functions.Pulse ( _SplusNVRAM.PULSETIME, PASSWORDERROR ) ; 
                    __context__.SourceCodeLine = 31;
                    return  this ; 
                    } 
                
                __context__.SourceCodeLine = 34;
                _SplusNVRAM.ACCESS = (short) ( PCHECK.login( USERNAME .ToString() , PASSWORD .ToString() , DEVICE  .ToString() ) ) ; 
                __context__.SourceCodeLine = 35;
                PASSWORD  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 36;
                PASSWORDOUT  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 38;
                switch ((int)_SplusNVRAM.ACCESS)
                
                    { 
                    case - 1 : 
                    
                        { 
                        __context__.SourceCodeLine = 42;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, PASSWORDERROR ) ; 
                        __context__.SourceCodeLine = 43;
                        break ; 
                        } 
                    
                    goto case 0 ;
                    case 0 : 
                    
                        { 
                        __context__.SourceCodeLine = 47;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, PASSWORDINCORRECT ) ; 
                        __context__.SourceCodeLine = 48;
                        break ; 
                        } 
                    
                    goto case 31 ;
                    case 31 : 
                    
                        { 
                        __context__.SourceCodeLine = 52;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, AUTHADMIN ) ; 
                        __context__.SourceCodeLine = 53;
                        break ; 
                        } 
                    
                    goto case 15 ;
                    case 15 : 
                    
                        { 
                        __context__.SourceCodeLine = 57;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, AUTHPROGRAMMER ) ; 
                        __context__.SourceCodeLine = 58;
                        break ; 
                        } 
                    
                    goto case 7 ;
                    case 7 : 
                    
                        { 
                        __context__.SourceCodeLine = 62;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, AUTHOPERATOR ) ; 
                        __context__.SourceCodeLine = 63;
                        break ; 
                        } 
                    
                    goto case 2 ;
                    case 2 : 
                    
                        { 
                        __context__.SourceCodeLine = 67;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, AUTHUSER ) ; 
                        __context__.SourceCodeLine = 68;
                        break ; 
                        } 
                    
                    goto case 1 ;
                    case 1 : 
                    
                        { 
                        __context__.SourceCodeLine = 72;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, AUTHCONNECT ) ; 
                        __context__.SourceCodeLine = 73;
                        break ; 
                        } 
                    
                    goto case 3 ;
                    case 3 : 
                    
                        { 
                        __context__.SourceCodeLine = 77;
                        Functions.Pulse ( _SplusNVRAM.PULSETIME, AUTHOTHER ) ; 
                        __context__.SourceCodeLine = 78;
                        break ; 
                        } 
                    
                    break;
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
            
            __context__.SourceCodeLine = 91;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 92;
            _SplusNVRAM.PULSETIME = (ushort) ( 25 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        CHECKPASSWORD = new Crestron.Logos.SplusObjects.DigitalInput( CHECKPASSWORD__DigitalInput__, this );
        m_DigitalInputList.Add( CHECKPASSWORD__DigitalInput__, CHECKPASSWORD );
        
        PASSWORDERROR = new Crestron.Logos.SplusObjects.DigitalOutput( PASSWORDERROR__DigitalOutput__, this );
        m_DigitalOutputList.Add( PASSWORDERROR__DigitalOutput__, PASSWORDERROR );
        
        PASSWORDINCORRECT = new Crestron.Logos.SplusObjects.DigitalOutput( PASSWORDINCORRECT__DigitalOutput__, this );
        m_DigitalOutputList.Add( PASSWORDINCORRECT__DigitalOutput__, PASSWORDINCORRECT );
        
        AUTHADMIN = new Crestron.Logos.SplusObjects.DigitalOutput( AUTHADMIN__DigitalOutput__, this );
        m_DigitalOutputList.Add( AUTHADMIN__DigitalOutput__, AUTHADMIN );
        
        AUTHPROGRAMMER = new Crestron.Logos.SplusObjects.DigitalOutput( AUTHPROGRAMMER__DigitalOutput__, this );
        m_DigitalOutputList.Add( AUTHPROGRAMMER__DigitalOutput__, AUTHPROGRAMMER );
        
        AUTHOPERATOR = new Crestron.Logos.SplusObjects.DigitalOutput( AUTHOPERATOR__DigitalOutput__, this );
        m_DigitalOutputList.Add( AUTHOPERATOR__DigitalOutput__, AUTHOPERATOR );
        
        AUTHUSER = new Crestron.Logos.SplusObjects.DigitalOutput( AUTHUSER__DigitalOutput__, this );
        m_DigitalOutputList.Add( AUTHUSER__DigitalOutput__, AUTHUSER );
        
        AUTHCONNECT = new Crestron.Logos.SplusObjects.DigitalOutput( AUTHCONNECT__DigitalOutput__, this );
        m_DigitalOutputList.Add( AUTHCONNECT__DigitalOutput__, AUTHCONNECT );
        
        AUTHOTHER = new Crestron.Logos.SplusObjects.DigitalOutput( AUTHOTHER__DigitalOutput__, this );
        m_DigitalOutputList.Add( AUTHOTHER__DigitalOutput__, AUTHOTHER );
        
        USERNAME = new Crestron.Logos.SplusObjects.StringInput( USERNAME__AnalogSerialInput__, 50, this );
        m_StringInputList.Add( USERNAME__AnalogSerialInput__, USERNAME );
        
        PASSWORD = new Crestron.Logos.SplusObjects.StringInput( PASSWORD__AnalogSerialInput__, 50, this );
        m_StringInputList.Add( PASSWORD__AnalogSerialInput__, PASSWORD );
        
        PASSWORDOUT = new Crestron.Logos.SplusObjects.StringOutput( PASSWORDOUT__AnalogSerialOutput__, this );
        m_StringOutputList.Add( PASSWORDOUT__AnalogSerialOutput__, PASSWORDOUT );
        
        DEVICE = new StringParameter( DEVICE__Parameter__, this );
        m_ParameterList.Add( DEVICE__Parameter__, DEVICE );
        
        
        CHECKPASSWORD.OnDigitalPush.Add( new InputChangeHandlerWrapper( CHECKPASSWORD_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        PCHECK  = new password_helper.PWchecker();
        
        
    }
    
    public UserModuleClass_RBI_PASSWORD_HELPER_SPLUS_V2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CHECKPASSWORD__DigitalInput__ = 0;
    const uint USERNAME__AnalogSerialInput__ = 0;
    const uint PASSWORD__AnalogSerialInput__ = 1;
    const uint PASSWORDERROR__DigitalOutput__ = 0;
    const uint PASSWORDINCORRECT__DigitalOutput__ = 1;
    const uint AUTHADMIN__DigitalOutput__ = 2;
    const uint AUTHPROGRAMMER__DigitalOutput__ = 3;
    const uint AUTHOPERATOR__DigitalOutput__ = 4;
    const uint AUTHUSER__DigitalOutput__ = 5;
    const uint AUTHCONNECT__DigitalOutput__ = 6;
    const uint AUTHOTHER__DigitalOutput__ = 7;
    const uint PASSWORDOUT__AnalogSerialOutput__ = 0;
    const uint DEVICE__Parameter__ = 10;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        [SplusStructAttribute(0, false, true)]
            public ushort PULSETIME = 0;
            [SplusStructAttribute(1, false, true)]
            public short ACCESS = 0;
            
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
