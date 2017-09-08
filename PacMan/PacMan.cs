using System;

namespace PacMan
{
    public class PacMan
    {
        private bool _lifeAdded;
        public PacMan(int lives, int score)
        {
            Lives = lives;
            Score = score;
        }

        public int EatedGhostCount { get; set; }

        public void Step(string step)
        {
            switch (step)
            {
                case "Dot":
                    AddScore(10);
                    break;
                case "Apple":
                    AddScore(700);
                    break;
                case "Bell":
                    AddScore(3000);
                    break;
                case "Cherry":
                    AddScore(100);
                    break;
                case "Galaxian":
                    AddScore(2000);
                    break;
                case "Key":
                    AddScore(5000);
                    break;
                case "Melon":
                    AddScore(1000);
                    break;
                case "Orange":
                    AddScore(500);
                    break;
                case "Strawberry":
                    AddScore(300);
                    break;
                case "VulnerableGhost":
                    EatedGhostCount++;
                    AddScore((int) (100  *  Math.Pow(2, EatedGhostCount)));
                    break;
                 case "InvincibleGhost":
                     Lives--;
                     break;
                  
            }
        }

        private void AddScore(int points)
        {
            Score = Score + points;

            if (!_lifeAdded && Score >= 10000)
            {
                Lives++;
                _lifeAdded = true;
            }
        }

        public int Lives { get; private set; }
        public int Score { get; private set; }

        public bool HasLives()
        {
            return Lives > 0;
        }
    }
}