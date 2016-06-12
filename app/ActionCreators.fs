module ActionCreators

type ActionType = Increment | Decrement
type Action = { ``type`` : ActionType }

let toString = function
    | Increment -> "Increment"
    | Decrement -> "Decrement"

let toObj { ``type`` = actionType } =
    [ ("type", actionType :> obj) ] 
    |> List.toSeq
    |> Fable.Core.Operators.createObj

let increment _ = { ``type`` = Increment }
let decrement _ = { ``type`` = Decrement }
