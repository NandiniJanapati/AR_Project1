using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP { get; set; }
    public int Atk { get; set; }
    public int PDef { get; set; }
    public int MDef { get; set; }
    public int Spe { get; set; }


    public virtual void Initialize()
    {
        HP = -1;
        PDef = -1;
        MDef = -1;
        Spe = -1;
        Atk = -1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Attack(ref HeroScript hero) 
    {
        int inflicted_dmg = Atk - hero.Def;
        if(inflicted_dmg > 0)
        {
            hero.HP -= inflicted_dmg;
        }
        else
        {
            inflicted_dmg = 0;
        }

        Spe -= 2;

        return inflicted_dmg;
    }

    public void PrintStats()
    {
        UnityEngine.Debug.Log("HP: " + HP);
        UnityEngine.Debug.Log("Spe: " + Spe);
        UnityEngine.Debug.Log("Atk: " + Atk);
    }

    public virtual void PrintName()
    {
        UnityEngine.Debug.Log("villain");
    }

    public virtual int checkType()
    {
        return -1;
        //villain: -1
        //goblin: 0
        //golem: 1
        //zombie: 2
        //spirit: 3
        //vampire: 4
        //dragon: 5
    }
}
