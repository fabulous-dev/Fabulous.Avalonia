namespace NewApp.Desktop

open System
open Avalonia
open Fabulous.Avalonia
open NewApp

// Initialization code. Don't use any Avalonia, third-party APIs or any
// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
// yet and stuff might break.
[<STAThread; EntryPoint>]
let Main (args: string array) =

    AppBuilder
        .Configure(fun () -> Program.startApplication App.program)
        .UsePlatformDetect()
        .LogToTrace(?level = None)
        .StartWithClassicDesktopLifetime(args)