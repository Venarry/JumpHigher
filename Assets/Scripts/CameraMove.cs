using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _char;
    [SerializeField] Vector3 _coordinates;
    [SerializeField] float _smooth;
    Vector3 _campos, _posEnd;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (_char.transform.position.y >= 0)
            _posEnd = new Vector3(_coordinates.x, _char.position.y + _coordinates.y, _coordinates.z);
        else _posEnd = new Vector3(_coordinates.x, 0  + _coordinates.y, _coordinates.z);
        _campos = Vector3.Lerp(transform.position, _posEnd, _smooth);
        transform.position = _campos;
    }

}
