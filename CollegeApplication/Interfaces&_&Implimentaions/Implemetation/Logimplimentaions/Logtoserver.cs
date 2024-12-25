using CollegeApplication.Interfaces___Implimentaions.Interfaces;

namespace CollegeApplication.Logings.Implemet_ILog
{
    public class Logtoserver : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
