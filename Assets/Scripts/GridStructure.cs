using UnityEngine;

public class GridStructure {
    private int _cellSize;

    public GridStructure(int cellSize) {
        this._cellSize = cellSize;
    }

    public Vector3 CalculateGridPosition(Vector3 inputPosition) {
        int x = Mathf.FloorToInt((float)inputPosition.x / _cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / _cellSize);

        return new Vector3(x * _cellSize, 0, z * _cellSize);
    }

}
