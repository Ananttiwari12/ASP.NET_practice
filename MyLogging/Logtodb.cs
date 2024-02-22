namespace ASP.NET_tut.MyLogging
{
    public class LogtoDB:IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogToDB");
        }
    }   
}