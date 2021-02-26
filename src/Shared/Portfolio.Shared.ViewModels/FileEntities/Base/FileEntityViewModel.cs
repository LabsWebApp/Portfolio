using System;
using Portfolio.Shared.ViewModels.Base;

namespace Portfolio.Shared.ViewModels.FileEntities.Base
{
    public abstract class FileEntityViewModel : BaseViewModel
    {
        private string name, fullName;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                set(ref name, value);
            }
        }

        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                set(ref fullName, value);
            }
        }

        protected FileEntityViewModel(string name) => Name = name;
    }
}