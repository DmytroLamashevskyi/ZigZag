using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public float smooth;
    public Transform target;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > 0)
        {
            Folow();
        }
    }

    void Folow()
    {
        Vector3 curentPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(curentPos, targetPos, smooth * Time.deltaTime);

    }
}
