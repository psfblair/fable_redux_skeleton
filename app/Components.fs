module Components

open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

module R = Fable.Helpers.React
module Props = R.Props
module Redux = Fable.Import.Redux
module ReactRedux = Fable.Import.ReactRedux

type State = { Pair: string list }

type VotingProps = 
    { Store: Redux.Store; Children: Function option }
        interface ReactRedux.Property with 
            member self.store with get () = Some self.Store
            member self.children with get () = self.Children


let initialPair = ["Trainspotting"; "28 Days Later"];
let initialProps store = { Store = store; Children = None }


// TODO How to do mixins: PureRenderMixin?
// import PureRenderMixin from 'react-addons-pure-render-mixin'
type Voting(props) =
    inherit R.Component<VotingProps, State>(props, { Pair = initialPair })

    member self.render () =
        let buttons = 
            self.state.Pair 
            |> List.map (fun entry -> R.button [Props.Key entry] [
                                        R.h1 [] [unbox entry]])
        R.div [Props.ClassName "voting"] buttons

let voting props = R.com<Voting,_,_> props []

let provider store = 
    let props = initialProps store
    R.com<ReactRedux.Provider,_,_> props [voting props]

