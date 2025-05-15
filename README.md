# Random Art Screen Saver (C# Windows Forms)

[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![.NET](https://github.com/MadMerick/RandomArt_ScreenSaver/workflows/.NET/badge.svg)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/MadMerick/RandomArt_ScreenSaver)

## Overview

The Random Art Screen Saver is a C# Windows Forms application that displays a rotating selection of procedurally generated visual art as a custom screen saver. It cycles through various artistic styles, each with its own unique parameters, creating a dynamic and ever-changing display on your screen. Smooth transitions between art styles enhance the viewing experience.

## Art Styles & Settings

The screen saver features the following art generation methods, with customizable settings:

* **Dots:** Draws a pattern of individual dots.
    * *(No specific settings exposed in `SaverSettings.cs`)*
* **Grow:** Creates an effect of elements growing or expanding.
    * *(No specific settings exposed in `SaverSettings.cs`)*
* **Scribble:** Generates random scribbled lines.
    * **Length:** Controls the average length of the scribble lines (`Scribble.Length`, default: 4).
* **Light:** Simulates a light source with adjustable transparency and center position.
    * **Transparent:** Sets the transparency level of the light effect (0.0 - 0.99, `Light.Transparent`, default: 0.0).
    * **Center:** Adjusts the center point of the light effect (0.0 - 1.0, `Light.Center`, default: 0.0).
* **Weeds:** Creates a pattern resembling growing weeds or organic lines.
    * *(No specific settings exposed in `SaverSettings.cs`)*
* **Bubbles:** Generates a display of floating bubbles with adjustable transparency and center concentration.
    * **Transparent:** Sets the transparency level of the bubbles (0.0 - 0.99, `Bubble.Transparent`, default: 0.5).
    * **Center:** Controls the concentration of bubbles towards a center point (0.0 - 0.99, `Bubble.Center`, default: 0.2).
* **Warp:** Distorts the display with wave-like effects.
    * **Angles:** Determines the number of angles or waves in the warp effect (4 - 100, `Warp.Angles`, default: 50).
    * **Rand:** Enables or disables random variations in the warp effect (`Warp.Rand`, default: true).
    * **Smooth:** Toggles smooth transitions in the warp effect (`Warp.Smooth`, default: true).
    * **Speed:** Controls the speed of the warp animation (1 - 250, `Warp.Speed`, default: 20).
* **Plasma:** Generates dynamic and colorful plasma effects.
    * **Type:** Selects the plasma generation type (0=Random, 1=Mirror, 2=Normal, `Plasma.Type`, default: 0).
    * **ColorRand:** Enables or disables random color selection (`Plasma.ColorRand`, default: true).
    * **ColorVRand:** Enables or disables random variation in color intensity (`Plasma.ColorVRand`, default: true).
    * **ColorV:** Sets the amount of color variation (0 - 255, `Plasma.ColorV`, default: 255).
    * **Color:** Determines the number of base colors used (1 - 8, `Plasma.Color`, default: 4).
    * **Transition:** Controls the smoothness of transitions between plasma scenes (higher value for smoother transition, `Plasma.Transition`, default: 100).

Each art type in the `artTypes` list within `SaverSettings.cs` also has a:

* **Percentage:** Determines the likelihood of this art type being selected for display.
* **Speed:** Influences the animation speed or dynamism of the art type.

## Features

* **Diverse Range of Art Styles:** Offers a curated selection of visually distinct procedural art forms.
* **Customizable Art Parameters:** Many art styles have adjustable settings to create varied visual outcomes.
* **Weighted Art Selection:** The `Percentage` setting for each `ArtType` controls how frequently it appears.
* **Adjustable Speed:** The `Speed` setting for each `ArtType` influences its animation or dynamism.
* **Smooth Transitions:** Implements blending animations between different art styles.
* **Background Processing:** Generates the next art scene in the background for seamless transitions.
* **Standard Windows Screen Saver:** Functions as a standard Windows screen saver (`.scr` file).
* **Background Color Control:** Allows setting a static or random background color (`BackGround` settings).
* **Wallpaper Setting (Optional):** Provides an option to set the last displayed art as the desktop wallpaper (`setWallpaper`).
* **Multi-Screen Support:** Option to display the screen saver across all connected monitors (`AllScreens`).
* **Background Image (Optional):** Option to use a background image (`UseBack` and `backGround` settings).

## How It Works

The Random Art Screen Saver operates by:

1.  **Selecting Art Styles:** It randomly selects an art style from the `artTypes` list based on their assigned `Percentage`.
2.  **Generating Art:** A background process generates the visual art according to the chosen style and its parameters.
3.  **Transitioning:** A blending animation smoothly transitions from the current display to the newly generated art.
4.  **Cycling:** This process repeats, continuously presenting different random art styles.
5.  **Applying Settings:** The screen saver respects user-defined settings for background color, wallpaper setting, and multi-screen display.

## Getting Started

### Prerequisites

* Microsoft Windows operating system.
* .NET Desktop Runtime (version specified in the project, currently likely .NET 9).

### Installation for End Users

1.  **Download the `.scr` file:** Navigate to the [Releases](https://github.com/MadMerick/RandomArt_ScreenSaver/releases) section and download the latest compiled `.scr` file.
2.  **Place the `.scr` file:** Copy the `.scr` file to the Windows System directory (`C:\Windows\System32` for 32-bit, `C:\Windows\SysWOW64` for 64-bit).
3.  **Activate the Screen Saver:** Follow the standard Windows steps to select and activate the "Random Art Screen Saver" in the Screen Saver Settings.

### Building from Source (for Developers)

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/MadMerick/RandomArt_ScreenSaver.git](https://github.com/MadMerick/RandomArt_ScreenSaver.git)
    cd RandomArt_ScreenSaver
    ```
2.  **Prerequisites:**
    * Microsoft Visual Studio (or a compatible C# development environment).
    * .NET SDK (version 9 or as specified in the `.csproj` file).
3.  **Open the Solution:** Open `RandomArt.sln` in Visual Studio.
4.  **Build the Project:** Build the "RandomArt" project in Release configuration.
5.  **Create the `.scr` File:** Rename the output executable (`.exe`) to `RandomArt.scr`.
6.  **Install as Screen Saver:** Place the `.scr` file in the Windows System directory.

## Future Enhancements

* **Configuration UI:** Develop a user interface within the screen saver settings to allow users to customize the probability and speed of each art style, as well as their individual parameters.
* **More Art Styles:** Implement additional procedural art generation algorithms.
* **Enhanced Image Handling:** Provide options for users to select image sources or control image display parameters.
* **Performance Optimization:** Continue to refine the rendering and animation processes.
* **User Presets:** Allow users to save and load their preferred configurations.

## Contributing

Contributions are welcome! Please fork the repository, create a branch for your changes, and submit a pull request with a clear description of your additions or modifications.

## License

This project is licensed under the [MIT License](LICENSE). See the `LICENSE` file for more information.

---

**Note:** Ensure you have a `LICENSE` file in your repository.
