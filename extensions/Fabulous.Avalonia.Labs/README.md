## Labs for Fabulous.Avalonia

Avalonia has some experimental [packages](https://www.nuget.org/packages?q=Avalonia.Labs) that are not yet part of the main Avalonia project.
This repository contains the source code for the Fabulous.Avalonia.Labs package, which is a collection of experimental features that are not yet part of the main Fabulous.Avalonia package.
https://www.nuget.org/packages?q=Avalonia.Labs

### How to use
- Add the `Fabulous.Avalonia.Labs` package to your project.
- Open `Fabulous.Avalonia` namespace at the top of the file.

### Features

#### AsyncImage
```fsharp
HWrap() {
    AsyncImage(ImageSource.fromString("avares://Gallery/Assets/Icons/fsharp-icon.png"))

    AsyncImage("https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png")
}
```

## Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.