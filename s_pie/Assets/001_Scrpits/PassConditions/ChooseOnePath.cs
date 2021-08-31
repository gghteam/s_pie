using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �ϳ��� �����ؼ� �� �� ����
public class ChooseOnePath : MonoBehaviour
{
    [Header("������ ������ ��� �� �ֱ�")]
    [SerializeField] private ChooseOnePath[] link = null;

    private bool noPass = false;

    //���� �������ٸ� �ٸ� ���� �������� ���ϰ� �ϴ� �ڵ�
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!noPass && collision.CompareTag("Player"))
        {
            for (int i = 0; i < link.Length; i++)
            {
                link[i].noPass = true;
                link[i].gameObject.layer = LayerMask.NameToLayer("NoPassing");
            }

            gameObject.SetActive(false);
        }
    }
}
