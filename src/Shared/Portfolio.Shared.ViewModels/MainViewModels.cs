using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Portfolio.Shared.ViewModels.Base;
using Portfolio.Shared.ViewModels.FileEntities;
using Portfolio.Shared.ViewModels.FileEntities.Base;

namespace Portfolio.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties
        public string CurrentPath { get; set; }
        public string Title { get; private set; } 
        public FileEntityViewModel SelectedFileEntity { get; set; }

        public ObservableCollection<FileEntityViewModel>
            DirectoriesAndFiles { get; set; } = new ObservableCollection<FileEntityViewModel>();
        #endregion

        #region Commands
        public ICommand OpenCommand { get; }

        #endregion

        #region Command Methods

        private void Open(object parametr)
        {
            if (parametr is DirectoryViewModel directoryViewModel)
            {
                CurrentPath = directoryViewModel.FullName;
                Title = directoryViewModel.Name ?? "Портфолио";
                DirectoriesAndFiles.Clear();
                var directoryInfo = new DirectoryInfo(CurrentPath);
                foreach (var directory in directoryInfo.GetDirectories())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
                foreach (var file in directoryInfo.GetFiles())
                    DirectoriesAndFiles.Add(new FileViewModel(file));
            }
        }

        #endregion

        #region Construktors
        public MainViewModel()
        {
            OpenCommand = new Command(Open);
            foreach (var logicalDrive in Directory.GetLogicalDrives()) 
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
            Title = "Портфолио";
        }
        #endregion
    }
}
