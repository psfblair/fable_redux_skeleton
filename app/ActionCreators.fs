module ActionCreators

type ActionType = Increment | Decrement
type Action = { Type' : ActionType }

let increment state = { Type' = Increment }
let decrement state = { Type' = Decrement }
