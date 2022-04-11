//Пользователь вводит текст из скобок. 
//Требуется проверить "баланс" этих скобок, а также то, что у каждой открывающейся скобки есть закрывающая.
//((()())) - баланс есть
//(()))() - баланса нет
//Если баланс есть, то нужно вывести сообщение, что все хорошо, если нет

public static class Program
{
    public static void Main()
    {
        UserInput userInput = new UserInput();
        char[] userInputToArray = userInput.UserInputToArray(userInput.GetUserInput());

        BracketsCheck brackets = new BracketsCheck(userInputToArray.Length);

        brackets.CheckBracketBalance(userInputToArray);

    }

    public class UserInput 
    {
        public string? GetUserInput() 
        {
            return Console.ReadLine();
        }

        public char[] UserInputToArray(string? userInput) 
        {
            char[] arr = new char[userInput.Length];
            for (int i = 0; i < userInput.Length; i++) 
            {
                arr[i] = userInput[i];
            }
            return arr;
        }
    }

    public class BracketsCheck
    {
        private Tokens token;
        public BracketsCheck(int length)
        {
            token = new Tokens(length);
        }

        public void CheckForPairs(char[] arr) 
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                int openBracketsCounter = 0;
                {
                    int indexOfOpenBracket = i;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] == '(')
                        {
                            openBracketsCounter++;
                        }
                        else if (arr[j] == ')' && openBracketsCounter > 0)
                        {
                            openBracketsCounter--;
                        }
                        else if (arr[j] == ')' && openBracketsCounter == 0)
                        {
                            token.PlaceToken(indexOfOpenBracket);
                            token.PlaceToken(j);
                            break;
                        }
                    }
                }
            }
        }

        public void CheckBracketBalance(char[] arr)
        {
            CheckForPairs(arr);
            if (token.CalcSumOfTokens() == arr.Length)
            {
                Console.WriteLine("You achieved perfect balance of brackets!");
            }
            else 
            {
                Console.WriteLine("There is no balance of brakets!");
                PrintIndexesOfPairlessBrackets();
            }
        }

        public void PrintIndexesOfPairlessBrackets() 
        {
            for (int i = 0; i < token.GetLength(); i++) 
            {
                if (token.GetTokenState(i) == 0) 
                {
                    Console.WriteLine($"Bracket with index [{i}] is pairless");
                }
            }
        }
    }

    public class Tokens
    {
        private int[] _tokensArr;

        public Tokens(int length)
        {
            _tokensArr = new int[length];
        }
        
        public int[] CreateArrForTokens(int arrLength)
        {
            return _tokensArr = new int[arrLength];
        }

        public void PlaceToken(int index) 
        {
            _tokensArr[index] = 1;
        }

        public int CalcSumOfTokens() 
        {
            return _tokensArr.Sum();
        }

        public int GetLength()
        {
            return _tokensArr.Length;
        }

        public int GetTokenState(int index)
        {
            return _tokensArr[index];
        }
    }
}



