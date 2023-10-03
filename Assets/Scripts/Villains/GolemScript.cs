using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GolemScript : VillainScript
{
    public override void Initialize()
    {
        HP = 25;
        Atk = 3;
        PDef = 4;
        MDef = 1;
        Spe = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PrintName()
    {
        Debug.Log("Golem");
    }
    public override int checkType()
    {
        return 1;
    }
}
