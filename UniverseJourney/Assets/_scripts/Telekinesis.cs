using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    private enum Sounds{
        +
    }


    public float ManuplationDistance = 20f;
    private GameObject _heldObject;
    public Transform holdPosition;
    private Rigidbody _boxRigidBody;
    private bool _holdsObject;
    public float attractionSpeed = 5f;
    public float throwForce = 5f;
    private float _minThrow = 2f;
    private float _maxThrow = 100f;
    private Vector3 _rotateVector;
    public TextMeshProUGUI forceText;
    public AudioClip[] tkSounds;
    private AudioSource _audioSource;




    private void Raycast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, ManuplationDistance))
        {
            if (hit.collider.CompareTag("Box"))
            {
                _heldObject = hit.collider.gameObject;
                _heldObject.transform.SetParent(holdPosition);

                _boxRigidBody = _heldObject.GetComponent<Rigidbody>();
                _boxRigidBody.constraints = RigidbodyConstraints.FreezeAll;

                _holdsObject = true;



            }
        }
    }
    private void MoveObjectPosition()
    {
        _heldObject.transform.position = Vector3.Lerp(_heldObject.transform.position, holdPosition.transform.position, attractionSpeed * Time.deltaTime);
    }
    public float CheckDistance()
    {
        return Vector3.Distance(_heldObject.transform.position, holdPosition.transform.position);

    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!_holdsObject)
            {
                Raycast();
                CalculateRotationVector();
            }
            else
            {
                ShootObject();
            }

        }
        if (Input.GetMouseButton(0) && _holdsObject)
        {
            throwForce += 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.F) && _holdsObject)
        {
            ReleaseObject();
        }

        if (_holdsObject)
        {
            RotateBox();
            if (CheckDistance() >= 1f)
            {
                MoveObjectPosition();
            }
        }
        forceText.text = throwForce.ToString(format:"F1");
    }


    private void ReleaseObject()
    {
        _boxRigidBody.constraints = RigidbodyConstraints.None;
        _heldObject.transform.parent = null;
        _holdsObject = false;
        _heldObject = null;
        throwForce = 5f;
    }

    private void ShootObject()
    {
        throwForce = Mathf.Clamp(throwForce, _minThrow, _maxThrow);
        _boxRigidBody.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
        ReleaseObject();
    }

    private void CalculateRotationVector()
    {
        float x = UnityEngine.Random.Range(-1f, 1f);
        float y = UnityEngine.Random.Range(-1f, 1f);
        float z = UnityEngine.Random.Range(-1f, 1f);
        _rotateVector = new Vector3(x, y, z);
    }

    private void RotateBox()
    {
        _heldObject.transform.Rotate(_rotateVector);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

}
