using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonScript : VillainScript
{
    public override void Initialize()
    {
        HP = 30;
        Atk = 4;
        PDef = 3;
        MDef = 3;
        Spe = 2;
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
        Debug.Log("Dragon");
    }
    public override int checkType()
    {
        return 5;
    }
}
