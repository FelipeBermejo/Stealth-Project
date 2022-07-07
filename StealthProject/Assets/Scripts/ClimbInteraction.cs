using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteraction : XRBaseInteractable
{


    [SerializeField] ContinuousMoveProviderBase continuousMoveProvider;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;
        base.OnSelectEntered(args);
        if(interactor is XRDirectInteractor)
        {
            PlayerClimber.climbingHand = interactor.GetComponent<ActionBasedController>();
            continuousMoveProvider.useGravity = false;
        }
        
    }


    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;
        base.OnSelectExited(args);
        if (PlayerClimber.climbingHand && PlayerClimber.climbingHand.name == interactor.name)
        {
            PlayerClimber.climbingHand = null;
            continuousMoveProvider.useGravity = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        continuousMoveProvider = GameObject.Find("Locomotion System").GetComponent<ContinuousMoveProviderBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
