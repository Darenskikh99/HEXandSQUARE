using UnityEngine;

public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;

    public Color color;

    [SerializeField]
    HexCell[] neighbours;

    private int elevation;

    public RectTransform uiRect;

    int distance;

    public int Elevation
    {
        get { return elevation; }
        set
        {
            elevation = value;
            Vector3 position = transform.localPosition;
            position.y = value * HexMetrics.elevationStep;
            transform.localPosition = position;

            Vector3 uiPosition = uiRect.localPosition;
            uiPosition.z = elevation * (-HexMetrics.elevationStep);
            uiRect.localPosition = uiPosition;
        }
    }

    public HexCell GetNeighbour (HexDirection direction)
    {
        return neighbours[(int)direction];
    }

    public void SetNeighbor(HexDirection direction, HexCell cell)
    {
        neighbours[(int)direction] = cell;
        cell.neighbours[(int)direction.Opposite()] = this;
    }

    public HexEdgeType GetEdgeType (HexDirection direction)
    {
        return HexMetrics.GetEdgeType(elevation, neighbours[(int)direction].elevation);
    }

}
