﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private        Inventory        theInventory        = null; // Inventory.cs
    [SerializeField] private        GameObject       clickerMinigame     = null;
    [SerializeField] private        GameObject       tearPictureMinigame = null;
    [SerializeField] private        GameObject       mainCam             = null;
    [SerializeField] private        GameObject       secCam              = null;
    [SerializeField] private        GameObject       player              = null;
    [SerializeField] private        Slider           slider              = null; // 볼륨 조절 용
    [SerializeField] private        GameObject       virtualPad          = null; // 멀티 플렛폼 용도 (PC버전에서는 가상패드 불필요)
                     public  static UIManager        UM                  = null;
                     private        ChallengeManager challengeManager    = null;
                     private        GameManager      gameManager         = null;
                     private        AudioSource      clip                = null;
   

    void Awake() => UM = this;

    private void Start()
    {
        challengeManager = ChallengeManager.Instance;
        gameManager = GameManager.Instance;

        clip = GetComponent<AudioSource>();
        slider.maxValue = 1.0f;
        slider.minValue = 0f;
        slider.value    = 0.2f;

        // 놀랍게도 멀티플레폼용 코드
#if UNITY_STANDALONE
        virtualPad.gameObject.SetActive(false);
#endif

    }

    private void Update()
    {
        // 볼륨 조정 용
        clip.volume = slider.value;
    }


    //변수 선언
    public string curBtn; // awl = 송곳, Thur = 츄르, Cat_01 = 고양이1, Cat_02 = 고양이2, EmptyBox = 빈상자, Clicker = 클리커미니게임


    bool active;
    Item item;
    public Button interactionBtn;

    public void SetInteractionBtn(string index, bool _active, Item _item)
    {
        curBtn = index;
        active = _active;
        item = _item;
        interactionBtn.GetComponent<Button>().interactable = active;
    }

    public void SetInteractionBtn(string index, bool _active)
    {
        curBtn = index;
        active = _active;
        interactionBtn.GetComponent<Button>().interactable = active;
    }

    public void ClickInteractionBtn()
    {
        switch (curBtn)
        {
            case "Awl":
                theInventory.AcquireItem(item);
                dialog.instance.DialogStart(1);
                GameObject.Find("Awl").SetActive(false);
                return;

            case "Thur":
                theInventory.AcquireItem(item);
                dialog.instance.DialogStart(2);
                GameObject.Find("Thur").SetActive(false);
                return;

            case "Cat_01":
                if (theInventory.UseItem("Thur"))
                {
                    dialog.instance.DialogStart(3);
                    theInventory.AcquireItem(item);
                    GameObject.Find("Cat_01").SetActive(false);
                }
                else
                {
                    dialog.instance.DialogStart(4);
                }
                return;

            case "Cat_02":
                dialog.instance.DialogStart(5);
                return;

            case "EmptyBox":
                dialog.instance.DialogStart(0);
                return;

            case "Clicker":
                if (FindObjectOfType<ClickerManager>() == null) // 임시 나중에 코드정리해둘것
                {
                    Instantiate(clickerMinigame);
                    GameObject.Find("Box_Clicker").transform.GetChild(0).gameObject.SetActive(true);
                }
                return;

            case "FloorStairs_01":
                secCam.SetActive(true);
                mainCam.SetActive(false);
                player.transform.position = new Vector3(1.5f, 13.0f, player.transform.position.z);
                return;

            case "FloorStairs_02":
                mainCam.SetActive(true);
                secCam.SetActive(false);
                player.transform.position = new Vector3(-1.5f, 3.0f, player.transform.position.z);
                return;

            case "Window":
                if (gameManager.GetIsPhotoDone())
                {
                    gameManager.SetGameClear(true);
                    gameManager.SetIsPhotoDone(false);
                }
                return;

            case "Photo":
                #region 에러가 난 이유(추측)
                // 고양이를 먹었을 경우에는 theInventory.UseItem("Cat_01")가 실행 된 후 theInventory.UseItem("Awl")에서 에러가
                // 발생하므로 문제없이 작동이 됨. 그러나 송곳을 먹은 경우 theInventory.UseItem("Cat_01")에서 에러가 발생하여
                // theInventory.UseItem("Awl")가 실행되지 않음. 
                // 그래서 theInventory.UseItem()에서 null 에러가 생기는 것을 방지함.
                #endregion
                if (theInventory.UseItem("Cat_01"))  
                {
                    challengeManager.SetChallenge1(true); // 고양이로 클리어시 업적 잠금해제
                    GameObject.Find("Box_Photo").transform.GetChild(0).gameObject.SetActive(true);
                    gameManager.SetIsPhotoDone(true);
                    Instantiate(tearPictureMinigame);
                }
                if (theInventory.UseItem("Awl"))
                {
                    GameObject.Find("Box_Photo").transform.GetChild(0).gameObject.SetActive(true);
                    gameManager.SetIsPhotoDone(true);
                    Instantiate(tearPictureMinigame);
                }
                return;

            case "Door_01":
                return;


        }

        #region 승핵이의 만행
#if false
        // 송곳
        if (curBtn == "Awl")
        {
            theInventory.AcquireItem(item);
            GameObject.Find("Awl").SetActive(false);
        }

        // 츄르
        else if (curBtn == "Thur")
        {
            theInventory.AcquireItem(item);
            GameObject.Find("Thur").SetActive(false);
        }

        // 고양이1
        else if (curBtn == "Cat_01")
        {
            if (theInventory.UseItem("Thur"))
            {
                theInventory.AcquireItem(item);
                GameObject.Find("Cat_01").SetActive(false);
            }
        
        }

        // 고양이2
        else if (curBtn == "Cat_02")
        {
            //냐옹 냐옹
        }

        //빈 박스
        else if (curBtn == "EmptyBox")
        {
            //이 상자는 비어있다.
        }

        // 클리커 미니게임
        else if(curBtn == "Clicker")
        {
            Instantiate(clickerMinigame);
        }

        //1층계단 ( 올라감)
        else if (curBtn == "FloorStairs_01")
        {
            secCam.SetActive(true);
            mainCam.SetActive(false);
            
            player.transform.position = new Vector3(1.5f, 13.0f, player.transform.position.z);
        }
        //2층계단 (내려가기)
        else if (curBtn == "FloorStairs_02")
        {
            mainCam.SetActive(true);
            secCam.SetActive(false);

            player.transform.position = new Vector3(-1.5f, 3.0f, player.transform.position.z);
        }
        // 창문 탈출?
        else if (curBtn == "Window")
        {
            // 탈출하는코드 써주세요
        }
#endif
        #endregion
    }

}
