using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerStatusTest {
    private UIController _uiController;
    private GameManager _gameManagerComponent;

    [SetUp]
    public void Init() {
        GameObject gameManagerObject = new GameObject();
        CameraMovement cameraMovementComponent = gameManagerObject.AddComponent<CameraMovement>();

        _uiController = gameManagerObject.AddComponent<UIController>();
        GameObject buildBtnObject = new GameObject();
        GameObject cancelBtnObject = new GameObject();
        GameObject cancelPanel = new GameObject();
        _uiController.cancelActionBtn = cancelBtnObject.AddComponent<Button>();
        var buildComponentBtn = buildBtnObject.AddComponent<Button>();
        _uiController.buildResidentialAreaBtn = buildComponentBtn;
        _uiController.cancelActionPanel = cancelPanel;

        _uiController.buildingMenuPanel = cancelPanel;
        _uiController.openBuildMenuBtn = _uiController.cancelActionBtn;
        _uiController.demolishBtn = _uiController.cancelActionBtn;

        _gameManagerComponent = gameManagerObject.AddComponent<GameManager>();
        _gameManagerComponent.cameraMovement = cameraMovementComponent;
        _gameManagerComponent.uIController = _uiController;
    }

    [UnityTest]
    public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithEnumeratorPasses() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        _uiController.buildResidentialAreaBtn.onClick.Invoke();
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(_gameManagerComponent.State is PlayerBuildingSingleStructureState);
    }

    [UnityTest]
    public IEnumerator PlayerStatusPlayerSelectionStateTesttWithEnumeratorPasses() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(_gameManagerComponent.State is PlayerSelectionState);
    }
}
