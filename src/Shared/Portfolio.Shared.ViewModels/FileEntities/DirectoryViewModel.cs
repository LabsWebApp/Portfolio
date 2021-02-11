using System.IO;
using Portfolio.Shared.ViewModels.FileEntities.Base;

namespace Portfolio.Shared.ViewModels.FileEntities
{
    public sealed class DirectoryViewModel : FileEntityViewModel
    {
        public DirectoryViewModel(string directoryName) 
            : base(directoryName) => FullName = directoryName;

        public DirectoryViewModel(DirectoryInfo directoryName) 
            : base(directoryName.Name) => FullName = directoryName.FullName;
    }
}