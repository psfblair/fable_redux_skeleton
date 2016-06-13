﻿module Components

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

    let labelFrom actionCreator =  actionCreator().``type`` |> toString
    
    let dispatcherFrom actionCreator (_:React.MouseEvent) = 
        let actionDispatcher action = 
            match (props :> ReactRedux.Property<CounterProps>).store with
            | None -> failwith "Cannot create action dispatcher without a Redux store"
            | Some store -> action
                            |> toObj
                            |> store.dispatch
                            |> ignore
        actionCreator () |> actionDispatcher

    let createActionButton (actionLabel, dispatcher) =
        Tag.button [ Attr.Key actionLabel
                     Attr.OnClick dispatcher
                   ] 
                   [ Tag.h1 [] [unbox actionLabel]]

    let count =
        match (props :> ReactRedux.Property<CounterProps>).store with
        | Some store -> store.getState() |> unbox 
        | None -> failwith "Cannot get state without a Redux store"

    member self.render () =
        let buttons = 
            [ ActionCreators.increment; ActionCreators.decrement ]
            |> List.map (fun actionCreator -> (labelFrom actionCreator, dispatcherFrom actionCreator))
            |> List.map createActionButton
        Tag.div 
            [ Attr.ClassName "counter" ] 
            [ Tag.h1 [Attr.ClassName "count"] [unbox (sprintf "Count: %d" count)] 
              Tag.div [] buttons
            ]

let counter props = Tag.com<Counter,CounterProps,CounterState> props []

let provider props = 
    Tag.com<ReactRedux.Provider<CounterState, CounterProps>,ReactRedux.Property<CounterProps>,CounterState> props [counter props]


