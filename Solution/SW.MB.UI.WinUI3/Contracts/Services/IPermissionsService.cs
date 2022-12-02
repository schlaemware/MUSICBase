namespace SW.MB.UI.WinUI3.Contracts.Services {
  public interface IPermissionsService {
    public bool IsCompositionsModuleEnabled { get; }
    public bool IsMandatorsModuleEnabled { get; }
    public bool IsMembersModuleEnabled { get; }
    public bool IsMusiciansModuleEnabled { get; }
    public bool IsProgramsModuleEnabled { get; }
    public bool IsUsersModuleEnabled { get; }

    public void EvaluatePermissions();
  }
}
