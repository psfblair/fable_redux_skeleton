module Reducers

module Redux = Fable.Import.Redux
open System
open ActionCreators
open Props

(*
NOTE: When a store is created, an "INIT" action is dispatched so that every
reducer returns their initial state. This effectively populates
the initial state tree.
Right now the initial counter state on the page reads 0 because of the way
this pattern match translates to JS: The type test is on "Decrement", and if
that fails the count is incremented. F# thinks this is an exhaustive pattern
match because it doesn't envision an action of some other type ever being sent
into the reducer. So the React INIT action gets handled as if it were an increment.
Bad.
*)

let inner = function
    | ({ count = state }, { ``type`` = Increment }) -> { count = state + 1 }
    | ({ count = state }, { ``type`` = Decrement }) -> { count = state - 1 }

let reducer = Func<CounterState,Action,CounterState>(fun state action -> inner (state, action))
