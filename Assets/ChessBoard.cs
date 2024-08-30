using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] private int boardSize = 8;
    [SerializeField] private float tileSize = 1;
    [field: SerializeField] public List<ChessPiece> chessPieces { get; private set; }

    private Vector3 pieceOffset;

    private List<ChessPiece> currentPieces = new List<ChessPiece>();


    public void OnDrawGizmos()
    {
        GenerateBoard();
    }

    void OnDrawGizmosSelected()
    {
        ResetPieces();
        GeneratePieces();
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                GenerateBoardTile(i, j);
            }
            Gizmos.color = SwapColor(Gizmos.color);
        }
    }

    public void GenerateBoardTile(int i, int j)
    {
        float boardOffset = (float)boardSize/2 - tileSize / 2;
        Vector3 boardPosition = new Vector3(i - boardOffset, j - boardOffset, 1);
        if (i == 0 && j == 0)
            pieceOffset = boardPosition;
        Gizmos.DrawWireCube(boardPosition, Vector3.one * tileSize);
        Gizmos.color = SwapColor(Gizmos.color);
    }

    private void ResetPieces()
    {
        foreach (ChessPiece piece in currentPieces)
            DestroyImmediate(piece.gameObject);

        currentPieces.Clear();
        Gizmos.color = Color.black;
    }

    private void GeneratePieces()
    {
        foreach (ChessPiece piece in chessPieces)
        {
            if (piece == null) continue;

            foreach (Vector2 startPosition in piece.startPositions)
            {
                Vector3 piecePosition = pieceOffset + new Vector3(startPosition.x, startPosition.y, 0);
                ChessPiece newPiece = Instantiate(piece, piecePosition, Quaternion.identity, transform).GetComponent<ChessPiece>();
                currentPieces.Add(newPiece);
                newPiece.SwapPieceColor();
                
                newPiece.gameObject.name = Enum.GetName(typeof(ChessPiece.PieceType), newPiece.type);
            }
        }
    }

    public Color SwapColor(Color color)
    {
        if (color == Color.black)
            return Color.white;
        else
            return Color.black;
    }
}
