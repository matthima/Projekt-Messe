using MesseContextNamespace;

namespace Database._Test
{
    internal class MainLaunch
    {
        public static void Main(string[] args)
        {
            BaseContext db = new MesseContext();
            // TestDataScript.CreateTestData(db);
            DisplayAll.Display(db);
        }
    }
}
