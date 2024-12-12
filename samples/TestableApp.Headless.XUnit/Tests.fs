namespace TestableApp


open Avalonia
open Avalonia.Controls
open Avalonia.Headless
open Avalonia.Headless.XUnit
open Fabulous
open Fabulous.Avalonia
open Xunit

open type Fabulous.Avalonia.View
open type Fabulous.Context
// https://docs.avaloniaui.net/docs/concepts/headless/
// https://github.com/AvaloniaUI/Avalonia.Samples/tree/main/src/Avalonia.Samples/Testing/TestableApp.Headless.XUnit#writing-ui-tests
// https://github.com/VerifyTests/Verify.Avalonia


module Tests =
    /// It takes the root of the widget tree and create the corresponding Avalonia node, and recursively creating all children nodes
    let mkView<'msg, 'marker, 'a when 'msg: equality> (root: WidgetBuilder<'msg, 'marker>) : 'a =
        let widget = root.Compile()
        let definition = WidgetDefinitionStore.get widget.Key
        let logger = ProgramDefaults.defaultLogger()

        let treeContext =
            { CanReuseView = ViewHelpers.canReuseView
              GetViewNode = ViewNode.get
              GetComponent = Component.get
              SetComponent = Component.set
              SyncAction = ViewHelpers.defaultSyncAction
              Logger = logger
              Dispatch = ignore }

        let envContext = new EnvironmentContext(logger)

        let struct (_, view) =
            definition.CreateView(widget, envContext, treeContext, ValueNone)

        (view :?> 'a)

    [<AvaloniaFact>]
    let ``Should_Type_Text_Into_TextBox`` () =
        let window = App.view() |> mkView<_, _, Window>

        window.Show()

        let content = window.Content :?> ReversibleStackPanel |> _.Children

        let fullName = content[0] :?> Label
        let firstName = content[1] :?> TextBox
        let lastName = content[2] :?> TextBox

        // Focus text box:
        firstName.Focus() |> ignore

        // Simulate text input:
        window.KeyTextInput("Edgar")

        lastName.Focus() |> ignore

        window.KeyTextInput("Gonzalez")

        //let frame = window.CaptureRenderedFrame()
        //frame.Save("file.png");
        // // Assert:
        Assert.Equal("Full name is Edgar Gonzalez", fullName.Content |> string)
        Assert.Equal("Edgar", firstName.Text)
        Assert.Equal("Gonzalez", lastName.Text)
