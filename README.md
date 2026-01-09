# Chess Mobile — Unity Prototype

Prototype Unity project for a realistic 3D chess mobile app (iOS & Android).

What this prototype includes
- Unity scene (Main) with a 3D chessboard and Staunton piece prefabs (placeholders)
- Touch controls: drag-and-drop and tap-to-move
- Full rule enforcement: castling, en-passant, promotion UI
- Move list (algebraic notation) and PGN export
- Clock / time-control UI (basic)
- UCI integration stub for Stockfish (instructions to add binary)

Requirements
- Unity 2021 LTS (recommended)
- (Optional) Stockfish native binary for mobile if you want on-device AI (not included)

How to open
1. Clone the repository
2. Open the project in Unity Hub (select the recommended Unity version)
3. Open the scene referenced in Assets/Scenes/ (Main scene placeholder) and press Play in the Editor

Stockfish / AI
This prototype includes a UCI wrapper stub (C#). To enable on-device AI:
1. Add the Stockfish native binary to Assets/Plugins/<platform>/ (see platform-specific README notes).
2. If the binary is large, consider using Git LFS for distribution.

Notes & Next steps
- This is a client-side prototype (no online matchmaking yet).
- On-device Stockfish is NOT included in this initial commit. The repository contains integration stubs and instructions.
- After the initial push I will provide next steps for adding the Stockfish binary, sample art assets, and scene setup.

License
MIT
