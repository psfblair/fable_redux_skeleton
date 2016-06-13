module Initialize

open System
open Fable.Core
open Fable.Import
open Props
module Redux = Fable.Import.Redux

let initialState: CounterState = -1 
let store = Redux.Globals.createStore(Reducers.reducer, initialState)
let initialProps = CounterProps(Some store, None)

let load() = 
    let provider = Components.provider initialProps
    ReactDom.render(provider, Browser.document.getElementById "app") |> ignore

if Browser.document.readyState <> "complete" then
    let eventListener = Utilities.toBrowserEventHandler(fun _ -> load())
    Browser.document.addEventListener ("DOMContentLoaded", eventListener)
else
    load()
