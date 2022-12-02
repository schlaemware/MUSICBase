using System;
using SW.MB.Domain.Contracts.Services;
using SW.MB.Domain.Models.Records;

namespace SW.MB.UI.WPF.ViewModels {
    public class DashboardViewModel : PageViewModel {
        private int _DashboardValue;
        private MandatorRecord? _Mandator;

        public int DashboardValue {
            get => _DashboardValue;
            set => SetProperty(ref _DashboardValue, value);
        }

        #region CONSTRUCTORS
        public DashboardViewModel(IServiceProvider serviceProvider) : base(serviceProvider) {
            IMandatorsDataService.MandatorChanged +=IMandatorsService_MandatorChanged;
        }
        #endregion CONSTRUCTORS

        protected override void OnIsActiveChanged() {
            base.OnIsActiveChanged();

            if (IsActive) {
                LoadDashboard();
            }
        }

        private void LoadDashboard() {
            DashboardValue = new Random().Next();
        }

        #region CALLBACKS
        private void IMandatorsService_MandatorChanged(object? sender, MandatorRecord e) {
            _Mandator = e;

            if (IsActive) {
                LoadDashboard();
            }
        }
        #endregion CALLBACKS
    }
}
