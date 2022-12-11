using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AstroidSpawner astroidSpawner;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    public void EndGame(){
        astroidSpawner.enabled=false;
        int finalScore=scoreSystem.EndTimer();
        gameOverText.text=$"Your Score: {finalScore}";
        gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain(){
      SceneManager.LoadScene(1);
    }
    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
    }
    public void Continue(){
        AdManager.Instance.ShowAd(this);
        continueButton.interactable=false;
    }

    public void ContinueGame()
    {
        scoreSystem.StartTime();
        player.transform.position=Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity=Vector3.zero;
        astroidSpawner.enabled=true;
        gameOverDisplay.gameObject.SetActive(false);
        
    }
}
