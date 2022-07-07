using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveControl : MonoBehaviour
{

    public Transform nextTarget;
    public List<Transform> targets;
    public Transform player;
    private NavMeshAgent enemy;
    private int counter = 0;
    private bool detectado = false;
    private bool wallDetect = false;
    private int maxCount;
    public LayerMask layerWall;
    [SerializeField] SceneChange sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        maxCount = targets.Count;
        nextTarget = targets[0];

    }

    // Update is called once per frame
    void Update()
    {
        enemy.destination = nextTarget.position;
        checkTarget();
        checkDetected();
        checkDetectWall();
        

    }


    void checkTarget()
    {
        if (Vector3.Distance(enemy.transform.position, nextTarget.position) < 1f)
        {
            
            if (counter == maxCount - 1)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }
            Debug.Log(counter);
            nextTarget = targets[counter];
        }
        else if (detectado == true && wallDetect == true)
        {
            nextTarget.position = player.position;
        }
    }

    public void SetDetected(bool detect)
    {
        detectado = detect;
    }

    public void checkDetected()
    {
        
        if (detectado)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) < 1.0f)
            {
                sceneChange.PlayerDeath();
            }
        }
        
    }

    public void checkDetectWall()
    {
        RaycastHit raycast;
        
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), player.transform.position - this.transform.position, out raycast, 10000, layerWall))
        {
            
            if(raycast.collider.tag == "Player")
            {                
                wallDetect = true;
                Debug.DrawRay(transform.position + new Vector3(0,1,0) , player.transform.position - this.transform.position, Color.green);
                

            }
            else
            {            
                wallDetect = false;
                Debug.DrawRay(transform.position + new Vector3(0,1,0) , player.transform.position - this.transform.position, Color.red);
                
            }
        }
    }

  

}
