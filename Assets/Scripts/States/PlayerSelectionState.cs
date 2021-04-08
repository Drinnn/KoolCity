using UnityEngine;

public class PlayerSelectionState : PlayerState {
    public PlayerSelectionState(GameManager gameManager) : base(gameManager) {
    }

    public override void OnCancel() {
        return;
    }
}
