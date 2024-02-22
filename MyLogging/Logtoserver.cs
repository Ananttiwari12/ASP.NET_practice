namespace ASP.NET_tut.MyLogging
{
    public class Logtoserver: IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogToServer");
        }
    }
}