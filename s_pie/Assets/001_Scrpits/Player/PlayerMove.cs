﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 우앱: 플레이어가 타일 뒤로 들어가는 문제 때문에 Vector3 로 바꿨슴

    //이동 관련 변수
    [SerializeField] private float distance = 1f;  //이동거리
    private bool isMove = false;

    private TurnManager turnManager = null; //플레이어 턴인지 아닌지 확인하기 위해서 만듬

    [SerializeField] private LayerMask layerMask; //지나갈 수 없는 곳의 레이어 설정

    private Animator animator = null; //애니메이션 사용

    private SpriteRenderer spriteRenderer = null; //캐릭터 이미지 뒤집기 사용

    private BoxCollider2D boxCollider2D;

    // 키보드 입력 막는 용도
    public static bool isPossible = true;
    
    #region 코드리뷰 추가 코드
    public Vector2 getPlayerHeading { get; private set; }
    private void DoSetPlayerHeading(Direction myDirection)
    {
        //Debug.Log($"{transform.position} 플레이어 현재 위치");

        Vector2 playerPos = transform.position;
        switch (myDirection)
        {
            case Direction.Up:
                playerPos.y += distance;
                break;
            case Direction.Down:
                playerPos.y -= distance;
                break;
            case Direction.Right:
                playerPos.x += distance;
                break;
            case Direction.Left:
                playerPos.x -= distance;
                break;
        }
        getPlayerHeading = playerPos;

        //Debug.Log($"{getPlayerHeading} 플레이어 목표 위치");
    }
    #endregion

    private enum Direction
    {
          Up    //위쪽으로 움직임
        , Down  //아레쪽으로 움직임
        , Right //오른쪽으로 움직임
        , Left  //왼쪽으로 움직임
    }

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();

        #region 널레퍼런스 방지용 코드 (유니티 에디터에서만 실행됨)
#if UNITY_EDITOR
        NullCheck();
#endif
        #endregion

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        boxCollider2D = GetComponent<BoxCollider2D>();

        isPossible = true;
    }


    #region 널레퍼런스 방지용 코드 (유니티 에디터에서만 실행됨)
#if UNITY_EDITOR
    void NullCheck()
    {
        if (turnManager == null)
        {
            UnityEditor.EditorUtility.DisplayDialog("턴 메니저 오류", "턴 메니저가 씬에서 발견되지 않았습니다.", "확인");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
#endif
    #endregion
    #region 영상용 코드 (WASD 움직임)
    private void Update()
    {
        if(isPossible)
        {
            if (Input.GetKeyDown(KeyCode.W))
                ClickUp();
            if (Input.GetKeyDown(KeyCode.S))
                ClickDown();
            if (Input.GetKeyDown(KeyCode.A))
                ClickLeft();
            if (Input.GetKeyDown(KeyCode.D))
                ClickRight();
        }
    }
    #endregion


    public void ClickUp() //위에 있는 버튼을 눌렀을때
    {
        if(isMove == false)
        {
            if (turnManager.playerTurn == true) //플레이어 턴 인지 확인
            {
                DoSetPlayerHeading(Direction.Up);
                if (NoPassingCheck(Direction.Up) == true)
                    return;

                StartCoroutine(Move(Direction.Up));
            }
        }
    }

    public void ClickDown() //아레 있는 버튼을 눌렀을때
    {
        if(isMove == false)
        {
            if (turnManager.playerTurn == true)
            {
                DoSetPlayerHeading(Direction.Down);
                if (NoPassingCheck(Direction.Down) == true)
                    return;

                StartCoroutine(Move(Direction.Down));
            }
        }
    }

    public void ClickRight() //오른쪽에 있는 버튼을 눌렀을때
    {
        if(isMove == false)
        {
            if (turnManager.playerTurn == true)
            {
                DoSetPlayerHeading(Direction.Right);
                if (NoPassingCheck(Direction.Right) == true)
                    return;

                StartCoroutine(Move(Direction.Right));
            }
        }
    }

    public void ClickLeft() //왼쪽에 있는 버튼을 눌렀을때
    {
        if(isMove == false)
        {
            if (turnManager.playerTurn == true)
            {
                DoSetPlayerHeading(Direction.Left);
                if (NoPassingCheck(Direction.Left) == true)
                    return;

                StartCoroutine(Move(Direction.Left));
            }
        }
    }

    private bool NoPassingCheck(Direction direction) //지나갈 수 없는 곳인지 확인
    {
        //플레이어가 가는 방향에 layer가 NoPassing인 박스 컬라이더가 있으면 지나가지 못한다.
        
        RaycastHit2D hit;
        Vector2 start = transform.localPosition;
        Vector2 end = transform.localPosition;

        switch (direction)
        {
            case Direction.Up:
                end.y += distance;
                break;
            case Direction.Down:
                end.y -= distance;
                break;
            case Direction.Right:
                end.x += distance;
                break;
            case Direction.Left:
                end.x -= distance;
                break;
        }

        hit = Physics2D.Linecast(start, end, layerMask);

        if (hit.transform != null)
        {
            //Debug.Log("플레이어가 뭔가를 찾음");
            return true;
        }

        //Debug.Log("플레이어가 못 찾음");
        return false;
    }

    private IEnumerator Move(Direction direction) //플레이어 움직임
    {
        isMove = true;
        Vector3 targetPosition = Vector3.zero;

        switch (direction)
        {
            case Direction.Up:
                targetPosition.y = distance / 20; //1번 움직일때 움직이는 거리
                break;
            case Direction.Down:
                targetPosition.y = -(distance / 20);
                break;
            case Direction.Right:
                targetPosition.x = distance / 20;
                spriteRenderer.flipX = false;
                break;
            case Direction.Left:
                targetPosition.x = -(distance / 20);
                spriteRenderer.flipX = true;
                break;
        }

        //0.01초당 1번씩 총 20번 움직임
        animator.SetBool("Move", true);
        for (int i = 0; i < 20; i++)
        {
            transform.localPosition += targetPosition;
            yield return new WaitForSeconds(0.01f);
        }
        animator.SetBool("Move", false);

        turnManager.EndPlayerTurn(1); // 플레이어 턴 종료
        yield return new WaitForSeconds(0.2f);
        boxCollider2D.enabled = false;
        boxCollider2D.enabled = true;
        
        isMove = false;
    }
}
