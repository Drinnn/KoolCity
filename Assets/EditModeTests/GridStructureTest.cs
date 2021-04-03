using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridStructureTest {
    GridStructure _gridStructure;

    [OneTimeSetUp]
    public void Init() {
        _gridStructure = new GridStructure(3);
    }

    [Test]
    public void CalculateGridPositionPasses() {
        Vector3 mockInputPosition = new Vector3(0, 0, 0);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);

        Assert.AreEqual(Vector3.zero, gridPosition);
    }

    [Test]
    public void CalculateGridPositionFloatPasses() {
        Vector3 mockInputPosition = new Vector3(2.9f, 1.5f, 0f);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);

        Assert.AreEqual(Vector3.zero, gridPosition);
    }

    [Test]
    public void CalculateGridPositionFails() {
        Vector3 mockInputPosition = new Vector3(3.1f, 0, 0);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);

        Assert.AreNotEqual(Vector3.zero, gridPosition);
    }
}