using UnityEngine;

public class BuildingManager {
    private PlacementManager _placementManager;
    private StructureRepository _structureRepository;

    private GridStructure _grid;

    public BuildingManager(PlacementManager placementManager, StructureRepository structureRepository, int gridWidth, int gridLength, int cellSize) {
        this._placementManager = placementManager;
        this._structureRepository = structureRepository;
        this._grid = new GridStructure(gridWidth, gridLength, cellSize);
    }

    public void PlaceStructureAt(Vector3 inputPosition, string structureName, StructureType structureType) {
        GameObject buildingPrefab = this._structureRepository.GetBuildingPrefabByName(structureName, structureType);
        Vector3 gridPosition = this._grid.CalculateGridPosition(inputPosition);

        if (!_grid.IsCellTaken(gridPosition)) {
            _placementManager.PlaceBuilding(gridPosition, _grid, buildingPrefab);
        }
    }

    public void RemoveBuildingAt(Vector3 inputPosition) {
        Vector3 gridPosition = this._grid.CalculateGridPosition(inputPosition);

        if (_grid.IsCellTaken(gridPosition)) {
            _placementManager.RemoveBuilding(gridPosition, _grid);
        }
    }
}
