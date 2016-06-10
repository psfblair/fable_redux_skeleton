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

    var inner = exports.inner = function (_arg1_0, _arg1_1) {
        var _arg1, state;

        return _arg1 = [_arg1_0, _arg1_1], _arg1[1].Type.Case === "Decrement" ? (state = _arg1[0], state - 1) : (state = _arg1[0], state + 1);
    };

    var reducer = exports.reducer = (state, action) => {
        return inner(state, action);
    };
});
//# sourceMappingURL=Reducers.js.map