using Database;
using Microsoft.EntityFrameworkCore;

namespace ApiContextNamespace {
    public class ApiContext : BaseContext {
        public ApiContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "messe_api.db");
            Console.WriteLine(DbPath);
            Database.EnsureCreated();
        }

        public ApiContext(DbContextOptions options) : base(options) {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "messe_api.db");
            Console.WriteLine(DbPath);
            Database.EnsureCreated();
        }
    }
}