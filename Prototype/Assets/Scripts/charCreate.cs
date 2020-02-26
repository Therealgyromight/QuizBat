using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charCreate : MonoBehaviour {

    public Text abilitiesTxt, classTxt, passTxt;
    public int currentClass, ultimate = 0;
    public string password;
    

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Ultimate", 0);
        PlayerPrefs.SetInt("Class", 0);
	}
	
	// Update is called once per frame
	void Update () {
        password = passTxt.text;
        
	}

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Next()
    {
        if (currentClass == 0 || ultimate == 0)
        {

        }

        else
        {
            PlayerPrefs.SetInt("Class", currentClass);
            PlayerPrefs.SetInt("Ultimate", ultimate);

            if(password == "secret")
            {
                PlayerPrefs.SetInt("Level", 4);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
            else
            {
                PlayerPrefs.SetInt("Level", 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
            
        }
    }


    public void Fighter()
    {
        abilitiesTxt.text = "Passive: Has a chance to block enemy attacks                                                                Basic Attack: Deals moderate damage and gains 5 Energy                                             Special Attack: Low damage attack that stuns the enemy for one turn (Costs 30 Energy)                                                             Ultimate: Choose from options A (Cut your health to double your damage to the enemy) or B (Deal Damage based on your missing health) (Costs 50 Energy)";
        classTxt.text = "A brave warrior from a far away land, his quests have earned him a solid reputation and strong sword arm. Equipped with a Sword and Shield.";
        currentClass = 1;
    }

    public void Mage()
    {
        abilitiesTxt.text = "Passive: Once per fight, when an attack would kill you, if you have 50 Energy lose it and regain 30 HP                                        Basic Attack: Regain 20 Energy deals low damage                                                   Special Attack: Launch a fireball dealing heavy damage and burning for 2 turns (Costs 50 Energy)                             Ultimate: Choose from options A (Supernova that does damage the more enrgy you have) or B (A healing spell that restores 150 health but costs 100 energy";
        classTxt.text = "An old man who spent his whole life studying the arcane, his knowledge and his beard are both beyond limit. Equipped with a spellbook and staff";
        currentClass = 3;
    }

    public void Thief()
    {
        abilitiesTxt.text = "Passive: The first attack each combat does triple damage                                      Basic Attack: Deals moderate damage and regains 10 energy                          Special Attack: Moderate damage with a debilitating effect reducing enemy damage (Costs 30 Energy)                    Ultime: Choose from Option A (Unloads all daggers into the enemy, each hit does more damage than the last) or B (Throws a smokescreen giving a chance to dodge attacks and a low chance to trigger the passive on basic attacks)";
        classTxt.text = "A cold blooded assassin making her profit from the misery of others. Equipped with daggers and toxins";
        currentClass = 2;
    }

    public void UltimateA()
    {
        ultimate = 1;
    }

    public void UltimateB ()
    {
        ultimate = 2;
    }
}
