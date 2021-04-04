using System;
using UnityEngine;

public class GridStructure {
    private int _width;
    private int _length;
    private int _cellSize;
    private Cell[,] _grid;

    public GridStructure(int width, int length, int cellSize) {
        this._width = width;
        this._length = length;
        this._cellSize = cellSize;
        this._grid = new Cell[this._width, this._length];
        for (int row = 0; row < _grid.GetLength(0); row++) {
            for (int col = 0; col < _grid.GetLength(1); col++) {
                _grid[row, col] = new Cell();
            }
        }
    }

    public Vector3 CalculateGridPosition(Vector3 inputPosition) {
        int x = Mathf.FloorToInt((float)inputPosition.x / _cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / _cellSize);

        return new Vector3(x * _cellSize, 0, z * _cellSize);
    }

    public Vector2Int CalculateGridIndex(Vector3 gridPosition) {
        return new Vector2Int((int)(gridPosition.x / this._cellSize), (int)(gridPosition.z / this._cellSize));
    }

    public bool IsCellTaken(Vector3 gridPosition) {
        var cellIndex = CalculateGridIndex(gridPosition);
        if (cellIndex.x > 0 && cellIndex.x < _grid.GetLength(1) && cellIndex.y > 0 && cellIndex.y < _grid.GetLength(0))
            return _grid[cellIndex.y, cellIndex.x].IsTaken;

        throw new IndexOutOfRangeException("No index " + cellIndex + " in grid.");
    }

    public void PlaceStructureOnGrid(GameObject structure, Vector3 gridPosition) {
        var cellIndex = CalculateGridIndex(gridPosition);
        if (cellIndex.x > 0 && cellIndex.x < _grid.GetLength(1) && cellIndex.y > 0 && cellIndex.y < _grid.GetLength(0))
            _grid[cellIndex.y, cellIndex.x].SetConstruction(structure);
    }



}
