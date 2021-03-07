using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inGameUI;
    public GameObject startMenu;
    public GameObject controls;
    public Slider senseSlider;
    void Start()
    {
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetGame()
    {
        inGameUI.SetActive(false);
        startMenu.SetActive(true);
        controls.SetActive(false);      
    }
    public void startGame()
    {
        inGameUI.SetActive(true);
        startMenu.SetActive(false);
        controls.SetActive(false);
        // wherever actual game loop is
        GameObject.Find("GrappleManager").GetComponent<DrawLines>().setGameStarted(true);
        Time.timeScale = 1.0f; 
    }
    public void showControlMenu()
    {
        inGameUI.SetActive(false);
        startMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void leaveControlMenu()
    {
        inGameUI.SetActive(false);
        startMenu.SetActive(true);
        controls.SetActive(false);       
    }
    public void setGamePaused()
    {
        inGameUI.SetActive(false);
        startMenu.SetActive(true);
        controls.SetActive(false);
        // wherever actual game loop is
        GameObject.Find("GrappleManager").GetComponent<DrawLines>().setGameStarted(false);   
        Time.timeScale = 0.0f;
    }
    public void updateSensitivity()
    {
        GameObject.Find("Main Camera").GetComponent<ActionCameraController>().setSensitivity(senseSlider.value);   
    }
}
