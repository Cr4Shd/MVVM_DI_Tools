using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NAV_Prototyp_Vorlage.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceprovider;

        public NavigationService(IServiceProvider _service)
        {
            this._serviceprovider = _service;
        }

        public void OpenWindow<T>() where T : Window
        {
            var window = _serviceprovider.GetRequiredService<T>();
            window.Show();
        }
    }
}
