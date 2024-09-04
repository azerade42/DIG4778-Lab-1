using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    [field: SerializeField] public List<Vector2> startPositions { get; set; }
    [SerializeField] private List<Vector2> validMoves;
    [SerializeField] private Sprite icon;
    [SerializeField] private PieceColor color;
    [field: SerializeField] public PieceType type { get; set; }

    public enum PieceColor
    {
        white,
        black
    }
    public enum PieceType
    {
        Pawn,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = icon;
        SwapPieceColor();
    }

    public void SwapPieceColor()
    {
        if(this.color == PieceColor.black)
        {
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    private void OnDrawGizmosSelected()
    {
        SwitchPiece();
        Gizmos.color = Color.blue;
        DrawValidMoveRays();
    }

    private void DrawValidMoveRays()
    {
        for (int i = 0; i < validMoves.Count; i++)
        {
            Vector2 move = validMoves[i];
            Vector3 pieceMove = new Vector3(move.x, move.y, 0);

            if (type == PieceType.Knight)
            {
                bool xGreater = Mathf.Abs(move.x) > Mathf.Abs(move.y);
                Vector2 ray1, ray2;

                if (xGreater)
                {
                    ray1 = new Vector2(move.x, 0);
                    ray2 = new Vector2(0, move.y);
                }
                else
                {
                    ray1 = new Vector2(0, move.y);
                    ray2 = new Vector2(move.x, 0);
                }
                
                Gizmos.DrawRay(transform.position, ray1);
                Gizmos.DrawRay((Vector2)transform.position + ray1, ray2);
            }
            else if (type == PieceType.Pawn)
            {
                float offset = 0.1f;
                Vector2 offsetVector = new Vector2(offset, 0);
                if (i == 0)
                {
                    Gizmos.DrawRay((Vector2)transform.position - offsetVector, (Vector2)pieceMove);
                }
                else
                {
                    Gizmos.DrawRay((Vector2)transform.position + offsetVector, (Vector2)pieceMove);
                }
            }
            else
            {
                Gizmos.DrawRay(transform.position, pieceMove);
            }
        }
    }

    private void SwitchPiece()
    {
        foreach (ChessPiece piece in transform.parent.GetComponent<ChessBoard>().chessPieces)
        {
            if (piece.type == this.type)
            {
                this.startPositions = piece.startPositions;
                this.validMoves = piece.validMoves;
                this.icon = piece.icon;
                GetComponent<SpriteRenderer>().sprite = icon;
                SwapPieceColor();
                gameObject.name = Enum.GetName(typeof(PieceType), piece.type);
            }
        }
    }
    
}
