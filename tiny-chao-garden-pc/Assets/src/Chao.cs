using UnityEngine;
using System.Collections;

public class Chao {

    /* ENUM TYPES*/

    private enum ChaoType
    {
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

    private enum Grade
    {
        E,
        D,
        C,
        B,
        A,
        S
    }

    private enum Emotiball 
    { 
        Normal,
        Flame,
        None
    }

    private enum Eyes
    {
        Normal,
        Painful,
        ClosedStraight,
        ClosedHappy,
        ClosedUp,
        Tiny,
        Circles,
        ClosedDown,
        Tiny2,
        HalfClosed,
        Mean,
        GreenChaos,
        BlueChaos,
        YellowChaos
    }

    private enum Mouth
    {
        ToothySmile,
        Open,
        ClosedSmile,
        ClosedFrown,
        OpenSmile,
        OpenFrown,
        ClosedSmile2, // same as ClosedSmile
        Squiggly,
        ToothyFrown,
        ClosedFrown2, // same as ClosedFrown
        WideOpen,
        ClosedFrown3, // same as ClosedFrown
        StraightMoustache,
        SquigglyMoustache1,
        SquigglyMoustache2
    }

    private enum ColourSA2B
    {
        Normal,
        Yellow,
        White,
        Brown,
        SkyBlue,
        Pink,
        Blue,
        Grey,
        Green,
        Red,
        LimeGreen,
        Purple,
        Orange,
        Black
    }

    private enum TextureSA2B 
    {
        None,
        YellowJewel,
        WhiteJewel,
        PinkJewel,
        BlueJewel,
        GreenJewel,
        PurpleJewel,
        SkyBlueJewel,
        RedJewel,
        BlackJewel,
        LimeGreenJewel,
        OrangeJewel,
        Pearl,
        Metal1,
        Metal2,
        Glass,
        Moon
    }

    private enum EggColourSA2B
    {
        Normal,
        YellowMono,
        WhiteMono,
        BrownMono,
        SkyBlueMono,
        PinkMono,
        BlueMono,
        GreyMono,
        GreenMono,
        RedMono,
        LimeGreenMono,
        PurpleMono,
        OrangeMono,
        BlackMono,
        WhiteTwo,
        BrownTwo,
        SkyBlueTwo,
        PinkTwo,
        BlueTwo,
        GreyTwo,
        GreenTwo,
        RedTwo,
        LimeGreenTwo,
        PurpleTwo,
        OrangeTwo,
        BlackTwo,
        NormalShiny,
        YellowShinyMono,
        WhiteShinyMono,
        BrownShinyMono,
        SkyBlueShinyMono,
        PinkShinyMono,
        BlueShinyMono,
        GreyShinyMono,
        GreenShinyMono,
        RedShinyMono,
        LimeGreenShinyMono,
        PurpleShinyMono,
        OrangeShinyMono,
        BlackShinyMono,
        YellowShinyTwo,
        WhiteShinyTwo,
        BrownShinyTwo,
        SkyBlueShinyTwo,
        PinkShinyTwo,
        BlueShinyTwo,
        GreyShinyTwo,
        GreenShinyTwo,
        RedShinyTwo,
        LimeGreenShinyTwo,
        PurpleShinyTwo,
        OrangeShinyTwo,
        BlackShinyTwo,
        GlitchyNormal

    }

    private enum FavouriteFruit
    { 
        RoundFruit1,
        RoundFruit2,
        TriangleFruit1,
        TriangleFruit2,
        SquareFruit1,
        SquareFruit2,
        None1,
        None2
    }


 


    /* GENERAL */
    //GENERAL : basics
    private string name; //0x12 18
    private byte happiness; //0x82 130
    //GENERAL : life
    private short remainingLifespan1; //0x8A 138
    private short remainingLifespan2; //0x8C 140
    private short reincarnations; //0x8E 142
    private ChaoType chaoType; //0x80 128 ChaoType Enum

    /* EVOLUTION */
    //EVOLUTION : transformations
    private float alignment; //0xB0 176 -1 to +1 of hero/dark alignment
    private float runPowerTrans; //0xA8 168
    private float swimFlyTrans; //0xAC 172
    private float transMaginitude; //0xC0 192 0 to 1.2+ visiblity of transformation (increases with food)

    /* STATS */
    //STATS : stat bars
    private byte swimStatBar; //0x20 32
    private byte flyStatBar; //0x21 33
    private byte runStatBar; //0x22 34
    private byte powerStatBar; //0x23 35
    private byte staminaStatBar; //0x24 36
    private byte luckStatBar; //0x25 37
    private byte intelligenceStatBar; //0x26 38
    //STATS : stat grades
    private Grade swimGrade; //0x28 40
    private Grade flyGrade; //0x29 41
    private Grade runGrade; //0x2A 42
    private Grade powerGrade; //0x2B 43
    private Grade staminaGrade; //0x2C 44
    private Grade luckGrade; //0x2D 45
    private Grade intelligenceGrade; //0x2E 46
    //STATS : level
    private byte swimLevel; //0x30 48
    private byte flyLevel; //0x31 49
    private byte runLevel; //0x32 50
    private byte powerLevel; //0x33 51
    private byte staminaLevel; //0x34 52
    private byte luckLevel; //0x35 53
    private byte intelligenceLevel; //0x36 54
    //STATS : stat points
    private short swimStatPoints; //0x38 56 
    private short flyStatPoints; //0x3A 58
    private short runStatPoints; //0x3C 60
    private short powerStatPoints; //0x3E 62
    private short staminaStatPoints; //0x40 64
    private short luckStatPoints; //0x42 66
    private short intelligenceStatPoints; //0x44 68

    /* APPERANCE */
    //APPEARANCE : breed
    private ColourSA2B colour; //0xD8 216
    private bool monotoneFlag; //0xD9 217
    private TextureSA2B texture; //0xDA 218
    private bool shinyFlag; //0xDB 219
    private EggColourSA2B eggColour; //0xDC 220

    //APPERANCE : body shape
    private Eyes eyes; //0xD1 209
    private Mouth mouth; //0xD2 210
    private Emotiball emotiball; //0xD3 211
    private bool hiddenFeetFlag; //0xD6 214

    /* DNA */
    //DNA : grades
    private Grade DNAswim1; //0x494 1172
    private Grade DNAswim2; //0x495 1173
    private Grade DNAfly1; //0x496 1174
    private Grade DNAfly2; //0x497 1175
    private Grade DNArun1; //0x498 1176
    private Grade DNArun2; //0x499 1177
    private Grade DNApower1; // 0x49A 1178
    private Grade DNApower2; //0x49B 1179
    private Grade DNAstamina1; //0x49C 1180
    private Grade DNAstamina2; //0x49D 1181
    private Grade DNAluck1; //0x49E 1182
    private Grade DNAluck2; //0x49F 1183
    private Grade DNAintelligence1; //0x4A0 1184
    private Grade DNAintelligence2; //0x4A1 1185

    //DNA : personality
    private FavouriteFruit DNAfavouriteFruit1; //0x4C6 1222
    private FavouriteFruit DNAfavouriteFruit2; // 0x4C7 1223

    //DNA : appearance
    private ColourSA2B DNAcolour1; //0x4CC 1228
    private ColourSA2B DNAcolour2; //0x3CD 1229
    private bool DNAmonotoneFlag1; //0x4CE 1230
    private bool DNAmonotoneFlag2; //0x4CF 1231
    private bool DNAshinyFlag1; //0x4D2 1234
    private bool DNAshinyFlag2; //0x4D3 1235
    private EggColourSA2B DNAeggColour1; //0x4D4 1236
    private EggColourSA2B DNAeggColour2; //0x4D5 1237



    /* CHARACTER BONDS */
    //BONDS : SA2B
    private byte SonicBond; //0x16C 364
    private byte ShadowBond; //0x172 370
    private byte TailsBond; //0x178 376
    private byte EggmanBond; //0x17E 382
    private byte KnucklesBond; //0x184 388
    private byte RougeBond; //0x18A 394

    //BONDS : SADX
    /* insert bonds for SADX here */


    /* EMOTIONS */
    //EMOTIONS : standard
    private short desireToMate; //0x13A 314
    private short hunger; //0x138 312
    private short sleepiness; //0x134 292
    private short tiredness; //0x136 310


    public Chao() { 
    
    }




}
