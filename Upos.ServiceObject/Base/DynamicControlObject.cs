using System;
using log4net;

namespace Upos.ServiceObject.Base
{
    /// <summary>
    /// Since each device has it's own unique GUID for firing an event
    /// this class exists to bridge the gap by using a dynamic object.
    /// </summary>
    public abstract class DynamicControlObject : COPOS
    {
        private static ILog _log = LogManager.GetLogger(typeof(DynamicControlObject));

        public void SOData(int Status)
        {
            try
            {
                FireDataEvent(Status);
            }
            catch (Exception ex)
            {
                _log.Error("Error firing Data event", ex);
            }
        }

        public void SODirectIO(int EventNumber, ref int pData, ref string pString)
        {
            try
            {
                FireDirectIOEvent(EventNumber, ref pData, ref pString);
            }
            catch (Exception ex)
            {
                _log.Error("Error firing DirectIO event", ex);
            }
        }

        public void SOError(int ResultCode, int ResultCodeExtended, int ErrorLocus, ref int pErrorResponse)
        {
            try
            {
                FireErrorEvent(ResultCode, ResultCodeExtended, ErrorLocus, ref pErrorResponse);
            }
            catch (Exception ex)
            {
                _log.Error("Error firing Error event", ex);
            }
        }

        public void SOOutputComplete(int OutputID)
        {
            try
            {
                FireOutputCompleteEvent(OutputID);
            }
            catch (Exception ex)
            {
                _log.Error("Error output complete event", ex);
            }
        }

        public void SOStatusUpdate(int Data)
        {
            try
            {
                FireStatusUpdateEvent(Data);
            }
            catch (Exception ex)
            {
                _log.Error("Error status updated event", ex);
            }
        }

        public void SOProcessID(out int pProcessID)
        {
            try
            {
                GetProcessId(out pProcessID);
            }
            catch (Exception ex)
            {
                _log.Error("Error getting process id", ex);
                pProcessID = -1;
            }
        }

        protected abstract void FireDataEvent(int status);

        protected abstract void FireDirectIOEvent(int eventNumber, ref int pData, ref string pString);

        protected abstract void FireErrorEvent(int resultCode, int resultCodeExtended, int errorLocus,
            ref int pErrorResponse);

        protected abstract void FireOutputCompleteEvent(int outputId);

        protected abstract void FireStatusUpdateEvent(int data);

        protected abstract void GetProcessId(out int pProcessId);
    }
}
