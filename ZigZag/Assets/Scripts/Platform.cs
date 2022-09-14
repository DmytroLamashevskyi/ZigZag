using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<CarController>() != null)
        {
            Invoke("Fall", 0.2f);
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1);
    }
}
