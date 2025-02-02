﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseboxScript : MonoBehaviour
{
    private Vector2 currentPosition = Vector2.zero;
    private PlayerScript playerScript = null;
    private MazeManager mazeManager = null;
    private SpriteRenderer spriteRenderer = null;

    private bool playerCome = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScript = FindObjectOfType<PlayerScript>();
        mazeManager = FindObjectOfType<MazeManager>();

        spriteRenderer.sprite = playerScript.GetFuseboxSprite();

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.localPosition;

        ComeCheck();

        transform.localPosition = currentPosition;
    }
    void ComeCheck()
    {
        if(playerScript.GetCurrentPosition() == currentPosition && !playerCome)
        {
            playerCome = true;
            int a;
            a = mazeManager.GetComeFuseboxNum();
            a++;
            mazeManager.SetComeFuseboxNum(a);
            spriteRenderer.sprite = null;

        }
    }
}
