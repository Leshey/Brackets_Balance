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
        BracketsCheck brackets = new BracketsCheck();

        brackets.CheckBracketBalance(userInput.UserInputToArray(userInput.GetUserInput()));

    }

    public class UserInput 
    {
        public string GetUserInput() 
        {
            string userInput;
            return userInput = Console.ReadLine();
        }

        public char[] UserInputToArray(string userInput) 
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
        Tokens token = new Tokens();
        
        public void CheckForPairs(char[] arr) 
        {
            token.CreateArrForTokens(arr.Length);
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
                            continue;
                        }
                        else if (arr[j] == ')' && openBracketsCounter > 0)
                        {
                            openBracketsCounter--;
                            continue;
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
            for (int i = 0; i < token._tokensArr.Length; i++) 
            {
                if (token._tokensArr[i] == 0) 
                {
                    Console.WriteLine($"Bracket with index [{i}] is pairless");
                }
            }

        }

    }

    public class Tokens
    {
        public int[] _tokensArr;
        
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
    }
}



