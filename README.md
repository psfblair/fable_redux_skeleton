# Brunch Skeleton for F#/Fable, React, Redux, and React-Router

# NOTE: This skeleton is not yet viable!!

In the project's current state, I haven't figured out how successfully to connect the React
components to the state. This is supposed to be done using the `connect` function. However,
the component returned by `connect` is a JS `function`, whereas the React type validator is
requiring that it be of type `object`. Not sure why this is the case or how to fix it.

I don't plan on returning to this project to make it work, so if you'd like to use this skeleton
be prepared to invest the time in getting it to work.

-- PB

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

Fable will compile into build/dist the F# source files as well as the `Fable.Helpers.React.fs` file 
that lives in node_modules/fable-import-react. Interface declaration files (i.e., files whose  
name starts with `Fable.Import` or `Fable.Core`) don't get compiled to Javascript by Fable. 
However, the helper file is not simply an interface declaration file and so must be 
compiled and be part of the build output.

