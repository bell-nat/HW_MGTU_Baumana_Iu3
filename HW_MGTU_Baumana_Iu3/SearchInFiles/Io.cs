namespace HW_MGTU_Baumana_Iu3.SearchInFiles
{
    public class Io
    {
        public List<string> Reader(string path)
        {
            List<string> list = new List<string>();
            using StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    list.Add(line);
                }
            }
            return list;
        }
    }
}
