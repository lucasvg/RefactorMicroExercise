using NUnit.Framework;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class TicketDispenserTests
    {
        [Test]
        public void FirstThreeTickets()
        {
            var ticketDispenser = new TicketDispenser();
            var ticket1 = ticketDispenser.GetTurnTicket();
            Assert.AreEqual(0, ticket1.TurnNumber);
            var ticket2 = ticketDispenser.GetTurnTicket();
            Assert.AreEqual(1, ticket2.TurnNumber);
            var ticket3 = ticketDispenser.GetTurnTicket();
            Assert.AreEqual(2, ticket3.TurnNumber);
        }
    }
}
