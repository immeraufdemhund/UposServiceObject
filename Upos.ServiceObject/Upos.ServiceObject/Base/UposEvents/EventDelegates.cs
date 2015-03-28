using System;

namespace Upos.ServiceObject.Base.UposEvents
{

    /// <summary>
    /// Fired by a Service Object to communicate directly with the application
    /// This event provides a means for a Service Object to provide events to the application that are not otherwise supported by the Control Object
    /// </summary>
    /// <param name="eventNumber">Event number</param>
    /// <param name="numericData">reference to addtional numeric data</param>
    /// <param name="stringData">reference to additional string data</param>
    public delegate void DirectIOEventHandler(Int32 eventNumber, ref Int32 numericData, ref String stringData);

    /// <summary>
    /// Fired when an error is detected and the Control’s State transitions into the error state.
    /// Input error events are not delivered until the DataEventEnabled property is TRUE, so that proper application sequencing occurs.
    /// Unlike a DataEvent, the Control does not disable further DataEvents or input
    /// ErrorEvents; it leaves the DataEventEnabled property value at TRUE. Note that
    /// the application may set DataEventEnabled to FALSE within its event handler if
    /// subsequent input events need to be disabled for a period of time.
    /// </summary>
    /// <param name="resultCode">Result code causing the error event. See ResultCode for values.</param>
    /// <param name="resultCodeExtended">Extended result code causing the error event. See ResultCodeExtended for values.</param>
    /// <param name="errorLocus">Location of the error.</param>
    /// <param name="errorResponse">Reference to error event response from Control Object, set as default</param>
    public delegate void ErrorEventHandler(Int32 resultCode, Int32 resultCodeExtended, Int32 errorLocus, ref Int32 errorResponse);

    /// <summary>
    /// Fired when a previously started asynchronous output request completes successfully.
    /// </summary>
    /// <param name="outputId">The OutputID parameter indicates the ID number of the asynchronous output request that is complete</param>
    public delegate void OutputCompleteEventHandler(Int32 outputId);

    /// <summary>
    /// Fired when a Control needs to alert the application of a device status change. 
    /// Examples are a change in the cash drawer position (open vs. closed) 
    /// or a change in a POS printer sensor (form present vs. absent). 
    /// When a device is enabled, then the Control may fire initial StatusUpdateEvents
    /// to inform the application of the device state. This behavior, however, is not required
    /// </summary>
    /// <param name="status">The Status parameter is for device class-specific data, describing the type of status change.</param>
    public delegate void StatusUpdateEventHandler(Int32 status);
}
