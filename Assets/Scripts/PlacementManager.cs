using UnityEngine;

public class PlacementManager : MonoBehaviour {
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private Transform ground;

    public void PlaceBuilding(Vector3 gridPosition, GridStructure grid) {
        GameObject newStructure = Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity);
        grid.PlaceStructureOnGrid(newStructure, gridPosition);
    }
}
