using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("starting point of raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("how far from the raycastOrigin we will search for interactive elements")]
    [SerializeField]
    private float maxRange = 5.0f;

    [SerializeField]
    private LayerMask interactablelayer;

    public static event Action<IInteractive> lookedatinteractivechanged;

    public IInteractive LookedAtInteractive
    {
        get {return lookedAtInteractive; }
        private set
        {
            bool isinteracticechanged = value != lookedAtInteractive;
            if (isinteracticechanged)
            {
            lookedAtInteractive = value;
                    lookedatinteractivechanged.Invoke(lookedAtInteractive);
            }
        }
    }

    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        LookedAtInteractive = getlookedatinteractive();

    }

    private IInteractive getlookedatinteractive()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        if (objectWasDetected)
        {
            //Debug.Log("player is looking at: " + hitInfo.collider.gameObject.name);
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        return interactive;
    }
}
