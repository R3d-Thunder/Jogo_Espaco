using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_laser : MonoBehaviour
{
    private float _speed = 7.0f;

    private void Update(){
        
        Movement();
        
    }

    private void Movement(){

        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -5.84f){

            Destroy(this.gameObject);            

        }

    }

}
