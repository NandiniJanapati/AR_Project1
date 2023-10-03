using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : HeroScript //Support Action: double attack, -2 HP to party upon calling the support
{
    // Start is called before the first frame update

    public override void Initialize()
    {
        HP = 7;
        Def = 1;
        Spe = 2;
        isPhysical = false;
        Atk = 3;
        supportOn = false;
        heroname = "Wizard";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int AttackAction(ref VillainScript enemy, ref List<HeroScript> Party)
    {
        Debug.Log("Wizard's Attack function. Here are the enemies stats before attack:");
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

    //public override (bool, int) AttackAction()
    //{
    //    return (isPhysical, Atk);
    //}
    public override void StartSupport(ref List<HeroScript> Party)
    {
        Debug.Log("WizardScript Start support");
        supportOn = true;
        Atk += 3; //(effecively doubles base stat)
    }

    public override void EndSupport(ref List<HeroScript> Party)
    {
        Debug.Log("WizardScript End support");
        supportOn = false;
        Atk -= 3; //(removes the buf)
    }
    public override void SupportAction(ref List<HeroScript> Party)
    {
        for (int i = 0;i < Party.Count;i++)
        {
            Party[i].HP -= 2;
        }
        if (supportOn)
        {
            EndSupport(ref Party);
        }
        StartSupport(ref Party);
        Spe -= 2;

        Debug.Log("Wizard's SupportAction function. Here is everyone's stats after Wizard has called support:");
        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].PrintName();
            Party[i].PrintStats();
        }

    }

    public override void PrintName()
    {
        Debug.Log("Wizard: ");
    }

    public override int checkType()
    {
        return 1;
    }
}
