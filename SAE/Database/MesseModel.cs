using Database;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace MesseContextNamespace {
    public class MesseContext : BaseContext {

        [SetsRequiredMembers]
        public MesseContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, "messe.db");
            Console.WriteLine(DbPath);
        }
    }
}