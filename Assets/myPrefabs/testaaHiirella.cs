using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testaaHiirella : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    static Vector3 target1 = new Vector3(137.7f, 10.6f, 56.7f);
    static Vector3 target2 = new Vector3(-57.3f, 10.6f, 185.8f);
    static Vector3 target3 = new Vector3(-166.9f, 10.6f, -83.4f);
    static Vector3 target4 = new Vector3(-85.6f, 1.1f, -149.5f);

    // public GameObject player;
    // public int playerCount = 0;

    static Vector3 currentTarget = target4;
    void Start()
    { 
        // makePlayers(playerCount);
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        SetDestinationToNew();
        // if (Input.GetMouseButtonDown(0))
        // {
        //   SetDestinationToMousePosition();
        // }
    }

    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            myNavMeshAgent.SetDestination(hit.point);
            Debug.Log(hit.point);
        }
    }
    void SetDestinationToNew()
    {
      myNavMeshAgent.SetDestination(currentTarget);    
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "aitrigger1"){
          Debug.Log("TRIGGER1");
          currentTarget = target2;
        }
        if(collider.gameObject.name == "aitrigger2"){
          Debug.Log("TRIGGER2");
          currentTarget = target3;
        }
        if(collider.gameObject.name == "aitrigger3"){
          Debug.Log("TRIGGER3");
          currentTarget = target4;
        }
        if(collider.gameObject.name == "aitrigger4"){
          Debug.Log("TRIGGER4");
          currentTarget = target1;
        }
    }
    // private void makePlayers(int count){
    //   for(int i=0; i < count; i++){
    //     Instantiate(player, new Vector3(-31.7f, 3.5f, 0.2f), Quaternion.identity);
    //   }
    // }
}

