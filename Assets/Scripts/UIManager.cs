using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    public GameObject gameOver;
    GameManager gm;
    private void Start()
    {
        gm = GameManager.Instance;
        gameOver.SetActive(false);
    }

    public void MainMenu()
    {
        gameOver.SetActive(false);
        startMenuUI.SetActive(true);
    }


    public void PlayButtonHandler()
    {
        gm.StartGame();
        startMenuUI.SetActive(false);
        gameOver.SetActive(false);
        
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}