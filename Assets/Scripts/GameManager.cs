using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public IInputManager inputManager;
    [SerializeField] public PlacementManager placementManager;
    [SerializeField] public UIController uIController;
    [SerializeField] public CameraMovement cameraMovement;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridLength;


    private GridStructure _grid;
    private int _cellSize = 3;
    private bool _isOnBuildingMode = false;

    private void Start() {
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        _grid = new GridStructure(gridWidth, gridLength, _cellSize);
        cameraMovement.SetCameraBounds(0, gridWidth, 0, gridLength);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        inputManager.AddListenerOnPointerSecondDownEvent(HandleInputCameraPanStart);
        inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        uIController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uIController.AddListenerOnCancelEvent(CancelPlacementMode);
    }

    private void HandleInput(Vector3 position) {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        if (_isOnBuildingMode && !_grid.IsCellTaken(gridPosition)) {
            placementManager.PlaceBuilding(gridPosition, _grid);
        }
    }

    private void HandleInputCameraPanStart(Vector3 position) {
        if (!_isOnBuildingMode) {
            cameraMovement.MoveCamera(position);
        }
    }

    private void HandleInputCameraPanStop() {
        cameraMovement.StopCameraMovement();
    }

    private void StartPlacementMode() {
        _isOnBuildingMode = true;
    }

    private void CancelPlacementMode() {
        _isOnBuildingMode = false;
    }

}
