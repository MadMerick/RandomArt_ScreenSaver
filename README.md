# Random Art Screen Saver (C# Windows Forms)

[![License](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![.NET](https://github.com/MadMerick/RandomArt_ScreenSaver/workflows/.NET/badge.svg)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/MadMerick/RandomArt_ScreenSaver)

This project is a rewrite and modernization of an old screen saver created in 2004. The Random Art Screen Saver is a C# Windows Forms application that displays a rotating selection of procedurally generated visual art as a custom screen saver. It cycles through various artistic styles, each with its own unique parameters, creating a dynamic and ever-changing display on your screen.

## Art Styles & Settings

The screen saver features the following art generation methods, with customizable settings:

* **Dots:** Draws a random pattern of individual colored dots/pixels on the screen.
    * *(No specific settings exposed)*
* **Grow:** Creates an effect of elements growing by randomly stacking colored dots/pixels on top of one another.
    * *(No specific settings exposed in)*
* **Scribble:** Generates random scribbles in different colors.
    * **Length:** Controls the average length (size) of the scribble (min: 1, max:100, default: 4).
* **Light:** Simulates a random colored light source with adjustable transparency and light size (center size).
    * **Transparent:** Sets the transparency level of the light effect (min: 0% (opaque), max: 99% (tranparent), default: 0%).
    * **Center:** Adjusts the light size (center size) of the light effect before it fades out (min: 0% (full fading), max: 100% (no fade), default: 0%).
* **Weeds:** Creates a random pattern resembling growing weeds or organic lines.
    * *(No specific settings exposed)*
* **Bubbles:** Generates a display of floating bubbles with adjustable transparency and center concentration.
    * **Transparent:** Sets the transparency level of the bubbles (min: 0% (opaque), max: 99% (transparent), default: 50%).
    * **Center:** Controls the center concentration (or center size) before fading (min: 0% (start fading at center point), 99% (no fade - center is completly transparent), default: 20%).
* **Warp:** Creates a random color warp tunnel effect.
    * **Angles:** Determines how round the tunnal is (min: 4 (diamond shaped), max: 100 (circular shaped), default: 50).
    * **Random Angles:** Enables or disables random variations in the shape of the warp tunnel (default: true).
    * **Smooth:** Toggles smooth transitions between the warp colors (default: true).
    * **Speed:** Controls the speed of the warp animation (how fast one is traveling through the tunnel) (min: 1 (slow), max: 250 (fast), default: 20).
* **Plasma:** Generates dynamic and colorful plasma effects.
    * **Type:** Selects the plasma generation type (full screen or mirrored effect (0=Random, 1=Mirror, 2=Full screen, default: 0).
    * **Random Color:** Enables or disables random color intensity (default: true).
    * **Color:** Determines the amount of colors intensity used (min: 1 (single color), max: 8 (more colors), default: 4).
    * **Random Color Variation:** Enables or disables random variation in colors (default: true).
    * **Color Variation:** Sets the amount of color variation (min: 0 (no variation), max: 255 (colors can change drastically), default: 255).
    * **Transition:** Controls the smoothness of transitions between plasma scenes (higher value for smoother transition, default: 100).

Each art style also has a:

* **Percentage:** Determines the likelihood of this art style being selected for display.
* **Speed:** Influences the frequancy (or speed) of which the screen saver draws an art style.

## Features

* **Diverse Range of Art Styles:** Offers a curated selection of visually distinct procedural art forms.
* **Customizable Art Parameters:** Many art styles have adjustable settings to create varied visual outcomes.
* **Weighted Art Selection:** The `Percentage` setting for each `Art Style` controls how frequently it appears.
* **Adjustable Speed:** The `Speed` setting for each `Art Style` influences its how frequany it draws an art style.
* **Smooth Transitions:** Implements blending animations between different art styles.
* **Background Processing:** Generates the next art scene in the background for seamless transitions.
* **Standard Windows Screen Saver:** Functions as a standard Windows screen saver (`.scr` file).
* **Background Color Control:** Allows setting a static or random background color.
* **Save Art Setting (Optional):** Provides an option to save the last displayed art in your pictures folder.
* **Multi-Screen Support:** Option to display the same art style across all connected monitors or a different style on each monitor.
* **Background Image (Optional):** Option to draw the art over the current windows screen (complete overlay on the current screen vs creating a background color).

## How It Works

The Random Art Screen Saver operates by:

1.  **Selecting Art Styles:** It randomly selects an art style from the `artTypes` list based on their assigned `Percentage`.
2.  **Generating Art:** A background process generates the visual art according to the chosen style, its parameters, and random algorithms.

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

This project is licensed under the **GNU General Public License v3.0**. See the full text of the license in the [LICENSE](LICENSE) file.

---

**Note:** The full text of the GNU General Public License v3.0 is available in the `LICENSE` file in this repository.
