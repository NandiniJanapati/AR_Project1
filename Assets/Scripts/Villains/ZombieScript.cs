using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieScript : VillainScript
{
    // Start is called before the first frame update
    public override void Initialize()
    {
        HP = 10;
        Atk = 2;
        PDef = 2;
        MDef = 2;
        Spe = 1;
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PrintName()
    {
        Debug.Log("Zombie");
    }

    public override int checkType()
    {
        return 2;
    }
}
