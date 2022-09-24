namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
        readonly TurnNumberSequence _turnNumberSequence;

        public TicketDispenser() : this(TurnNumberSequence.GetOrCreate())
        {
        }
        
        public TicketDispenser(TurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }
        
        public TurnTicket GetTurnTicket() 
            => new TurnTicket(_turnNumberSequence.GetNextTurnNumber());
    }
}
