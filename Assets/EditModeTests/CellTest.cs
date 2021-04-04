using System;
using NUnit.Framework;
using UnityEngine;

public class CellTest {
    [Test]
    public void CellSetGameObjectPasses() {
        Cell cell = new Cell();

        cell.SetConstruction(new GameObject());

        Assert.IsTrue(cell.IsTaken);
    }

    [Test]
    public void CellSetGameObjectNullFails() {
        Cell cell = new Cell();

        cell.SetConstruction(null);

        Assert.IsFalse(cell.IsTaken);
    }
}
