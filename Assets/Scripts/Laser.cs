using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    //[SerializeField]
    //private GameObject _parentGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
        //transform.position.y

        //if(transform.position.y >= 8f && transform.parent == null)
        //{
        //    Destroy(this.gameObject);
        //} 
        //else if(transform.position.y >= 8f && transform.parent != null)
        //{
        //    Destroy(transform.parent);
        //    Destroy(this.gameObject);
        //}

        if (transform.position.y >= 6.7f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
