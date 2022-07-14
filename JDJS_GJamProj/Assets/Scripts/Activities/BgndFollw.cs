using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgndFollw : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = target.position;
        transform.position = pos;
    }
}
