using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody))]
public class CrabController : MonoBehaviour
{
    public float _speed = 1f;

    private Rigidbody _rigidbody;
    public float sensitivity = 2f;
    float value;
    float multiplier;
    Camera camera;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
       
    }

    private void Update()
    {
        multiplier = 1f;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        transform.Rotate(new Vector3(0, mouseX, 0));
        if (Input.GetKey(KeyCode.LeftShift))
            multiplier = 2f;
        value = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        
      

        if (_rigidbody.velocity.magnitude < _speed * multiplier)
        {

            //float value = Input.GetAxis("Vertical");
            //if (value != 0)
            //    _rigidbody.AddForce(0, 0, -value * Time.fixedDeltaTime * 1000f);
            
            if (value != 0)
                _rigidbody.AddRelativeForce(transform.forward.x-value * Time.fixedDeltaTime * 1000f, transform.forward.y, transform.forward.z);
        }
    }
}