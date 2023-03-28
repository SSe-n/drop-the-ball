using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    public GameObject _effectPrefab;
    public Transform _effectPos;    //이펙트가 생성되는 위치

    Camera _mainCam;
    private void Start()
    {
        _mainCam = Camera.main;
    }
    void Update()
    {
        // 해당 오브젝트를 클릭시 그곳에서 구체 생성
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

                GameObject _effectObj = Instantiate(_effectPrefab, _effectPos);
                ParticleSystem instantEffect = _effectObj.GetComponent<ParticleSystem>();
                BallObj.effect = instantEffect;


            }   
        }
    }
}
