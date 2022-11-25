using Newtonsoft.Json;

namespace SW.MB.Domain.Helpers {
  public static class MyJsonConverter {
    public static async Task<string> StringifyAsync(object? value) {
      return await Task.Run(() => {
        return JsonConvert.SerializeObject(value);
      });
    }

    public static async Task<T> ToObjectAsync<T>(string value) {
      return await Task.Run(() => {
        return JsonConvert.DeserializeObject<T>(value)!;
      });
    }
  }
}
