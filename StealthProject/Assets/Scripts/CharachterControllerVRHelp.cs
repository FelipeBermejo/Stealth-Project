using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace UnityEngine.XR.Interaction.Toolkit
{ 

public class CharachterControllerVRHelp : MonoBehaviour
{
    public XROrigin n_XROrigin;
    public CharacterController n_CharacterController;
    public CharacterControllerDriver driver;
    // Start is called before the first frame update
    void Start()
    {
        n_XROrigin = GetComponent<XROrigin>();
        n_CharacterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }

    protected virtual void UpdateCharacterController()
    {
        if (n_XROrigin == null || n_CharacterController == null)
            return;

        var height = Mathf.Clamp(n_XROrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = n_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + n_CharacterController.skinWidth;

        n_CharacterController.height = height;
        n_CharacterController.center = center;
    }
}
}
