module Components

open System
open Fable.Core
open Fable.Import

module React = Fable.Import.React
module ReactRedux = Fable.Import.ReactRedux
module R = Fable.Helpers.React
open R.Props

open Types

// TODO How to do mixins: PureRenderMixin?
// import PureRenderMixin from 'react-addons-pure-render-mixin'
type Counter(props, ?state) =
    inherit R.Component<CounterProps, CounterState>(props, ?state = state)

    let labelFrom actionCreator = 
        actionCreator().``type`` |> Types.toString
    let dispatcherFrom actionCreator (_:React.MouseEvent) = 
        actionCreator () |> actionDispatcher props
    let createActionButton (actionLabel, dispatcher) =
        R.button [ Key actionLabel
                   OnClick dispatcher
                 ] 
                 [ R.h1 [] [unbox actionLabel]]

    member self.render () =
        let buttons = 
            [ ActionCreators.increment; ActionCreators.decrement ]
            |> List.map (fun actionCreator -> (labelFrom actionCreator, dispatcherFrom actionCreator))
            |> List.map createActionButton
        R.div 
            [ ClassName "counter" ] 
            [ R.h1 [ClassName "count"] [unbox (getState props) ] 
              R.div [] buttons
            ]

let counter props = R.com<Counter,CounterProps,CounterState> props []

let provider store = 
    let props = Types.initialProps store
    R.com<ReactRedux.Provider<CounterProps>,ReactRedux.Property<CounterProps>,obj> props [counter props]


