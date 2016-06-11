module ActionCreators
open Types

let increment _ = { ``type`` = Increment }
let decrement _ = { ``type`` = Decrement }
