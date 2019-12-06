using System;
using UnityEngine;

public class ClockCodeGen : MonoBehaviour
{
    const float degreesPerHour = 360 / 12;
    const float degreesPerMinuteAndSecond = 360 / 60;
    private Vector3 _clockBuildPosition = new Vector3(0, 0, 0);
    private Vector3 _clockFinalPosition = new Vector3(5, 0, 0);

    private GameObject _face;
    private GameObject _hoursMarker;
    private GameObject _hoursArm;
    private GameObject _minutesArm;
    private GameObject _secondsArm;

    void Start()
    {
        this.transform.position = _clockBuildPosition;

        _face.transform.parent = this.transform;
        _hoursMarker.transform.parent = this.transform;
        _hoursArm.transform.parent = this.transform;
        _minutesArm.transform.parent = this.transform;
        _secondsArm.transform.parent = this.transform;

        // move clock to final position
        this.transform.rotation = Quaternion.Euler(-90, 0, 0);
        this.transform.position = _clockFinalPosition;
    }

    void Update()
    {
        var time = DateTime.Now.TimeOfDay;
        _hoursArm.transform.localRotation = Quaternion.Euler(0f, (float)(time.TotalHours * degreesPerHour), 0f);
        _minutesArm.transform.localRotation = Quaternion.Euler(0f, (float)(time.TotalMinutes * degreesPerMinuteAndSecond), 0f);
        _secondsArm.transform.localRotation = Quaternion.Euler(0f, (float)(time.TotalSeconds * degreesPerMinuteAndSecond), 0f);
    }

    void Awake()
    {
        var matClockDark = Resources.Load<Material>("Materials\\Clock Dark");
        var matClockRed = Resources.Load<Material>("Materials\\Clock Red");

        // face
        _face = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        _face.transform.localScale = new Vector3(10, 0.1f, 10);

        // hours markers
        _hoursMarker = CreateMarker(new Vector3(0, 0.2f, 4), new Vector3(0.5f, 0.2f, 1), matClockDark);

        // arms
        _hoursArm = CreateArm(new Vector3(0, 0.2f, 0.75f), new Vector3(0.3f, 0.2f, 2.5f), matClockDark);
        _minutesArm = CreateArm(new Vector3(0, 0.375f, 1), new Vector3(0.2f, 0.15f, 4), matClockDark);
        _secondsArm = CreateArm(new Vector3(0, 0.5f, 1.25f), new Vector3(0.1f, 0.1f, 5), matClockRed);
    }

    private GameObject CreateArm(Vector3 position, Vector3 scale, Material material)
    {
        var outer = new GameObject();

        var arm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        arm.transform.parent = outer.transform;
        arm.transform.localScale = scale;
        arm.transform.localPosition = position;
        arm.GetComponent<MeshRenderer>().material = material;

        return outer;
    }

    private GameObject CreateMarker(Vector3 position, Vector3 scale, Material material)
    {
        var marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
        marker.transform.position = position;
        marker.transform.localScale = scale;
        marker.GetComponent<MeshRenderer>().material = material;
        return marker;
    }
}
