module Initialize

open System
open Fable.Core
open Fable.Import
module RR = Fable.Helpers.React

open Utilities
open Components
open Reducers

module Redux = Fable.Import.Redux

let store = Redux.Globals.createStore reducer

let load() = ReactDom.render(Components.provider store, Browser.document.getElementById "app") |> ignore

if Browser.document.readyState <> "complete" then
    let eventListener = Utilities.toBrowserEventHandler(fun _ -> load())
    Browser.document.addEventListener ("DOMContentLoaded", eventListener)
else
    load()
