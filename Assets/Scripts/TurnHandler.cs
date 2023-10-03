using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class TurnHandler : MonoBehaviour
{
    private List<HeroScript> Party = new List<HeroScript>();
    private List<VillainScript> Enemies = new List<VillainScript>();
    private bool GameEnd = false;
    private int roundNumber = 0;
    private int currentPlayersTurn = 0;
    
    [SerializeField] GameObject PaladinPreFab, ClericPreFab, WizardPreFab, BardPreFab, BarbarianPreFab, RougePreFab,
                                GoblinPreFab, GolemPreFab, ZombiePreFab, SpiritPreFab, VampirePreFab, DragonPreFab;
    [SerializeField] List<Transform> PlayerTargets;
    [SerializeField] List<Transform> EnemyTargets;

    List<GameObject> playerCharacters = new List<GameObject>();
    List<GameObject> enemyCharacters = new List<GameObject>();
    private int ActionToTake = -1;

    bool isSliding = false;//if a character is moving to it's opponent
    private enum RoundState { HeroesTurn, VillainsTurn, RoundEnd };
    private RoundState currState = RoundState.HeroesTurn;
    private enum GameState { CharSelection, GameInProgress, GameOver};
    private GameState gameState = GameState.CharSelection;


    //--before game starts variables for character selection
    [SerializeField] Button startgamebtn;
    [SerializeField] Button confirmP1;
    [SerializeField] Button confirmP2;
    [SerializeField] Button confirmE1;

    public Text CurrentSelectionTxt;
    //public Text LogTxt;
    [SerializeField] TMP_Text LogTxt;
    private enum Heroes { Paladin = 0, Wizard, Cleric, Rouge, Bard, Barbarian};
    private enum Villains { Goblin = 0, Golem, Zombie, Spirit, Vampire, Dragon};

    private int player1choice = -1;
    private int player2choice = -1;
    private int enemy1choice = -1;
    private int currentchoice = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject player1Character = new GameObject();
        GameObject player2Character = new GameObject();
        GameObject enemy1Character = new GameObject();
        playerCharacters.Add(player1Character);
        playerCharacters.Add(player2Character);
        enemyCharacters.Add(enemy1Character);
        gameState = GameState.CharSelection;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void AttackActionCardPlayed()
    {
        Debug.Log("Attack Card detected");
        ActionToTake = 0;
    }
    
    public void AttackActionCardRemoved()
    {
        Debug.Log("Attack Card lost");
        ActionToTake = -1;
    }

    public void SupportActionCardPlayed()
    {
        Debug.Log("Support Card detected");
        ActionToTake = 1;
    }

    public void SupportActionCardRemoved()
    {
        Debug.Log("Support Card lost");
        ActionToTake = -1;
    }

    public void StartGame()
    {
        Debug.Log("GAME START");
        startgamebtn.gameObject.SetActive(false);
        switch (player1choice)
        {
            case 0:
                playerCharacters[0] = Instantiate(PaladinPreFab, PlayerTargets[0]);
                PaladinScript paladin = playerCharacters[0].GetComponent<PaladinScript>();
                paladin.Initialize();
                Party.Add(paladin);
                break;
            case 1:
                playerCharacters[0] = Instantiate(WizardPreFab, PlayerTargets[0]);
                WizardScript wizard = playerCharacters[0].GetComponent<WizardScript>();
                wizard.Initialize();
                Party.Add(wizard);
                break;
            case 2:
                playerCharacters[0] = Instantiate(ClericPreFab, PlayerTargets[0]);
                ClericScript cleric = playerCharacters[0].GetComponent<ClericScript>();
                cleric.Initialize();
                Party.Add(cleric);
                break;
            case 3:
                playerCharacters[0] = Instantiate(RougePreFab, PlayerTargets[0]);
                RougeScript rouge = playerCharacters[0].GetComponent<RougeScript>();
                rouge.Initialize();
                Party.Add(rouge);
                break;
            case 4:
                playerCharacters[0] = Instantiate(BardPreFab, PlayerTargets[0]);
                BardScript bard = playerCharacters[0].GetComponent<BardScript>();
                bard.Initialize();
                Party.Add(bard);
                break;
            case 5:
                playerCharacters[0] = Instantiate(BarbarianPreFab, PlayerTargets[0]);
                BarbarianScript barbarian = playerCharacters[0].GetComponent<BarbarianScript>();
                barbarian.Initialize();
                Party.Add(barbarian);
                break;
            default:
                break;
        }
        switch (player2choice)
        {
            case 0:
                playerCharacters[1] = Instantiate(PaladinPreFab, PlayerTargets[1]);
                PaladinScript paladin = playerCharacters[1].GetComponent<PaladinScript>();
                paladin.Initialize();
                Party.Add(paladin);
                break;
            case 1:
                playerCharacters[1] = Instantiate(WizardPreFab, PlayerTargets[1]);
                WizardScript wizard = playerCharacters[1].GetComponent<WizardScript>();
                wizard.Initialize();
                Party.Add(wizard);
                break;
            case 2:
                playerCharacters[1] = Instantiate(ClericPreFab, PlayerTargets[1]);
                ClericScript cleric = playerCharacters[1].GetComponent<ClericScript>();
                cleric.Initialize();
                Party.Add(cleric);
                break;
            case 3:
                playerCharacters[1] = Instantiate(RougePreFab, PlayerTargets[1]);
                RougeScript rouge = playerCharacters[1].GetComponent<RougeScript>();
                rouge.Initialize();
                Party.Add(rouge);
                break;
            case 4:
                playerCharacters[1] = Instantiate(BardPreFab, PlayerTargets[1]);
                BardScript bard = playerCharacters[1].GetComponent<BardScript>();
                bard.Initialize();
                Party.Add(bard);
                break;
            case 5:
                playerCharacters[1] = Instantiate(BarbarianPreFab, PlayerTargets[1]);
                BarbarianScript barbarian = playerCharacters[1].GetComponent<BarbarianScript>();
                barbarian.Initialize();
                Party.Add(barbarian);
                break;
            default:
                break;
        }
        switch (enemy1choice)
        {
            case 0:
                enemyCharacters[0] = Instantiate(GoblinPreFab, EnemyTargets[0]);
                GoblinScript goblin = enemyCharacters[0].GetComponent<GoblinScript>();
                goblin.Initialize();
                Enemies.Add(goblin);
                break;
            case 1:
                enemyCharacters[0] = Instantiate(GolemPreFab, EnemyTargets[0]);
                GolemScript golem = enemyCharacters[0].GetComponent<GolemScript>();
                golem.Initialize();
                Enemies.Add(golem);
                break;
            case 2:
                enemyCharacters[0] = Instantiate(ZombiePreFab, EnemyTargets[0]);
                ZombieScript zombie = enemyCharacters[0].GetComponent<ZombieScript>();
                zombie.Initialize();
                Enemies.Add(zombie);
                break;
            case 3:
                enemyCharacters[0] = Instantiate(SpiritPreFab, EnemyTargets[0]);
                SpiritScript spirit = enemyCharacters[0].GetComponent<SpiritScript>();
                spirit.Initialize();
                Enemies.Add(spirit);
                break;
            case 4:
                enemyCharacters[0] = Instantiate(VampirePreFab, EnemyTargets[0]);
                VampireScript vampire = enemyCharacters[0].GetComponent<VampireScript>();
                vampire.Initialize();
                Enemies.Add(vampire);
                break;
            case 5:
                enemyCharacters[0] = Instantiate(DragonPreFab, EnemyTargets[0]);
                DragonScript dragon = enemyCharacters[0].GetComponent<DragonScript>();
                dragon.Initialize();
                Enemies.Add(dragon);
                break;
            default:
                break;
        }
        //PaladinScript paladin = Instantiate(PaladinPreFab, PlayerTargets[0]).GetComponent<PaladinScript>();
        //WizardScript wizard = Instantiate(WizardPreFab, PlayerTargets[1]).GetComponent<WizardScript>();
        //GoblinScript goblin = Instantiate(GoblinPreFab, EnemyTargets[0]).GetComponent<GoblinScript>();
        //paladin.Initialize();
        //wizard.Initialize();
        //goblin.Initialize();
        //Party.Add(paladin);
        //Party.Add(wizard);
        //Enemies.Add(goblin);
        //Round();
        GameEnd = false;
        isSliding = false;
        roundNumber = 0;
        currState = RoundState.HeroesTurn;
        currentPlayersTurn = 0;
        ActionToTake = -1;
        gameState = GameState.GameInProgress;
        StartCoroutine(RoundHandler2());
    }

    bool CheckAllCharactersSpeed()
    {
        for(int i = 0; i < Party.Count; i++)
        {
            if (Party[i].Spe >= 2) //if anyone has more speed left, return true
            {
                return true;
            }
        }
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].Spe >= 2) //if anyone has more speed left, return true
            {
                return true;
            }
        }

        return false; //if no one's speed is enough to play, return false
    }

    bool DeathCheck()
    {
        bool heroesdead = true;
        bool enemiesdead = true;
        for(int i = Party.Count-1; i >= 0; i--)
        {
            if (Party[i].HP > 0)
            {
                heroesdead = false;
            }
            else
            {
                if(i == 0)
                {
                    Debug.Log("Hero 1 died.");
                    Destroy(playerCharacters[i]);
                }
                else
                {
                    Debug.Log("Hero 2 died.");
                    Destroy(playerCharacters[i]);
                }
            }
        }
        for (int i = Enemies.Count - 1; i >= 0; i--)
        {
            if (Enemies[i].HP > 0)
            {
                enemiesdead = false;
            }
            else
            {
                if(i == 0)
                {
                    Debug.Log("Enemy 1 died.");
                    Destroy(enemyCharacters[0]);
                }
            }
        }
        
        return (heroesdead || enemiesdead);
    }
    
    IEnumerator RoundHandler2()
    {
        while (!GameEnd)
        {
            roundNumber++;
            Debug.Log("----------Beginning of Round " + roundNumber + "------------");
            LogTxt.text = "Round " + roundNumber + " Begin";
            yield return new WaitForSeconds(3);
            while (CheckAllCharactersSpeed() && !GameEnd)
            {
                for (int i = 0; i < Party.Count; i++)
                {
                    Debug.Log("Check Speed for Player " + i);
                    if ((Party[i].Spe >= 2) && (Party[i].HP > 0))
                    {
                        Debug.Log("Hero " + i + " passed speed requirement");
                        Debug.Log("Begin Hero" + i + "Turn. Action To Take currently: " + ActionToTake);
                        while (ActionToTake == -1) //no action taken yet
                        {
                            LogTxt.text = "Waiting for " + Party[i].heroname + "to take action";
                            yield return null;
                        }
                        if (ActionToTake == 0) // attack action played
                        {
                            Debug.Log("Action To Take currently: " + ActionToTake + ". Hero " + i + " will attack");
                            LogTxt.text = Party[i].heroname + " Attacks!";
                            isSliding = true;
                            Vector3 original_position = playerCharacters[i].transform.position;
                            bool reachedEnemy = false;
                            bool completedLap = false;
                            Vector3 currentTarget = enemyCharacters[0].transform.position;
                            Vector3 currpos = playerCharacters[i].transform.position;
                            while (!completedLap)
                            {
                                //float distanceToTarget = Vector3.Distance(playerCharacters[i].transform.position, currentTarget);

                                // Check if we've reached the current target
                                //if (distanceToTarget < 0.1f)
                                //{
                                //    currentTarget = original_position;
                                //}
                                playerCharacters[i].transform.position = Vector3.MoveTowards(playerCharacters[i].transform.position, currentTarget, 0.05f);
                                if((currpos == playerCharacters[i].transform.position) && !reachedEnemy)
                                {
                                    reachedEnemy = true;
                                    currentTarget = original_position;
                                    playerCharacters[i].transform.position = Vector3.MoveTowards(playerCharacters[i].transform.position, currentTarget, 0.05f);
                                }
                                else if(currpos == playerCharacters[i].transform.position)
                                {
                                    completedLap = true;
                                }
                                //if(playerCharacters[i].transform.position == original_position)
                                //{
                                //    reachedEnemy = true;
                                //}
                                currpos = playerCharacters[i].transform.position;
                                yield return null;
                            }

                            isSliding = false;
                            VillainScript enemyToAttack = Enemies[0];
                            int dmgTaken = Party[i].AttackAction(ref enemyToAttack, ref Party);
                            LogTxt.text = Party[i].heroname + "delt " + dmgTaken.ToString() + " to the enemy";
                            yield return new WaitForSeconds(3);
                            if ((Party[i].checkType() == 4) && Party[i].supportOn) //checking if the party member is a bard and if thier support is on
                            {
                                enemyToAttack.HP -= 1;
                                dmgTaken++;
                                Debug.Log("enemy took 1 extra damage due to the Bard's support!");
                                LogTxt.text = "enemy took 1 extra damage due to the Bard's support!";
                                yield return new WaitForSeconds(2);
                            }
                            ActionToTake = -1;
                        } //end of attack action played
                        else
                        {
                            Debug.Log("Action To Take currently: " + ActionToTake + ". Hero " + i + " will supprt");
                            LogTxt.text = Party[i].heroname + " calls their support action!";
                            Party[i].SupportAction(ref Party);
                            ActionToTake = -1;
                            yield return new WaitForSeconds(3);
                            if (Party[0].HP <= 0)
                            {
                                LogTxt.text = Party[0].heroname + " died!";
                                yield return new WaitForSeconds(3);
                            }
                            else if (Party[1].HP <= 0)
                            {
                                LogTxt.text = Party[1].heroname + " died!";
                                yield return new WaitForSeconds(3);
                            }
                            
                        }//end of support action played
                        GameEnd = DeathCheck(); //handle enemy death log message in the game end
                    } // end of the hero's turn
                }//end of all hero's turn

                if ((Enemies[0].Spe >= 2) && (Enemies[0].HP > 0))
                {
                    Debug.Log("Begin Villain 1 Turn");
                    int number = UnityEngine.Random.Range(0, Party.Count);
                    if (Party[number].HP <= 0)
                    {
                        if (number == 0) number = 1;
                        else number = 0;
                    }
                    VillainScript villain = Enemies[0];
                    HeroScript hero = Party[number]; //select random hero

                    isSliding = true;
                    Vector3 original_position = enemyCharacters[0].transform.position;
                    bool reachedEnemy = false;
                    bool completedLap = false;
                    Vector3 currentTarget = playerCharacters[number].transform.position;
                    Vector3 currpos = enemyCharacters[0].transform.position;
                    while (!completedLap)
                    {
                        enemyCharacters[0].transform.position = Vector3.MoveTowards(enemyCharacters[0].transform.position, currentTarget, 0.05f);
                        if ((currpos == enemyCharacters[0].transform.position) && !reachedEnemy)
                        {
                            reachedEnemy = true;
                            currentTarget = original_position;
                            enemyCharacters[0].transform.position = Vector3.MoveTowards(enemyCharacters[0].transform.position, currentTarget, 0.05f);
                        }
                        else if (currpos == enemyCharacters[0].transform.position)
                        {
                            completedLap = true;
                        }
                        currpos = enemyCharacters[0].transform.position;
                        yield return null;
                    }
                    isSliding = false;

                    int dmg = villain.Attack(ref hero); //attack random hero
                                              //check which players, if any are still in battle
                    LogTxt.text = "Enemy delt " + dmg + " damage to " + Party[number].heroname;
                    yield return new WaitForSeconds(3);
                    if (Party[0].HP <= 0)
                    {
                        LogTxt.text = Party[0].heroname + " died!";
                        yield return new WaitForSeconds(3);
                    }
                    else if (Party[1].HP <= 0)
                    {
                        LogTxt.text = Party[1].heroname + " died!";
                        yield return new WaitForSeconds(3);
                    }
                    GameEnd = DeathCheck();
                }

            } //end of while someone can play (end of round)

            for (int i = 0; i < Party.Count; i++)
            {
                Party[i].Spe += 2;
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Spe += 2;
            }
            ActionToTake = -1;
        }//end while game is not over
        StartCoroutine(EndGameHandler());
    }

    IEnumerator EndGameHandler()
    {
        while (GameEnd)
        {
            if (Enemies[0].HP <= 0)
            {
                LogTxt.text = "You Won!";
            }
            else
            {
                LogTxt.text = "Game Over";
            }
            yield return null;
        }
    }

    /*
    IEnumerator HeroTurn(int heroindex)
    {
        bool heroesTurn = true;
        Debug.Log("Begin Hero Turn Coroutine. Action To Take currently: " + ActionToTake);
        while (heroesTurn)
        {
            //yield return null; // Wait for a frame
            
            if(ActionToTake > -1) //did user supply an action
            {
                if(ActionToTake == 0)
                {
                    Debug.Log("Action To Take is: " + ActionToTake);
                    VillainScript enemy = Enemies[0];//I'm taking away the child class attributes!
                    Party[heroindex].AttackAction(ref enemy, ref Party);
                    for (int i = 0; i < Party.Count; i++)
                    {
                        Debug.Log("Party["+i+"].checkType(): " + Party[i].checkType());
                        if ((Party[i].checkType() == 4) && Party[i].supportOn) //checking if the party member is a bard and if thier support is on
                        {
                            enemy.HP -= 1;
                        }
                    }

                    Debug.Log("enemy hp: " + enemy.HP);
                }
                else
                {
                    Debug.Log("Action To Take is: " + ActionToTake);
                    Party[heroindex].SupportAction(ref Party);
                }
                heroesTurn = false;
            }
            else
            {
                yield return new WaitForSeconds(3);
            }

        }
        
        yield return null;
    }
    */

    //---------------------character selection functions--------------------------
    public void ConfirmP1()
    {
        player1choice = currentchoice;
        LogTxt.text = "Player 1 selected: " + (Heroes) player1choice;
        currentchoice = 0;
        UpdateSelectionTxt();
        confirmP1.gameObject.SetActive(false);
        confirmP2.gameObject.SetActive(true);
    }

    public void ConfirmP2()
    {
        player2choice = currentchoice;
        LogTxt.text = "Player 2 selected: " + (Heroes) player2choice;
        currentchoice = 0;
        UpdateSelectionTxt();
        confirmP2.gameObject.SetActive(false);
        confirmE1.gameObject.SetActive(true);
    }

    public void ConfirmE1()
    {
        enemy1choice = currentchoice;
        LogTxt.text = "Enemy 1 selected: " + (Villains) enemy1choice;
        //currentchoice = 0;
        //UpdateSelectionTxt();
        CurrentSelectionTxt.text = "";
        confirmE1.gameObject.SetActive(false);
        startgamebtn.gameObject.SetActive(true);
    }

    public void DetectedPaladin()
    {
        if (player1choice == -1 || player2choice == -1)
        {
            currentchoice = 0;
            UpdateSelectionTxt();
        }
    }

    public void DetectedWizard()
    {
        if (player1choice == -1 || player2choice == -1)
        {
            currentchoice = 1;
            UpdateSelectionTxt();
        }
    }

    public void DetectedCleric()
    {
        if (player1choice == -1 || player2choice == -1)
        {
            currentchoice = 2;
            UpdateSelectionTxt();
        }
    }

    public void DetectedRouge()
    {
        if (player1choice == -1 || player2choice == -1)
        {
            currentchoice = 3;
            UpdateSelectionTxt();
        }
    }

    public void DetectedBard()
    {
        if (player1choice == -1 || player2choice == -1)
        {
            currentchoice = 4;
            UpdateSelectionTxt();
        }
    }

    public void DetectedBarbarian()
    {
        if (player1choice == -1 || player2choice == -1)
        {
            currentchoice = 5;
            UpdateSelectionTxt();
        }
    }

    public void DetectedGoblin()
    {
        if(player2choice != -1)
        {
            currentchoice = 0;
            UpdateSelectionTxt();
        }
    }
    public void DetectedGolem()
    {
        if (player2choice != -1)
        {
            currentchoice = 1;
            UpdateSelectionTxt();
        }
    }
    public void DetectedZombie()
    {
        if (player2choice != -1)
        {
            currentchoice = 2;
            UpdateSelectionTxt();
        }
    }
    public void DetectedSpirit()
    {
        if (player2choice != -1)
        {
            currentchoice = 3;
            UpdateSelectionTxt();
        }
    }
    public void DetectedVampire()
    {
        if (player2choice != -1)
        {
            currentchoice = 4;
            UpdateSelectionTxt();
        }
    }
    public void DetectedDragon()
    {
        if (player2choice != -1)
        {
            currentchoice = 5;
            UpdateSelectionTxt();
        }
    }

    void UpdateSelectionTxt()
    {
        if(gameState == GameState.CharSelection)
        {
            if (player2choice < 0)
            {
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
                switch (currentchoice)
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
}
