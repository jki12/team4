using System;
//using ;

class BullsAndCows
{
    public static int _strike;
    public static bool IsNumberLengh(string input, int NumberLengh)
    {
        if (input.Length != NumberLengh)
        {
            Console.WriteLine($"숫자는 {NumberLengh}자리여야 합니다.");
            return false;
        }
        return true;
    }
    public static bool IsValidInput(bool success)
    {
        if (!success)
        {
            Console.WriteLine("유효한 정수를 입력하세요.");
            return false;
        }
        return true;
    }
    public static bool IsOverlap(int[] guessNumbers)
    {
        for (int i = 0; i < 10; i++)
        {
            int count = guessNumbers.Count(n => n == i);
            if (count > 1)
            {
                Console.WriteLine("숫자는 중복되지 않습니다.");
                return false;
            }
        }
        if (guessNumbers[0] == 0)
        {
            Console.WriteLine("맨 앞 숫자는 0이 아닙니다. 1000~9999 범위의 숫자를 입력하세요.");
            return false;
        }
        return true;
    }
    public static string CompareNumbers(int[] guessNumbers, int[] answerNumbers) //비교
    {
        int strike = 0;
        int ball = 0;
        string result;
        for (int i = 0; i < guessNumbers.Length; i++)
        {
            if (guessNumbers[i] == answerNumbers[i])
                strike++;
            else if (Array.IndexOf(guessNumbers, answerNumbers[i]) != -1)
                ball++;
        }
        result = strike + "S " + ball + "B";
        _strike = strike;

        if (strike == 0 && ball == 0)
            result = "OUT";
        return result;
    }

    static void Main()
    {
        const int NumberLengh = 4;
        int[] answerNumbers = { 1, 2, 3, 4 }; //랜덤 숫자
        int[] guessNumbers = new int[NumberLengh];

        Console.WriteLine("숫자야구 게임을 시작합니다!");
        Console.WriteLine($"답은 {NumberLengh}자리이며, 1000~9999 범위의 중복되지 않는 숫자입니다.\n");

        while (true)
        {
            Console.Write("숫자를 입력하세요: ");
            string input = Console.ReadLine();

            if (input == "")
            {
                Console.WriteLine("숫자를 입력하세요.");
                continue;
            }

            bool success = true;

            if (!IsNumberLengh(input, NumberLengh))
                continue;
            for (int i = 0; i < NumberLengh; i++)
            {
                success = int.TryParse(input[i].ToString(), out guessNumbers[i]);
                if (!IsValidInput(success))
                    break;
            }
            if (!success)
                continue;
            if (!IsOverlap(guessNumbers))
                continue;

            string resultValue;
            resultValue = CompareNumbers(guessNumbers, answerNumbers);
            Console.WriteLine(resultValue);

            if (_strike == NumberLengh)
            {
                Console.WriteLine($"답을 맞췄습니다! 답: {input}");
                break;
            }
        }
    }
}