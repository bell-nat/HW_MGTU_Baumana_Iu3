namespace HW_NGTU_Baumana_Iu3;

public class ValueBox<T>
{
    public T? Value { get; set; }
    public bool IsParse { get; set; }
}


public static class ConsoleWrapper
{
    public static float GetFloat(string message) => GetDigital<float>(message, FloatParse);

    public static int GetInt(string message) => GetDigital<int>(message, IntParse);

    private static T GetDigital<T>(string message, Delegate method)
    {
        Console.WriteLine(message);
        do
        {
            string? line = Console.ReadLine();
            ValueBox<T> valueBox = (ValueBox<T>)method.DynamicInvoke(new object[] { line });
            if (valueBox?.IsParse ?? false) { return valueBox.Value; }
            Console.WriteLine("Повторите ввод.");
        } while (true);
    }

    private static ValueBox<int> IntParse(string? line) => new()
    {
        IsParse = int.TryParse(line, out int result),
        Value = result
    };

    private static ValueBox<float> FloatParse(string? line) => new()
    {
        IsParse = float.TryParse(line, out float result),
        Value = result
    };
}