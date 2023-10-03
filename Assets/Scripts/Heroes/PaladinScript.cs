using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaladinScript : HeroScript //Support Action: +1 Def to party
{
    // Start is called before the first frame update

    public override void Initialize()
    {
        HP = 10;
        Def = 2;
        Spe = 1;
        isPhysical = true;
        Atk = 2;
        supportOn = false;
        heroname = "Paladin";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //(bool, int) AttackAction() {
    //    return (isPhysical, Atk); //pysical attack, 2 pts
    //}
    public override int AttackAction(ref VillainScript enemy, ref List<HeroScript> Party)
    {
        Debug.Log("Paladin's Attack function. Here are the enemies stats before attack:");
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

        Debug.Log("Here are the enemies stats after attack:");
        enemy.PrintName();
        enemy.PrintStats();

        return dmg;
    }
    public override void StartSupport(ref List<HeroScript> Party)
    {
        Debug.Log("PaladinScript Start support");
        supportOn = true;
        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].Def++;
        }
    }

    public override void EndSupport(ref List<HeroScript> Party)
    {
        Debug.Log("PaladinScript End support");
        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].Def--;
        }
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

        Debug.Log("Paladin's SupportAction function. Here is everyone's stats after Paladin has called support:");
        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].PrintName();
            Party[i].PrintStats();
        }
    }

    public override void PrintName()
    {
        Debug.Log("Paladin: ");
    }
    public override int checkType()
    {
        return 0;
    }
}
