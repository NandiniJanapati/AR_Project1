using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClericScript : HeroScript //Support Action: +2 HP to party upon calling the support
{
    public override void Initialize()
    {
        HP = 9;
        Def = 2;
        Spe = 1;
        isPhysical = false;
        Atk = 1;
        supportOn = false;
        heroname = "Cleric";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int AttackAction(ref VillainScript enemy, ref List<HeroScript> Party)
    {
        Debug.Log("Cleric's Attack function. Here are the enemies stats before attack:");
        enemy.PrintName();
        enemy.PrintStats();
        int dmg = base.AttackAction(ref enemy, ref Party);
        /*
        //int critroll = UnityEngine.Random.Range(1, 11);
        //int inflicted_dmg = (isPhysical) ? Atk - enemy.PDef : Atk - enemy.MDef;
        //if (critroll == 10)
        //{
        //    inflicted_dmg *= 2;
        //}

        //if (inflicted_dmg > 0)
        //{
        //    enemy.HP -= inflicted_dmg;
        //}
        //if (supportOn)
        //{
        //    EndSupport(ref Party);
        //}
        //Spe -= 2;
        */

        if (supportOn)
        {
            EndSupport(ref Party);
        }
        
        enemy.PrintName();
        enemy.PrintStats();
        return dmg;
    }


    public override void StartSupport(ref List<HeroScript> Party)
    {
        Debug.Log("ClericScript Start support");
        supportOn = true;
        for(int i = 0; i < Party.Count; i++)
        {
            Party[i].HP += 2;
        }
       
    }

    public override void EndSupport(ref List<HeroScript> Party)
    {
        Debug.Log("ClericScript End support");
        supportOn = false;
    }
    public override void SupportAction(ref List<HeroScript> Party)
    {
        
        if (supportOn)
        {
            EndSupport(ref Party);
        }
        StartSupport(ref Party);

        Spe -= 2;

        Debug.Log("Cleric's SupportAction function. Here is everyone's stats after Cleric has called support:");
        for (int i = 0; i< Party.Count; i++)
        {
            Party[i].PrintName();
            Party[i].PrintStats();
        }
        
    }

    public override void PrintName()
    {
        Debug.Log("Cleric");
    }

    public override int checkType()
    {
        return 2;
    }
}
