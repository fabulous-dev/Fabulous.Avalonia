namespace Gallery.Pages

open System.Globalization
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Gallery

type FormattedTextControl() =
    inherit UserControl()

    override this.Render(context: DrawingContext) =
        let testString =
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor"

        let tf = Typeface.Default

        // Create the initial formatted text string.
        let formattedText =
            FormattedText(testString, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, tf, 32, Brushes.Black)

        formattedText.MaxTextHeight <- 240.
        formattedText.MaxTextWidth <- 300.

        // Set a maximum width and height. If the text overflows these values, an ellipsis "..." appears.

        // Use a larger font size beginning at the first (zero-based) character and continuing for 5 characters.
        // The font size is calculated in terms of points -- not as device-independent pixels.
        formattedText.SetFontSize(36. * (96.0 / 72.0), 0, 5)

        // Use a Bold font weight beginning at the 6th character and continuing for 11 characters.
        formattedText.SetFontWeight(FontWeight.Bold, 6, 11)

        let gradient = LinearGradientBrush()
        gradient.GradientStops.Add(GradientStop(Colors.Orange, 0))
        gradient.GradientStops.Add(GradientStop(Colors.Teal, 1))
        gradient.StartPoint <- RelativePoint(0, 0, RelativeUnit.Relative)
        gradient.EndPoint <- RelativePoint(0, 1, RelativeUnit.Relative)

        // Use a linear gradient brush beginning at the 6th character and continuing for 11 characters.
        formattedText.SetForegroundBrush(gradient, 6, 11)

        // Use an Italic font style beginning at the 28th character and continuing for 28 characters.
        formattedText.SetFontStyle(FontStyle.Italic, 28, 28)

        context.DrawText(formattedText, Point(10., 0.))

        let point = Point(10. + (formattedText.Width + 10.), 0.)

        let geometry = formattedText.BuildGeometry(point)

        context.DrawGeometry(gradient, null, geometry)

        let highlightGeometry =
            formattedText.BuildHighlightGeometry(Point(10. + formattedText.Width + 10., 0))

        context.DrawGeometry(null, ImmutablePen(gradient.ToImmutable(), 2), highlightGeometry)

type IFabFormattedTextControl =
    inherit IFabControl

module FabFormattedTextControl =
    let WidgetKey = Widgets.register<FormattedTextControl>()

[<AutoOpen>]
module FabFormattedTextControlBuilders =
    type Fabulous.Avalonia.View with

        static member FormattedTextControl() =
            WidgetBuilder<'msg, IFabFormattedTextControl>(FabFormattedTextControl.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

module FormattedTextPage =
    open type Fabulous.Avalonia.View
    type Model = { Nothing: bool }

    type Msg = | DoNothing

    type CmdMsg = | NoMsg

    let mapCmdMsgToCmd nav cmdMsg =
        match cmdMsg with
        | NoMsg -> Navigation.goBack nav

    let init () = { Nothing = true }, []

    let update msg model =
        match msg with
        | DoNothing -> model

    let view _ =
        VStack(spacing = 15.) { FormattedTextControl() }
