using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianScript : HeroScript //Support Action: 2x attack -2 Def
{
    public override void Initialize()
    {
        HP = 8;
        Def = 1;
        Spe = 2;
        isPhysical = true;
        Atk = 3;
        supportOn = false;
        heroname = "Barbarian";
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
        Debug.Log("Barbarian's Attack function. Here are the enemies stats before attack:");
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
        Debug.Log("BarbarianScript Start support");
        supportOn = true;
        Atk += 3; //effectively doubles attack
        Def -= 2;
    }

    public override void EndSupport(ref List<HeroScript> Party)
    {
        Debug.Log("BarbarianScript End support");
       
        //supporteffect = 0; //idk assert that supporteffect dropped to 0
        supportOn = false;
        Atk -= 3;
        Def += 2;

    }
    public override void SupportAction(ref List<HeroScript> Party)
    {
        
        if (supportOn)
        {
            EndSupport(ref Party);
        }
        StartSupport(ref Party);
        Spe -= 2;

        Debug.Log("Barbarian's SupportAction function. Here is everyone's stats after Barbarian has called support:");
        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].PrintName();
            Party[i].PrintStats();
        }

    }

    public override void PrintName()
    {
        Debug.Log("Barbarian: ");
    }

    public override int checkType()
    {
        return 5;
    }
}
