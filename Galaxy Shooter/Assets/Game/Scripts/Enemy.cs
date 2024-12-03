using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _thrusterRight;
    [SerializeField]
    private GameObject _thrusterLeft;
    private UI_Manager _uiManager;
    private float _nextFire = 0.0f;
    private bool _move = false;
    private bool _aux = true;
    private float _limiter;

    private void Start(){

        _limiter = 3.0f;
        transform.position = new Vector3(Random.Range(-10,10),6.34f,0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        
    }

    private void Update(){
        
        Movement();

    }

    private void Movement(){

        if(transform.position.y > _limiter){

            _thrusterLeft.SetActive(true);
            _thrusterRight.SetActive(true);
            transform.Translate(Vector3.down * Time.deltaTime * _speed);

        }else if(_aux == true){

            _thrusterLeft.SetActive(false);
            _thrusterRight.SetActive(false);
            StartCoroutine(MovementCooldown());

        }
 
        if(transform.position.y > -6.34f && transform.position.y <= _limiter && _move == true){

            _thrusterLeft.SetActive(true);
            _thrusterRight.SetActive(true);
            transform.Translate(Vector3.down * Time.deltaTime * _speed * 2.0f);

        }else if(_move == true){

            if(GameObject.FindGameObjectWithTag("Player") == null){

                Destroy(this.gameObject);

            }
            
            _move = false;
            _aux = true;
            //_limiter = Random.Range(1,3);
            transform.position = new Vector3(Random.Range(-10,10),6.34f,0);

        }

        Shooting();

    }
    private void Shooting(){

        if(_aux == false && _move == false && Time.time > _nextFire){
            
            _nextFire = Time.time + fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);

        }

    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player_Laser" || other.tag == "Player"){

            _uiManager.UpdateScore(1);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }

    }

    private IEnumerator MovementCooldown(){

        _aux = false;
        yield return new WaitForSeconds(_timer);
        _move = true;

    }

}
