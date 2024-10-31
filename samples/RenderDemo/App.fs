namespace RenderDemo

open Fabulous.Avalonia.Mvu

open type Fabulous.Avalonia.Mvu.View

[<AutoOpen>]
module App =
    [<Struct>]
    type DetailPage =
        | ImplicitAnimations
        | DrawLineAnimation
        | CompositorAnimations
        | Animations
        | SpringAnimations
        | Transitions
        | RenderTransform
        | Brushes
        | Clipping
        | Drawing
        | LineBounds
        | Transform3D
        | WritableBitmap
        | RenderTargetBitmap
        | PathMeasurement
        | CustomAnimator
        | GlyphRun
        | FormattedText
        | TextFormatter

    [<return: Struct>]
    let (|CurrentPage|_|) page =
        match page with
        | "Implicit Animations" -> ValueSome ImplicitAnimations
        | "Draw Line Animation" -> ValueSome DrawLineAnimation
        | "Compositor Animations" -> ValueSome CompositorAnimations
        | "Animations" -> ValueSome Animations
        | "Spring Animations" -> ValueSome SpringAnimations
        | "Transitions" -> ValueSome Transitions
        | "Render Transform" -> ValueSome RenderTransform
        | "Brushes" -> ValueSome Brushes
        | "Clipping" -> ValueSome Clipping
        | "Drawing" -> ValueSome Drawing
        | "Line Bounds" -> ValueSome LineBounds
        | "Transform3D" -> ValueSome Transform3D
        | "Writable Bitmap" -> ValueSome WritableBitmap
        | "Render Target Bitmap" -> ValueSome RenderTargetBitmap
        | "Path Measurement" -> ValueSome PathMeasurement
        | "Custom Animator" -> ValueSome CustomAnimator
        | "GlyphRun" -> ValueSome GlyphRun
        | "FormattedText" -> ValueSome FormattedText
        | "TextFormatter" -> ValueSome TextFormatter
        | _ -> ValueNone

    [<return: Struct>]
    let (|CurrentWidget|_|) page =
        match page with
        | ImplicitAnimations -> ValueSome(AnyView(ImplicitCanvasAnimationsPage.view()))
        | DrawLineAnimation -> ValueSome(AnyView(DrawLineAnimationPage.view()))
        | CompositorAnimations -> ValueSome(AnyView(CompositorAnimationsPage.view()))
        | Animations -> ValueSome(AnyView(AnimationsPage.view()))
        | SpringAnimations -> ValueSome(AnyView(SpringAnimationsPage.view()))
        | Transitions -> ValueSome(AnyView(TransitionsPage.view()))
        | RenderTransform -> ValueSome(AnyView(RenderTransformPage.view()))
        | Brushes -> ValueSome(AnyView(BrushesPage.view()))
        | Clipping -> ValueSome(AnyView(ClippingPage.view()))
        | Drawing -> ValueSome(AnyView(DrawingPage.view()))
        | LineBounds -> ValueSome(AnyView(LineBoundsPage.view()))
        | Transform3D -> ValueSome(AnyView(Transform3DPage.view()))
        | WritableBitmap -> ValueSome(AnyView(WriteableBitmapPage.view()))
        | RenderTargetBitmap -> ValueSome(AnyView(RenderTargetBitmapPage.view()))
        | PathMeasurement -> ValueSome(AnyView(PathMeasurementPage.view()))
        | CustomAnimator -> ValueSome(AnyView(CustomAnimatorPage.view()))
        | GlyphRun -> ValueSome(AnyView(GlyphRunPage.view()))
        | FormattedText -> ValueSome(AnyView(FormattedTextPage.view()))
        | TextFormatter -> ValueSome(AnyView(TextFormatterPage.view()))
