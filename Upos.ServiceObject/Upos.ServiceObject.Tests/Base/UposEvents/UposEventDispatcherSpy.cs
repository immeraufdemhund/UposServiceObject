using FluentAssertions;
using System;

namespace Upos.ServiceObject.Base.UposEvents
{
    internal class UposEventDispatcherSpy
    {
        private bool _dataEventFired;
        private bool _errorEventFired;
        private bool _directIoEventFired;
        private bool _outputCompleteEventFired;
        private bool _statusUpdateEventFired;

        public void OnlyDirectIOEventFired()
        {
            _directIoEventFired.Should().BeTrue("because DirectIO should have been called");

            _dataEventFired.Should().BeFalse("because a Data Event should not have been called");
            _errorEventFired.Should().BeFalse("because a Error Event should not have been called");
            _outputCompleteEventFired.Should().BeFalse("because a Output Complete Event should not have been called");
            _statusUpdateEventFired.Should().BeFalse("because a Status Update Event should not have been called");
        }

        public void OnlyOutputCompleteFired()
        {
            _outputCompleteEventFired.Should().BeTrue("because a Output Complete Event should have been called");

            _dataEventFired.Should().BeFalse("because a Data Event should not have been called");
            _directIoEventFired.Should().BeFalse("because a DirectIO should not have been called");
            _errorEventFired.Should().BeFalse("because a Error Event should not have been called");
            _statusUpdateEventFired.Should().BeFalse("because a Status Update Event should not have been called");
        }

        public void Reset()
        {
            _dataEventFired = false;
            _errorEventFired = false;
            _directIoEventFired = false;
        }

        public void SpyOnDataEvent(int status)
        {
            _dataEventFired = true;
        }

        public void SpyOnDirectIO(int eventnumber, int numericdata, string stringdata)
        {
            _directIoEventFired = true;
        }

        public void SpyOnErrorEvent(int resultcode, int resultcodeextended, int errorlocus, ref int errorresponse)
        {
            _errorEventFired = true;
        }

        public void SpyOnOutputCompleteEvent(int outputid)
        {
            _outputCompleteEventFired = true;
        }

        public void SpyOnStatusUpdateEvent(int status)
        {
            _statusUpdateEventFired = true;
        }

        public void ThrowOnDataEvent(int status) { Throw("Data Event"); }

        public void ThrowOnDirectIO(int eventnumber, int numericdata, string stringdata) { Throw("DirectIO Event"); }

        public void ThrowOnErrorEvent(int resultcode, int resultcodeextended, int errorlocus, ref int errorresponse) { Throw("Error Event"); }

        public void ThrowOnOutputCompleteEvent(int outputid) { Throw("Output Complete Event"); }

        public void ThrowOnStatusUpdateEvent(int status) { Throw("Status Update Event"); }

        private void Throw(string eventName)
        {
            throw new Exception(string.Format("{0} should not have been called", eventName));
        }
    }

}
