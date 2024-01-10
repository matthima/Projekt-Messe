using ApiContextNamespace;
using MesseContextNamespace;

namespace Database {
    internal class MainLaunch {
        public static void Main(string[] args) {
            BaseContext db = new ApiContext();
            // TestDataScript.CreateTestData(db);
            DisplayAll.Display(db);
        }
    }
}
