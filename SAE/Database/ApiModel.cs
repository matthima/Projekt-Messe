using Database;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ApiContextNamespace {
    public class ApiContext : BaseContext {

        [SetsRequiredMembers]
        public ApiContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "messe_api.db");
            Console.WriteLine(DbPath);
            Database.EnsureCreated();
        }

        [SetsRequiredMembers]
        public ApiContext(DbContextOptions options) : base(options) {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "messe_api.db");
            Console.WriteLine(DbPath);
            Database.EnsureCreated();
        }
    }
}