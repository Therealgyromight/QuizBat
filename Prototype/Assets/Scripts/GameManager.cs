using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Button retry, main, attack, next, special, ult;
    public Text lose, win, eHP, eEN, pHP, pEN, eL, pL, eT, pLog, eLog;

    // Use this for initialization
    void Start () {

        lose.gameObject.SetActive(false);
        retry.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerPrefs.GetInt("PlayerHealth") <= 0)
        {
            Lose();
        }

        if (PlayerPrefs.GetInt("EnemyHealth") <= 0)
        {
            Win();
        }
    }

    void Lose()
    {
        // Clears canvas and shows only the relevant buttons and text
        lose.gameObject.SetActive(true);
        retry.gameObject.SetActive(true);
        main.gameObject.SetActive(true);
        attack.gameObject.SetActive(false);
        eHP.gameObject.SetActive(false);
        pHP.gameObject.SetActive(false);
        eEN.gameObject.SetActive(false);
        pEN.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        eL.gameObject.SetActive(false);
        eT.gameObject.SetActive(false);
        eLog.gameObject.SetActive(false);
        pLog.gameObject.SetActive(false);
        pL.gameObject.SetActive(false);
        PlayerPrefs.SetInt("EnemyHealth", 1);
        PlayerPrefs.SetInt("PlayerHealth", 1);
    }

    void Win()
    {
        //Hide the UI elements when you win or lose
        main.gameObject.SetActive(true);
        win.gameObject.SetActive(true);
        attack.gameObject.SetActive(false);
        eHP.gameObject.SetActive(false);
        pHP.gameObject.SetActive(false);
        eEN.gameObject.SetActive(false);
        pEN.gameObject.SetActive(false);
        next.gameObject.SetActive(true);
        retry.gameObject.SetActive(false);
        eL.gameObject.SetActive(false);
        eT.gameObject.SetActive(false);
        eLog.gameObject.SetActive(false);
        pLog.gameObject.SetActive(false);
        pL.gameObject.SetActive(false);
        PlayerPrefs.SetInt("EnemyHealth", 1);
        PlayerPrefs.SetInt("PlayerHealth", 1);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Level", 1);
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(2);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
