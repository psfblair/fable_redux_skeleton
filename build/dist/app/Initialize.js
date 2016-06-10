(function (global, factory) {
    if (typeof define === "function" && define.amd) {
        define(["exports", "redux", "./Reducers", "react-dom", "./Components", "./Utilities"], factory);
    } else if (typeof exports !== "undefined") {
        factory(exports, require("redux"), require("./Reducers"), require("react-dom"), require("./Components"), require("./Utilities"));
    } else {
        var mod = {
            exports: {}
        };
        factory(mod.exports, global.redux, global.Reducers, global.reactDom, global.Components, global.Utilities);
        global.unknown = mod.exports;
    }
})(this, function (exports, _redux, _Reducers, _reactDom, _Components, _Utilities) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
        value: true
    });
    exports.load = exports.store = undefined;

    var $import0 = _interopRequireWildcard(_redux);

    var $import2 = _interopRequireWildcard(_reactDom);

    function _interopRequireWildcard(obj) {
        if (obj && obj.__esModule) {
            return obj;
        } else {
            var newObj = {};

            if (obj != null) {
                for (var key in obj) {
                    if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key];
                }
            }

            newObj.default = obj;
            return newObj;
        }
    }

    var eventListener;
    var store = exports.store = $import0.createStore(_Reducers.reducer);

    var load = exports.load = function () {
        $import2.render((0, _Components.provider)(store), document.getElementById("app"));
    };

    document.readyState !== "complete" ? (eventListener = (0, _Utilities.toBrowserEventHandler)(_arg1 => {
        load();
    }), document.addEventListener("DOMContentLoaded", eventListener)) : load();
});
//# sourceMappingURL=Initialize.js.map