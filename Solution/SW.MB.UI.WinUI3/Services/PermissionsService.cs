using SW.MB.UI.WinUI3.Contracts.Services;

namespace SW.MB.UI.WinUI3.Services {
  internal class PermissionsService: IPermissionsService {
    public bool IsCompositionsModuleEnabled { get; set; }
    public bool IsMandatorsModuleEnabled { get; set; }
    public bool IsMembersModuleEnabled { get; set; }
    public bool IsMusiciansModuleEnabled { get; set; }
    public bool IsProgramsModuleEnabled { get; set; }
    public bool IsUsersModuleEnabled { get; set; }

    public void EvaluatePermissions() {
      IsCompositionsModuleEnabled = true;
      IsMandatorsModuleEnabled = true;
      IsMembersModuleEnabled = true;
      IsMusiciansModuleEnabled = true;
      IsProgramsModuleEnabled = true;
      IsUsersModuleEnabled = true;
    }
  }
}
