using Database;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ApiContextNamespace {
    public class ApiContext : BaseContext {

        [SetsRequiredMembers]
        public ApiContext() {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, "messe_api.db");
            Console.WriteLine(this.DbPath);
            this.Database.EnsureCreated();
        }

        [SetsRequiredMembers]
        public ApiContext(DbContextOptions options) : base(options) {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, "messe_api.db");
            Console.WriteLine(this.DbPath);
            this.Database.EnsureCreated();
        }
    }
}