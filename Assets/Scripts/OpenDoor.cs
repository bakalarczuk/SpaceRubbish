using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public string boolString = "Open";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleDoorOpen());
    }

    private void ToggleDoorOpen()
    {
        bool isOpen = animator.GetBool(boolString);
        animator.SetBool(boolString, !isOpen);
    }
}
