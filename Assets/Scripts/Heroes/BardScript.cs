using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardScript : HeroScript //Support Action: +2 Speed to party
{
    public override void Initialize()
    {
        HP = 8;
        Def = 2;
        Spe = 2;
        isPhysical = false;
        Atk = 2;
        supportOn = false;
        heroname = "Bard";
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
        Debug.Log("Bard's Attack function. Here are the enemies stats before attack:");
        enemy.PrintName();
        enemy.PrintStats();

        int dmg = base.AttackAction(ref enemy, ref Party);
        
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
        Debug.Log("BardScript Start support");
        supportOn = true;
        for(int i = 0; i < Party.Count; i++)
        {
            Party[i].Spe += 1;
            Party[i].Def += 1;
        }
    }

    public override void EndSupport(ref List<HeroScript> Party)
    {
        Debug.Log("BardScript End support");
        supportOn = false;
        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].Spe -= 1;
            Party[i].Def -= 1;
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

        Debug.Log("Bard's SupportAction function. Here is everyone's stats after Bard has called support:");

        for (int i = 0; i < Party.Count; i++)
        {
            Party[i].PrintName();
            Party[i].PrintStats();
        }

    }

    public override void PrintName()
    {
        Debug.Log("Bard: ");
        
    }

    public override int checkType()
    {
        return 4;
    }
}
