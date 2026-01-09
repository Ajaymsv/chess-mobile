using UnityEngine;
using System.Collections.Generic;

// GameController scaffold: manages game state, move list, PGN export hook.
public class GameController : MonoBehaviour
{
    public BoardController boardController;

    private List<string> moves = new List<string>();

    void Start()
    {
        if (boardController == null) boardController = FindObjectOfType<BoardController>();
    }

    public void RegisterMove(string algebraic)
    {
        moves.Add(algebraic);
        Debug.Log("Move registered: " + algebraic);
    }

    public string ExportPGN()
    {
        // Very simple PGN exporter (placeholder)
        return string.Join(" ", moves.ToArray());
    }
}
