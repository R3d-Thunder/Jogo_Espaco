using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour{

    [SerializeField]
    private float speed;
    [SerializeField]
    private int id;
    [SerializeField]
    private AudioClip _clip;
    private UI_Manager _uiManager;

    private void Start(){

        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

    }

    private void Update(){

        Movement();

    }

    private void Movement(){

        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -6.4f){

            Destroy(this.gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){

            Player player = other.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip,transform.position);
            
            if(player != null){
                
                switch(id){

                    case 0:
                        
                        player.TripleShotOn();
                        break;
                    case 1:
                        
                        player.SpeedUpOn();
                        break;
                    case 2:
                        
                        player.ShieldOn();
                        break;
                    default:
                        
                        Debug.Log("Id desconhecido!");
                        break;
                    
                }
            
            }

            _uiManager.UpdateScore(3);
            Destroy(this.gameObject);

        }

    }

}
