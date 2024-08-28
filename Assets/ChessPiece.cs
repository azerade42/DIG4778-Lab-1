using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private List<Vector3> validMoves;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite altIcon;
    [SerializeField] private PieceColor color;
    [SerializeField] private PieceType type;
    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = icon;
        if(this.color == PieceColor.black)
        {
            this.GetComponent<SpriteRenderer>().sprite = altIcon;
        }
    }
    public enum PieceColor
    {
        white,
        black
    }

    public enum PieceType
    {
        pawn,
        knight,
        bishop,
        rook,
        queen,
        king
    }


}
