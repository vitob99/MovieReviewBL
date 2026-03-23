
public sealed class LogManager
{
    private static LogManager? instance;

    private List<string> log_list = new List<string>();
    


    public static LogManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new LogManager();
            }
            return instance;
        }
    }
        
    public void AddLog(string type, string log_message)
    {
        string log_string = $"[{type}] - [{DateTime.Now}] - {log_message}";
        log_list.Add(log_string);
    }
    
    public void GetLogs()
    {
        foreach(string log in log_list)
        {
            Console.WriteLine(log.PadLeft((Console.WindowWidth + log.Length) / 2));
        }
    }

    public int LogNumber()
    {
        return log_list.Count();
    }

    public void ClearLogs()
    {
        log_list.Clear();
    }
}