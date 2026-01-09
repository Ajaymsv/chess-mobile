This folder is intended for platform-specific engine binaries (Stockfish). Do NOT add binaries to the repo unless necessary. Instead:

- For Android: put the native binary in Assets/Plugins/Android/ with proper ABI folders (armeabi-v7a, arm64-v8a).
- For iOS: integrate Stockfish as a static library and link in Xcode.

See README.md for more details.
