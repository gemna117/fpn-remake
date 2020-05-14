using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryMenuItemToggle : MonoBehaviour
{
    private InventoryObject associatedinventoryobject;

    [SerializeField]
    private Image iconimage;

    public static event Action<InventoryObject> inventorymenuitemselected;
    public InventoryObject associatedInventoryobject
    {
        get { return associatedInventoryobject; }
        set
        {
            associatedInventoryobject = value;
            iconimage.sprite = associatedInventoryobject.Icon;
        }
    }

    public void inventorymenuitemwastoggled(bool ison)
    {
        if (ison)
            inventorymenuitemselected.Invoke(associatedInventoryobject);
        Debug.Log($"toggled: {ison}");
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup togglegroup = GetComponentInChildren<ToggleGroup>();
        toggle.group = togglegroup;
    }
}
