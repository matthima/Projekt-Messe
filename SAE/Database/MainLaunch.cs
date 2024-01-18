using MesseContextNamespace;

namespace Database {
    internal class MainLaunch {
        public static void Main(string[] args) {
            BaseContext db = new MesseContext();
            // TestDataScript.CreateTestData(db);
            DisplayAll.Display(db);
        }
    }
}
