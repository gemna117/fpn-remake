using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventorymenuitemtoggleprefab;

    [SerializeField]
    private Transform inventorylistcontentarea;

    [SerializeField]
    private Text itemlabeltext;

    [SerializeField]
    private Text arealabeltext;

    private static InventoryMenu instance;
    private CanvasGroup canvasgroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private ToggleGroup togglegroup;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("there is no inventorymenu instance, " + "you're trying to access it. make sure the script is applied");
            return instance;
        }
        private set { instance = value; }
    }

    private bool isvisible => canvasgroup.alpha > 0;

    public void exitmenubuttonclicked()
    {
        hidemenu();
    }

    public void additemtomenu(InventoryObject inventoryobjectoadd)
    {
        GameObject clone = Instantiate(inventorymenuitemtoggleprefab, inventorylistcontentarea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.associatedInventoryobject = inventoryobjectoadd;
    }
    private void hidemenu()
    {
        canvasgroup.alpha = 0;
        canvasgroup.interactable = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        rigidbodyFirstPersonController.enabled = true;
    }

    private void showmenu()
    {
        canvasgroup.alpha = 1;
        canvasgroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void oninventorymenuitemselected(InventoryObject inventoryobjectthatwasselected)
    {
        itemlabeltext.text = inventoryobjectthatwasselected.objectname;
        arealabeltext.text = inventoryobjectthatwasselected.Description;
    }

    private void OnEnable()
    {
        InventoryMenuItemToggle.inventorymenuitemselected += oninventorymenuitemselected;
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.inventorymenuitemselected -= oninventorymenuitemselected;
    }

    private void Update()
    {
        handleinput();
    }

    private void handleinput()
    {
        if (Input.GetButtonDown("Show Inventory")) ;
        if (isvisible)
            hidemenu();
        else
            showmenu();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("");

        canvasgroup = GetComponent<CanvasGroup>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        togglegroup = GetComponentInChildren<ToggleGroup>();
    }

    private void Start()
    {
        hidemenu();
    }

    private IEnumerator waitforaudioclip()
    {
        Debug.Log("");
        yield return new WaitForSeconds(2);
        Debug.Log("");
    }
}
