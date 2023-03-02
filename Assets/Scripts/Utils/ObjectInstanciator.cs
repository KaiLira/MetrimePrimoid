using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstanciator : MonoBehaviour
{
    public void MakeInstance(GameObject go)
    {
        Instantiate(go, transform.position, transform.rotation);
    }
}
