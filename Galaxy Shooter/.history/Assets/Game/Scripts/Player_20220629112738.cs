using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    
    public float speed;

    private void Start(){

        UnityEngine.Debug.Log("Hello from: " + name);
        transform.position = new Vector3(0,0,0);

    }

    
    private void Update(){

        transform.Translate(Vector3.right * Time.deltaTime * speed);
        
    }

}
