using UnityEngine;

[CreateAssetMenu(fileName = "New Facility", menuName = "Structure Data/Facility")]
public class SingleFacilitySO : SingleStructureBaseSO {
    public int maxCustomers;
    public float upkeepPerCustomer;
}
