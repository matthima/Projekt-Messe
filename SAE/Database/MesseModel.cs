using Database;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MesseContextNamespace {
    public class MesseContext : BaseContext {


        public MesseContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, "messe.db");
            Console.WriteLine(DbPath);
        }

        public MesseContext(DbContextOptions options) : base(options) {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = Path.Join(path, "messe_api.db");
            //Console.WriteLine(DbPath);
        }
    }
}