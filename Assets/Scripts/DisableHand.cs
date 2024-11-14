using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableHand : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    private void ShowGrabbingHand(SelectExitEventArgs arg0)
    {
        if (arg0.interactorObject.transform.CompareTag("LeftHand"))
        {
            leftHandModel.SetActive(true);
        }
        else if (arg0.interactorObject.transform.CompareTag("RightHand"))
        {
            rightHandModel.SetActive(true);
        }
    }

    private void HideGrabbingHand(SelectEnterEventArgs arg0)
    {
        if (arg0.interactorObject.transform.CompareTag("LeftHand"))
        {
            leftHandModel.SetActive(false);
        }
        else if (arg0.interactorObject.transform.CompareTag("RightHand"))
        {
            rightHandModel.SetActive(false);
        }
    }
}
