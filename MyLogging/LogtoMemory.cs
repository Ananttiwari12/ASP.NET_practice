namespace ASP.NET_tut.MyLogging
{
    public class LogtoMemory: IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogToMemory");
        }
    }
}