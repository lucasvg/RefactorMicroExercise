namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnNumberSequence
    {
        static TurnNumberSequence _singleton;
        public static TurnNumberSequence GetOrCreate() => _singleton ?? (_singleton = new TurnNumberSequence());

        int _turnNumber = 0;

        public int GetNextTurnNumber() => _turnNumber++;
    }
}
