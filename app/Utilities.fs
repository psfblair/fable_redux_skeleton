module Utilities

open System

open Fable.Core
open Fable.Import

let toBrowserEventHandler func =
    Browser.EventListenerOrEventListenerObject.Case1(Func<Browser.Event,unit>(fun _ -> func()))