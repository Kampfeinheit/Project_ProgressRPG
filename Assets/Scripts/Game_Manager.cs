using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BreakInfinity;

public class Game_Manager : MonoBehaviour
{
    public Game_Data data;
    public TMP_Text DamageText;


    public void Start()
    {
        data = new Game_Data();
        data.Damages = 1;
    }



    public void Update()
    {
        DamageText.text = "Damages : " + data.Damages;
        data.Damages = BigDouble.Pow(10, 550000);
        
    }



    public void AttackDamages()
    {
        data.Damages += 1;
    }

}
