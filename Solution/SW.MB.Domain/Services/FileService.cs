using Newtonsoft.Json;
using System.Text;
using SW.MB.Domain.Contracts.Services;

namespace SW.MB.Domain.Services {
  public class FileService: IFileService {
    public T? Read<T>(string folderPath, string fileName) where T : class {
      string path = Path.Combine(folderPath, fileName);
      if (File.Exists(path)) {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<T>(json) ?? default;
      }

      return default;
    }

    public void Save<T>(string folderPath, string fileName, T content) {
      if (!Directory.Exists(folderPath)) {
        Directory.CreateDirectory(folderPath);
      }

      string fileContent = JsonConvert.SerializeObject(content);
      File.WriteAllText(Path.Combine(folderPath, fileName), fileContent, Encoding.UTF8);
    }

    public void Delete(string folderPath, string fileName) {
      if (fileName != null && File.Exists(Path.Combine(folderPath, fileName))) {
        File.Delete(Path.Combine(folderPath, fileName));
      }
    }
  }
}
