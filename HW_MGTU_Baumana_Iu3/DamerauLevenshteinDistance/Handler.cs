namespace HW_MGTU_Baumana_Iu3.DamerauLevenshteinDistance;

public class Handler : BaseHandler
{
    public override void Start()
    {
        Distance distance = new();
        string first = "Аббревиатура";
        string second = "Бабреваитуар";
        int interval = distance.DamerauLevenshteinDistance(first, second);
        Console.WriteLine($"Расстояние Дамерау-Левенштейна между \"{first}\" и \"{second}\": {interval}");
        first = "Фуникулер";
        second = "Уфнниуклер";
        interval = distance.DamerauLevenshteinDistance(first, second);
        Console.WriteLine($"Расстояние Дамерау-Левенштейна между \"{first}\" и \"{second}\": {interval}");
    }
}