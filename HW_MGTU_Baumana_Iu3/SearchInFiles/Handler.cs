namespace HW_MGTU_Baumana_Iu3.SearchInFiles;

/*
 Поиск номеров с ошибкой

   У большинства правовых актов или судебных решений есть определенный регистрационный номер, по которому их просто находить. При этом номер может состоять из цифр, букв, знаков препинания, примеры:
   ●  00-04-05/1809
   ●  33-10000/10
   ●  003/У-МС
   ●  А63-3110/2013
   ●  ПНАЭ Г-5-40-97
   ●  23-НП
   ●  (17135)А07-СК-1/6/2007-Г-БАА
   Часто пользователи могут случайно ошибиться при вводе такого сложного номера – забыть поставить тире или пропустить нолик. В архиве «2numbers.rar» находится список всех реально существующих номеров законов и судебных решений, а также запросы, в которых номера были введены с ошибками. Предлагается реализовать алгоритм, который, получая на вход некорректный номер, возвращал один или несколько наиболее похожих на него реальных номеров.
   Примеры
   ●  На запрос 0817/пзн нужно уметь находить «08-17/ПЗ-Н»
   ●  На запрос 140311/07539 нужно уметь находить «14-03-11/07-539»
   ●  На запрос ЯК373/12611 нужно уметь находить «ЯК-37-3/12611@»

   Задание
   Каждому номеру закона и судебного решения, написанному с ошибками, из файла «номера_запросы» сопоставить его правильный вариант из файлов «номера_законов» и «номера_судебных_решений».
 */
public class Handler : BaseHandler
{
    public override void Start()
    {
        string pathQeries = "SearchInFiles\\Запросы.txt";
        string pathDecisions = "SearchInFiles\\Решения.txt";
        string pathLaws = "SearchInFiles\\Законы.txt";

        Io io = new Io();
        List<string> qeries = io.Reader(pathQeries);
        Random rnd = new();

        List<string> decisions = io.Reader(pathDecisions);
        List<string> laws = io.Reader(pathLaws);

        Finder finder = new(decisions, laws);
        Viewer viewer = new();
        do
        {
            string query = qeries[rnd.Next(0, qeries.Count - 1)];
            List<string> resLaws = finder.SearchLaws(query);
            List<string> resDec = finder.SearchDecisions(query);
            viewer.View(ref resLaws, ref resDec, ref query);
            Console.WriteLine("Для завершения нажмите Escape");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
        } while (true);
    }
}