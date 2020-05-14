using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [SerializeField]
    private string description;

    [SerializeField]
    private Sprite icon;

    public string objectname => objectName;
    public Sprite Icon => icon;
    public string Description => description;

    private new Renderer renderer;
    private new Collider collider;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }
    public InventoryObject()
    {
        displaytext = $"Take {objectName}";
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.inventoryObjects.Add(this);
        InventoryMenu.Instance.additemtomenu(this);
        GetComponent<Renderer>().enabled = false;
        renderer.enabled = false;
        collider.enabled = false;
        Debug.Log($"inventory object name {InventoryMenu.Instance.name}");
    }
}
