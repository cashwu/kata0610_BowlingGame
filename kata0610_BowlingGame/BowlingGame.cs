namespace kata0610_BowlingGame
{
    internal class BowlingGame
    {
        private readonly int[] _rollPins = new int[21];
        private int _rollIndex;
        public void Roll(int pins)
        {
            _rollPins[_rollIndex] = pins;
            _rollIndex++;
        }

        public double Score()
        {
            var score = 0;

            var frameRollIndex = 0;
            for (int i = 1; i <= 10; i++)
            {
                if (IsStrike(frameRollIndex))
                {
                    GetStrikeScore(ref score, frameRollIndex);
                    frameRollIndex += 1;
                }
                else if (IsSpare(frameRollIndex))
                {
                    GetSpareScore(ref score, frameRollIndex);
                    frameRollIndex += 2;
                }
                else
                {
                    GetNormalScore(ref score, frameRollIndex);
                    frameRollIndex += 2;
                }
            }

            return score;
        }

        private void GetNormalScore(ref int score, int frameRollIndex)
        {
            score += GetNormalFrameScore(frameRollIndex);
        }

        private void GetSpareScore(ref int score, int frameRollIndex)
        {
            score += 10 + GetSpareBonus(frameRollIndex);
        }

        private void GetStrikeScore(ref int score, int frameRollIndex)
        {
            score += 10 + GetStrikeBonus(frameRollIndex);
        }

        private int GetStrikeBonus(int frameRollIndex)
        {
            return _rollPins[frameRollIndex + 1] + _rollPins[frameRollIndex + 2];
        }

        private bool IsStrike(int frameRollIndex)
        {
            return _rollPins[frameRollIndex] == 10;
        }

        private int GetSpareBonus(int frameRollIndex)
        {
            return _rollPins[frameRollIndex + 2];
        }

        private bool IsSpare(int frameRollIndex)
        {
            return GetNormalFrameScore(frameRollIndex) == 10;
        }

        private int GetNormalFrameScore(int frameRollIndex)
        {
            return _rollPins[frameRollIndex] + _rollPins[frameRollIndex + 1];
        }
    }
}