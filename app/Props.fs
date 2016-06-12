module Props

open Fable.Core
open Fable.Import
open Fable.Import.JS
module React = Fable.Import.React
module Redux = Fable.Import.Redux
module ReactRedux = Fable.Import.ReactRedux
module FsMap = FSharp.Collections.Map

open ActionCreators

type CounterState = int

type CounterProps(maybeStore : Redux.Store option, maybeChildren : React.ReactElement<CounterProps> option) = 
    member self.toProperty = self :> ReactRedux.Property<CounterProps>
    member this.increment = ActionCreators.increment
    member this.decrement = ActionCreators.decrement

    interface ReactRedux.Property<CounterProps> with 
        member val store = maybeStore
        member val children = maybeChildren

let initialProps store = CounterProps(Some store, None)

let getState (props: CounterProps) = 
    match props.toProperty.store with
    | Some store -> store.getState()
    | None -> failwith "Cannot get state without a Redux store"

let actionDispatcher (props: CounterProps) action =
    match props.toProperty.store with
    | None -> failwith "Cannot create action dispatcher without a Redux store"
    | Some store -> action
                    |> toObj
                    |> store.dispatch
                    |> ignore
