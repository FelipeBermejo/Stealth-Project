using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerClimber : MonoBehaviour
{

    private CharacterController character;
    public static ActionBasedController climbingHand;
    private ActionBasedContinuousMoveProvider continuousMovement;
    private ActionBasedController previousHand;
    private Vector3 previousPos;
    private Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        //continuousMovement = GetComponent<ActionBasedContinuousMoveProvider>();

        Debug.Log(previousPos);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (climbingHand)
        {
            if (previousHand == null)
            {
                previousHand = climbingHand;
                previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
            }
            if (climbingHand.name != previousHand.name)
            {
                previousHand = climbingHand;
                previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
                Debug.Log("DIFFERENT HAND NOW");
            }
            //continuousMovement.enabled = false;
            Climb();

        }


        void Climb()
        {
            currentVelocity = (climbingHand.positionAction.action.ReadValue<Vector3>() - previousPos) / Time.deltaTime;
            character.Move(transform.rotation * -currentVelocity * Time.deltaTime);

            previousPos = climbingHand.positionAction.action.ReadValue<Vector3>();
        }
    }
}
