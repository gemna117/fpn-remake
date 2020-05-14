using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField]
    private DetectLookedAtInteractive detectLookedAtInteractive;

    private IInteractive lookedAtInteractive;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("interact") && detectLookedAtInteractive.LookedAtInteractive != null)
        {
            Debug.Log("player pressed the interact button.");
            detectLookedAtInteractive.LookedAtInteractive.InteractWith();
        }
    }

    private void onlookedatinteractivechanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region event subscription / unsubscription
    private void OnEnable()
    {
        DetectLookedAtInteractive.lookedatinteractivechanged += onlookedatinteractivechanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.lookedatinteractivechanged -= onlookedatinteractivechanged;
    }
    #endregion
}
