using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetHolder : MonoBehaviour
{
    private GameObject m_target = null;

    public GameObject Target
    {
        get
        {
            if (m_target == null)
                m_findPlayer();

            if (!m_target.activeInHierarchy)
                m_findPlayer();

            return m_target;
        }
    }

    private void Awake()
    {
        m_findPlayer();
    }

    private void m_findPlayer()
    {
        var tagged = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in tagged)
        {
            if ((player.TryGetComponent<Rigidbody>(out var _) ||
                player.TryGetComponent<CharacterController>(out var _)) &&
                player.activeInHierarchy)
            {
                m_target = player;
                return;
            }
        }
    }
}
