namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module Canvas =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        VStack(spacing = 15.) {
            TextBlock("A panel which lays out its children by explicit coordinates")
            // <Canvas Background="Yellow" Width="300" Height="400">
            //   <Rectangle Fill="Blue" Width="63" Height="41" Canvas.Left="40" Canvas.Top="31" RadiusX="10" RadiusY="10">
            //     <Rectangle.OpacityMask>
            //       <LinearGradientBrush StartPoint="0%,0%" EndPoint="100%,100%">
            //         <LinearGradientBrush.GradientStops>
            //           <GradientStop Offset="0" Color="Black"/>
            //           <GradientStop Offset="1" Color="Transparent"/>
            //         </LinearGradientBrush.GradientStops>
            //       </LinearGradientBrush>
            //     </Rectangle.OpacityMask>
            //   </Rectangle>
            //   <Rectangle Fill="hsva(240, 83%, 73%, 90%)" Stroke="hsl(5, 85%, 85%)" StrokeThickness="2" Width="40" Height="20" Canvas.Left="150" Canvas.Top="10" RadiusX="10" RadiusY="5" />
            //   <Ellipse Fill="Green" Width="58" Height="58" Canvas.Left="88" Canvas.Top="100"/>
            //   <Path Fill="Orange" Data="M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,-50 Z" Canvas.Left="30" Canvas.Top="250"/>
            //   <Path Fill="OrangeRed" Canvas.Left="180" Canvas.Top="250">
            //     <Path.Data>
            //       <PathGeometry>
            //         <PathFigure StartPoint="0,0" IsClosed="True">
            //           <QuadraticBezierSegment Point1="50,0" Point2="50,-50" />
            //           <QuadraticBezierSegment Point1="100,-50" Point2="100,0" />
            //           <LineSegment Point="50,0" />
            //           <LineSegment Point="50,50" />
            //         </PathFigure>
            //       </PathGeometry>
            //     </Path.Data>
            //   </Path>
            //   <Line StartPoint="120,185" EndPoint="30,115" Stroke="Red" StrokeThickness="2"/>
            //   <Polygon Points="75,0 120,120 0,45 150,45 30,120" Stroke="DarkBlue" StrokeThickness="1" Fill="Violet" Canvas.Left="150" Canvas.Top="31"/>
            //   <Polyline Points="0,0 65,0 78,-26 91,39 104,-39 117,13 130,0 195,0" Stroke="Brown" Canvas.Left="30" Canvas.Top="350"/>
            // </Canvas>
            (Canvas() {
                Rectangle(10., 10.)
                    .size(63., 41.)
                    .fill(SolidColorBrush(Colors.Blue))
                    .canvasLeft(40.)
                    .canvasTop(31.)
                    .opacityMask (
                        LinearGradientBrush(RelativePoint.Center, RelativePoint.BottomRight) {
                            GradientStop(0., Colors.Black)
                            GradientStop(1., Colors.Transparent)
                        }
                    )

                Rectangle(10., 5.)
                    .size(40., 20.)
                    .fill(SolidColorBrush(Color.ToHsv(byte 240., byte 83., byte 73., byte 90.).ToRgb()))
                    .stroke(SolidColorBrush(Color.ToHsl(byte 5., byte 85., byte 85.).ToRgb()))
                    .strokeThickness(2.)
                    .canvasLeft(150.)
                    .canvasTop (10.)

                Ellipse()
                    .size(58., 58.)
                    .fill(SolidColorBrush(Colors.Green))
                    .canvasLeft(88.)
                    .canvasTop (100.)

                Path("M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,-50 Z")
                    .fill(SolidColorBrush(Colors.Orange))
                    .canvasLeft(30.)
                    .canvasTop (250.)


                Path(
                    PathGeometry(FillRule.NonZero) {
                        PathFigure(Point(0., 0.)) {
                            QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
                            QuadraticBezierSegment(Point(100., -50.), Point(100., 0.))
                            LineSegment(Point(50., 0.))
                            LineSegment(Point(50., 50.))

                        }
                    }
                )
                    .fill(SolidColorBrush(Colors.OrangeRed))
                    .canvasLeft(180.)
                    .canvasTop (250.)


                Line(Point(120., 185.), Point(30., 115.))
                    .stroke(SolidColorBrush(Colors.Red))
                    .strokeThickness (2.)

                Polygon(
                    [ Point(75., 0.)
                      Point(120., 120.)
                      Point(0., 45.)
                      Point(150., 45.)
                      Point(30., 120.) ]
                )
                    .stroke(SolidColorBrush(Colors.DarkBlue))
                    .strokeThickness(1.)
                    .fill(SolidColorBrush(Colors.Violet))
                    .canvasLeft(150.)
                    .canvasTop (31.)

                Polyline(
                    [ Point(0., 0.)
                      Point(65., 0.)
                      Point(78., -26.)
                      Point(91., 39.)
                      Point(104., -39.)
                      Point(117., 13.)
                      Point(130., 0.)
                      Point(195., 0.) ]
                )
                    .stroke(SolidColorBrush(Colors.Brown))
                    .canvasLeft(30.)
                    .canvasTop (350.)
            })
                .background(SolidColorBrush(Colors.Yellow))
                .size (300., 400.)

        }

    let sample =
        { Name = "Canvas"
          Description = "Control that lays out its children by explicit coordinates"
          Program = Helper.createProgram init update view }
