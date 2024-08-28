using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private List<Vector3> validMoves;
    [SerializeField] private Sprite icon;

    public enum PieceColor
    {
        White,
        Black
    }

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = icon;
    }
}
