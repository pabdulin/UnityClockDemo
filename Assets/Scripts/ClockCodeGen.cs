using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCodeGen : MonoBehaviour
{
    private GameObject _face = null;
    private Vector3 _clockPosition = new Vector3(5, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = _clockPosition;
        _face.transform.parent = this.transform;
        this.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        // create face
        _face = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        _face.transform.localScale = new Vector3(10, 0.1f, 10);
        _face.transform.localPosition = _clockPosition;
    }
}
