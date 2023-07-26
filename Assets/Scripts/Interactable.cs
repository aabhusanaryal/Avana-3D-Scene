using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //interaction message
    public string promptMessage;

    //called from player
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //template fn for subclass
    }
    
}
