using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    
    [SerializeField] Button startgamebtn;
    [SerializeField] Button confirmP1;
    [SerializeField] Button confirmP2;
    [SerializeField] Button confirmE1;

    public Text CurrentSelectionTxt;

    private int player1choice = -1;
    private int player2choice = -1;
    private int enemy1choice = -1;
    private int currentchoice = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateSelectionTxt();
    }

    public void ConfirmP1()
    {
        player1choice = currentchoice;
        confirmP1.gameObject.SetActive(false);
        confirmP2.gameObject.SetActive(true);
    }

    public void ConfirmP2()
    {
        player2choice = currentchoice;
        confirmP2.gameObject.SetActive(false);
        confirmE1.gameObject.SetActive(true);
    }

    public void ConfirmE1()
    {
        enemy1choice = currentchoice;
        confirmE1.gameObject.SetActive(false);
        startgamebtn.gameObject.SetActive(true);
    }

    public void DetectedPaladin()
    {
        currentchoice = 0;
        UpdateSelectionTxt();
    }

    public void DetectedWizard()
    {
        currentchoice = 1;
        UpdateSelectionTxt();
    }

    public void DetectedCleric()
    {
        currentchoice = 2;
        UpdateSelectionTxt();
    }

    public void DetectedRouge()
    {
        currentchoice = 3;
        UpdateSelectionTxt();
    }

    public void DetectedBard()
    {
        currentchoice = 4;
        UpdateSelectionTxt();
    }

    public void DetectedBarbarian()
    {
        currentchoice = 5;
        UpdateSelectionTxt();
    }

    public void DetectedGoblin()
    {
        currentchoice = 0;
        UpdateSelectionTxt();
    }
    public void DetectedGolem()
    {
        currentchoice = 1;
        UpdateSelectionTxt();
    }
    public void DetectedZombie()
    {
        currentchoice = 2;
        UpdateSelectionTxt();
    }
    public void DetectedSpirit()
    {
        currentchoice = 3;
        UpdateSelectionTxt();
    }
    public void DetectedVampire()
    {
        currentchoice = 4;
        UpdateSelectionTxt();
    }
    public void DetectedDragon()
    {
        currentchoice = 5;
        UpdateSelectionTxt();
    }
    

    void UpdateSelectionTxt()
    {
        if(player2choice < 0) {
            switch (currentchoice)
            {
                case 0:
                    CurrentSelectionTxt.text = "Current Selection: Paladin";
                    break;
                case 1:
                    CurrentSelectionTxt.text = "Current Selection: Wizard";
                    break;
                case 2:
                    CurrentSelectionTxt.text = "Current Selection: Cleric";
                    break;
                case 3:
                    CurrentSelectionTxt.text = "Current Selection: Rouge";
                    break;
                case 4:
                    CurrentSelectionTxt.text = "Current Selection: Bard";
                    break;
                case 5:
                    CurrentSelectionTxt.text = "Current Selection: Barbarian";
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch(currentchoice)
            {
                case 0:
                    CurrentSelectionTxt.text = "Current Selection: Goblin";
                    break;
                case 1:
                    CurrentSelectionTxt.text = "Current Selection: Golem";
                    break;
                case 2:
                    CurrentSelectionTxt.text = "Current Selection: Zombie";
                    break;
                case 3:
                    CurrentSelectionTxt.text = "Current Selection: Spirit";
                    break;
                case 4:
                    CurrentSelectionTxt.text = "Current Selection: Vampire";
                    break;
                case 5:
                    CurrentSelectionTxt.text = "Current Selection: Dragon";
                    break;
                default:
                    break;
            }
        }
        
    }





}
