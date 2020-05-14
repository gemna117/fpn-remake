using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [SerializeField]
    private InventoryObject key;

    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private bool consumesKey;

    [SerializeField]
    private string lockeddisplaytext = "locked";

    public override string Displaytext => isLocked ? lockeddisplaytext : base.Displaytext;

    //public override string displaytext
    //{
      //get
    //{
      //      string toReturn;
      //if (isLocked)
        //toReturn = hasKey ? $"Use {key.objectName}" : lockeddisplaytext;
      //else
        //toReturn = base.displaytext;
      //      return toReturn;
    //}
    //}

    private bool hasKey => PlayerInventory.inventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen;
    private int shouldOpenAnimParameter = Animator.StringToHash(nameof(shouldOpenAnimParameter));

    public Door()
    {
        displaytext = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        initializedislocked();
    }

    private void initializedislocked()
    {
        if (key != null)
            isLocked = true;

    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (isLocked && !hasKey)
            {

            }
            else
            {
                animator.SetBool(shouldOpenAnimParameter, true);
                displaytext = string.Empty;
                isOpen = true;
                unlockdoor();
            }

            base.InteractWith();

        }
    }

    private void unlockdoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
            PlayerInventory.inventoryObjects.Remove(key);
    }
}
