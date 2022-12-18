namespace Fabulous.Avalonia

open System.Globalization
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabMaskedTextBox =
    inherit IFabTextBox

module MaskedTextBox =
    let WidgetKey = Widgets.register<MaskedTextBox>()

    let AsciiOnly =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.AsciiOnlyProperty

    let Culture =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.CultureProperty

    let HidePromptOnLeave =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.HidePromptOnLeaveProperty

    let Mask = Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.MaskProperty

    let PasswordChar =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.PasswordCharProperty

    let PromptChar =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.PromptCharProperty

    let ResetOnPrompt =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.ResetOnPromptProperty

    let ResetOnSpace =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.ResetOnSpaceProperty

[<AutoOpen>]
module MaskedTextBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline MaskedTextBox<'msg>(text: string, mask: string) =
            WidgetBuilder<'msg, IFabMaskedTextBox>(
                MaskedTextBox.WidgetKey,
                TextBlock.Text.WithValue(text),
                MaskedTextBox.Mask.WithValue(mask)
            )

[<Extension>]
type MaskedTextBoxModifiers =
    [<Extension>]
    static member inline asciiOnly(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, asciiOnly: bool) =
        this.AddScalar(MaskedTextBox.AsciiOnly.WithValue(asciiOnly))

    [<Extension>]
    static member inline culture(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, culture: CultureInfo) =
        this.AddScalar(MaskedTextBox.Culture.WithValue(culture))

    [<Extension>]
    static member inline hidePromptOnLeave(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, hidePromptOnLeave: bool) =
        this.AddScalar(MaskedTextBox.HidePromptOnLeave.WithValue(hidePromptOnLeave))

    [<Extension>]
    static member inline passwordChar(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, passwordChar: char) =
        this.AddScalar(MaskedTextBox.PasswordChar.WithValue(passwordChar))

    [<Extension>]
    static member inline promptChar(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, promptChar: char) =
        this.AddScalar(MaskedTextBox.PromptChar.WithValue(promptChar))

    [<Extension>]
    static member inline resetOnPrompt(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, resetOnPrompt: bool) =
        this.AddScalar(MaskedTextBox.ResetOnPrompt.WithValue(resetOnPrompt))

    [<Extension>]
    static member inline resetOnSpace(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, resetOnSpace: bool) =
        this.AddScalar(MaskedTextBox.ResetOnSpace.WithValue(resetOnSpace))
