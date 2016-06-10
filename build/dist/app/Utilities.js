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

    var toBrowserEventHandler = exports.toBrowserEventHandler = function (func) {
        return _arg1 => {
            func();
        };
    };
});
//# sourceMappingURL=Utilities.js.map