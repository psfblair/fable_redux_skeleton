(function (global, factory) {
  if (typeof define === "function" && define.amd) {
    define(["exports"], factory);
  } else if (typeof exports !== "undefined") {
    factory(exports);
  } else {
    var mod = {
      exports: {}
    };
    factory(mod.exports);
    global.unknown = mod.exports;
  }
})(this, function (exports) {
  "use strict";

  Object.defineProperty(exports, "__esModule", {
    value: true
  });
  var ActionType = exports.ActionType = class ActionType {
    constructor() {
      this.Case = arguments[0];
      this.Fields = [];

      for (var i = 1; i < arguments.length; i++) {
        this.Fields[i - 1] = arguments[i];
      }
    }

  };
  var Action = exports.Action = class Action {
    constructor($arg0) {
      this.Type = $arg0;
    }

  };

  var increment = exports.increment = function (state) {
    return new Action(new ActionType("Increment"));
  };

  var decrement = exports.decrement = function (state) {
    return new Action(new ActionType("Decrement"));
  };
});
//# sourceMappingURL=ActionCreators.js.map