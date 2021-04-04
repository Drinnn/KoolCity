using UnityEngine;

public class PlacementManager : MonoBehaviour {
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private Transform ground;

    public void PlaceBuilding(Vector3 gridPosition) {
        Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity);
    }
}
