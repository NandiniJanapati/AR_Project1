using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RougeScript : HeroScript //Support Action: +2 Speed to party
{
    public override void Initialize()
    {
        HP = 7;
        Def = 1;
        Spe = 3;
        isPhysical = true;
        Atk = 2;
        supportOn = false;
        heroname = "Rouge";
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
        Debug.Log("Rouge's Attack function. Here are the enemies stats before attack:");

        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].PrintName();
            Party[i].PrintStats();
        }

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
        Debug.Log("Here are the enemies stats after attack:");
        enemy.PrintName();
        enemy.PrintStats();
        return dmg;
    }

    //public override (bool, int) AttackAction()
    //{
    //    return (isPhysical, Atk);
    //}
    public override void StartSupport(ref List<HeroScript> Party)
    {
        Debug.Log("RougeScript Start support");
        supportOn = true;
        for(int i = 0; i < Party.Count; i++)
        {
            Party[i].Spe += 2;
        }
    }

    public override void EndSupport(ref List<HeroScript> Party)
    {
        Debug.Log("RougeScript End support");
        supportOn = false;
        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].Spe -= 2;
        }
    }
    public override void SupportAction(ref List<HeroScript> Party)
    {
        
        if (supportOn)
        {
            EndSupport(ref Party);
        }
        StartSupport(ref Party);
        
        Spe -= 2;

        Debug.Log("Rouge's SupportAction function. Here is everyone's stats after Rouge has called support:");

        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].PrintName();
            Party[i].PrintStats();
        }
    }

    public override void PrintName()
    {
        Debug.Log("Rouge: ");
    }
    public override int checkType()
    {
        return 3;
    }
}
