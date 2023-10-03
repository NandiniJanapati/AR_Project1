using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VampireScript : VillainScript
{
    public override void Initialize()
    {
        HP = 20;
        Atk = 3;
        PDef = 3;
        MDef = 3;
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
        Debug.Log("Vampire");
    }
    public override int checkType()
    {
        return 4;
    }
}
