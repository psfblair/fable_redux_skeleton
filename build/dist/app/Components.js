(function (global, factory) {
    if (typeof define === "function" && define.amd) {
        define(["exports", "babel-runtime/core-js/array/from", "fable-core", "./../node_modules/fable-import-react/Fable.Helpers.React", "react", "react-redux"], factory);
    } else if (typeof exports !== "undefined") {
        factory(exports, require("babel-runtime/core-js/array/from"), require("fable-core"), require("./../node_modules/fable-import-react/Fable.Helpers.React"), require("react"), require("react-redux"));
    } else {
        var mod = {
            exports: {}
        };
        factory(mod.exports, global.from, global.fableCore, global.FableHelpers, global.react, global.reactRedux);
        global.unknown = mod.exports;
    }
})(this, function (exports, _from, _fableCore, _FableHelpers, _react, _reactRedux) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
        value: true
    });
    exports.provider = exports.voting = exports.Voting = exports.initialProps = exports.initialPair = exports.VotingProps = exports.State = undefined;

    var _from2 = _interopRequireDefault(_from);

    var $import3 = _interopRequireWildcard(_react);

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

    function _interopRequireDefault(obj) {
        return obj && obj.__esModule ? obj : {
            default: obj
        };
    }

    var State = exports.State = class State {
        constructor($arg0) {
            this.Pair = $arg0;
        }

    };
    var VotingProps = exports.VotingProps = class VotingProps {
        constructor($arg0, $arg1) {
            this.Store = $arg0;
            this.Children = $arg1;
        }

        get store() {
            return this.Store;
        }

        get children() {
            return this.Children;
        }

    };

    _fableCore.Util.setInterfaces(VotingProps.prototype, ["Fable.Import.ReactRedux.Property"]);

    var initialPair = exports.initialPair = _fableCore.List.ofArray(["Trainspotting", "28 Days Later"]);

    var initialProps = exports.initialProps = function (store) {
        return new VotingProps(store);
    };

    var Voting = exports.Voting = class Voting extends _FableHelpers.Component {
        constructor(props) {
            super(props, new State(initialPair));
        }

        render() {
            var buttons;
            return buttons = _fableCore.List.map(entry => {
                return $import3.createElement("button", {
                    key: entry
                }, ...[$import3.createElement("h1", {}, ...[entry])]);
            }, this.state.Pair), $import3.createElement("div", {
                className: "voting"
            }, ...(0, _from2.default)(buttons));
        }

    };

    var voting = exports.voting = function (props) {
        return $import3.createElement(Voting, (0, _FableHelpers.toPlainJsObj)(props), ...[]);
    };

    var provider = exports.provider = function (store) {
        var props;
        return props = initialProps(store), $import3.createElement(_reactRedux.Provider, (0, _FableHelpers.toPlainJsObj)(props), ...[voting(props)]);
    };
});
//# sourceMappingURL=Components.js.map