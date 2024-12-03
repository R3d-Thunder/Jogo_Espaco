using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public bool tripleShot;
    public bool speedUp;
    public bool ShieldPowerup;
    public int lives;

    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _powerUpDuration;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _doubleLaserPrefab;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _Shield;
    [SerializeField]
    private GameObject _EngineRight;
    [SerializeField]
    private GameObject _EngineLeft;
    [SerializeField]
    private AudioClip _clip;
    private UI_Manager _uiManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;
    private bool _canMove = true;
    private bool _Invu = false;
    private float _nextFire = 0.0f;


    private void Start(){

        transform.position = new Vector3(0,-2.585f,0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();

    }

    
    private void Update(){
        
        if(_canMove){
            
            if(speedUp){
        
                Movement(1.5f);
        
            }else{

                Movement(1);

            }
        
        }
        
        if(tripleShot){
        
            TripleShooting();
        
        }else{

            Shooting();

        }

        _uiManager.UpdateLives(lives);

    }

    private void Movement(float mod){

        PlayerMovement(mod);

        if (transform.position.y > 0){

            transform.position = new Vector3(transform.position.x, 0, 0);

        }else if(transform.position.y < -5.17f){

            transform.position = new Vector3(transform.position.x, -5.17f, 0);

        }

        if(transform.position.x > 10.9f){

            transform.position = new Vector3(-10.9f, transform.position.y, 0);

        }else if(transform.position.x < -10.9f){

            transform.position = new Vector3(10.9f, transform.position.y, 0);

        }

    }

    private void PlayerMovement(float mod){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * _speed * mod * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * mod * verticalInput);

    }

    private void Shooting(){

        if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > _nextFire){
            
            _nextFire = Time.time + fireRate;
            _audioSource.Play();
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.77f, 0), Quaternion.identity);

        }

    }

    private void TripleShooting(){

        if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > _nextFire){
            
            _nextFire = Time.time + fireRate;
            _audioSource.Play();
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.77f, 0), Quaternion.identity);
            Instantiate(_doubleLaserPrefab, transform.position + new Vector3(0, -0.19f, 0), Quaternion.identity);

        }

    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Enemy" || other.tag == "Enemy_Laser"){

            if(ShieldPowerup){

                ShieldPowerup = false;
                _Shield.SetActive(false);
                StartCoroutine(Invunerable());

            }else{

                if(other.tag == "Enemy_Laser"){

                    Destroy(other.gameObject);

                }

                if(_Invu == false){

                    lives--;
                    AudioSource.PlayClipAtPoint(_clip,transform.position,1.0f);
                    StartCoroutine(Invunerable());

                }
            
            } 

            if(lives <= 0){

                _canMove = false;
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                StartCoroutine(ExplosionTimer());

            }

        }

    }

    public void TripleShotOn(){

        tripleShot = true;
        StartCoroutine(TripleShotCooldown());

    }

    public void SpeedUpOn(){

        speedUp = true;
        StartCoroutine(SpeedUpCooldown());

    }

    public void ShieldOn(){

        ShieldPowerup = true;
        _Shield.SetActive(true);

    }
    public IEnumerator TripleShotCooldown(){

        yield return new WaitForSeconds(_powerUpDuration);
        tripleShot = false;

    }

    public IEnumerator SpeedUpCooldown(){

        yield return new WaitForSeconds(_powerUpDuration);
        speedUp = false;

    }

    private IEnumerator Invunerable(){

        _Invu = true;
        _EngineRight.SetActive(true);
        _EngineLeft.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        _EngineRight.SetActive(false);
        _EngineLeft.SetActive(false);
        _Invu = false;

    }

    private IEnumerator ExplosionTimer(){

        yield return new WaitForSeconds(0.5f);
        _gameManager.GameOverSequence();
        Destroy(this.gameObject);

    }

}
