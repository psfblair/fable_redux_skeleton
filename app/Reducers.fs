module Reducers

module Redux = Fable.Import.Redux
open System
open Types

(*
NOTE: When a store is created, an "INIT" action is dispatched so that every
reducer returns their initial state. This effectively populates
the initial state tree.
*)

let inner = function
    | (state, { ``type`` = Increment }) -> state + 1
    | (state, { ``type`` = Decrement }) -> state - 1

let reducer = Func<int,Action,int>(fun state action -> inner (state, action))
