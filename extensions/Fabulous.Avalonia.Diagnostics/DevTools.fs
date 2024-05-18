namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Diagnostics
open Fabulous
open Fabulous.Avalonia

module DevTools =    
    let AttachDevTools =
        Attributes.defineProperty
            "Application_AttachDevTools"
            (ValueNone, ValueNone)
            (fun target (value: DevToolsOptions voption * Input.KeyGesture voption) ->
                let app = target :?> FabApplication
                let options, gesture = value

                if options.IsSome then
                    app.MainWindow.AttachDevTools(options.Value)
                else if gesture.IsSome then
                    app.MainWindow.AttachDevTools(gesture.Value)
                else
                    app.MainWindow.AttachDevTools())

type DevToolsModifiers =
    /// <summary>Attaches the Avalonia Developer Tools with the specified options.
    /// See https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools</summary>
    /// <param name="this">The Current widget.</param>
    /// <param name="value">The Developer Tools options.</param>
    [<Extension>]
    static member inline attachDevTools(this: WidgetBuilder<'msg, #IFabApplication>, value: DevToolsOptions) =
        this.AddScalar(DevTools.AttachDevTools.WithValue((ValueSome value, ValueNone)))

    /// <summary>Attaches the Avalonia Developer Tools with the specified gesture.
    /// See https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools</summary>
    /// <param name="this">The Current widget.</param>
    /// <param name="value">The key gesture.</param>
    [<Extension>]
    static member inline attachDevTools(this: WidgetBuilder<'msg, #IFabApplication>, value: Input.KeyGesture) =
        this.AddScalar(DevTools.AttachDevTools.WithValue((ValueNone, ValueSome value)))

    /// <summary>Attaches the Avalonia Developer Tools opened using F12.
    /// See https://docs.avaloniaui.net/docs/guides/implementation-guides/developer-tools</summary>
    /// <param name="this">The Current widget.</param>
    [<Extension>]
    static member inline attachDevTools(this: WidgetBuilder<'msg, #IFabApplication>) =
        this.AddScalar(DevTools.AttachDevTools.WithValue((ValueNone, ValueNone)))