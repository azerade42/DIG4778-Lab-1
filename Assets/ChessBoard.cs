using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] private int boardSize = 8;
    [SerializeField] private float tileSize = 1;
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                float boardOffset = (float)boardSize/2 - tileSize / 2;
                Vector3 boardPosition = new Vector3(i - boardOffset, j - boardOffset, 1);
                Gizmos.DrawCube(boardPosition, Vector3.one);
                Gizmos.color = SwapColor(Gizmos.color);
            }
            Gizmos.color = SwapColor(Gizmos.color);
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
