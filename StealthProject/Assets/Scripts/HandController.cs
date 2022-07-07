using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class HandController : MonoBehaviour
{
    [SerializeField] InputActionReference actionGrip;
    [SerializeField] InputActionReference actionTrigger;
    [SerializeField] private Animator handAnimator;

    void Start()
    {
        handAnimator = GetComponent<Animator>();
        actionGrip.action.performed += GripPress;
        actionTrigger.action.performed += TriggerPress;
        

    }

    private void OnDestroy()
    {
        actionGrip.action.performed -= GripPress;
        actionTrigger.action.performed -= TriggerPress;
    }

    private void OnEnable()
    {
        actionGrip.action.performed += GripPress;
        actionTrigger.action.performed += TriggerPress;
    }

    private void OnDisable()
    {
        actionGrip.action.performed -= GripPress;
        actionTrigger.action.performed -= TriggerPress;
    }

    private void Awake()
    {
       
    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
