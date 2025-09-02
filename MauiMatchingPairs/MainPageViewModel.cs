using CommunityToolkit.Mvvm.ComponentModel;
using MauiMatchingPairs.Components.MatchCards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMatchingPairs
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty] public ObservableCollection<MatchingPair> _myPairs;

        public MainPageViewModel()
        {
            MyPairs = new ObservableCollection<MatchingPair>()
            {
                new MatchingPair { Left = "to guide", Right = "guiar" },
                new MatchingPair { Left = "to walk", Right = "caminar" },
                new MatchingPair { Left = "to run", Right = "correr" }
            };
        }
    }
}