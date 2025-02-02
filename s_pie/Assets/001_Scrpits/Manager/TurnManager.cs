﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    private MoveAI[]   moveAI   = null; //AI가 여러개 일수도 있기 때문에 배열로 만듬
    private NoticeAI[] noticeAI = null;

    private int turn = 0; //현재 턴이 몇인지 확인
    public bool playerTurn = true; //현재 플레이어 턴인지 확인

    [SerializeField] private Text turnText; //턴UI
    [Header("여기에 턴 제한 수를 넣으면 됨")]
    [SerializeField] private int limitTurn; //턴 제한

    private GameManager gameManager = null;

    private void Awake()
    {
        gameManager = GameManager.Instance;

        moveAI   = FindObjectsOfType<MoveAI>();
        noticeAI = FindObjectsOfType<NoticeAI>();
        TurnCheck();
    }

    public void EndPlayerTurn(int addTurn/*플레이어가 몇턴을 사용했는지 받아옴*/) //플레이어 턴
    {
        playerTurn = false;
        turn += addTurn;
        AITurn(addTurn); //AI턴으로 넘어감
        TurnCheck(); //현재 턴이 제한된 턴을 넘었는지 확인
    }

    private void AITurn(int aITurn/*플레이어가 사용한 턴 만큼 AI가 이동함*/) //AI턴
    {
        #region AI가 움직이는 코드
        for (int i = 0; i < aITurn; i++)
        {
            for(int aINum = 0; aINum <noticeAI.Length; ++aINum) // 고정식 AI 는 AIMove 사용하지 않아서 일단 이렇게 해둠
            {
                noticeAI[aINum].AILookUp();
            }
            for (int aINum = 0; aINum < moveAI.Length; aINum++)
            {
                moveAI[aINum].AIMove();
            }
        }
        #endregion

        playerTurn = true;
    }

    private void TurnCheck()
    {
        turnText.text = limitTurn - turn + "분 남음"; //남은 턴 표시
        gameManager.SetWasteTurn(limitTurn - turn);
        if (turn >= limitTurn)
        {
            GameManager.Instance.SetGameOver(true); //게임오버
        }
    }
}
