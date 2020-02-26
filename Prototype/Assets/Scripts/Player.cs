using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int baseHP;
    public int baseEnergy;
    public int mageHP, thiefHP, fighterHP, mageE, thiefE, fighterE, mageDmg, fighterDmg, thiefDmg;

    public int playerHP;
    public int playerEnergy;
    public int playerLevel;
    public int playerDamage;
    public int playerClass;
    public int playerUlt;
    public bool playerTurn = true;
    public Button button, retryBtn, quitBtn, specialBtn, ultBtn;
    public Text healthText, overTxt;
    public Text energyText;
    public Text pLevel, logTxt;
    public int turn;
    public int maxHp, maxE;
    public int smoke = 0;
    public int chanceCheck;
    public int difHP;
    
    
    

	// Use this for initialization
	void Start () {
        
        PlayerPrefs.SetInt("Smoke", 0);
        PlayerPrefs.SetInt("Turn", 1);
        turn = 1;
        playerLevel = PlayerPrefs.GetInt("Level");
        playerClass = PlayerPrefs.GetInt("Class");
        playerUlt = PlayerPrefs.GetInt("Ultimate");
        pLevel.text = "Level: " + playerLevel.ToString();

        //Assigns health, energy and damage based on the class and custom values
        if(playerClass == 1)
        {
            PlayerPrefs.SetInt("Smoke", 1);
            playerHP = fighterHP * playerLevel;
            playerEnergy = fighterE * playerLevel;
            playerDamage = fighterDmg * playerLevel;
        }

        if (playerClass == 2)
        {
            playerHP = thiefHP * playerLevel;
            playerEnergy = thiefE * playerLevel;
            playerDamage = thiefDmg * playerLevel;
        }

        if (playerClass == 3)
        {
            playerHP = mageHP * playerLevel;
            playerEnergy = mageE * playerLevel;
            playerDamage = mageDmg * playerLevel;
            maxHp = playerHP;
        }

        if (playerEnergy > maxE)
        {
            playerEnergy = maxE;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        // Sets the health and energy 
        
        healthText.text = "Health: " + playerHP.ToString();
        energyText.text = "Energy: " + playerEnergy.ToString();

        // Checks for win and loss


        if(PlayerPrefs.GetInt("PlayerHealth") <= 0)
        {
            
        }

        if(PlayerPrefs.GetInt("EnemyHealth") <= 0)
        {
            
        }
        // Handles energy costs for ultimate and special and clickable buttons
        if (playerClass == 1)
        {
            if (playerTurn == true)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }

            if (playerEnergy < 30 || playerTurn == false)
            {
                specialBtn.interactable = false;
            }
            else
            {
                specialBtn.interactable = true;
            }

            if (playerEnergy < 50 || playerTurn == false)
            {
                ultBtn.interactable = false;
            }
            else
            {
                ultBtn.interactable = true;
            }
        }

        if (playerClass == 2)
        {
            if (playerTurn == true)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }

            if (playerEnergy < 30 || playerTurn == false)
            {
                specialBtn.interactable = false;
            }
            else
            {
                specialBtn.interactable = true;
            }

            if (playerEnergy < 100 || playerTurn == false)
            {
                ultBtn.interactable = false;
            }
            else
            {
                ultBtn.interactable = true;
            }
        }

        if (playerClass == 3)
        {
            if (playerTurn == true)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }

            if (playerEnergy < 35 || playerTurn == false)
            {
                specialBtn.interactable = false;
            }
            else
            {
                specialBtn.interactable = true;
            }

            if (playerEnergy < 100 || playerTurn == false)
            {
                ultBtn.interactable = false;
            }
            else
            {
                ultBtn.interactable = true;
            }
        }
    }

    public void Click()
    {
        // Check which class was picked to determine which attack is called
        if (playerClass == 1)
        {
            // Deal Damage and End player Turn
            GameObject theEnemy = GameObject.Find("Enemy");
            Enemy enemyscript = theEnemy.GetComponent<Enemy>();
            enemyscript.enemyHP = enemyscript.enemyHP - playerDamage;
            PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
            PlayerPrefs.SetInt("PlayerTurn", 0);
            playerEnergy = playerEnergy + 10;
            logTxt.text = "Enemy takes " + playerDamage + " Damage";
            playerTurn = false;
            turn++;
        }

        if (playerClass == 2)
        {
            if(turn == 1)
            {
                GameObject theEnemy = GameObject.Find("Enemy");
                Enemy enemyscript = theEnemy.GetComponent<Enemy>();
                enemyscript.enemyHP = enemyscript.enemyHP - (playerDamage * 3);
                PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
                playerEnergy = playerEnergy + 10;
                logTxt.text = "Enemy takes " + (playerDamage * 3) + " Damage";
                playerTurn = false;
                turn++;
            }
            if(smoke == 1)
            {
                chanceCheck = Random.Range(1, 11);
                if (chanceCheck == 4)
                {
                    GameObject theEnemy = GameObject.Find("Enemy");
                    Enemy enemyscript = theEnemy.GetComponent<Enemy>();
                    enemyscript.enemyHP = enemyscript.enemyHP - (playerDamage * 3);
                    PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
                    playerEnergy = playerEnergy + 10;
                    logTxt.text = "Enemy takes " + (playerDamage * 3) + " Damage";
                    playerTurn = false;
                    turn++;
                }
            }

            if(smoke == 0 && turn != 1)
            {
                GameObject theEnemy = GameObject.Find("Enemy");
                Enemy enemyscript = theEnemy.GetComponent<Enemy>();
                enemyscript.enemyHP = enemyscript.enemyHP - playerDamage;
                PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
                logTxt.text = "Enemy takes " + playerDamage + " Damage";
                playerEnergy = playerEnergy + 10;
                playerTurn = false;
                turn++;
            }
            
        }

        if (playerClass == 3)
        {
            //Deal damage to enemy and regain energy

            GameObject theEnemy = GameObject.Find("Enemy");
            Enemy enemyscript = theEnemy.GetComponent<Enemy>();
            enemyscript.enemyHP = enemyscript.enemyHP - playerDamage;
            PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
            logTxt.text = "Enemy takes " + playerDamage + " Damage";
            playerEnergy = playerEnergy + 25;
            turn++;
            // End player turn
            playerTurn = false;
        }



    }

    public void SpecialAttack()
    {
        if (playerClass == 1)
        {
            GameObject theEnemy = GameObject.Find("Enemy");
            Enemy enemyscript = theEnemy.GetComponent<Enemy>();
            enemyscript.enemyHP = enemyscript.enemyHP - (playerDamage + 40);
            PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
            PlayerPrefs.SetInt("Status", 2);
            playerEnergy = playerEnergy - 30;
            playerTurn = false;
            logTxt.text = "Enemy takes " + (playerDamage + 40) + " Damage";
            turn++;
        }

        if (playerClass == 2)
        {
            GameObject theEnemy = GameObject.Find("Enemy");
            Enemy enemyscript = theEnemy.GetComponent<Enemy>();
            enemyscript.enemyHP = enemyscript.enemyHP - (playerDamage + 40);
            PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
            PlayerPrefs.SetInt("Status", 1);
            playerEnergy = playerEnergy - 30;
            playerTurn = false;
            logTxt.text = "Enemy takes " + (playerDamage + 40) + " Damage";
            turn++;
        }

        if (playerClass == 3)
        {
            GameObject theEnemy = GameObject.Find("Enemy");
            Enemy enemyscript = theEnemy.GetComponent<Enemy>();
            enemyscript.enemyHP = enemyscript.enemyHP - (playerDamage + 40);
            PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
            playerEnergy = playerEnergy - 30;
            playerTurn = false;
            logTxt.text = "Enemy takes " + (playerDamage + 40) + " Damage";
            turn++;
        }
    }

    public void Ultimate()
    {
        if (playerClass == 1)
        {
            if(playerUlt == 1)
            {
                playerHP = playerHP - (playerHP / 4);            
                logTxt.text = "You feel a devilish strenght build within";
                playerDamage = playerDamage * 2;
                playerTurn = false;
                playerEnergy = playerEnergy - 50;
                turn++;
            }
            else
            {
                difHP = maxHp - playerHP;

                GameObject theEnemy = GameObject.Find("Enemy");
                Enemy enemyscript = theEnemy.GetComponent<Enemy>();
                enemyscript.enemyHP = enemyscript.enemyHP - (difHP *2);
                PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
                logTxt.text = "Enemy takes " + (difHP * 2) + " Damage";
                playerTurn = false;
                playerEnergy = playerEnergy - 50;
                turn++;
            }
        }

        if (playerClass == 2)
        {
            if (playerUlt == 1)
            {
                GameObject theEnemy = GameObject.Find("Enemy");
                Enemy enemyscript = theEnemy.GetComponent<Enemy>();
                enemyscript.enemyHP = enemyscript.enemyHP - playerDamage;
                enemyscript.enemyHP = enemyscript.enemyHP - (playerDamage+40);
                enemyscript.enemyHP = enemyscript.enemyHP - (playerDamage+60);
                PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
                logTxt.text = "Enemy takes " + playerDamage + " , " + (playerDamage + 40) + " and " + (playerDamage + 60) + " damage";
                playerEnergy = playerEnergy - 100;
                playerTurn = false;
                turn++;
            }
            else
            {
                smoke = 1;
                PlayerPrefs.SetInt("Smoke", 1);
                playerEnergy = playerEnergy - 100;
                logTxt.text = "Enemy is surrounded by a smokescreen";
                playerTurn = false;
                turn++;
            }
        }

        if (playerClass == 3)
        {
            if (playerUlt == 1)
            {
                GameObject theEnemy = GameObject.Find("Enemy");
                Enemy enemyscript = theEnemy.GetComponent<Enemy>();
                enemyscript.enemyHP = enemyscript.enemyHP - (playerLevel * (playerEnergy/3));
                PlayerPrefs.SetInt("EnemyHealth", enemyscript.enemyHP);
                logTxt.text = "Enemy takes " + (playerLevel * (playerEnergy / 3)) + " Damage";
                playerEnergy = 0;
                playerTurn = false;
                turn++;
            }
            else
            {
                logTxt.text = "Your health is restored";
                playerHP = playerHP + 150;
                
                playerEnergy = 0;
                playerTurn = false;
                turn++;
            }
        }
    }
}
