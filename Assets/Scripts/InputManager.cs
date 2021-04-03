using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {
    [SerializeField] private LayerMask groundLayerMask;

    // [SerializeField] private GameObject buildingPrefab;

    private void Update() {
        GetInput();
    }

    private void GetInput() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, groundLayerMask)) {
                Vector3 position = hit.point - transform.position;
            }
        }
    }

    // private void CreateBuilding(Vector3 buildingPosition) {
    //     Instantiate(buildingPrefab, buildingPosition, Quaternion.identity);
    // }
}
