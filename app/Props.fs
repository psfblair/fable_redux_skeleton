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
    member this.increment = ActionCreators.increment
    member this.decrement = ActionCreators.decrement

    interface ReactRedux.Property<CounterProps> with 
        member val store = maybeStore
        member val children = maybeChildren
