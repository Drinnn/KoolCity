using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private Action OnBuildAreaHandler;
    private Action OnCancelHandler;
    private Action OnDemolishActionHandler;


    [SerializeField] public Button buildResidentialAreaBtn;

    [SerializeField] public GameObject cancelActionPanel;
    [SerializeField] public Button cancelActionBtn;

    [SerializeField] public GameObject buildingMenuPanel;
    [SerializeField] public Button openBuildMenuBtn;
    [SerializeField] public Button demolishBtn;

    private void Start() {
        cancelActionPanel.SetActive(false);
        buildingMenuPanel.SetActive(false);
        buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        cancelActionBtn.onClick.AddListener(OnCancelCallback);
        openBuildMenuBtn.onClick.AddListener(OnOpenBuildMenu);
        demolishBtn.onClick.AddListener(OnDemolishHandler);
    }

    private void OnOpenBuildMenu() {
        buildingMenuPanel.SetActive(true);
    }

    private void OnBuildAreaCallback() {
        cancelActionPanel.SetActive(true);
        buildingMenuPanel.SetActive(false);
        OnBuildAreaHandler?.Invoke();
    }

    private void OnCancelCallback() {
        cancelActionPanel.SetActive(false);
        OnCancelHandler?.Invoke();
    }

    private void OnDemolishHandler() {
        OnDemolishActionHandler?.Invoke();
        cancelActionPanel.SetActive(true);
        buildingMenuPanel.SetActive(false);
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

    public void AddListenerOnDemolishActionEvent(Action listener) {
        OnDemolishActionHandler += listener;
    }

    public void RemoveListenerOnDemolishActionEvent(Action listener) {
        OnDemolishActionHandler -= listener;
    }

}
