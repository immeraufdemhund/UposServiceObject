using NUnit.Framework;
using Upos.ServiceObject.Base.Properties;

namespace Upos.ServiceObject.Base.UposEvents
{
    [TestFixture]
    public class UposEventArgumentsTests
    {
        [OneTimeSetUp]
        public void FixtureSetup()
        {
            _spy = new UposEventDispatcherSpy();
            _uposProperties = new TestableUposBaseProperties();
            _uposEventArguments = new UposEventArguments(_uposProperties);
            _dispatcher = IUposEventDispatcherFactory.Create(_uposEventArguments);
        }

        [SetUp]
        public void Setup()
        {
            _uposEventArguments.DataEventHandler = _spy.ThrowOnDataEvent;
            _uposEventArguments.DirectIOEventHandler = _spy.ThrowOnDirectIO;
            _uposEventArguments.ErrorEventHandler = _spy.ThrowOnErrorEvent;
            _uposEventArguments.OutputCompleteEventHandler = _spy.ThrowOnOutputCompleteEvent;
            _uposEventArguments.StatusUpdateEventHandler = _spy.ThrowOnStatusUpdateEvent;

            _spy.Reset();
        }

        private IUposProperties _uposProperties;
        private UposEventArguments _uposEventArguments;
        private IUposEventDispatcher _dispatcher;
        private UposEventDispatcherSpy _spy;

        [Test]
        public void WhenDirectIOEventIsEnqueued_ItIsFiredImmediatly()
        {
            _uposEventArguments.DirectIOEventHandler = _spy.SpyOnDirectIO;

            _dispatcher.EnqueueDirectIOEvent(new DirectIOEventArguments(1, 2, "3"));
            _spy.OnlyDirectIOEventFired();
        }

        [Test]
        public void WhenOutputCompleteEventIsEnqueued_ItIsFiredImmediatly()
        {
            _uposEventArguments.OutputCompleteEventHandler = _spy.SpyOnOutputCompleteEvent;

            _dispatcher.EnqueueOutputCompleteEvent(new OutputCompleteEventArguments(1));
            _spy.OnlyOutputCompleteFired();
        }
    }
}
