namespace MathQuizGame;

public class Math
{
  public void GenerateNewQuestion()
  {
    RandomOperation generate = new RandomOperation();
    int randomNumber = generate.GetRandomNumber();
    switch(randomNumber)
      {
    case 1:
      Question addition = new Addition();
      Console.WriteLine(addition.GetQuestion());
      break;

    case 2:
      Question subtract = new Subtraction();
      Console.WriteLine(subtract.GetQuestion());
      subtract.GetUserInput();
      break;

    case 3:
      Question multiply = new Multiplication();
      Console.WriteLine(multiply.GetQuestion());
      multiply.GetUserInput();
      break;

    case 4:
      Question divide = new Division();
      Console.WriteLine(divide.GetQuestion());
      divide.GetUserInput();
      break;
      
    default:
      Console.Write("Error");
      break;
    }
  }
}

public class RandomOperation{
  public int GetRandomNumber()
  {
    Random random = new Random();
    return random.Next(1, 1);
  }
}

public class RandomOperand
{
  private static int maxOperand = 10;
  
  public void SetMaxOperand(int inNumber)
  {
    maxOperand = inNumber;
  }
  public int[] GetRandomArray()
  {
    Random generator = new Random();
    int[] numberArray = {generator.Next(1,maxOperand), generator.Next(1,maxOperand), generator.Next(1, maxOperand)};
    return numberArray;
  }
}

public class Question
{
  public Question()
  {
    RandomOperand questionOperation = new RandomOperand();
    int[] numberArray = questionOperation.GetRandomArray();
    num1 = numberArray[0];
    num2 = numberArray[1];
    quotient = numberArray[2];
  }

  public int num1;
  public int num2;
  public int quotient;
  
  public virtual string GetQuestion(){
    return "N/A";
  }

  public virtual int GetAnswer(){
    return 0;
  }

  public int GetNum1()
  {
    return num1;
  }

  public int GetNum2()
  {
    return num2;
  }

  public void SetNum1(int inNumber)
  {
    num1 = inNumber;
  }

  public int GetQuotient()
  {
    return quotient;
  }

  public void GetUserInput()
  {
    Console.Write("Input: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    if (userInput == GetAnswer())
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Correct!");
      Console.ResetColor();
    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Incorrect!");
      Console.ResetColor();
      Console.WriteLine("Answer: " + GetAnswer());
    }
  }
}

public class Addition : Question
{
  public override string GetQuestion()
  {
    return "What is " + GetNum1() + " + " + GetNum2() + "?";
  }

  public override int GetAnswer()
  {
    return GetNum1() + GetNum2();
  }
}

public class Subtraction : Question
{
  public override string GetQuestion()
  {
    return "What is " + GetNum1() + " - " + GetNum2() + "?";
  }

  public override int GetAnswer()
  {
    return GetNum1() - GetNum2();
  }
}

public class Multiplication : Question
{
  public override string GetQuestion()
  {
    return "What is " + GetNum1() + " * " + GetNum2() + "?";
  }

  public override int GetAnswer()
  {
    return GetNum1() * GetNum2();
  }
}

public class Division : Question
{
  private void CreateDivisionProblem()
  {
    SetNum1(GetNum2() * GetQuotient());
  }
  public override string GetQuestion()
  {
    CreateDivisionProblem();
    return "What is " + GetNum1() + " / " + GetNum2() + "?";
  }

  public override int GetAnswer()
  {
    return GetNum1() / GetNum2();
  }
}