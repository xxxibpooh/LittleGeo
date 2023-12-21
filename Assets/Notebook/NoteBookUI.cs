using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoteBookUI : MonoBehaviour
{
    public GameObject notebook;

    public GameObject museumPageContent;
    public GameObject mountainPageContent;
    public GameObject farmPageContent;
    public GameObject campingsitePageContent;
    public GameObject lakePageContent;

    public GameObject introPageContent;



    private GameObject currentPage;

    public GameObject museumLock;
    public GameObject mountainLock;
    public GameObject farmLock;
    public GameObject campingsiteLock;
    public GameObject lakeLock;

    public GameObject notebookButton;

    public GameObject campingsitePageButton;
    public GameObject farmPageButton;
    public GameObject mountainPageButton;
    public GameObject lakePageButton;
    public GameObject museumPageButton;

    public Animator redDotAnimatorMuseum;
    public Animator redDotAnimatorMountain;
    public Animator redDotAnimatorLake;
    public Animator redDotAnimatorFarm;
    public Animator redDotAnimatorCampingsite;

    public Animator redDotAnimatorMuseumButton;
    public Animator redDotAnimatorMountainButton;
    public Animator redDotAnimatorLakeButton;
    public Animator redDotAnimatorFarmButton;
    public Animator redDotAnimatorCampingsiteButton;

    public Animator endAnimator;


    public GameObject closeButton;
    public GameObject menuUI;
    public GameObject EndingContinueButton;

    public GameObject endingBackground;
    public GameObject pullOutFire;
    public GameObject heavyFire;



    private bool newMountain;
    private bool newMuseum;
    private bool newFarm;
    private bool newCampingsite;
    private bool newLake;

    private bool firstTimeCloseNotebook = true;
    private bool firstMuseum;

    private bool isHeavyFire;
    private void Awake()
    {
        firstTimeCloseNotebook = true;
        notebook.SetActive(true);
        currentPage = introPageContent;
        currentPage.SetActive(true);
        closeButton.SetActive(true);
        menuUI.SetActive(false);

        notebookButton.SetActive(false);

        museumPageButton.SetActive(false);
        campingsitePageButton.SetActive(false);
        farmPageButton.SetActive(false);
        mountainPageButton.SetActive(false);
        lakePageButton.SetActive(false);

        EndingContinueButton.SetActive(false);

        newMountain = false;
        newMuseum = false;
        newFarm = false;
        newCampingsite = false;
        newLake = false;

        isHeavyFire = false;
    }

    private void Start()
    {
        //解锁noteBook
        EventHandler.ShowMap += OnShowMap;

        //解锁按钮
        EventHandler.CampingsiteSceneUnlock += OnCampingsiteSceneUnlock;
        EventHandler.FarmSceneUnlock += OnFarmSceneUnlock;
        EventHandler.MountainSceneUnlock += OnMountainSceneUnlock;
        EventHandler.LakeSceneUnlock += OnLakeSceneUnlock;

        //解锁内容
        EventHandler.SmokeExtinguishInteractiveEvent += EventHandler_SmokeExtinguishInteractiveEvent;
        EventHandler.SignInteractiveEvent += EventHandler_SignInteractiveEvent;
        EventHandler.CrowInteractiveEvent += EventHandler_CrowInteractiveEvent;
        EventHandler.CoinPicked += EventHandler_CoinPicked;
        EventHandler.TouristInteractiveEvent += EventHandler_TouristInteractiveEvent;

        //Ending
        EventHandler.SmokeHeavyInteractiveEvent += EventHandler_SmokeHeavyInteractiveEvent;
    }



    private void EventHandler_SmokeHeavyInteractiveEvent(ItemName obj)
    {
        isHeavyFire = true;
    }

    public void ShowNoteBook()
    {
        EventHandler.CallClickMusic();
        notebookButton.SetActive(false);
        closeButton.SetActive(true);
        notebook.SetActive(true);
        currentPage = introPageContent;
        currentPage.SetActive(true);

        //redDotAnimator.SetBool("Notification", false);

        if (newMuseum)
        {

            if (firstMuseum)
            {
                museumPageButton.SetActive(true);
                firstMuseum = false;
            }
                
            redDotAnimatorMuseum.SetBool("rb", true);
        }
            
        if (newLake)
            redDotAnimatorLake.SetBool("rb", true);

        if (newMountain)
            redDotAnimatorMountain.SetBool("rb", true);

        if (newFarm)
            redDotAnimatorFarm.SetBool("rb", true);

        if (newCampingsite)
            redDotAnimatorCampingsite.SetBool("rb", true);
                
    }
    public void CloseNotebook()
    {
        if (firstTimeCloseNotebook)
        {
            Debug.Log("111");
            EventHandler.CallPlayerWalk();
            notebookButton.SetActive(true);
            firstTimeCloseNotebook = false;

            currentPage.SetActive(false);
            currentPage = introPageContent;
            notebook.SetActive(false);
            closeButton.SetActive(false);

            menuUI.SetActive(true);

            EventHandler.CallDialogueEnable();


        }
        else
        {
            notebookButton.SetActive(true);
            currentPage.SetActive(false);
            currentPage = introPageContent;
            notebook.SetActive(false);
            closeButton.SetActive(false);
        }   

    }

    private void OnShowMap()
    {
        notebookButton.SetActive(true);
        //redDotAnimator.SetBool("Notification", true);
        redDotAnimatorMuseumButton.SetBool("rb", true);
        newMuseum = true;
        firstMuseum = true;
    }

    private void OnLakeSceneUnlock()
    {
        Debug.Log("解锁湖边场景");
        EventHandler.LakeSceneUnlock-= OnLakeSceneUnlock;

        lakePageButton.SetActive(true);
        //redDotAnimator.SetBool("Notification", true);
        redDotAnimatorLakeButton.SetBool("rb", true);
        newLake = true;
    }

    private void OnMountainSceneUnlock()
    {
        Debug.Log("解锁Hiking场景");
        EventHandler.MountainSceneUnlock-= OnMountainSceneUnlock;

        mountainPageButton.SetActive(true);
        //redDotAnimator.SetBool("Notification", true);
        redDotAnimatorMountainButton.SetBool("rb", true);
        newMountain = true;

    }

    private void OnFarmSceneUnlock()
    {
        Debug.Log("解锁Farm场景");
        EventHandler.FarmSceneUnlock-= OnFarmSceneUnlock;

        farmPageButton.SetActive(true);
        //redDotAnimator.SetBool("Notification", true);
        redDotAnimatorFarmButton.SetBool("rb", true);
        newFarm = true;
    }

    private void OnCampingsiteSceneUnlock()
    {
        Debug.Log("解camping场景");
        EventHandler.CampingsiteSceneUnlock-= OnCampingsiteSceneUnlock;

        campingsitePageButton.SetActive(true);
        //redDotAnimator.SetBool("Notification", true);
        redDotAnimatorCampingsiteButton.SetBool("rb", true);
        newCampingsite = true;
    }

    private void EventHandler_CoinPicked()
    {
        if(farmLock) Destroy(farmLock);
        redDotAnimatorFarmButton.SetBool("rb", true);
        newFarm = true;
        //redDotAnimator.SetBool("Notification", true);
    }

    private void EventHandler_CrowInteractiveEvent(ItemName obj)
    {
        if (mountainLock) Destroy(mountainLock);
        redDotAnimatorMountainButton.SetBool("rb", true);
        newMountain = true;
        //redDotAnimator.SetBool("Notification", true);
    }

    private void EventHandler_SignInteractiveEvent(ItemName obj)
    {
        if(lakeLock) Destroy(lakeLock);
        redDotAnimatorLakeButton.SetBool("rb", true);
        newLake = true;
        //redDotAnimator.SetBool("Notification", true);
    }

    private void EventHandler_SmokeExtinguishInteractiveEvent(ItemName obj)
    {
        if(campingsiteLock) Destroy(campingsiteLock);
        redDotAnimatorCampingsiteButton.SetBool("rb", true);
        newCampingsite = true;
        //redDotAnimator.SetBool("Notification", true);
    }
    private void EventHandler_TouristInteractiveEvent(ItemName obj)
    {
        if (museumLock) Destroy(museumLock);
        redDotAnimatorMuseumButton.SetBool("rb", true);
        newMuseum = true;
    }


    public void MuseumPressed()
    {
        currentPage.SetActive(false);
        currentPage = museumPageContent;
        currentPage.SetActive(true);

        newMuseum = false;
        redDotAnimatorMuseum.SetBool("rb", false);
        redDotAnimatorMuseumButton.SetBool("rb", false);

        EventHandler.CallClickMusic();

    }

    public void MountainPressed()
    {
        currentPage.SetActive(false);
        currentPage = mountainPageContent;
        currentPage.SetActive(true);

        newMountain = false;
        redDotAnimatorMountain.SetBool("rb", false);
        redDotAnimatorMountainButton.SetBool("rb", false);

        EventHandler.CallClickMusic();
    }

    public void FarmPressed()
    {
        currentPage.SetActive(false);
        currentPage = farmPageContent;
        currentPage.SetActive(true);

        newFarm = false;
        redDotAnimatorFarm.SetBool("rb", false);
        redDotAnimatorFarmButton.SetBool("rb", false);

        EventHandler.CallClickMusic();
    }

    public void CampingsitePressed()
    {
        currentPage.SetActive(false);
        currentPage = campingsitePageContent;
        currentPage.SetActive(true);

        newCampingsite = false;
        redDotAnimatorCampingsite.SetBool("rb", false);
        redDotAnimatorCampingsiteButton.SetBool("rb", false);

        EventHandler.CallClickMusic();
    }

    public void LakePressed()
    {
        currentPage.SetActive(false);
        currentPage = lakePageContent;
        currentPage.SetActive(true);

        newLake = false;
        redDotAnimatorLake.SetBool("rb", false);
        redDotAnimatorLakeButton.SetBool("rb", false);

        EventHandler.CallClickMusic();
    }
    public void EndingClicked()
    {
        Debug.Log("点击Ok");

        ShowNoteBook();
        closeButton.SetActive(false);

        endAnimator.SetBool("IsEndClose", true);
        EndingContinueButton.SetActive(true);
    }

    public void EndingContinueClicked()
    {
        endingBackground.SetActive(true);
        EndingContinueButton.SetActive(false);

        if (isHeavyFire)
        {
            if (heavyFire)
                heavyFire.SetActive(true);
            if (pullOutFire)
                pullOutFire.SetActive(false);
        }
        else
        {
            if (heavyFire)
                heavyFire.SetActive(false);
            if (pullOutFire)
                pullOutFire.SetActive(true);
        }
    }
}
