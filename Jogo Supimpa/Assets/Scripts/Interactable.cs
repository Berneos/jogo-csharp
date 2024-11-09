using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Add or use an InteractionEvent component to this gameobject
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    //This function will be called from our player
    public void BaseInteract()
    {
        if (useEvents)
        
            GetComponent<InteractionEvent>().onInteract.Invoke();
        
        Interact();

    }

    protected virtual void Interact() {
    
        //We wont have any code written in this function
        //This is a template function to be overriden by our subclasses
        
    }
}
