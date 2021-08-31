using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��� ������ �޼��ؾ� ������ �� ����
public class PassConditionsAchievement : MonoBehaviour
{
    private BoxCollider2D boxCollider = null;
    private bool isCanPass = false;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //��� ������ �޼������� �� �Լ� ����
    private void ConditionsAchievement()
    {
        if (!isCanPass)
        {
            isCanPass = true;
            boxCollider.enabled = false;
        }
    }
}
