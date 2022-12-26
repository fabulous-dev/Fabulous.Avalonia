namespace Gallery

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Track =
    type Model = { TrackValue: float }


    type Msg =
        | TrackValueChanged of float

    let init () = { TrackValue = 50. }

    let update msg model =
        match msg with
        | TrackValueChanged value -> { model with TrackValue = value }

    let view model =
        (VStack() {
            Track(Thumb()
                      .size(24.0, 24.0)
                      .clip(RectangleGeometry(Rect(0.0, 0.0, 24.0, 24.0)))
                      .background(SolidColorBrush(Colors.Green)))
                .orientation(Orientation.Vertical)
                .minimum(0.0)
                .value(model.TrackValue)
                .maximum(100.0)
                .height(200.0)
                
        }).background(SolidColorBrush(Colors.Red))
    //     <Grid ColumnDefinitions="*">
    //     <Track Minimum="0" Maximum="100" Value="50" Orientation="Vertical">
    //         <Track.DecreaseButton>
    //             <RepeatButton  Content="-" Background="LightGray" Foreground="Black" />
    //         </Track.DecreaseButton>
    //         <Track.IncreaseButton>
    //             <RepeatButton Content="+" Background="LightGray" Foreground="Black" />
    //         </Track.IncreaseButton>
    //         <Thumb Name="Thumb" MinWidth="24" MinHeight="24">
    //             <Thumb.Template>
    //                 <ControlTemplate>
    //                     <Grid>
    //                         <Ellipse Width="24" Height="24" Fill="Green"/>
    //                     </Grid>
    //                 </ControlTemplate>
    //             </Thumb.Template>
    //         </Thumb>
    //     </Track>
    // </Grid>

    let sample =
        { Name = "Track"
          Description =
            "Represents a control primitive that handles the positioning and sizing of a Thumb control and two RepeatButton controls that are used to set a Value."
          Program = Helper.createProgram init update view }
