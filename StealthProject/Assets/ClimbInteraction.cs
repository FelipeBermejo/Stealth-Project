using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteraction : XRBaseInteractable
{

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;
        base.OnSelectEntered(args);
        if(interactor is XRDirectInteractor)
        {
            PlayerClimber.climbingHand = interactor.GetComponent<ActionBasedController>();
        }
        
    }


    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;
        base.OnSelectExited(args);
        if (PlayerClimber.climbingHand && PlayerClimber.climbingHand.name == interactor.name)
        {
            PlayerClimber.climbingHand = null;
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
