using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiMatchingPairs.Components.MatchCards;

public partial class MatchingPairsView : ContentView
{
    public static readonly BindableProperty AllMatchedProperty =
            BindableProperty.Create(
                nameof(AllMatched),
                typeof(bool),
                typeof(MatchingPairsView),
                false,
                BindingMode.OneWayToSource);

    public static readonly BindableProperty AttemptCountProperty =
            BindableProperty.Create(
                nameof(AttemptCount),
                typeof(int),
                typeof(MatchingPairsView),
                0,
                BindingMode.OneWayToSource);

    // BindableProperty for the button clicked event handler
    public static readonly BindableProperty ButtonConfirmClickedProperty =
        BindableProperty.Create(
            nameof(ButtonConfirmClicked),
            typeof(EventHandler),
            typeof(MatchingPairsView),
            null);

    // BindableProperty for the button command
    public static readonly BindableProperty ButtonConfirmCommandProperty =
        BindableProperty.Create(
            nameof(ButtonConfirmCommand),
            typeof(ICommand),
            typeof(MatchingPairsView),
            null);

    public static readonly BindableProperty ButtonConfirmStyleProperty =
        BindableProperty.Create(
            nameof(ButtonConfirmStyle),
            typeof(Style),
            typeof(MatchingPairsView),
            default(Style));

    public static readonly BindableProperty ButtonConfirmTextProperty =
        BindableProperty.Create(
            nameof(ButtonConfirmText),
            typeof(string),
            typeof(MatchingPairsView),
            "Continue");

    // BindableProperty for the correct color (green)
    public static readonly BindableProperty CorrectColorProperty =
        BindableProperty.Create(
            nameof(CorrectColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Colors.Green);

    // BindableProperty for the correct text color (default: Green)
    public static readonly BindableProperty CorrectTextColorProperty =
        BindableProperty.Create(
            nameof(CorrectTextColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Colors.Green);

    // BindableProperty for the default background color (white)
    public static readonly BindableProperty DefaultBackgroundColorProperty =
        BindableProperty.Create(
            nameof(DefaultBackgroundColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Colors.White);

    // BindableProperty for the default stroke color (gray)
    public static readonly BindableProperty DefaultStrokeColorProperty =
        BindableProperty.Create(
            nameof(DefaultStrokeColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Color.FromArgb("#FF444444"));

    // BindableProperty for the default text color (black)
    public static readonly BindableProperty DefaultTextColorProperty =
        BindableProperty.Create(
            nameof(DefaultTextColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Colors.Black);

    public static readonly BindableProperty DelayProperty =
        BindableProperty.Create(
            nameof(Delay),
            typeof(int),
            typeof(MatchingPairsView),
            200);

    public static readonly BindableProperty PairsProperty =
            BindableProperty.Create(
            nameof(Pairs),
            typeof(ObservableCollection<MatchingPair>),
            typeof(MatchingPairsView),
            propertyChanged: OnPairsChanged);

    // BindableProperty for the selected border color (default: DodgerBlue)
    public static readonly BindableProperty SelectedBorderColorProperty =
        BindableProperty.Create(
            nameof(SelectedBorderColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Color.FromArgb("#FF1E90FF"));

    // BindableProperty for the selected text color (default: DodgerBlue)
    public static readonly BindableProperty SelectedTextColorProperty =
        BindableProperty.Create(
            nameof(SelectedTextColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Color.FromArgb("#FF1E90FF"));

    // BindableProperty for showing or hiding the attempt count
    public static readonly BindableProperty ShowAttemptsProperty =
        BindableProperty.Create(
            nameof(ShowAttempts),
            typeof(bool),
            typeof(MatchingPairsView),
            true);

    // BindableProperty for the wrong color (red)
    public static readonly BindableProperty WrongColorProperty =
        BindableProperty.Create(
            nameof(WrongColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Colors.Red);

    // BindableProperty for the wrong text color (default: Red)
    public static readonly BindableProperty WrongTextColorProperty =
        BindableProperty.Create(
            nameof(WrongTextColor),
            typeof(Color),
            typeof(MatchingPairsView),
            Colors.Red);

    public MatchingPair? selectedLeft;

    public MatchingPair? selectedRight;

    private bool _isBusy;

    private List<MatchingPair> _pairs = new();

    public MatchingPairsView()
    {
        InitializeComponent();

        // Optionally, you can wire up the button click here if not done in XAML
        buttonConfirm.Clicked += OnButtonConfirmClicked;
    }

    public bool AllMatched
    {
        get => (bool)GetValue(AllMatchedProperty);
        set => SetValue(AllMatchedProperty, value);
    }

    public int AttemptCount
    {
        get => (int)GetValue(AttemptCountProperty);
        set => SetValue(AttemptCountProperty, value);
    }

    public EventHandler? ButtonConfirmClicked
    {
        get => (EventHandler?)GetValue(ButtonConfirmClickedProperty);
        set => SetValue(ButtonConfirmClickedProperty, value);
    }

    public ICommand? ButtonConfirmCommand
    {
        get => (ICommand?)GetValue(ButtonConfirmCommandProperty);
        set => SetValue(ButtonConfirmCommandProperty, value);
    }

    public Style? ButtonConfirmStyle
    {
        get => (Style?)GetValue(ButtonConfirmStyleProperty);
        set => SetValue(ButtonConfirmStyleProperty, value);
    }

    // DodgerBlue
    public string ButtonConfirmText
    {
        get => (string)GetValue(ButtonConfirmTextProperty);
        set => SetValue(ButtonConfirmTextProperty, value);
    }

    public Color CorrectColor
    {
        get => (Color)GetValue(CorrectColorProperty);
        set => SetValue(CorrectColorProperty, value);
    }

    public Color CorrectTextColor
    {
        get => (Color)GetValue(CorrectTextColorProperty);
        set => SetValue(CorrectTextColorProperty, value);
    }

    public Color DefaultBackgroundColor
    {
        get => (Color)GetValue(DefaultBackgroundColorProperty);
        set => SetValue(DefaultBackgroundColorProperty, value);
    }

    public Color DefaultStrokeColor
    {
        get => (Color)GetValue(DefaultStrokeColorProperty);
        set => SetValue(DefaultStrokeColorProperty, value);
    }
    public Color DefaultTextColor
    {
        get => (Color)GetValue(DefaultTextColorProperty);
        set => SetValue(DefaultTextColorProperty, value);
    }

    public int Delay
    {
        get => (int)GetValue(DelayProperty);
        set => SetValue(DelayProperty, value);
    }

    public ObservableCollection<MatchingPair> LeftWords { get; } = new();

    public ObservableCollection<MatchingPair> Pairs
    {
        get => (ObservableCollection<MatchingPair>)GetValue(PairsProperty);
        set => SetValue(PairsProperty, value);
    }

    public ObservableCollection<MatchingPair> RightWords { get; } = new();

    public Color SelectedBorderColor
    {
        get => (Color)GetValue(SelectedBorderColorProperty);
        set => SetValue(SelectedBorderColorProperty, value);
    }

    public Color SelectedTextColor
    {
        get => (Color)GetValue(SelectedTextColorProperty);
        set => SetValue(SelectedTextColorProperty, value);
    }

    // DodgerBlue
    public bool ShowAttempts
    {
        get => (bool)GetValue(ShowAttemptsProperty);
        set => SetValue(ShowAttemptsProperty, value);
    }

    public Color WrongColor
    {
        get => (Color)GetValue(WrongColorProperty);
        set => SetValue(WrongColorProperty, value);
    }

    public Color WrongTextColor
    {
        get => (Color)GetValue(WrongTextColorProperty);
        set => SetValue(WrongTextColorProperty, value);
    }

    private static void OnPairsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is MatchingPairsView view && newValue is IEnumerable<MatchingPair> pairs)
        {
            view.SetPairs(pairs);
        }
    }
    private void OnButtonConfirmClicked(object? sender, EventArgs e)
    {
        // Raise the event if set
        ButtonConfirmClicked?.Invoke(this, e);

        // Execute the command if set and can execute
        if (ButtonConfirmCommand?.CanExecute(null) == true)
            ButtonConfirmCommand.Execute(null);
    }

    private void OnLeftSelection(object sender, SelectionChangedEventArgs e)
    {
        var selected = e.CurrentSelection.FirstOrDefault() as MatchingPair;
        if (selected == null || !selected.IsLeftEnabled)
        {
            // Deselect if not enabled
            LeftCollection.SelectedItem = null;
            return;
        }
        selectedLeft = selected;

        LeftWords.Where(x => x.Left == selectedLeft.Left).ToList()
                 .ForEach(x =>
                 {
                     x.LeftColor = SelectedBorderColor;
                     x.LeftTextColor = SelectedTextColor;
                 });

        TryMatch();
    }

    private void OnRightSelection(object sender, SelectionChangedEventArgs e)
    {
        var selected = e.CurrentSelection.FirstOrDefault() as MatchingPair;
        if (selected == null || !selected.IsRightEnabled)
        {
            // Deselect if not enabled
            RightCollection.SelectedItem = null;
            return;
        }
        selectedRight = selected;

        RightWords.Where(x => x.Right == selectedRight.Right).ToList()
         .ForEach(x =>
         {
             x.RightColor = SelectedBorderColor;
             x.RightTextColor = SelectedTextColor;
         });

        TryMatch();
    }

    private void SetCollectionsEnabled(bool enabled)
    {
        LeftCollection.IsEnabled = enabled;
        RightCollection.IsEnabled = enabled;
    }

    private void SetPairs(IEnumerable<MatchingPair> pairs)
    {
        _pairs = pairs.ToList();
        LeftWords.Clear();
        RightWords.Clear();

        foreach (var pair in _pairs)
        {
            LeftWords.Add(new MatchingPair
            {
                Left = pair.Left,
                Right = pair.Right,
                LeftColor = DefaultStrokeColor,
                LeftTextColor = DefaultTextColor
            });
            RightWords.Add(new MatchingPair
            {
                Left = pair.Left,
                Right = pair.Right,
                RightColor = DefaultStrokeColor,
                RightTextColor = DefaultTextColor
            });
        }

        // Shuffle right column for game effect
        var shuffled = RightWords.OrderBy(_ => Guid.NewGuid()).ToList();
        RightWords.Clear();
        foreach (var w in shuffled) RightWords.Add(w);

        AttemptCount = 0; // Reset attempts
    }

    private async void TryMatch()
    {
        if (selectedLeft == null || selectedRight == null) return;
        if (_isBusy) return;

        _isBusy = true;
        SetCollectionsEnabled(false);

        AttemptCount++;

        // Use FirstOrDefault for single match
        var leftMatch = LeftWords.FirstOrDefault(x => x.Left == selectedLeft.Left);
        var rightMatch = RightWords.FirstOrDefault(x => x.Right == selectedRight.Right);

        if (leftMatch == null || rightMatch == null)
        {
            _isBusy = false;
            SetCollectionsEnabled(true);
            return;
        }

        if (selectedLeft.Right == selectedRight.Right)
        {
            leftMatch.LeftColor = CorrectColor;
            leftMatch.LeftTextColor = CorrectTextColor;
            leftMatch.IsMatched = true;
            leftMatch.IsLeftEnabled = false;

            rightMatch.RightColor = CorrectColor;
            rightMatch.RightTextColor = CorrectTextColor;
            rightMatch.IsMatched = true;
            rightMatch.IsRightEnabled = false;

            await Task.Delay(Delay); // Reduce delay for better UX
        }
        else
        {
            leftMatch.LeftColor = WrongColor;
            leftMatch.LeftTextColor = WrongTextColor;
            rightMatch.RightColor = WrongColor;
            rightMatch.RightTextColor = WrongTextColor;

            await Task.Delay(Delay);

            leftMatch.LeftColor = DefaultStrokeColor;
            leftMatch.LeftTextColor = DefaultTextColor;
            rightMatch.RightColor = DefaultStrokeColor;
            rightMatch.RightTextColor = DefaultTextColor;
        }

        selectedLeft = null;
        selectedRight = null;

        // Force UI update workaround for iOS
        LeftCollection.SelectionChanged -= OnLeftSelection;
        LeftCollection.SelectedItem = new object();
        LeftCollection.SelectedItem = null;
        LeftCollection.SelectionChanged += OnLeftSelection;

        // Force UI update workaround for iOS
        RightCollection.SelectionChanged -= OnRightSelection;
        RightCollection.SelectedItem = new object();
        RightCollection.SelectedItem = null;
        RightCollection.SelectionChanged += OnRightSelection;

        UpdateAllMatched();

        if (!AllMatched)
            SetCollectionsEnabled(true);

        _isBusy = false;
    }

    private void UpdateAllMatched()
    {
        AllMatched = LeftWords.All(x => !x.IsLeftEnabled) && RightWords.All(x => !x.IsRightEnabled);
    }
}