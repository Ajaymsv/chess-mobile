using UnityEngine;
using System.Diagnostics;
using System.Threading;

// Very small UCI wrapper scaffold for Stockfish. This is a placeholder: the repo does NOT include Stockfish binaries.
public class ChessEngine : MonoBehaviour
{
    private Process engineProcess;

    public void StartEngine(string enginePath)
    {
        UnityEngine.Debug.Log("Starting engine at: " + enginePath);
        // This is a placeholder; actual engine integration requires platform-specific native binaries.
    }

    public void StopEngine()
    {
        if (engineProcess != null && !engineProcess.HasExited) engineProcess.Kill();
    }
}
