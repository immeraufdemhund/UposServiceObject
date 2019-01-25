using System;

namespace Upos.ServiceObject.Base.UposEvents
{
    public abstract class EventArguments
    {
        public DateTime TimeStamp { get; }
        internal bool IsImmediate { get; }

        protected EventArguments(bool isImmediate)
        {
            IsImmediate = isImmediate;
            TimeStamp = DateTime.Now;
        }
    }

    public class DirectIOEventArguments : EventArguments
    {
        public int EventNumber { get; private set; }
        public int NumericData;
        public string StringData;

        public DirectIOEventArguments(int eventNumber, int numericData, string stringData)
            : base(true)
        {
            EventNumber = eventNumber;
            NumericData = numericData;
            StringData = stringData;
        }
    }

    public class ErrorEventArguments : EventArguments
    {
        public ResultCodeConstants ResultCode { get; private set; }
        public int ResultCodeExtended { get; private set; }
        public ErrorLocusConstants ErrorLocus { get; private set; }
        public int ErrorResponse;

        public ErrorEventArguments(ResultCodeConstants resultCode, ErrorLocusConstants errorLocus)
            : base(false)
        {
            ResultCode = resultCode;
            ErrorLocus = errorLocus;
            switch (ErrorLocus)
            {
                case ErrorLocusConstants.Output:
                    ErrorResponse = (int)ErrorResponseConstants.Retry;
                    break;
                case ErrorLocusConstants.Input:
                    ErrorResponse = (int)ErrorResponseConstants.Clear;
                    break;
                case ErrorLocusConstants.Input_Data:
                    ErrorResponse = (int)ErrorResponseConstants.ContinueInput;
                    break;
            }
        }

        public ErrorEventArguments(int resultCodeExtended, ErrorLocusConstants errorLocus)
            : this(ResultCodeConstants.Extended, errorLocus)
        {
            ResultCodeExtended = resultCodeExtended;
        }
    }

    public class OutputCompleteEventArguments : EventArguments
    {
        public int OutputID { get; private set; }

        public OutputCompleteEventArguments(int outputId)
            : base(false)
        {
            OutputID = outputId;
        }
    }

    public class StatusUpdateEventArguments : EventArguments
    {
        public int Status { get; private set; }

        public StatusUpdateEventArguments(int status)
            : base(true)
        {
            Status = status;
        }

        public StatusUpdateEventArguments(StatusUpdateEventConstants status)
            : this((int)status)
        {
        }
    }

    public class DataEventArguments : EventArguments
    {
        public int Status { get; private set; }

        public DataEventArguments(int status)
            : base(false)
        {
            Status = status;
        }
    }
}
