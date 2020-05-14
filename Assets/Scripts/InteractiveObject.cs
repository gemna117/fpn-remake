using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    protected string displaytext = nameof(InteractiveObject);

    public virtual string Displaytext => displaytext;

    string IInteractive.displayText { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {

        audioSource.Play();
        }
        catch (System.Exception)
        {
            throw new System.Exception("missing audio source component.");
        }
        Debug.Log($"player just interacted with {gameObject.name}.");
    }
}
