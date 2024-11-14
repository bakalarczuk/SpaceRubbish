using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{
    public ParticleSystem laser;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10;

    private bool rayActive = false;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(Shoot);
        grabInteractable.deactivated.AddListener(StopShoot);
    }

    private void StopShoot(DeactivateEventArgs arg0)
    {
        laser.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActive = false;
    }

    private void Shoot(ActivateEventArgs arg0)
    {
        laser.Play();
        rayActive = true;
    }

    private void Update()
    {
        if (rayActive)
        {
            RaycastCheck();
        }
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);

        if (hasHit)
        {
            hit.transform.gameObject.SendMessage("Destruction", SendMessageOptions.DontRequireReceiver);
        }
    }
}
