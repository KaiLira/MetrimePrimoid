using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Attack : State
{
    [SerializeField] private Detection m_PlayerDetection;
    public Transform m_Muzzle;
    public GameObject m_Bullet;

    public override void OnEnter()
    {
        m_PlayerDetection = gameObject.GetComponent<Detection>();
        m_Muzzle = transform.Find("Muzzle");
        Resources.Load("");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
