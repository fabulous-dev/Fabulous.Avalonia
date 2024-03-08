namespace Gallery

open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module StylesPage =
    let view () =
        UserControl(
            (VStack(spacing = 15.) {
                TextBlock("I'm a Heading1!").classes([ "h1" ])

                TextBlock("I'm a Heading2!").classes([ "h2" ])

                TextBlock("I'm a Heading3!").classes([ "h3" ])

                TextBlock("I'm a Heading4!").classes([ "h4" ])

                TextBlock("I'm a Heading5!").classes([ "h5" ])

                TextBlock("I'm a Heading6!").classes([ "h6" ])

                TextBlock("I'm a Body1!").classes([ "h7" ])

                TextBlock("I'm a Body2!").classes([ "h8" ])

                TextBlock("I'm a Body3!").classes([ "h9" ])

                TextBlock("I'm just a text")

            })
        )
            .styles([ "avares://Gallery/Styles/TextStyles.xaml" ])
