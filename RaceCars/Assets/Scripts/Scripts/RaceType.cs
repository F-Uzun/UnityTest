﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceType : MonoBehaviour
{
    public bool TimeTrial = true;
    public float GoldMinutes;
    public float GoldSeconds;
    public float SilverMinutes;
    public float SilverSeconds;
    public float BronzeMinutes;
    public float BronzeSeconds;



    void Start()
    {
        void Start()
        {
            if (TimeTrial == true)
            {
                SaveScript.TimeTrialMinG = GoldMinutes;
                SaveScript.TimeTrialSecondsG = GoldSeconds;
                SaveScript.TimeTrialMinS = SilverMinutes;
                SaveScript.TimeTrialSecondsS = SilverSeconds;
                SaveScript.TimeTrialMinB = BronzeMinutes;
                SaveScript.TimeTrialSecondsB = BronzeSeconds;
            }
        }
    }

    void Update()
    {
        if(SaveScript.RaceOver == true)
        {
            if (TimeTrial == true)
            {

                if ((SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) > 59)
                {
                    SaveScript.PenaltySeconds = (SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) - 59;
                    SaveScript.RaceTimeMinutes++;
                    SaveScript.RaceTimeSeconds = 0 + SaveScript.PenaltySeconds;
                }
                if (SaveScript.RaceTimeMinutes < GoldMinutes)
                {
                    Debug.Log("Gold");
                    SaveScript.Gold = true;
                }
                if (SaveScript.RaceTimeMinutes == GoldMinutes && (SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) <GoldSeconds)
                {
                    Debug.Log("Gold");
                    SaveScript.Gold = true;
                }
                if (SaveScript.RaceTimeMinutes < SilverMinutes)
                {
                    if (SaveScript.Gold == false)
                    {
                        Debug.Log("Silver");
                        SaveScript.Silver = true;
                    }
                }
                if (SaveScript.RaceTimeMinutes == SilverMinutes && (SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) <SilverSeconds)
                {
                    if (SaveScript.Gold == false)
                    {
                        Debug.Log("Silver");
                        SaveScript.Silver = true;
                    }
                }



                if (SaveScript.RaceTimeMinutes < BronzeMinutes)
                {
                    if (SaveScript.Gold == false && SaveScript.Silver == false)
                    {
                        Debug.Log("Bronze");
                        SaveScript.Bronze = true;
                    }
                }
                if (SaveScript.RaceTimeMinutes == BronzeMinutes && (SaveScript.RaceTimeSeconds + SaveScript.PenaltySeconds) <
               BronzeSeconds)
                {
                    if (SaveScript.Gold == false && SaveScript.Silver == false)
                    {
                        Debug.Log("Bronze");
                        SaveScript.Bronze = true;
                    }
                }
                else if (SaveScript.Gold == false && SaveScript.Silver == false && SaveScript.Bronze == false)
                {
                    Debug.Log("Fail");
                    SaveScript.Fail = true;
                }

            }
        }
    }
}