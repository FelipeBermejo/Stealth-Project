using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    //public ActionBasedContinuousMoveProvider continuousMovement;

    void Start()
    {
        character = GetComponent<CharacterController>();
        //continuousMovement = GetComponent<ActionBasedContinuousMoveProvider>();
    }

    void FixedUpdate()
    {
        if (climbingHand)
        {
            //continuousMovement.enabled = false;
            Climb();
        }
        else
        {
            //continuousMovement.enabled = true;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
        Debug.Log("CLIMBING");
        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
