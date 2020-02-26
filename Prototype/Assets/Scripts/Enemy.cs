using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
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
    void Start()
    {
        PlayerPrefs.SetInt("Status", 0);
        enemyHP = baseHealth * enemyLevel;
        enemyEnergy = baseEnergy * enemyLevel;
        PlayerPrefs.SetInt("EnemyHealth", enemyHP);
        enemyLvl.text = "Level: "+ enemyLevel.ToString();
        enemyType.text = "Type: " +type.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Passes values to text on screen
        enemyHealthText.text = "Health: "+enemyHP.ToString();
        enemyEnergyText.text = "Energy: "+enemyEnergy.ToString();
        

        Debug.Log(enemyHP);
        //References player to be able to change its health values
        GameObject thePlayer = GameObject.Find("Player");
        Player playerscript = thePlayer.GetComponent<Player>();
        if (playerscript.playerTurn == false)
        {
            if(PlayerPrefs.GetInt("Status") == 1)
            {

                enemyDamage = (enemyDamage/5) * 4;
                Attack();
            }
            if (PlayerPrefs.GetInt("Status") == 2)
            {
                Stun();
                
            }

            if (PlayerPrefs.GetInt("Status") == 0)
            {
                Attack();
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
        if(PlayerPrefs.GetInt("Smoke") == 1)
        {
            ignore = Random.Range(1, 11);
            Debug.Log(ignore);
            //If the player blocks or dodges the attack
            if (ignore == 5)
            {
                GameObject thePlayer = GameObject.Find("Player");
                Player playerscript = thePlayer.GetComponent<Player>();
                
                playerscript.playerTurn = true;
                PlayerPrefs.SetInt("Status", 0);
                logTxt.text = "Player avoided the damage";
                turn++;
                PlayerPrefs.SetInt("Turn", turn);
                PlayerPrefs.SetInt("PlayerTurn", 1);
            }
            else
            {
                GameObject thePlayer = GameObject.Find("Player");
                Player playerscript = thePlayer.GetComponent<Player>();
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
            GameObject thePlayer = GameObject.Find("Player");
            Player playerscript = thePlayer.GetComponent<Player>();
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

    private void Stun()
    {
        GameObject thePlayer = GameObject.Find("Player");
        Player playerscript = thePlayer.GetComponent<Player>();
        playerscript.playerTurn = true;
        PlayerPrefs.SetInt("PlayerTurn", 1);
        logTxt.text = "Enemy is stunned";
        PlayerPrefs.SetInt("Status", 0);
    }
}
