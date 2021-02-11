using System.IO;
using Portfolio.Shared.ViewModels.FileEntities.Base;

namespace Portfolio.Shared.ViewModels.FileEntities
{
    public sealed class FileViewModel : FileEntityViewModel
    {
        public FileViewModel(string name) : base(name) { }
        public FileViewModel(FileInfo fileInfo)
            : base(fileInfo.Name) => FullName = fileInfo.FullName;
    }
}