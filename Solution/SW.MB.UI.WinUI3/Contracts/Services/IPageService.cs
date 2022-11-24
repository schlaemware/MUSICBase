using System;

namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface IPageService {
    public Type GetPageType(string key);
  }
}
