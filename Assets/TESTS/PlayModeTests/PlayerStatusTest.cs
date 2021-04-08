using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

[TestFixture]
public class PlayerStatusTest {
    private UIController _uiController;
    private GameManager _gameManagerComponent;

    [SetUp]
    public void Init() {
        GameObject gameManagerObject = new GameObject();
        CameraMovement cameraMovementComponent = gameManagerObject.AddComponent<CameraMovement>();

        _uiController = Substitute.For<UIController>();

        _gameManagerComponent = gameManagerObject.AddComponent<GameManager>();
        _gameManagerComponent.cameraMovement = cameraMovementComponent;
        _gameManagerComponent.uIController = _uiController;
    }

    [UnityTest]
    public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithEnumeratorPasses() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        _gameManagerComponent.State.OnBuildSingleStructure(null);
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(_gameManagerComponent.State is PlayerBuildingSingleStructureState);
    }

    [UnityTest]
    public IEnumerator PlayerStatusPlayerBuildingAreaStateTestWithEnumeratorPasses() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        _gameManagerComponent.State.OnBuildArea(null);
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(_gameManagerComponent.State is PlayerBuildingZoneState);
    }

    [UnityTest]
    public IEnumerator PlayerStatusPlayerBuildingRoadStateTestWithEnumeratorPasses() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        _gameManagerComponent.State.OnBuildRoad(null);
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(_gameManagerComponent.State is PlayerBuildingRoadState);
    }

    [UnityTest]
    public IEnumerator PlayerStatusPlayerRemoveBuildingnStateTestWithEnumeratorPasses() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        _gameManagerComponent.State.OnDemolishAction();
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(_gameManagerComponent.State is PlayerRemoveBuildingState);
    }

    [UnityTest]
    public IEnumerator PlayerStatusPlayerSelectionStateTesttWithEnumeratorPasses() {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Assert.IsTrue(_gameManagerComponent.State is PlayerSelectionState);
    }
}
