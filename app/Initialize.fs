module Initialize

open System
open Fable.Core
open Fable.Import
open Types
module Redux = Fable.Import.Redux

let initialState: CounterState = 0
let store = Redux.Globals.createStore(Reducers.reducer, initialState)

let load() = 
    let provider = Components.provider store
    ReactDom.render(provider, Browser.document.getElementById "app") |> ignore

if Browser.document.readyState <> "complete" then
    let eventListener = Utilities.toBrowserEventHandler(fun _ -> load())
    Browser.document.addEventListener ("DOMContentLoaded", eventListener)
else
    load()
