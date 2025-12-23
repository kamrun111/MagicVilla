namespace MagicVilla_API.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, string type)
        {
           if (type == "Error")
            {
                Console.WriteLine(" error." + message);
            }
            else 
            {
                Console.WriteLine(message);
            }
     
        }
    }
}
