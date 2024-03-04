namespace console_card_game
{
    public enum CurrentStep
    {
        First,
        Second
    }
    public class Step
    {
        private CurrentStep _currentStep = CurrentStep.First;
        private int _stepNumber = 0;
        
        public CurrentStep GetCurrentStep()
        {
            return _currentStep;
        }

        public void NextStep()
        {
            _stepNumber++;
            _currentStep = (_currentStep == CurrentStep.First) ? CurrentStep.Second : CurrentStep.First;
        }
    }
}