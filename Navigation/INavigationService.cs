using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NAV_Prototyp_Vorlage.Navigation
{
    public interface INavigationService
    {
        void OpenWindow<T>() where T : Window;
    }
}
