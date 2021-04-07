using UnityEngine;

public class PlacementManager : MonoBehaviour {
    [SerializeField] private Transform ground;

    public void PlaceBuilding(Vector3 gridPosition, GridStructure grid, GameObject buildingPrefab) {
        GameObject newStructure = Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity);
        grid.PlaceStructureOnGrid(newStructure, gridPosition);
    }

    public void RemoveBuilding(Vector3 gridPosition, GridStructure grid) {
        GameObject structure = grid.GetStructureFromGrid(gridPosition);
        if (structure != null) {
            Destroy(structure);
            grid.RemoveStructureFromGrid(gridPosition);
        }
    }
}
