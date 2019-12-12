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

namespace UserModule_RBI_DYNAMIC_LOGO_HELPER_V1A
{
    public class UserModuleClass_RBI_DYNAMIC_LOGO_HELPER_V1A : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.StringInput PROCESSORIP;
        Crestron.Logos.SplusObjects.DigitalInput SSLENABLED;
        StringParameter FILENAME;
        Crestron.Logos.SplusObjects.StringOutput URL;
        private void MAKEURLSTRING (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 45;
            if ( Functions.TestForTrue  ( ( SSLENABLED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 47;
                MakeString ( URL , "https://{0}/{1}", PROCESSORIP , FILENAME ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 52;
                MakeString ( URL , "http://{0}/{1}", PROCESSORIP , FILENAME ) ; 
                } 
            
            
            }
            
        object PROCESSORIP_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 59;
                MAKEURLSTRING (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SSLENABLED_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 64;
            MAKEURLSTRING (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    SSLENABLED = new Crestron.Logos.SplusObjects.DigitalInput( SSLENABLED__DigitalInput__, this );
    m_DigitalInputList.Add( SSLENABLED__DigitalInput__, SSLENABLED );
    
    PROCESSORIP = new Crestron.Logos.SplusObjects.StringInput( PROCESSORIP__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( PROCESSORIP__AnalogSerialInput__, PROCESSORIP );
    
    URL = new Crestron.Logos.SplusObjects.StringOutput( URL__AnalogSerialOutput__, this );
    m_StringOutputList.Add( URL__AnalogSerialOutput__, URL );
    
    FILENAME = new StringParameter( FILENAME__Parameter__, this );
    m_ParameterList.Add( FILENAME__Parameter__, FILENAME );
    
    
    PROCESSORIP.OnSerialChange.Add( new InputChangeHandlerWrapper( PROCESSORIP_OnChange_0, false ) );
    SSLENABLED.OnDigitalChange.Add( new InputChangeHandlerWrapper( SSLENABLED_OnChange_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_RBI_DYNAMIC_LOGO_HELPER_V1A ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint PROCESSORIP__AnalogSerialInput__ = 0;
const uint SSLENABLED__DigitalInput__ = 0;
const uint FILENAME__Parameter__ = 10;
const uint URL__AnalogSerialOutput__ = 0;

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
