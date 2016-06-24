using System;

namespace Upos.ServiceObject.Base.UposEvents
{
    public abstract class EventArguments
    {
        public DateTime TimeStamp { get; private set; }

        protected EventArguments()
        {
            TimeStamp = DateTime.Now;
        }
    }

    public class DirectIOEventArguments : EventArguments
    {
        public int EventNumber { get; private set; }
        public int NumericData { get; private set; }
        public string SringData { get; private set; }

        public DirectIOEventArguments(int eventNumber, int numericData, string stringData)
            : base()
        {
            EventNumber = eventNumber;
            NumericData = numericData;
            SringData = stringData;
        }
    }

    public class ErrorEventArguments : EventArguments
    {
        public ResultCodeConstants ResultCode { get; private set; }
        public int ResultCodeExtended { get; private set; }
        public ErrorLocusConstants ErrorLocus { get; private set; }
        public ErrorResponseConstants ErrorResponse { get; private set; }

        public ErrorEventArguments(ResultCodeConstants resultCode, ErrorLocusConstants errorLocus)
            : base()
        {
            ResultCode = resultCode;
            ErrorLocus = errorLocus;
            switch (ErrorLocus)
            {
                case ErrorLocusConstants.Output:
                    ErrorResponse = ErrorResponseConstants.Retry;
                    break;
                case ErrorLocusConstants.Input:
                    ErrorResponse = ErrorResponseConstants.Clear;
                    break;
                case ErrorLocusConstants.Input_Data:
                    ErrorResponse = ErrorResponseConstants.ContinueInput;
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
            : base()
        {
            OutputID = outputId;
        }
    }

    public class StatusUpdateEventArguemtns : EventArguments
    {
        public int Status { get; private set; }

        public StatusUpdateEventArguemtns(int status)
            : base()
        {
            Status = status;
        }

        public StatusUpdateEventArguemtns(StatusUpdateEventConstants status)
            : this((int)status)
        {
        }
    }
}
