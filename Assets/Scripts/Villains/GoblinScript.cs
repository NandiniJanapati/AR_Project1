using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoblinScript : VillainScript
{
    public override void Initialize()
    {
        HP = 10;
        Atk = 1;
        PDef = 1;
        MDef = 1;
        Spe = 3;
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
        Debug.Log("Goblin");
    }
    public override int checkType()
    {
        return 0;
    }
}
