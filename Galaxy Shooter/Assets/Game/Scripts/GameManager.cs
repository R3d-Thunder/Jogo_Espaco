using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver = true;
    public GameObject player;
    public GameObject SpawnManager;
    public GameObject UI;
    private UI_Manager _uiManager;

    private void Start(){

        _uiManager = UI.GetComponent<UI_Manager>();
        _uiManager.UpdateTitleScreen(gameOver);

    }

    private void Update(){

        if (gameOver){

            if(Input.anyKeyDown){

                gameOver = false;
                _uiManager.UpdateTitleScreen(gameOver);
                _uiManager.UpdateScore(4);
                StartCoroutine(Timer());

            }

        }

    }

    public void GameOverSequence(){


        gameOver = true;
        _uiManager.UpdateTitleScreen(gameOver);

    }

    private IEnumerator Timer(){

        yield return new WaitForSeconds(0.5f);
        Instantiate(player,Vector3.zero,Quaternion.identity);
        SpawnManager.SetActive(true);

    }

}
