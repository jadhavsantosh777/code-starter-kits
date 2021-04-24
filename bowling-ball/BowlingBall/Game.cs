namespace BowlingBall
{
    public class Game
    {
        private int currentFrame = 0;
        private bool isFirstRoll = true;
        private Scorer scorer = new Scorer();
        public int Score
        {
            get
            {
                return GetScoreForFrame(currentFrame);
            }
        }
        public void Roll(int pins)
        {           
            scorer.AddRoll(pins);
            AdjustCurrentFrame(pins);
        }
        private void AdjustCurrentFrame(int pins)
        {
            if (IsLastBallInFrame(pins))
                AdvanceFrame();
            else
                isFirstRoll = false;
        }
        private bool IsLastBallInFrame(int pins)
        {
            return IsStrike(pins) || (!isFirstRoll);
        }
        private bool IsStrike(int pins)
        {
            return (isFirstRoll && pins == 10);
        }
        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
                currentFrame = 10;
        }
        public int GetScoreForFrame(int theFrame)
        {
            return scorer.GetScoreForFrame(theFrame);
        }
    }   
}
