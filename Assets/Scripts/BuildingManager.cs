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

    public void PrepareStructureForPlacement(Vector3 inputPosition, string structureName, StructureType structureType) {
        GameObject buildingPrefab = this._structureRepository.GetBuildingPrefabByName(structureName, structureType);
        Vector3 gridPosition = this._grid.CalculateGridPosition(inputPosition);
        Vector3Int gridPositionInt = Vector3Int.FloorToInt(gridPosition);
        if (!_grid.IsCellTaken(gridPosition)) {
            if (_structuresToBeModified.ContainsKey(gridPositionInt)) {
                RevokeStructureFromPlacementAt(gridPositionInt);
            } else {
                PlaceNewStructureAt(gridPosition, gridPositionInt, buildingPrefab);
            }
        }
    }

    private void RevokeStructureFromPlacementAt(Vector3Int gridPositionInt) {
        GameObject structure = _structuresToBeModified[gridPositionInt];
        _placementManager.DestroySingleStructure(structure);
        _structuresToBeModified.Remove(gridPositionInt);
    }

    private void PlaceNewStructureAt(Vector3 gridPosition, Vector3Int gridPositionInt, GameObject buildingPrefab) {
        _structuresToBeModified.Add(gridPositionInt, _placementManager.CreateGhostStructure(gridPosition, buildingPrefab));
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

    public void PrepareStructureForRemovalAt(Vector3 inputPosition) {
        Vector3 gridPosition = this._grid.CalculateGridPosition(inputPosition);

        if (_grid.IsCellTaken(gridPosition)) {
            Vector3Int gridPositionInt = Vector3Int.FloorToInt(gridPosition);
            GameObject structure = _grid.GetStructureFromGrid(gridPosition);
            if (_structuresToBeModified.ContainsKey(gridPositionInt)) {
                RemoveStructureForDemolishionAt(gridPositionInt, structure);
            } else {
                AddStructureForDemolishion(gridPositionInt, structure);
            }
        }
    }

    private void RemoveStructureForDemolishionAt(Vector3Int gridPositionInt, GameObject structure) {
        _placementManager.ResetBuildingMaterial(structure);
        _structuresToBeModified.Remove(gridPositionInt);
    }

    private void AddStructureForDemolishion(Vector3Int gridPositionInt, GameObject structure) {
        _structuresToBeModified.Add(gridPositionInt, structure);
        _placementManager.SetBuildingForRemoval(structure);
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

    // TODO: REMOVE "CHEAT" METHODS FOR TESTING ONLY
    public GameObject CheckForStructureInGrid(Vector3 inputPosition) {
        Vector3 gridPosition = _grid.CalculateGridPosition(inputPosition);
        if (_grid.IsCellTaken(gridPosition)) {
            return _grid.GetStructureFromGrid(gridPosition);
        }

        return null;
    }

    public GameObject CheckForStructureInDictionary(Vector3 inputPosition) {
        Vector3 gridPosition = _grid.CalculateGridPosition(inputPosition);
        Vector3Int gridPositionInt = Vector3Int.FloorToInt(gridPosition);
        if (_structuresToBeModified.ContainsKey(gridPositionInt)) {
            return _structuresToBeModified[gridPositionInt];
        }

        return null;
    }
    //
}
