using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�濡 ������ �������� ����ؾ� ���� �� ����
public class FindItemCanPass : MonoBehaviour
{
    [Header("�������� ���ϰ� �ϴ� �ݶ��̴� �ֱ�")]
    [SerializeField] private GameObject noPassCollider = null;
    [Header("����ؼ� ������ �� �ְ� �ϴ� ������")]
    [SerializeField] private Item needItem = null;

    private Inventory inventory = null;
    private bool isCheck = false;
    private bool isUseItem = false;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //�ѹ� �������� ���������� ����� �ڵ�
            if (!isCheck)
            {
                isCheck = true;
                noPassCollider.layer = LayerMask.NameToLayer("NoPassing");
            }
            //�������� ����ߴٸ� �ٽ� ������ �� �ְ� �ϴ� �ڵ�
            else if (!isUseItem)
            {
                if (inventory.UseItem(needItem.name))
                {
                    isUseItem = true;
                    noPassCollider.layer = LayerMask.NameToLayer("Default");
                }
            }
        }
    }
}
