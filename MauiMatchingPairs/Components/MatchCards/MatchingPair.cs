using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace MauiMatchingPairs.Components.MatchCards
{
    public class MatchingPair : INotifyPropertyChanged
    {
        private string? _left;
        private string? _right;
        private bool _isLeftMatched;
        private bool _isRightMatched;
        private bool _isMatched;
        private Color _leftColor = Colors.White;
        private Color _leftTextColor = Colors.White;
        private Color _rightColor = Colors.White;
        private Color _rightTextColor = Colors.White;
        private bool _isLeftEnabled = true;
        private bool _isRightEnabled = true;

        public string? Left
        {
            get => _left;
            set => SetProperty(ref _left, value);
        }

        public string? Right
        {
            get => _right;
            set => SetProperty(ref _right, value);
        }

        public bool IsLeftMatched
        {
            get => _isLeftMatched;
            set => SetProperty(ref _isLeftMatched, value);
        }

        public bool IsRightMatched
        {
            get => _isRightMatched;
            set => SetProperty(ref _isRightMatched, value);
        }

        public bool IsMatched
        {
            get => _isMatched;
            set => SetProperty(ref _isMatched, value);
        }

        public Color LeftColor
        {
            get => _leftColor;
            set => SetProperty(ref _leftColor, value);
        }

        public Color LeftTextColor
        {
            get => _leftTextColor;
            set => SetProperty(ref _leftTextColor, value);
        }

        public Color RightColor
        {
            get => _rightColor;
            set => SetProperty(ref _rightColor, value);
        }

        public Color RightTextColor
        {
            get => _rightTextColor;
            set => SetProperty(ref _rightTextColor, value);
        }

        public bool IsLeftEnabled
        {
            get => _isLeftEnabled;
            set => SetProperty(ref _isLeftEnabled, value);
        }

        public bool IsRightEnabled
        {
            get => _isRightEnabled;
            set => SetProperty(ref _isRightEnabled, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
