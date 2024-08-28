using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private List<Vector3> validMoves;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite altIcon;
    [SerializeField] private MyEnum color;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = icon;
        if(color == MyEnum.black)
        {
            this.GetComponent<SpriteRenderer>().sprite = altIcon;
        }
    }
    public enum MyEnum
    {
        white,
        black
    }

}
