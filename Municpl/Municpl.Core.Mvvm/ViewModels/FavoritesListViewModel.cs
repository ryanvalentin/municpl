using Municpl.Core.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Municpl.Core.ViewModels
{
    public class FavoritesListViewModel : MunicplBaseViewModel, IMunicplViewModel
    {
        public FavoritesListViewModel()
            : base("favorites", "Favorites")
        {
        }
    }
}
