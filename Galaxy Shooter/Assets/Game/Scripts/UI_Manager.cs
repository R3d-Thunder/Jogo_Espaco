using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] uiLives;
    public Image LivesImageDisplay;
    public Text scoreText;
    public GameObject titleScreen;
    public int score;
    
    public void UpdateLives(int currentLives){

        if(currentLives < 4){

            LivesImageDisplay.sprite = uiLives[currentLives];

        }else{

            LivesImageDisplay.sprite = uiLives[3];

        }

    }

    public void UpdateScore(int aux){

        switch(aux){

            case 1:

                score += 100;
                scoreText.text = "Score: " + score;
                break;
            case 2:

                score += 500;
                scoreText.text = "Score: " + score;
                break;
            case 3:

                score += 10;
                scoreText.text = "Score: " + score;
                break;
            case 4:

                score = 0;
                scoreText.text = "Score: " + score; 
                break;
            default:

                break;

        }

    }

    public void UpdateTitleScreen(bool aux){

        titleScreen.SetActive(aux);

    }

}
