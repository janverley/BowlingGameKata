using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        private int currentRoll;
        public int[] Rolls = new int[21];
        private int score;

        public void Roll(int knockedDown)
        {
            Rolls[currentRoll] = knockedDown;

            currentRoll++;
        }
        
        public int Score()
        {
            var result = 0;

            var currentRollIndex = 0;
            
            for (int currentFrameIndex = 0; currentFrameIndex < 10; currentFrameIndex++)
            {
                if (Rolls[currentRollIndex] == 10) // strike
                {
                    result += Rolls[currentRollIndex] + Rolls[currentRollIndex + 1] + Rolls[currentRollIndex + 2]; 
                    ++currentRollIndex;
                }
                else if (Rolls[currentRollIndex] + Rolls[currentRollIndex + 1] == 10) // spare
                {
                    result += Rolls[currentRollIndex] + Rolls[currentRollIndex + 1] + Rolls[currentRollIndex + 2];
                    ++currentRollIndex;
                    ++currentRollIndex;
                }
                else
                {
                    result += Rolls[currentRollIndex] + Rolls[currentRollIndex + 1];
                    ++currentRollIndex;
                    ++currentRollIndex;
                }                
            }
            
            return result;
        }
    }
}