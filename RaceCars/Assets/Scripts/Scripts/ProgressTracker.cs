﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public AudioSource Player;
    private bool IsPlaying = false;
    public int CurrentWP = 0;
    public int ThisWPNumber;
    public int LastWPNumber;



    void Start()
    {
        Player = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;
                Player.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            if (IsPlaying == true)
            {
                IsPlaying = false;
            }
        }
    }

    private void Update()
    {
        if(SaveScript.LapChange == true)
        {
            CurrentWP = 0;
        }


        if (CurrentWP > LastWPNumber)
        {
            StartCoroutine(CheckDirection());
        }
        if(LastWPNumber > ThisWPNumber)
        {
            SaveScript.WrongWay = false;
        }

        if (LastWPNumber < ThisWPNumber)
        {
            SaveScript.WrongWay = true;
        }
    }


    IEnumerator CheckDirection()
    {
        yield return new WaitForSeconds(0.5f);
        ThisWPNumber = LastWPNumber;
    }

}
