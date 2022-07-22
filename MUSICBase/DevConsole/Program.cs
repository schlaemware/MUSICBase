using SW.MB.DA.Models.Records;
using SW.MB.DA.Sqlite;

namespace DevConsole {
  internal class Program {
    static void Main(string[] args) {
      SQLiteDbContext context = new(@"C:\Temporary\MBSQLiteRepo.db");

      CompositionRecord? rec = context.Insert(new CompositionRecord() { Title = "Record" });
    }
  }
}