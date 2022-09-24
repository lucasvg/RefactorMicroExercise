namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
        readonly ITurnNumberSequence _turnNumberSequence;

        public TicketDispenser() : this(TurnNumberSequence.GetOrCreate())
        {
        }
        
        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }
        
        public TurnTicket GetTurnTicket() 
            => new TurnTicket(_turnNumberSequence.GetNextTurnNumber());
    }
}
