using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyManager : MonoBehaviour
{
    GameObject key;
    public bool correctKey;
    XRSocketInteractor thisInteractor;
    GameObject thisObject;

    Material snapMaterial;
    [SerializeField] Material correctMaterial;
    [SerializeField] Material wrongMaterial;
    // Start is called before the first frame update
    void Start()
    {
        thisInteractor = GetComponent<XRSocketInteractor>();
        snapMaterial = GetComponent<Material>();
        thisObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckCorrectKey()
    {
        IXRSelectInteractable keyInteracted = thisInteractor.GetOldestInteractableSelected();

        if (this.gameObject.name == "SnapZoneBlueKey")
        {
            if (keyInteracted.transform.name == "BlueKey")
            {
                this.gameObject.GetComponent<MeshRenderer>().material = correctMaterial; 
                correctKey = true;
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().material = wrongMaterial;
                correctKey = false;
            }
        } 
        else if (this.gameObject.name == "SnapZoneRedKey")
        {
            if (keyInteracted.transform.name == "RedKey")
            {
                correctKey = true;
                this.gameObject.GetComponent<MeshRenderer>().material = correctMaterial;
            }
            else
            {
                correctKey = false;
                this.gameObject.GetComponent<MeshRenderer>().material = wrongMaterial;
            }
        } 
        else if (this.gameObject.name == "SnapZoneGreenKey")
        {
            if (keyInteracted.transform.name == "GreenKey")
            {
                correctKey = true;
                this.gameObject.GetComponent<MeshRenderer>().material = correctMaterial;
            }
            else
            {
                correctKey = false;
                this.gameObject.GetComponent<MeshRenderer>().material = wrongMaterial;
            }
        }
    }
}
