module Reducers

module Redux = Fable.Import.Redux
open System
open ActionCreators

let inner = function
    | (state, { Type' = Increment }) -> state + 1
    | (state, { Type' = Decrement }) -> state - 1

let reducer = Func<int,Action,int>(fun state action -> inner (state, action))
