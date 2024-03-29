﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace SW.MB.UI.WPF.ViewModels
{
    public abstract class BaseViewModel : ObservableRecipient
    {
        public string ModelName => GetType().Name;
    }
}
