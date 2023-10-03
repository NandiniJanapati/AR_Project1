using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;


public class HeroScript : MonoBehaviour //hero class
{
    // Start is called before the first frame update
    public int HP = -1;
    public int Def = -1;
    public int Spe = -1;
    public bool isPhysical = false;
    public int Atk = -1;
    public string heroname = "hero";

    //public virtual int supporteffect = 0;

    public bool supportOn = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Initialize()
    {
        HP = -1;
        Def = -1;
        Spe = -1;
        isPhysical = false;
        Atk = -1;
        supportOn = false;
    }

    //public virtual void AttackAction(ref VillainScript enemy, ref List<HeroScript> Party) {

    //    int inflicted_dmg = (isPhysical) ? Atk - enemy.PDef : Atk - enemy.MDef;
    //    if (inflicted_dmg > 0)
    //    {
    //        enemy.HP -= inflicted_dmg;
    //    }

    //    if(supportOn)
    //    {
    //        EndSupport(ref Party);
    //    }

    //    //return (true, -1);
    //}

    public virtual int AttackAction(ref VillainScript enemy, ref List<HeroScript> Party)
    {
        int critroll = UnityEngine.Random.Range(1, 11);
        int inflicted_dmg = (isPhysical) ? Atk - enemy.PDef : Atk - enemy.MDef;
        
        if (critroll == 10)
        {
            inflicted_dmg *= 2;
        }

        if (inflicted_dmg > 0)
        {
            enemy.HP -= inflicted_dmg;
        }

        Spe -= 2;
        return inflicted_dmg;
    }

    //public virtual  (bool, int) AttackAction() //bool: isPhysical attack? true : false
    //{

    //    return (isPhysical, Atk);
    //}

    public virtual void StartSupport(ref List<HeroScript> Party)
    {
        UnityEngine.Debug.Log("HeroScript Start support");
        supportOn = true;
        //supporteffect++;
    }

    public virtual void EndSupport(ref List<HeroScript> Party)
    {
        UnityEngine.Debug.Log("HeroScript End support");
        supportOn = false;
        //supporteffect = 0;
    }

    //public virtual void SupportAction(ref List<HeroScript> Party, ref Queue<Tuple<int, int>> SupportQueue, int turnNumber, int herosIndexInParty) {

    //    StartSupport(ref Party);
    //    Tuple<int, int> supportcall = new Tuple<int, int>(herosIndexInParty, turnNumber);
    //    SupportQueue.Enqueue(supportcall);
    //}

    public virtual void SupportAction(ref List<HeroScript> Party)
    {
        if(supportOn)
        {
            EndSupport(ref Party);
        }
        StartSupport(ref Party);
    }

    public virtual void PrintName()
    {
        UnityEngine.Debug.Log("Hero");
    }

    public virtual int checkType() 
    {
        return -1;
        //hero: -1
        //paladin: 0
        //wizard: 1
        //cleric: 2
        //rouge: 3
        //bard: 4
        //barbarian: 5
    }

    public virtual void PrintStats()
    {
        UnityEngine.Debug.Log("HP: " + HP);
        UnityEngine.Debug.Log("Def: " + Def);
        UnityEngine.Debug.Log("Spe: " + Spe);
        UnityEngine.Debug.Log("Atk: " + Atk);
        UnityEngine.Debug.Log("SA on: " + supportOn);
    }
}
