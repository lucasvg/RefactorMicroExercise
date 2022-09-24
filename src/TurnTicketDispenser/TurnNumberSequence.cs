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

        public int GetNextTurnNumber() => _turnNumber++;
    }
}
