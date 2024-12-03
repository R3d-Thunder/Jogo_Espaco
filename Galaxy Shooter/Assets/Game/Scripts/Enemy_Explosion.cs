using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Explosion : MonoBehaviour
{

    void Start(){

        StartCoroutine(Timer());
        
    }

    void Update(){
        
    }

    private IEnumerator Timer(){

        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);

    }

}
