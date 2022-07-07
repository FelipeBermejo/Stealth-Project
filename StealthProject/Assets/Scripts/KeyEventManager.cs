using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEventManager : MonoBehaviour
{

    [SerializeField] List<KeyManager> keyManagers;
    bool keysOnPlace = false;
    [SerializeField] GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        
        keysOnPlace = true;
        foreach (KeyManager key in keyManagers)
        {
            if (key.correctKey == false)
            {
                keysOnPlace = false;
            }
        }

        if (keysOnPlace == true)
        {
            Debug.Log("Todas las llaves en su sitio");
            door.SetActive(false);
        } else
        {
            Debug.Log("Todavía faltan llaves");
        }
    }
}
