using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Porta : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    //this function is where we weill design our interaction using code.
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen",doorOpen);
       

    }
}
