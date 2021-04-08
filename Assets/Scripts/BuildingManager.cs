using System.Collections.Generic;
using UnityEngine;

public class BuildingManager {
    private PlacementManager _placementManager;
    private StructureRepository _structureRepository;
    private Dictionary<Vector3Int, GameObject> _structuresToBeModified = new Dictionary<Vector3Int, GameObject>();

    private GridStructure _grid;

    public BuildingManager(PlacementManager placementManager, StructureRepository structureRepository, int gridWidth, int gridLength, int cellSize) {
        this._placementManager = placementManager;
        this._structureRepository = structureRepository;
        this._grid = new GridStructure(gridWidth, gridLength, cellSize);
    }

    public void PlaceStructureAt(Vector3 inputPosition, string structureName, StructureType structureType) {
        GameObject buildingPrefab = this._structureRepository.GetBuildingPrefabByName(structureName, structureType);
        Vector3 gridPosition = this._grid.CalculateGridPosition(inputPosition);
        Vector3Int gridPositionInt = Vector3Int.FloorToInt(gridPosition);
        if (!_grid.IsCellTaken(gridPosition) && (!_structuresToBeModified.ContainsKey(gridPositionInt))) {
            _structuresToBeModified.Add(gridPositionInt, _placementManager.CreateGhostStructure(gridPosition, buildingPrefab));
        }
    }

    public void ConfirmPlacement() {
        _placementManager.PlaceStructuresOnMap(_structuresToBeModified.Values);
        foreach (var keyValuePair in _structuresToBeModified) {
            _grid.PlaceStructureOnGrid(keyValuePair.Value, keyValuePair.Key);
        }
        _structuresToBeModified.Clear();
    }

    public void CancelPlacement() {
        _placementManager.DestroyStructures(_structuresToBeModified.Values);
        _structuresToBeModified.Clear();
    }

    public void RemoveBuildingAt(Vector3 inputPosition) {
        Vector3 gridPosition = this._grid.CalculateGridPosition(inputPosition);

        if (_grid.IsCellTaken(gridPosition)) {
            GameObject structure = _grid.GetStructureFromGrid(gridPosition);
            _structuresToBeModified.Add(Vector3Int.FloorToInt(gridPosition), structure);
            _placementManager.SetBuildingForRemoval(structure);
        }
    }

    public void ConfirmRemoval() {
        foreach (Vector3Int gridPosition in _structuresToBeModified.Keys) {
            _grid.RemoveStructureFromGrid(gridPosition);
        }
        this._placementManager.DestroyStructures(_structuresToBeModified.Values);
        _structuresToBeModified.Clear();
    }

    public void CancelRemoval() {
        this._placementManager.PlaceStructuresOnMap(_structuresToBeModified.Values);
        _structuresToBeModified.Clear();
    }
}
