using UnityEngine;

public class PlacementManager : MonoBehaviour {
    [SerializeField] private GameObject buildingPrefab;

    public void PlaceBuilding(Vector3 position) {
        Instantiate(buildingPrefab, position, Quaternion.identity);
    }
}
