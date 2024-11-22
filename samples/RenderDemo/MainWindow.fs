namespace RenderDemo

open Fabulous.Avalonia
open System
open Avalonia.Markup.Xaml.Styling

open type Fabulous.Avalonia.View

module MainWindow =
    let view () =
        DesktopApplication(
            Window(
                (HamburgerMenu() {
                    TabItem("Implicit Animations", ImplicitCanvasAnimationsPage.view())
                    TabItem("Draw Line Animation", DrawLineAnimationPage.view())
                    TabItem("Compositor Animations", CompositorAnimationsPage.view())
                    TabItem("Animations", AnimationsPage.view())
                    TabItem("Spring Animations", SpringAnimationsPage.view())
                    TabItem("Transitions", TransitionsPage.view())
                    TabItem("Render Transform", RenderTransformPage.view())
                    TabItem("Brushes", BrushesPage.view())
                    TabItem("Clipping", ClippingPage.view())
                    TabItem("Drawing", DrawingPage.view())
                    TabItem("Line Bounds", LineBoundsPage.view())
                    TabItem("Transform3D", Transform3DPage.view())
                    TabItem("Writable Bitmap", WriteableBitmapPage.view())
                    TabItem("Render Target Bitmap", RenderTargetBitmapPage.view())
                    TabItem("Path Measurement", PathMeasurementPage.view())
                    TabItem("Custom Animator", CustomAnimatorPage.view())
                    TabItem("SkCanvas", CustomSkiaPage.view())
                    TabItem("GlyphRun", GlyphRunPage.view())
                    TabItem("FormattedText", FormattedTextPage.view())
                    TabItem("TextFormatter", TextFormatterPage.view())
                })
                    .expandedModeThresholdWidth(760)
            )
#if DEBUG
            |> _.attachDevTools()
#endif
        )

    let create () =
        let theme () =
            StyleInclude(baseUri = null, Source = Uri("avares://RenderDemo/App.xaml"))

        FabulousAppBuilder.Configure(theme, view)
