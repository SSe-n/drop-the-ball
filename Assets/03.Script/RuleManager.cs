using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RuleManager : MonoBehaviour
{
    public static RuleManager _instance;
    /// <summary>
    /// 스킨타입
    /// </summary>
    public enum BallType
    {
        Balls = 0,
    }
    /// <summary>
    /// 공의 최대 레벨
    /// </summary>
    public static int _maxLevel = 5;
    /// <summary>
    /// 현재 적용한 스킨
    /// </summary>
    public BallType _ballType;
    /// <summary>
    /// 스킨들의 레벨별 머티리얼
    /// </summary>
    public List<Material> _balls;
    // 임시
    private void Awake()
    {
        _instance = this;
        Material[] go = Resources.LoadAll<Material>(_ballType.ToString());
        for (int i = 0; i < go.Length; i++)
        {
            _balls.Add(go[i]);
        }
    }
}
