using System;
using System.Collections.Generic;
using System.Text;

namespace Municpl.Core.ViewModels
{
    public interface IMunicplViewModel
    {
        string Id { get; }

        void Initialize(object parameter);
    }
}
