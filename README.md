# Brunch Skeleton for F#/Fable, React, Redux, and React-Router

# Setup

* Clone this repository.
* Install the fable compiler (currently `sudo npm install -g fable-compiler` if you have node 4.4 or greater).
  - You will need to have F# 4.0 installed. If you're on OSX/Linux this will require installing `mono`.
* Install brunch (currently `sudo npm install -g brunch`).
* Coming soon: run the paket installation:
  - Windows: `./.paket/paket.bootstrapper.exe`
  - OS X/Linux: `mono ./.paket/paket.bootstrapper.exe`

# Running the build

* At the command prompt, first compile to js using fable: `fable`. Output will be generated under `build/dist/`.
* At the command prompt, run `brunch build`.  Output will be generated to the `public/` directory.

Coming soon: Testing

See the Fable and Brunch documentation for more build options.

# Notes

Fable will compile the source files as well as the `Fable.Helpers.React.fs` file
in node_modules/fable-import-react. Interface declaration files don't get compiled
to Javascript. However, the helper file is not simply an interface declaration file
and so must be compiled and be part of the build output.

Currently there is a workaround for an issue with brunch where the `Fable.Helpers.React`
module isn't found because fable compiles it under a node_modules subdirectory of the
build output directory. (See https://github.com/fsprojects/Fable/issues/188 and also
https://github.com/brunch/brunch/issues/1395 .)

The current workaround is to maintain another copy of `Fable.Helpers.React.fs` in a
`fable-import-react` directory at the top level. Naturally this is not ideal and
hopefully we'll have something better soon.

