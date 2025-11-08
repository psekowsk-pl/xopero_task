namespace XOPERO_task.UI_Tests;

public class ValueGeneratorHelper
{
    private static Random _rnd = new();
    public static int[] GetRandomNumbersArray(int minLength, int maxLength, int numberOfElements = 1)
    {
        if (minLength >= maxLength)
            throw new ArgumentException("Min must be less than max.");

        var generatedNumbers = new HashSet<int>();

        while (generatedNumbers.Count < numberOfElements)
        {
            generatedNumbers.Add(_rnd.Next(minLength, maxLength));
        }

        return generatedNumbers.ToArray();
    }
}
