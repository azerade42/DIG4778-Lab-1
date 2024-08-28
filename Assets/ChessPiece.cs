using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private List<Vector3> validMoves;
    [SerializeField] private Sprite Icon;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Icon;
    }
    public enum MyEnum
    {
        white,
        black
    }

}
