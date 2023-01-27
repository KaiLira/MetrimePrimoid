using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Attack : State
{
    [SerializeField] private Detection m_PlayerDetection;
    public Transform m_Muzzle;
    public GameObject m_Bullet;
    public IEnumerator m_CoroutineInstance;

    public override void OnEnter()
    {
        m_CoroutineInstance = CoroutineTime();
        StartCoroutine(m_CoroutineInstance);
        m_PlayerDetection = transform.Find("Detection").GetComponent<Detection>();
        m_Muzzle = transform.Find("Muzzle");
        m_Bullet = Resources.Load("Prefabs/Bullet") as GameObject;
        if (m_Bullet == null)
        {
            Debug.Log("coso1");
        }
    }

    public override void OnUpdate()
    {
        transform.LookAt(m_PlayerDetection.m_Direction);
        if (m_PlayerDetection.m_IsEnemy == false)
        {
            m_StateMachine.SetState(m_StateMachine.m_Patrol);
        }
    }

    public override void OnExit()
    {
        StopCoroutine(m_CoroutineInstance);
    }

     IEnumerator CoroutineTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            var bullet = Instantiate(m_Bullet);
            bullet.transform.SetPositionAndRotation(m_Muzzle.position, m_Muzzle.rotation);
        }
    }
}
