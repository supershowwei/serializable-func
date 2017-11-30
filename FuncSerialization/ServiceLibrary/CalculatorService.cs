using System;

namespace ServiceLibrary
{
    [Serializable]
    public class CalculatorService
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Add(AdditionParameter param)
        {
            return param.Number1 + param.Number2;
        }
    }
}