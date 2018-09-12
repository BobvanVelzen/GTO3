using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    Health,
    Attack
}

public enum Modifier
{
    Flat,
    Percentage
}

public class StatModifier : MonoBehaviour {

    public float value = 0;
    public Stat stat;
    public Modifier modifier;

    public StatModifier(float value, Stat stat, Modifier mod)
    {
        this.value = value;
        this.stat = stat;
        this.modifier = mod;
    }
    
}
