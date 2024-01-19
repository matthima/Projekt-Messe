using Database;
using System.Diagnostics.CodeAnalysis;

namespace MesseContextNamespace {
    public class MesseContext : BaseContext {

        [SetsRequiredMembers]
        public MesseContext() {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, "messe.db");
            Console.WriteLine(this.DbPath);
        }
    }
}