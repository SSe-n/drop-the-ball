using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    [SerializeField] GameObject _prefab;

    Camera _mainCam;
    private void Start()
    {
        _mainCam = Camera.main;
    }
    void Update()
    {
        // �ش� ������Ʈ�� Ŭ���� �װ����� ��ü ����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            LayerMask lMask;
            lMask = 1 << LayerMask.NameToLayer("TouchZone");
            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, lMask))
            {
                Vector3 pos = rayHit.point;
                Instantiate(_prefab, pos, Quaternion.LookRotation(Vector3.down));
            }   
        }
    }
}
