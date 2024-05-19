namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Automation
open Avalonia.Automation.Peers
open Fabulous


module AutomationProperties =
    let AcceleratorKey =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AcceleratorKeyProperty

    let AccessibilityView =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AccessibilityViewProperty

    let AccessKey =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AccessKeyProperty

    let AutomationId =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.AutomationIdProperty

    let ControlTypeOverride =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.ControlTypeOverrideProperty

    let HelpText =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.HelpTextProperty

    let IsIsColumnHeader =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsColumnHeaderProperty

    let IsRequiredForForm =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsRequiredForFormProperty

    let IsRowHeader =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsRowHeaderProperty

    let IsOffscreenBehavior =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.IsOffscreenBehaviorProperty

    let ItemStatus =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.ItemStatusProperty

    let ItemType =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.ItemTypeProperty

    let LiveSetting =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.LiveSettingProperty

    let Name =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.NameProperty

    let PositionInSet =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.PositionInSetProperty

    let SizeOfSet =
        Attributes.defineAvaloniaPropertyWithEquality AutomationProperties.SizeOfSetProperty


type AutomationPropertiesModifiers =
    [<Extension>]
    static member inline acceleratorKey(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.AcceleratorKey.WithValue(value))

    [<Extension>]
    static member inline accessibilityView(this: WidgetBuilder<'msg, #IFabStyledElement>, value: AccessibilityView) =
        this.AddScalar(AutomationProperties.AccessibilityView.WithValue(value))

    [<Extension>]
    static member inline accessKey(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.AccessKey.WithValue(value))

    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.AutomationId.WithValue(value))

    [<Extension>]
    static member inline controlTypeOverride(this: WidgetBuilder<'msg, #IFabStyledElement>, value: AutomationControlType) =
        this.AddScalar(AutomationProperties.ControlTypeOverride.WithValue(value))

    [<Extension>]
    static member inline helpText(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.HelpText.WithValue(value))

    [<Extension>]
    static member inline isColumnHeader(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(AutomationProperties.IsIsColumnHeader.WithValue(value))

    [<Extension>]
    static member inline isRequiredForForm(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(AutomationProperties.IsRequiredForForm.WithValue(value))

    [<Extension>]
    static member inline isRowHeader(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(AutomationProperties.IsRowHeader.WithValue(value))

    [<Extension>]
    static member inline isOffscreenBehavior(this: WidgetBuilder<'msg, #IFabStyledElement>, value: IsOffscreenBehavior) =
        this.AddScalar(AutomationProperties.IsOffscreenBehavior.WithValue(value))

    [<Extension>]
    static member inline itemStatus(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.ItemStatus.WithValue(value))

    [<Extension>]
    static member inline itemType(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.ItemType.WithValue(value))

    [<Extension>]
    static member inline liveSetting(this: WidgetBuilder<'msg, #IFabStyledElement>, value: AutomationLiveSetting) =
        this.AddScalar(AutomationProperties.LiveSetting.WithValue(value))

    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(AutomationProperties.Name.WithValue(value))

    [<Extension>]
    static member inline positionInSet(this: WidgetBuilder<'msg, #IFabStyledElement>, value: int) =
        this.AddScalar(AutomationProperties.PositionInSet.WithValue(value))

    [<Extension>]
    static member inline sizeOfSet(this: WidgetBuilder<'msg, #IFabStyledElement>, value: int) =
        this.AddScalar(AutomationProperties.SizeOfSet.WithValue(value))
