using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterDelay : MonoBehaviour
{
    public float m_lifeSpan;

    void Start()
    {
        StartCoroutine(deleteAfter());
    }

    private IEnumerator deleteAfter()
    {
        yield return new WaitForSeconds(m_lifeSpan);
        Destroy(gameObject);
    }
}
