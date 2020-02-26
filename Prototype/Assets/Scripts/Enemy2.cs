using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour {

    public int baseHealth;
    public int baseEnergy;
    public int enemyHP;
    public int enemyEnergy;
    public int enemyLevel;
    public int enemyDamage;
    public string type;
    public Text enemyHealthText;
    public Text enemyEnergyText;
    public Text enemyLvl, enemyType, logTxt;
    private int turn = 1;
    public int ignore;
    

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Status", 0);
        enemyHP = baseHealth * enemyLevel;
        enemyEnergy = baseEnergy * enemyLevel;
        PlayerPrefs.SetInt("EnemyHealth", enemyHP);
        enemyLvl.text = "Level: " + enemyLevel.ToString();
        enemyType.text = "Type: " + type.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        // Passes values to text on screen
        enemyHP = PlayerPrefs.GetInt("EnemyHealth");
        turn = PlayerPrefs.GetInt("PlayerTurn");
        enemyHealthText.text = "Health: " + enemyHP.ToString();
        enemyEnergyText.text = "Energy: " + enemyEnergy.ToString();


        Debug.Log(enemyHP);
        //References player to be able to change its health values
        GameObject thePlayer = GameObject.Find("Player2");
        Player2 playerscript = thePlayer.GetComponent<Player2>();
        if (playerscript.playerTurn == false)
        {
            //Decides which attack the enemy uses
            if (PlayerPrefs.GetInt("Status") == 1)
            {
                if (enemyHP < 1000 && enemyEnergy > 30)
                {
                    enemyDamage = (enemyDamage / 5) * 4;
                    Ultimate();
                }

                if (turn == 4 && enemyEnergy > 30)
                {
                    enemyDamage = (enemyDamage / 5) * 4;
                    Special();
                }
                else
                {
                    enemyDamage = (enemyDamage / 5) * 4;
                    Attack();
                }
                
            }
            if (PlayerPrefs.GetInt("Status") == 2)
            {
                Stun();

            }

            if (PlayerPrefs.GetInt("Status") == 0)
            {
                if (enemyHP < 1000 && enemyEnergy > 30)
                {
                    
                    Ultimate();
                }

                if (enemyEnergy > 30)
                {
                    
                    Special();
                }
                else
                {
                    
                    Attack();
                }

            }

        }

        if (PlayerPrefs.GetInt("PlayerHealth") <= 0)
        {
            Destroy(this);
        }

        if (PlayerPrefs.GetInt("EnemyHealth") <= 0)
        {
            Destroy(this);
        }

    }

    private void Attack()
    {
        if (PlayerPrefs.GetInt("Smoke") == 1)
        {
            ignore = Random.Range(1, 11);
            Debug.Log(ignore);
            //If the player blocks or dodges the attack
            if (ignore == 5)
            {
                PlayerPrefs.SetInt("PlayerTurn", 1);
                PlayerPrefs.SetInt("Status", 0);
                logTxt.text = "Player avoided the damage";
                turn++;
                PlayerPrefs.SetInt("Turn", turn);
                PlayerPrefs.SetInt("PlayerTurn", 1);
            }
            else
            {
                GameObject thePlayer = GameObject.Find("Player2");
                Player2 playerscript = thePlayer.GetComponent<Player2>();
                playerscript.playerHP = playerscript.playerHP - enemyDamage;
                playerscript.playerTurn = true;
                PlayerPrefs.SetInt("Status", 0);
                logTxt.text = "Player took " + enemyDamage + " damage";
                PlayerPrefs.SetInt("PlayerHealth", playerscript.playerHP);

                turn++;
                PlayerPrefs.SetInt("Turn", turn);
                PlayerPrefs.SetInt("PlayerTurn", 1);
            }

        }
        else
        {
            // Attacks the player, resets the status effects on itself and ends its turn
            GameObject thePlayer = GameObject.Find("Player2");
            Player2 playerscript = thePlayer.GetComponent<Player2>();
            playerscript.playerHP = playerscript.playerHP - enemyDamage;
            playerscript.playerTurn = true;
            PlayerPrefs.SetInt("Status", 0);
            logTxt.text = "Player took " + enemyDamage + " damage";
            PlayerPrefs.SetInt("PlayerHealth", playerscript.playerHP);
            enemyEnergy = enemyEnergy + 10;
            turn++;
            PlayerPrefs.SetInt("Turn", turn);
            PlayerPrefs.SetInt("PlayerTurn", 1);
        }

    }

    private void Stun()
    {
        GameObject thePlayer = GameObject.Find("Player2");
        Player2 playerscript = thePlayer.GetComponent<Player2>();
        playerscript.playerTurn = true;
        PlayerPrefs.SetInt("PlayerTurn", 1);
        logTxt.text = "Enemy is stunned";
        PlayerPrefs.SetInt("Status", 0);
    }

    private void Special()
    {
        GameObject thePlayer = GameObject.Find("Player2");
        Player2 playerscript = thePlayer.GetComponent<Player2>();
        playerscript.playerHP = playerscript.playerHP - (enemyDamage + 20);
        Debug.Log("Special");
        logTxt.text = "Enemy unleashes a terrible blast dealing " + (enemyDamage+20) + " Damage";
        playerscript.playerTurn = true;
        enemyEnergy = 0;
        PlayerPrefs.SetInt("PlayerHealth", playerscript.playerHP);
        turn++;
    }

    private void Ultimate()
    {
        GameObject thePlayer = GameObject.Find("Player2");
        Player2 playerscript = thePlayer.GetComponent<Player2>();
        playerscript.playerHP = playerscript.playerHP - (enemyDamage * 2);
        logTxt.text = "Enemy unleashes all its remaining energy, dealing " + (enemyDamage * 2) + " Damage";
        playerscript.playerTurn = true;
        enemyEnergy = 0;
        PlayerPrefs.SetInt("PlayerHealth", playerscript.playerHP);
        turn++;
    }
}
