using UnityEngine;

public class BuildingManager {
    private PlacementManager _placementManager;

    private GridStructure _grid;

    public BuildingManager(PlacementManager placementManager, int gridWidth, int gridLength, int cellSize) {
        this._placementManager = placementManager;
        this._grid = new GridStructure(gridWidth, gridLength, cellSize);
    }

    public void PlaceStructureAt(Vector3 inputPosition) {
        Vector3 gridPosition = this._grid.CalculateGridPosition(inputPosition);

        if (!_grid.IsCellTaken(gridPosition)) {
            _placementManager.PlaceBuilding(gridPosition, _grid);
        }
    }
}
