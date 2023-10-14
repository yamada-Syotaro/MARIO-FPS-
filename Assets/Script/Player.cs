using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _movePower = 3f;
    [SerializeField] float _jumpPower = 1f;
    Rigidbody _rb = default;

    Vector3 _dir;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.up * h;
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if(forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }
}
