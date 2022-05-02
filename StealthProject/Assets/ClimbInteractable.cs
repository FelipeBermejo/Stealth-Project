using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        Debug.Log("SELECT ENTER");
        if (interactor is XRDirectInteractor)
        {
            Debug.Log("CLIMBING HAND DETECTED");
            Climber.climbingHand = interactor.GetComponent<XRController>();
            Debug.Log(Climber.climbingHand);
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        Debug.Log("SELECT EXIT");
        if (interactor is XRDirectInteractor)
        {
            if (Climber.climbingHand && Climber.climbingHand.name == interactor.name)
            {
                Climber.climbingHand = null;
            }
        }
    }
}