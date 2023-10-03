using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiritScript : VillainScript
{
    public override void Initialize()
    {
        HP = 15;
        Atk = 2;
        PDef = 2;
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
        Debug.Log("Spirit");
    }
    public override int checkType()
    {
        return 3;
    }
}
