# Fabulous for Avalonia

[![build](https://img.shields.io/github/actions/workflow/status/fabulous-dev/Fabulous.Avalonia/build.yml?branch=main)](https://github.com/fabulous-dev/Fabulous.Avalonia/actions/workflows/build.yml) [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia)](https://www.nuget.org/packages/Fabulous.Avalonia#readme-body-tab) [![NuGet downloads](https://img.shields.io/nuget/dt/Fabulous.Avalonia)](https://www.nuget.org/packages/Fabulous.Avalonia) [![Discord](https://img.shields.io/discord/716980335593914419?label=discord&logo=discord)](https://discord.gg/bpTJMbSSYK) [![Twitter Follow](https://img.shields.io/twitter/follow/FabulousAppDev?style=social)](https://twitter.com/FabulousAppDev)

Fabulous.Avalonia brings the great development experience of Fabulous to [AvaloniaUI](https://github.com/AvaloniaUI/Avalonia), allowing you to take advantage of this UI framework with a tailored declarative UI DSL and clean architecture.

Deploy to any platform supported by Avalonia, such as Android, iOS, macOS, Windows, Linux and more!

### MVU Sample

```fs
    type Model =
        { Count: int }
    
    type Msg =
        | Increment
        | Decrement
    
    let init () =
        { Count = 0 }
    
    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }
    
    let content model =
        VStack(spacing = 16.) {
            Image("fabulous.png", Stretch.Uniform)
    
            TextBlock($"Count is {model.Count}")
    
            Button("Increment", Increment)
            Button("Decrement", Decrement)
        }
        
    #if MOBILE
        let app model = SingleViewApplication(content model)
    #else
        let app model = DesktopApplication(Window(content model))
    #endif
    
    let create () =
        let program = Program.statefulWithCmd init update |> Program.withView app

        FabulousAppBuilder.Configure(FluentTheme, program)
```

### MVU Component sample

```fs
    type Model =
        { Count: int }
    
    type Msg =
        | Increment
        | Decrement
    
    let init () =
        { Count = 0 }
    
    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }
    
    let content model =
        VStack(spacing = 16.) {
            Image("fabulous.png", Stretch.Uniform)
    
            TextBlock($"Count is {model.Count}")
    
            Button("Increment", Increment)
            Button("Decrement", Decrement)
        }
        
     let program = Program.statefulWithCmd init update
    
     let view () =
         Component(program) {
             let! model = Mvu.State
    
 #if MOBILE
             SingleViewApplication(content model)
 #else
             DesktopApplication(Window(content model))
 #endif
         }
    
     let create () =
         FabulousAppBuilder.Configure(FluentTheme, view)
```

## Additional Controls

We also provide additional binding for Avalonia controls, you can find them in the following packages:

- Fabulous.Avalonia.DataGrid [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.DataGrid)](https://www.nuget.org/packages/Fabulous.Avalonia.DataGrid#readme-body-tab)
- Fabulous.Avalonia.ColorPicker [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.ColorPicker)](https://www.nuget.org/packages/Fabulous.Avalonia.ColorPicker#readme-body-tab)
- Fabulous.Avalonia.ItemsRepeater [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.ItemsRepeater)](https://www.nuget.org/packages/Fabulous.Avalonia.ItemsRepeater#readme-body-tab)
- Fabulous.Avalonia.TreeDataGrid [![NuGet version](https://img.shields.io/nuget/v/Fabulous.Avalonia.TreeDataGrid)](https://www.nuget.org/packages/Fabulous.Avalonia.TreeDataGrid#readme-body-tab)

## Getting Started

You can start your new Fabulous.Avalonia app in a matter of seconds using the dotnet CLI templates.  
For a starter guide see our [Get Started with Fabulous.Avalonia](https://docs.fabulous.dev/avalonia/get-started).

## How to use the templates

Using the dotnet CLI, install the templates:

```sh
dotnet new install Fabulous.Avalonia.Templates
```

Then, you will be able to create new Fabulous.Avalonia projects with `dotnet new`:

#### Single Project

Single project takes the platform-specific development experiences and abstracts them into a single shared project that can target Android, iOS, Desktop.

```sh
dotnet new fabulous-avalonia -n MyApp
```

- MyApp
    - Platform
        - Android
        - iOS
        - Desktop

Note: Browser is not supported in single project template.

#### Multi Project

Multi project takes the platform-specific development and abstracts them into a multiple projects that can target Android, iOS, Desktop, Browser.

```sh
dotnet new fabulous-avalonia-multi -n MyApp
```

- MyApp
    - MyApp
    - MyApp.Android
    - MyApp.iOS
    - MyApp.Desktop
    - MyApp.Browser

net8.0-ios is not supported on Linux, thus net8.0-ios is excluded from build on a Linux host.

## Samples
We have a range of samples to help you get started.

You can find them in the [sample's repo](https://github.com/fabulous-dev/Fabulous.Avalonia.Samples).

## Controls Gallery
To run the `Gallery` sample app from the command line:

- This will restore the required workloads for the samples

```shell
dotnet workload restore
```

- Then you can run the Gallery sample

```shell
cd samples/Gallery
dotnet run -f net8.0
```

You can also open the solution `Fabulous.Avalonia.sln` with your favorite IDE(We recommend [Rider](https://www.jetbrains.com/rider/)) and select the platform you want, then press debug to deploy and run the app.

## Documentation

The full documentation for Fabulous.Avalonia can be found at [docs.fabulous.dev/avalonia](https://docs.fabulous.dev/avalonia).

Other useful links:
- [The official Fabulous website](https://fabulous.dev)
- [Get started](https://docs.fabulous.dev/avalonia/get-started)
- [Fabulous.Avalonia Samples](https://github.com/fabulous-dev/Fabulous.Avalonia.Samples)
- [API Reference](https://api.fabulous.dev/avalonia)
- [Contributor Guide](CONTRIBUTING.md)

Additionally, we have the [Fabulous Discord server](https://discord.gg/bpTJMbSSYK) where you can ask any of your Fabulous related questions.

## Supporting Fabulous

The simplest way to show us your support is by giving this project and the [Fabulous project](https://github.com/fabulous-dev/Fabulous) a star.

You can also support us by becoming our sponsor on the GitHub Sponsors program.  
This is a fantastic way to support all the efforts going into making Fabulous the best declarative UI framework for dotnet.

If you need support see Commercial Support section below.

## Contributing

Have you found a bug or have a suggestion of how to enhance Fabulous? Open an issue and we will take a look at it as soon as possible.

Do you want to contribute with a PR? PRs are always welcome, just make sure to create it from the correct branch (main) and follow the [Contributor Guide](CONTRIBUTING.md).

For bigger changes, or if in doubt, make sure to talk about your contribution to the team. Either via an issue, GitHub discussion, or reach out to the team either using the [Discord server](https://discord.gg/bpTJMbSSYK).

## Commercial support

If you would like us to provide you with:

- training and workshops,
- support services,
- and consulting services.

Feel free to contact us: [support@fabulous.dev](mailto:support@fabulous.dev)
