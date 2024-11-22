namespace CounterApp

open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View
open type Fabulous.Context

module App =
    let content () =
        Component("CounterApp") {
            let! count = State(0)
            let! timerOn = State(false)
            let! step = State(1)

            (VStack() {
                TextBlock($"%d{count.Current}").centerText()

                Button("Increment", (fun _ -> count.Set(count.Current + 1)))
                    .centerHorizontal()

                Button("Decrement", (fun _ -> count.Set(count.Current - 1)))
                    .centerHorizontal()

                (HStack() {
                    TextBlock("Timer").centerVertical()

                    ToggleSwitch(timerOn.Current, (fun _ -> count.Set(count.Current + step.Current)))
                })
                    .margin(20.)
                    .centerHorizontal()

                Slider(0., 10., float step.Current, (fun n -> step.Set(int(n + 0.5))))
                    .centerHorizontal()

                TextBlock($"Step size: %d{step.Current}").center()

                Button(
                    "Reset",
                    fun _ ->
                        count.Set(0)
                        timerOn.Set(false)
                        step.Set(1)
                )
                    .centerHorizontal()
            })
                .center()
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication(Window(content()))
#endif

    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
