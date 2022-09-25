namespace TDDMicroExercises.TurnTicketDispenser
{
    public interface ITurnNumberSequence
    {
        int GetNextTurnNumber();
    }

    public class TurnNumberSequence : ITurnNumberSequence
    {
        static TurnNumberSequence _singleton;
        public static TurnNumberSequence GetOrCreate() => _singleton ?? (_singleton = new TurnNumberSequence());

        int _turnNumber = 0;

        public int GetNextTurnNumber()
        {
            lock (this) // since the ticket sequence can be called from multiple places, it has to be thread safe 
                return _turnNumber++;
        }
    }
}
