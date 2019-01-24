using System;

namespace Upos.ServiceObject.Base
{
    /// <summary>
    /// Since each device has it's own unique GUID for firing an event
    /// this class exists to bridge the gap by using a dynamic object.
    /// </summary>
    public abstract class DynamicControlObject : COPOS
    {
        public void SOData(int Status)
        {
            try
            {
                FireDataEvent(Status);
            }
            catch (Exception ex)
            {
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
