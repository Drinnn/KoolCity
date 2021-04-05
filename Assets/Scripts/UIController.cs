using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private Action OnBuildAreaHandler;
    private Action OnCancelHandler;

    [SerializeField] public Button buildResidentialAreaBtn;
    [SerializeField] public Button cancelActionBtn;
    [SerializeField] public GameObject cancelActionPanel;

    private void Start() {
        cancelActionPanel.SetActive(false);
        buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancelActionBtn.onClick.AddListener(OnCancelCallback);
    }

    private void OnBuildAreaCallback() {
        cancelActionPanel.SetActive(true);
        OnBuildAreaHandler?.Invoke();
    }

    private void OnCancelCallback() {
        cancelActionPanel.SetActive(false);
        OnCancelHandler?.Invoke();
    }

    public void AddListenerOnBuildAreaEvent(Action listener) {
        OnBuildAreaHandler += listener;
    }

    public void RemoveListenerOnBuildAreaEvent(Action listener) {
        OnBuildAreaHandler -= listener;
    }

    public void AddListenerOnCancelEvent(Action listener) {
        OnCancelHandler += listener;
    }

    public void RemoveListenerOnCancelEvent(Action listener) {
        OnCancelHandler -= listener;
    }

}
