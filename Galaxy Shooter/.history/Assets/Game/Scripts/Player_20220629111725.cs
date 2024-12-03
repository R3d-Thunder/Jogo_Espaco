using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    
    // Start is called before the first frame update
    void Start(){

        UnityEngine.Debug.Log("Hello from: " + name);
        transform.position = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update(){


        
    }

}
