using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public IInputManager inputManager;
    [SerializeField] public PlacementManager placementManager;
    [SerializeField] public UIController uIController;
    [SerializeField] public CameraMovement cameraMovement;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridLength;
    [SerializeField] private LayerMask inputMask;

    private int _cellSize = 3;

    private BuildingManager _buildingManager;

    private PlayerState state;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;
    public PlayerRemoveBuildingState removeBuildingState;

    public PlayerState State { get => state; }

    private void Awake() {
        _buildingManager = new BuildingManager(placementManager, gridWidth, gridLength, _cellSize);
        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, _buildingManager);
        removeBuildingState = new PlayerRemoveBuildingState(this, _buildingManager);

        state = selectionState;

#if (UNITY_EDITOR && TEST) || !(UNITY_IOS || UNITY_ANDROID)
        inputManager = gameObject.AddComponent<InputManager>();
#endif
    }

    private void Start() {
        PrepareGameComponents();
        AssignInputListeners();
        AssignUIControllerListeners();
    }

    private void PrepareGameComponents() {
        inputManager.MouseInputMask = inputMask;
        cameraMovement.SetCameraBounds(0, gridWidth, 0, gridLength);
    }

    private void AssignInputListeners() {
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
        inputManager.AddListenerOnPointerSecondChangeEvent(HandleInputCameraPanStart);
        inputManager.AddListenerOnPointerSecondUpEvent(HandleInputCameraPanStop);
        inputManager.AddListenerOnPointerChangeEvent(HandlePointerChange);
    }

    private void AssignUIControllerListeners() {
        uIController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uIController.AddListenerOnCancelEvent(CancelPlacementMode);
        uIController.AddListenerOnDemolishActionEvent(StartDemolishMode);
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

    private void StartDemolishMode() {
        TransitionToState(removeBuildingState);
    }

    public void TransitionToState(PlayerState newState) {
        this.state = newState;
        this.state.EnterState();
    }

}
