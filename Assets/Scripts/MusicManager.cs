using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxMusicSource;

    public AudioClip positive;
    public AudioClip negative;
    public AudioClip doNotDoThat;
    public AudioClip flipThePage;

    private void Start()
    {
        EventHandler.WaterInteractiveEvent += EventHandler_WaterInteractiveEvent;
        EventHandler.CrowInteractiveEvent += EventHandler_CrowInteractiveEvent;
        EventHandler.SignInteractiveEvent += EventHandler_SignInteractiveEvent;
        EventHandler.TrashBinInteractiveEvent += EventHandler_TrashBinInteractiveEvent;
        EventHandler.SmokeExtinguishInteractiveEvent += EventHandler_SmokeExtinguishInteractiveEvent;
        EventHandler.TouristInteractiveEvent += EventHandler_TouristInteractiveEvent;
        EventHandler.CoinPicked += EventHandler_CoinPicked;
        EventHandler.CharaterFarmInteractiveEvent += EventHandler_CharaterFarmInteractiveEvent;
       


        EventHandler.SmokeHeavyInteractiveEvent += EventHandler_SmokeHeavyInteractiveEvent;


        EventHandler.ClickMusic += EventHandler_ClickMusic;
    }

    private void EventHandler_ClickMusic()
    {
        sfxMusicSource.clip = flipThePage;
        sfxMusicSource.Play();
    }

    private void EventHandler_CharaterFarmInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
    }

    private void EventHandler_CoinPicked()
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
    }

    private void EventHandler_TouristInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
    }

    private void EventHandler_SmokeExtinguishInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
    }

    private void EventHandler_TrashBinInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
    }

    private void EventHandler_SignInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
    }

    private void EventHandler_CrowInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
        EventHandler.CrowInteractiveEvent -= EventHandler_CrowInteractiveEvent;
    }

    private void EventHandler_WaterInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = positive;
        sfxMusicSource.Play();
    }

    private void EventHandler_SmokeHeavyInteractiveEvent(ItemName obj)
    {
        sfxMusicSource.clip = negative;
        sfxMusicSource.Play();
    }

}
