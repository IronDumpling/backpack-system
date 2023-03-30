using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backpack.Data;

public class Player : MonoBehaviour
{
    public static Player Instance => s_Instance;
    private static Player s_Instance;

    public Health m_Health;
    public GameObject m_HealthBar;
    const float HEALTH_NUM = 100;

    void Awake()
    {
        if (s_Instance != null && s_Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_Instance = this;

        m_Health = new Health(HEALTH_NUM, m_HealthBar);
    }
}
