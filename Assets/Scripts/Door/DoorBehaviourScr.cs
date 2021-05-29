using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviourScr : MonoBehaviour, IObserver<bool>
{
    public ContainingAnyTriggerObservable doorTrigger;
    public Transform DoorTransform;

    public int rotateSpeed;
    public float maxAngle;

    private float Rotation;

    private bool IsOpen = false;

    public void Notify(bool shouldOpen)
    {
        IsOpen = shouldOpen;
    }

    // Start is called before the first frame update
    void Start()
    {
        doorTrigger.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        if (IsOpen && Rotation < maxAngle)
        {
            Open();
        }
        else if (!IsOpen && Rotation > 0)
        {
            Close();
        }
        DoorTransform.localEulerAngles = new Vector3(
            DoorTransform.localEulerAngles.x,
            DoorTransform.localEulerAngles.y,
            Rotation);
    }

    private void Open()
    {
        Rotate(true);
        if (Rotation > maxAngle)
        {
            Rotation = maxAngle;
        }
    }

    private void Close()
    {
        Rotate(false);
        if (Rotation < 0)
        {
            Rotation = 0;
        }
    }

    private void Rotate(bool direction)
    {
        int directionModifier = 1;
        if (!direction)
        {
            directionModifier = -1;
        }
        Rotation += rotateSpeed * Time.deltaTime * directionModifier;
    }
}
