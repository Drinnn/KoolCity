using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private GameObject buildingPrefab;

    private int _cellSize = 3;

    private void Update() {
        GetInput();
    }

    private void GetInput() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, groundLayerMask)) {
                Vector3 position = hit.point - transform.position;
                CreateBuilding(CalculateGridPosition(position));
                Debug.Log(position);
            }
        }
    }

    private Vector3 CalculateGridPosition(Vector3 inputPosition) {
        int x = Mathf.FloorToInt((float)inputPosition.x / _cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / _cellSize);

        return new Vector3(x * _cellSize, 0, z * _cellSize);
    }

    private void CreateBuilding(Vector3 buildingPosition) {
        Instantiate(buildingPrefab, buildingPosition, Quaternion.identity);
    }
}
