using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{

    private float _speed = 30.0f;

    private void Update(){
        
        Movement();
        
    }

    private void Movement(){

        transform.Translate(Vector3.up * Time.deltaTime * _speed);

        if(transform.position.y > 6.07f){

            Destroy(this.gameObject);            

        }

    }

}
