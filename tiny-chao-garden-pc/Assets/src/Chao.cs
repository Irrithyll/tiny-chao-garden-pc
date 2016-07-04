using UnityEngine;
using System.Collections;

public class Chao {

    private enum ChaoType{
        Empty,	
        Egg,	
        Child,	
        Good,
        Bad,
        NeutralNormal,	
        HeroNormal,
        DarkNormal,
        NeutralSwim,
        HeroSwim,
        DarkSwim,
        NeutralFly,
        HeroFly,
        DarkFly,
        NeutralRun,
        HeroRun,
        DarkRun,
        NeutralPower,
        HeroPower,
        DarkPower,
        NeutralChaos,
        HeroChaos,
        DarkChaos,
        Tails,
        Knuckles,
        Amy
    }

    //basics
    private string name; //0x12 18
    private byte happiness; //0x82 130
    //life
    private short remainingLifespan1; //0x8A 138
    private short remainingLifespan2; //0x8C 140
    private short reincarnations; //0x8E 142
    private byte chaoType; //0x80 128 ChaoType Enum



    public Chao() { 
    
    }

}
