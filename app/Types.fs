module Types

open Fable.Core
open Fable.Import
open Fable.Import.JS
module React = Fable.Import.React
module Redux = Fable.Import.Redux
module ReactRedux = Fable.Import.ReactRedux
module FsMap = FSharp.Collections.Map

type CounterState = int

type CounterProps(maybeStore : Redux.Store option, maybeChildren : React.ReactElement<CounterProps> option) = 
    interface ReactRedux.Property<CounterProps> with 
        member val store = maybeStore
        member val children = maybeChildren

let initialProps store = CounterProps(Some store, None)

let getState (props: CounterProps) = 
    match (props :> ReactRedux.Property<CounterProps>).store with
    | Some store -> store.getState()
    | None -> failwith "Cannot get state without a Redux store"


type ActionType = Increment | Decrement
type Action = { ``type`` : ActionType }

let toString = function
    | Increment -> "Increment"
    | Decrement -> "Decrement"

let toObj { ``type`` = actionType } =
    [ ("type", actionType :> obj) ] 
    |> List.toSeq
    |> Fable.Core.Operators.createObj

let actionDispatcher (props: CounterProps) action =
    match (props :> ReactRedux.Property<CounterProps>).store with
    | None -> failwith "Cannot create action dispatcher without a Redux store"
    | Some store -> action
                    |> toObj
                    |> store.dispatch
                    |> ignore
