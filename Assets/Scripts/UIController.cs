using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
    private Action OnBuildAreaHandler;
    private Action OnCancelHandler;
    private Action OnDemolishActionHandler;

    [SerializeField] public StructureRepository structureRepository;

    [SerializeField] public Button buildResidentialAreaBtn;

    [SerializeField] public GameObject cancelActionPanel;
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
        CreateButtonsInPanel(zonesPanel.transform, structureRepository.GetZoneNames());
        CreateButtonsInPanel(facilitiesPanel.transform, structureRepository.GetSingleStructureNames());
        CreateButtonsInPanel(roadsPanel.transform, new List<string>() { structureRepository.GetRoadStructureName() });
    }

    private void CreateButtonsInPanel(Transform panelTransform, List<string> dataToShow) {
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
                button.onClick.AddListener(OnBuildAreaCallback);
            }
        }
    }

    private void OnBuildAreaCallback() {
        cancelActionPanel.SetActive(true);
        OnCloseMenuHandler();
        OnBuildAreaHandler?.Invoke();
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
