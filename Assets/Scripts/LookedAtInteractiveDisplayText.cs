using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookedAtInteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }
    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null)
            displayText.text = lookedAtInteractive.displayText;
        else
            displayText.text = string.Empty;
    }

    private void onlookedatinteractivechanged(IInteractive newlookedatinteractive)
    {
        lookedAtInteractive = newlookedatinteractive;
        UpdateDisplayText();
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
