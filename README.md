# MatchingPairsView (.NET MAUI Component)

## Overview

**MatchingPairsView** is a reusable .NET MAUI UI component for creating interactive matching-pairs games or exercises. It displays two columns of selectable items (words or phrases), where the user must match each item on the left with its corresponding item on the right. The component provides visual feedback for correct and incorrect matches, tracks the number of attempts, and exposes a customizable "Continue" button that is enabled only when all pairs are matched.

This component is ideal for educational apps, language learning, memory games, and any scenario where matching logic is required.

---

## Features

- **Two-column matching UI**: Users select one item from each column to attempt a match.
- **Visual feedback**: Colors indicate correct (green) or incorrect (red) matches, with customizable colors.
- **Selection feedback**: Customizable colors for selected items.
- **Disables matched pairs**: Once matched, items cannot be selected again.
- **Tracks attempts**: Counts and optionally displays the number of user attempts.
- **Customizable "Continue" button**: Text, style, command, and event can be customized.
- **Configurable delay**: Set the feedback display duration.
- **MVVM-friendly**: All parameters are bindable properties.

---

## Usage Example

```
<components:MatchingPairsView
	ButtonConfirmCommand="{Binding OnContinueCommand}"
	ButtonConfirmText="Next"
	CorrectColor="LimeGreen"
	DefaultBackgroundColor="White"
	DefaultStrokeColor="Gray"
	DefaultTextColor="Black"
	Delay="300"
	Pairs="{Binding MyPairs}"
	SelectedBorderColor="DodgerBlue"
	ShowAttempts="True"
	WrongColor="Crimson" />
```

---

## Parameters

| Property Name            | Type                | Default         | Description                                                                                 |
|--------------------------|---------------------|-----------------|---------------------------------------------------------------------------------------------|
| `Pairs`                  | ObservableCollection<MatchingPair> |             | The list of pairs to match.                                                                 |
| `ShowAttempts`           | bool                | `true`          | Whether to display the attempt count label.                                                 |
| `AttemptCount`           | int                 | `0`             | The number of attempts made (read-only, updated by the component).                          |
| `AllMatched`             | bool                | `false`         | Indicates if all pairs have been matched (read-only, updated by the component).             |
| `Delay`                  | int                 | `200`           | Delay in milliseconds for feedback display after a match attempt.                            |
| `ButtonConfirmText`      | string              | `"Continue"`    | The text displayed on the confirm button.                                                   |
| `ButtonConfirmStyle`     | Style               | `null`          | The style applied to the confirm button.                                                    |
| `ButtonConfirmCommand`   | ICommand            | `null`          | Command executed when the confirm button is clicked.                                        |
| `ButtonConfirmClicked`   | EventHandler        | `null`          | Event raised when the confirm button is clicked.                                            |
| `CorrectColor`           | Color               | `Green`         | Border color for a correct match.                                                           |
| `CorrectTextColor`       | Color               | `Green`         | Text color for a correct match.                                                             |
| `WrongColor`             | Color               | `Red`           | Border color for an incorrect match.                                                        |
| `WrongTextColor`         | Color               | `Red`           | Text color for an incorrect match.                                                          |
| `SelectedBorderColor`    | Color               | `DodgerBlue`    | Border color for a selected item.                                                           |
| `SelectedTextColor`      | Color               | `DodgerBlue`    | Text color for a selected item.                                                             |
| `DefaultStrokeColor`     | Color               | `#FF444444`     | Default border color for items.                                                             |
| `DefaultBackgroundColor` | Color               | `White`         | Default background color for items.                                                         |
| `DefaultTextColor`       | Color               | `White`         | Default text color for items.                                                               |

---

## Events and Commands

- **ButtonConfirmCommand**: Bind to an `ICommand` in your ViewModel for MVVM scenarios.
- **ButtonConfirmClicked**: Attach an event handler in code-behind for direct event handling.

---

## Data Model

Each item in `Pairs` should be a `MatchingPair` object with at least `Left` and `Right` string properties.

---

## Customization

All colors, button text, styles, and delay are fully customizable via bindable properties.

---

## Requirements

- .NET MAUI
- C# 13.0
- .NET 9
