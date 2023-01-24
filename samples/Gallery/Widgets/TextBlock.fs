namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TextBlock =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack(spacing = 15.) {
            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .margin(10., 0., 10., 0.)
                .textTrimming(TextTrimming.CharacterEllipsis)
                .textWrapping(TextWrapping.Wrap)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .margin(10., 0., 10., 0.)
                .textTrimming(TextTrimming.WordEllipsis)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Left)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Center)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Right)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Justify)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.Start)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textAlignment(TextAlignment.End)

            TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit.")
                .textTrimming(TextTrimming.None)
                .textWrapping(TextWrapping.NoWrap)

            TextBlock(
                "Multiline TextBlock with TextWrapping.&#xD;&#xD;Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus magna. Cras in mi at felis aliquet congue. Ut a est eget ligula molestie gravida. Curabitur massa. Donec eleifend, libero at sagittis mollis, tellus est malesuada tellus, at luctus turpis elit sit amet quam. Vivamus pretium ornare est."
            )
                .textWrapping(TextWrapping.Wrap)

            Border(
                VStack(8.) {
                    TextBlock("Custom font regular")
                        .fontFamily(FontFamily "SourceSansPro, Regular")
                        .fontStyle(FontStyle.Normal)
                        .fontWeight(FontWeight.Normal)

                    TextBlock("Custom font bold")
                        .fontFamily(FontFamily "SourceSansPro, Bold")
                        .fontStyle(FontStyle.Normal)
                        .fontWeight(FontWeight.Bold)

                    TextBlock("Custom font italic")
                        .fontFamily(FontFamily "SourceSansPro, Italic")
                        .fontStyle(FontStyle.Italic)
                        .fontWeight(FontWeight.Normal)

                    TextBlock("Custom font italic bold")
                        .fontFamily(FontFamily "SourceSansPro, Bold Italic")
                        .fontStyle(FontStyle.Italic)
                        .fontWeight(FontWeight.Bold)
                }
            )

            Border(
                VStack(8.0) {
                    TextBlock("Underline").textDecorations() { TextDecoration(TextDecorationLocation.Underline) }

                    TextBlock("Strikethrough").textDecorations() { TextDecoration(TextDecorationLocation.Strikethrough) }

                    TextBlock("Overline").textDecorations() { TextDecoration(TextDecorationLocation.Overline) }

                    TextBlock("Baseline").textDecorations() { TextDecoration(TextDecorationLocation.Baseline) }

                    TextBlock("Custom TextDecorations").textDecorations() {
                        TextDecoration(TextDecorationLocation.Overline)
                            .strokeThickness(2.0)
                            .strokeThicknessUnit(TextDecorationUnit.Pixel)
                            .stroke(
                                LinearGradientBrush(RelativePoint.Parse("0%,0%"), RelativePoint.Parse("100%,100%")) {
                                    GradientStop(0.0, Colors.Red)
                                    GradientStop(1.0, Colors.Green)
                                }
                            )

                        TextDecoration(TextDecorationLocation.Strikethrough)
                            .strokeThickness(1.0)
                            .strokeThicknessUnit(TextDecorationUnit.Pixel)
                            .stroke(
                                LinearGradientBrush(RelativePoint.Parse("0%,0%"), RelativePoint.Parse("100%,100%")) {
                                    GradientStop(0.0, Colors.Green)
                                    GradientStop(1.0, Colors.Blue)
                                }
                            )

                        TextDecoration(TextDecorationLocation.Underline)
                            .strokeThickness(2.0)
                            .strokeThicknessUnit(TextDecorationUnit.Pixel)
                            .stroke(
                                LinearGradientBrush(RelativePoint.Parse("0%,0%"), RelativePoint.Parse("100%,100%")) {
                                    GradientStop(0.0, Colors.Blue)
                                    GradientStop(1.0, Colors.Red)
                                }
                            )

                    }

                    Border(
                        VStack() {
                            TextBlock("🏻 👌🏻")
                            TextBlock("🏼 👌🏼")
                            TextBlock("🏽 👌🏽")
                            TextBlock("🏾 👌🏾")
                            TextBlock("🏿 👌🏿")
                        }
                    )

                    Border(TextBlock("👪 👨‍👩‍👧 👨‍👩‍👧‍👦"))
                }
            )

            TextBlock() {
                Run("This ")

                Span() { Run("is").fontWeight(FontWeight.Bold) }

                Run(" a ")

                Span() {
                    Run("TextBlock")
                        .background(SolidColorBrush(Colors.Silver))
                        .foreground(SolidColorBrush(Colors.Maroon))
                }

                Run(" with ")

                Span() { Run("several").textDecorations() { TextDecoration(TextDecorationLocation.Underline) } }

                Span() { Run("Span").fontStyle(FontStyle.Italic) }

                Run(" elements, ")

                Span() {
                    Run("using a ")
                    Bold("variety")
                    Run(" of ")
                    Italic("styles")
                }
            }

        }

    let sample =
        { Name = "TextBlock"
          Description = "The TextBlock control allows for the display of label-like text in the interface."
          Program = Helper.createProgram init update view }
