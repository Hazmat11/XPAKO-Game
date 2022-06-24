using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int inventoryWidth;
    public int inventoryHeight;
    public InventorySlot[,] inventorySlots;

    private void Start ()
    {
        inventorySlots = new InventorySlot[inventoryWidth, inventoryHeight];
    }

    void SetupUI ()
    {
        
    }
}
