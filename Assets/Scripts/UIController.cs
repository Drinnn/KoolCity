using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
    private Action<string> OnBuildAreaHandler;
    private Action<string> OnBuildSingleStructureHandler;
    private Action<string> OnBuildRoadHandler;
    private Action OnConfirmHandler;
    private Action OnCancelHandler;
    private Action OnDemolishActionHandler;

    [SerializeField] public StructureRepository structureRepository;

    [SerializeField] public Button buildResidentialAreaBtn;

    [SerializeField] public GameObject cancelActionPanel;
    [SerializeField] public Button confirmActionBtn;
    [SerializeField] public Button cancelActionBtn;

    [SerializeField] public GameObject buildingMenuPanel;
    [SerializeField] public Button openBuildMenuBtn;
    [SerializeField] public Button demolishBtn;

    [SerializeField] public GameObject zonesPanel;
    [SerializeField] public GameObject facilitiesPanel;
    [SerializeField] public GameObject roadsPanel;
    [SerializeField] public Button closeBuildMenuBtn;

    [SerializeField] public GameObject buildButtonPrefab;

    private void Start() {
        cancelActionPanel.SetActive(false);
        buildingMenuPanel.SetActive(false);
        // buildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        confirmActionBtn.onClick.AddListener(OnConfirmCallback);
        cancelActionBtn.onClick.AddListener(OnCancelCallback);
        openBuildMenuBtn.onClick.AddListener(OnOpenBuildMenu);
        demolishBtn.onClick.AddListener(OnDemolishHandler);
        closeBuildMenuBtn.onClick.AddListener(OnCloseMenuHandler);
    }

    private void OnOpenBuildMenu() {
        buildingMenuPanel.SetActive(true);
        PrepareBuildMenu();
    }

    private void PrepareBuildMenu() {
        CreateButtonsInPanel(zonesPanel.transform, structureRepository.GetZoneNames(), OnBuildAreaCallback);
        CreateButtonsInPanel(facilitiesPanel.transform, structureRepository.GetSingleStructureNames(), OnBuildSingleStructureCallback);
        CreateButtonsInPanel(roadsPanel.transform, new List<string>() { structureRepository.GetRoadStructureName() }, OnBuildRoadCallback);
    }

    private void CreateButtonsInPanel(Transform panelTransform, List<string> dataToShow, Action<string> callback) {
        if (dataToShow.Count > panelTransform.childCount) {
            int quantityDiff = dataToShow.Count - panelTransform.childCount;
            for (int i = 0; i < quantityDiff; i++) {
                Instantiate(buildButtonPrefab, panelTransform);
            }
        }

        for (int i = 0; i < panelTransform.childCount; i++) {
            Button button = panelTransform.GetChild(i).GetComponent<Button>();
            if (button != null) {
                button.GetComponentInChildren<TextMeshProUGUI>().text = dataToShow[i];
                button.onClick.AddListener(() => callback(button.GetComponentInChildren<TextMeshProUGUI>().text));
            }
        }
    }

    private void OnBuildAreaCallback(string structureName) {
        PrepareUIForBuilding();
        OnBuildAreaHandler?.Invoke(structureName);
    }

    private void OnBuildSingleStructureCallback(string structureName) {
        PrepareUIForBuilding();
        OnBuildSingleStructureHandler?.Invoke(structureName);
    }

    private void OnBuildRoadCallback(string structureName) {
        PrepareUIForBuilding();
        OnBuildRoadHandler?.Invoke(structureName);
    }

    private void PrepareUIForBuilding() {
        cancelActionPanel.SetActive(true);
        OnCloseMenuHandler();
    }

    private void OnConfirmCallback() {
        cancelActionPanel.SetActive(false);
        OnConfirmHandler?.Invoke();
    }

    private void OnCancelCallback() {
        cancelActionPanel.SetActive(false);
        OnCancelHandler?.Invoke();
    }

    private void OnDemolishHandler() {
        OnDemolishActionHandler?.Invoke();
        cancelActionPanel.SetActive(true);
        OnCloseMenuHandler();
    }

    private void OnCloseMenuHandler() {
        buildingMenuPanel.SetActive(false);
    }

    public void AddListenerOnBuildAreaEvent(Action<string> listener) {
        OnBuildAreaHandler += listener;
    }

    public void RemoveListenerOnBuildAreaEvent(Action<string> listener) {
        OnBuildAreaHandler -= listener;
    }

    public void AddListenerOnBuildSingleStructureEvent(Action<string> listener) {
        OnBuildSingleStructureHandler += listener;
    }

    public void RemoveListenerOnBuildSingleStructureEvent(Action<string> listener) {
        OnBuildSingleStructureHandler -= listener;
    }

    public void AddListenerOnBuildRoadEvent(Action<string> listener) {
        OnBuildRoadHandler += listener;
    }

    public void RemoveListenerOnBuildRoadEvent(Action<string> listener) {
        OnBuildRoadHandler -= listener;
    }

    public void AddListenerOnConfirmEvent(Action listener) {
        OnConfirmHandler += listener;
    }

    public void RemoveListenerOnConfirmEvent(Action listener) {
        OnConfirmHandler -= listener;
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
