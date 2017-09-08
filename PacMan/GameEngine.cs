namespace PacMan
{
    public class GameEngine
    {
        private PacMan _pacMan;

        public GameEngine(string stringSequence, PacMan pacMan)
        {
            _pacMan = pacMan;
            Sequence = ReadSequence(stringSequence);
            GameIndex = 0;
        }

        public string[] Sequence { get; }
        public int GameIndex { get; set; }

        public string[] ReadSequence(string stringSequence)
        {
            return stringSequence.Split(',');
        }

        public void MovePacMan()
        {
            _pacMan.Step(Sequence[GameIndex]);
            GameIndex++;
        }

        public bool CanContinue()
        {
            return _pacMan.HasLives();
        }
    }
}