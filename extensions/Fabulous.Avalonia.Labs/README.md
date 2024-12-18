## Fabulous.Avalonia.Labs

Avalonia has some experimental [packages](https://www.nuget.org/packages?q=Avalonia.Labs) that are not yet part of the main Avalonia project and might or might not be included in the future.

This repository contains the source code for the Fabulous.Avalonia.Labs package, which is a collection of experimental controls so that you can use them in your Fabulous.Avalonia applications.

> NOTe: This package is not yet stable and is subject to change.

### How to use
- Add the `Fabulous.Avalonia.Labs` package to your project.
- Open `Fabulous.Avalonia` namespace at the top of the file.

### Controls

#### AsyncImage
```fsharp
VStack() {
    AsyncImage(ImageSource.fromString("avares://Gallery/Assets/Icons/fsharp-icon.png"))

    AsyncImage("https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png")
}
```

## Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.