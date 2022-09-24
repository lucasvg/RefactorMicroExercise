using System.Reflection;
using NUnit.Framework;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class TicketDispenserTests
    {
        [SetUp]
        public void ResetState()
        {
            typeof(TurnNumberSequence)
                .GetField("_singleton", BindingFlags.Static | BindingFlags.NonPublic)
                ?.SetValue(null, null);
        }
        
        [Test]
        public void FirstThreeTickets()
        {
            var ticketDispenser = new TicketDispenser();
            var ticket1         = ticketDispenser.GetTurnTicket();
            Assert.AreEqual(0, ticket1.TurnNumber);
            var ticket2 = ticketDispenser.GetTurnTicket();
            Assert.AreEqual(1, ticket2.TurnNumber);
            var ticket3 = ticketDispenser.GetTurnTicket();
            Assert.AreEqual(2, ticket3.TurnNumber);
        }
        
        [Test]
        public void MultipleTicketDispensersGenerateUniqueTickets()
        {
            var ticketDispenser1 = new TicketDispenser();
            var ticket1          = ticketDispenser1.GetTurnTicket();
            Assert.AreEqual(0, ticket1.TurnNumber);
            
            var ticketDispenser2 = new TicketDispenser();
            var ticket2          = ticketDispenser2.GetTurnTicket();
            Assert.AreEqual(1, ticket2.TurnNumber);
        }
    }
}
