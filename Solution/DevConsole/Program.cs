using SW.MB.Data.Models.Records;

internal class Program {
  private static void Main(string[] args) {
    Console.WriteLine("Hello, MUSICBase!");

    CompositionRecord record = new CompositionRecord() {
      ID = 1,
      Title = "Titel A"
    };

    CompositionRecord record2 = record with { ID = 2, Title = "Titel B" };
  }
}