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

        private string _currentPath;
        public string CurrentPath 
        { 
            get => _currentPath;
            set => set(ref _currentPath, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => set(ref _title, value);
        }

        private FileEntityViewModel _selectedFileEntity;

        public FileEntityViewModel SelectedFileEntity
        {
            get => _selectedFileEntity;
            set => set(ref _selectedFileEntity, value);
        }

        private ObservableCollection<FileEntityViewModel> 
            _directoriesAndFiles = new();

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles
        {
            get => _directoriesAndFiles;
            set => set(ref _directoriesAndFiles, value);
        }
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
