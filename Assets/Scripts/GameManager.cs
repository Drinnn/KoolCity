using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public IInputManager inputManager;
    [SerializeField] public PlacementManager placementManager;
    [SerializeField] public UIController uIController;
    [SerializeField] public CameraMovement cameraMovement;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridLength;

    private int _cellSize = 3;

    private BuildingManager _buildingManager;

    private PlayerState state;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;

    public PlayerState State { get => state; }

    private void Awake() {
        _buildingManager = new BuildingManager(placementManager, gridWidth, gridLength, _cellSize);
        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, _buildingManager);

        state = selectionState;
    }

    private void Start() {
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        cameraMovement.SetCameraBounds(0, gridWidth, 0, gridLength);

        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        inputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPanStart);
        inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        inputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);

        uIController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uIController.AddListenerOnCancelEvent(CancelPlacementMode);
    }

    private void HandleInput(Vector3 position) {
        state.OnInputPointerDown(position);
    }

    private void HandleInputCameraPanStart(Vector3 position) {
        state.OnInputPanChange(position);
    }

    private void HandleInputCameraPanStop() {
        state.OnInputPanUp();
    }

    private void HandlePointerChange(Vector3 position) {
        state.OnInputPointerChange(position);
    }

    private void StartPlacementMode() {
        TransitionToState(buildingSingleStructureState);
    }

    private void CancelPlacementMode() {
        state.OnCancel();
    }

    public void TransitionToState(PlayerState newState) {
        this.state = newState;
        this.state.EnterState();
    }

}
