using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{

    [SerializeField]
    private GameObject _normalEnemy;
    [SerializeField]
    private GameObject[] _powerUps;
    [SerializeField]
    private GameObject _Player;
    [SerializeField]
    private float _enemySpawnTimer;
    [SerializeField]
    private float _powerUpSpawnTimer;
    private Player _playerChar;
    private float _nextEnemy = 0.0f;
    private float _nextPowerUp = 0.0f;

    private void Start(){
        
        _playerChar = _Player.GetComponent<Player>();
        _nextPowerUp = Time.time + _powerUpSpawnTimer;

    }

    private void Update(){

        if(GameObject.FindGameObjectWithTag("Player") == null){

            this.gameObject.SetActive(false);

        }

        if(_playerChar.lives > 0 && Time.time > _nextEnemy){

            _nextEnemy = Time.time + _enemySpawnTimer;
            Spawn(_normalEnemy);

        }

        if(_playerChar.lives > 0 && Time.time > _nextPowerUp){

            _nextPowerUp = Time.time + _powerUpSpawnTimer;
            Spawn(_powerUps[Random.Range(0,3)]);

        }

    }

    private void Spawn(GameObject aux){

        Instantiate(aux,new Vector3(Random.Range(-10,10),6.34f,0),Quaternion.identity);

    }

}
