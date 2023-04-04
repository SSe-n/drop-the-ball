using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RuleManager : MonoBehaviour
{
    public static RuleManager _instance;
    /// <summary>
    /// ��ŲŸ��
    /// </summary>
    public enum BallType
    {
        Balls = 0,
    }
    /// <summary>
    /// ���� �ִ� ����
    /// </summary>
    public static int _maxLevel = 5;
    /// <summary>
    /// ���� ������ ��Ų
    /// </summary>
    public BallType _ballType;
    /// <summary>
    /// ��Ų���� ������ ��Ƽ����
    /// </summary>
    public List<Material> _balls;
    // �ӽ�
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
