namespace SW.MB.Domain.Contracts.Services {
  public interface IFileService {
    public void Delete(string folderPath, string fileName);
    public T? Read<T>(string folderPath, string fileName) where T : class;
    public void Save<T>(string folderPath, string fileName, T content);
  }
}
