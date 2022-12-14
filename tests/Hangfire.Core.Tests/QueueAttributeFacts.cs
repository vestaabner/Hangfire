using Hangfire.States;
using Moq;
using Xunit;

namespace Hangfire.Core.Tests
{
    public class QueueAttributeFacts
    {
        private readonly ElectStateContextMock _context;

        public QueueAttributeFacts()
        {
            _context = new ElectStateContextMock();
            _context.CandidateStateValue = new EnqueuedState("queue");
        }

        [Fact]
        public void Ctor_CorrectlySets_AllPropertyValues()
        {
            var filter = new QueueAttribute("hello");
            Assert.Equal("hello", filter.Queue);
        }

        [Fact]
        public void OnStateElection_OverridesTheQueue_OfTheCandidateState()
        {
            var filter = new QueueAttribute("override");
            filter.OnStateElection(_context.Object);

            Assert.Equal("override", ((EnqueuedState)_context.Object.CandidateState).Queue);
        }

        [Fact]
        public void OnStateElection_DoesNotDoAnything_IfStateIsNotEnqueuedState()
        {
            var filter = new QueueAttribute("override");
            var context = new ElectStateContextMock();
            context.CandidateStateValue = new Mock<IState>().Object;

            Assert.DoesNotThrow(() => filter.OnStateElection(context.Object));
        }
    }
}
