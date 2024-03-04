
using console_card_game;

namespace TEST
{
    public class Fight
    {
        public Action<Player, Player, int, int, Step> EndStep;
        public Action<int> FightEnd;
        
        public readonly Player FirstPlayer = new(0, Hero.Preset1);
        public readonly Player SecondPlayer = new(1, Hero.Preset2);

        public int FirstPlayerScore = 0;
        public int SecondPlayerScore = 0;

        public readonly Step Step = new Step();

        public Fight()
        {
            StartFight();
        }

        private void StartFight()
        {
            FirstPlayer.RefreshCards();
            SecondPlayer.RefreshCards();
        }

        //возвращает ID победителя
        public void MakeStep(int firstPlayerCardIndex, int secondPlayerCardIndex)
        {
            if (!Equals(FirstPlayer.Cards[firstPlayerCardIndex].Type, SecondPlayer.Cards[secondPlayerCardIndex].Type) &&
                Step.GetCurrentStep() == CurrentStep.First)
            {
                FirstPlayerScore++;
            }

            if (!Equals(FirstPlayer.Cards[firstPlayerCardIndex].Type, SecondPlayer.Cards[secondPlayerCardIndex].Type) &&
                        Step.GetCurrentStep() == CurrentStep.Second)
            {
                SecondPlayerScore++;
            }
            //Console.WriteLine(_step.GetCurrentStep() + " " + _firstPlayerScore.ToString() + " " + 
            //                  FirstPlayer.Cards[firstPlayerCardIndex].Type + " " + _secondPlayerScore.ToString() + " " + 
            //                  SecondPlayer.Cards[secondPlayerCardIndex].Type);
            EndStep?.Invoke(FirstPlayer, SecondPlayer, FirstPlayerScore, SecondPlayerScore, Step);
            FirstPlayer.SpendCard(firstPlayerCardIndex);
            SecondPlayer.SpendCard(secondPlayerCardIndex);
            CheckWinner();
            Step.NextStep();
        }

        private void CheckWinner()
        {
            if (FirstPlayerScore >= 3)
            {
                //первый выйграл
                FightEnd?.Invoke(FirstPlayer.ID);
                return;
            }
            if (SecondPlayerScore >= 3)
            {
                //второй выйграл
                FightEnd?.Invoke(SecondPlayer.ID);
                return;
            }
        }
    }
}