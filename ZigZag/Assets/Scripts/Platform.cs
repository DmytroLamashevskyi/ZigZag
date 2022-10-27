using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int propability;
    public GameObject diamondPrefub;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0,101) < propability)
        {
           Vector3 pos = transform.position;
           pos.y += 1f;
           Instantiate(diamondPrefub,pos,diamondPrefub.transform.rotation,gameObject.transform);
        }

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
