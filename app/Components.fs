module Components

open System
open Fable.Core
open Fable.Import

module React = Fable.Import.React
module ReactRedux = Fable.Import.ReactRedux
module Tag = Fable.Helpers.React
module Attr = Tag.Props

open ActionCreators
open Props

// TODO How to do mixins: PureRenderMixin?
// import PureRenderMixin from 'react-addons-pure-render-mixin'
type Counter(props, ?state) =
    inherit Tag.Component<CounterProps, CounterState>(props, ?state = state)

    let labelFrom actionCreator = 
        actionCreator().``type`` |> toString
    let dispatcherFrom actionCreator (_:React.MouseEvent) = 
        actionCreator () |> actionDispatcher props
    let createActionButton (actionLabel, dispatcher) =
        Tag.button [ Attr.Key actionLabel
                     Attr.OnClick dispatcher
                   ] 
                   [ Tag.h1 [] [unbox actionLabel]]

    member self.render () =
        let buttons = 
            [ ActionCreators.increment; ActionCreators.decrement ]
            |> List.map (fun actionCreator -> (labelFrom actionCreator, dispatcherFrom actionCreator))
            |> List.map createActionButton
        Tag.div 
            [ Attr.ClassName "counter" ] 
            [ Tag.h1 [Attr.ClassName "count"] [unbox (getState props) ] 
              Tag.div [] buttons
            ]

let counter props = Tag.com<Counter,CounterProps,CounterState> props []

let provider store = 
    let props = Props.initialProps store
    Tag.com<ReactRedux.Provider<CounterState, CounterProps>,ReactRedux.Property<CounterProps>,CounterState> props [counter props]


