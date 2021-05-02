﻿using System.Windows.Input;
using RBTools.Application.Config;
using RBTools.Application.Exceptions;
using RBTools.UI.Wpf.SeedWork;

namespace RBTools.UI.Wpf.ViewModels
{
    public class SettingsViewModel : NotifyPropertyChanged
    {
        private IConfigurationMemento _memento;
        private readonly IConfigurationManager _settingsManager;

        public SettingsViewModel(ConfigurationViewModel configuration, IConfigurationManager settingsManager)
        {
            Configuration = configuration;
            _settingsManager = settingsManager;
            _memento = new ConfigurationMemento(configuration.ToConfiguration());
            
            ImportCommand = new RelayCommand<object>(o => Import());
            ExportCommand = new RelayCommand<object>(o => Export());
            SaveCommand = new RelayCommand<object>(o => Save(), o => _memento.HasStateChanged(Configuration.ToConfiguration()));
        }

        public ConfigurationViewModel Configuration { get; }
        public ICommand ImportCommand { get; }
        public ICommand ExportCommand { get; }
        public ICommand SaveCommand { get; }

        private void Import()
        {
            try
            {
                IConfiguration configuration = _settingsManager.Import();
                Configuration.FromConfiguration(configuration);
            }
            catch (UserAbortedActionException)
            {
                return;
            }
        }

        private void Export()
        {
            IConfiguration configuration = Configuration.ToConfiguration();
            _settingsManager.Export(configuration);
        }

        private void Save()
        {
            IConfiguration configuration = Configuration.ToConfiguration();
            _settingsManager.Save(configuration);
            _memento = new ConfigurationMemento(configuration);
        }
    }
}
