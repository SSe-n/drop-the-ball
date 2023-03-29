using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObj : MonoBehaviour
{
    public GameObject effectPrefab;
    public static ParticleSystem effect;


    public int _rank;
    bool _isGrowing;
    bool _isTouch;
    float _time;
    float _growSpeed = 1;
    int _dice;


    private void Awake()
    {
        //_rank = Random.Range(1, 6);
        _rank = 1;
        InitSetData();
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = RuleManager._instance._balls[_rank - 1];
    }
    private void Update()
    {
        if (_isGrowing)
        {
            Growing();
        }
    }

    void InitSetData()
    {
        gameObject.transform.localScale = Vector3.one * _rank;
    }

    void Growing()
    {
        _time += Time.deltaTime;
        transform.localScale = (Vector3.one * (_rank - 1)) * (1f + _time * 0.5f);

        if (transform.localScale.x >= _rank)
        {
            _time = 0;
            _isGrowing = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {
            BallObj temp = other.GetComponent<BallObj>();
            if (_rank == temp._rank)
            {
                if (_rank == RuleManager._maxLevel)
                    return;
                Destroy(other.gameObject);
                EffectPlay();
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SfxPlay(SoundManager.Sfx.RankUp);
                _isGrowing = true;
                _rank++;
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = RuleManager._instance._balls[_rank - 1];
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Box")
        {
            StartCoroutine("TouchRoutine");
        }

    }
    IEnumerator TouchRoutine()
    {
        if (_isTouch)
        {
            yield break;
        }

        _isTouch = true;

        GameObject.Find("SoundManager").GetComponent<SoundManager>().SfxPlay(SoundManager.Sfx.Touch_small);

        yield return new WaitForSeconds(0.2f);
        _isTouch = false;

    }

    void EffectPlay()
    {
        effect.transform.position = transform.position; //이펙트 위치 -> 공의 위치
        effect.transform.localScale = transform.localScale;
        effect.Play();

    }
}
