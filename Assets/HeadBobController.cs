using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField]
    private bool enable = true;

    [SerializeField, Range(0, 0.1f)]
    private float amplitube = 0.015f;
    [SerializeField, Range(0, 30)]
    private float frequency = 10.0f;

    [SerializeField] private Transform camera = null;
    [SerializeField] private Transform cameraSocket = null;

    private float toggleSpeed = 3.0f;
    private Vector3 startPos;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = camera.localPosition;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;

        if (speed < toggleSpeed) return;

        PlayMotion(FootStepMotion());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitube;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitube * 2;
        return pos;
    }

    private void ResetPosition()
    {
        if (camera.localPosition == startPos) return;
        camera.localPosition = Vector3.Lerp(camera.localPosition, startPos, 1 * Time.deltaTime);
    }
    private void PlayMotion(Vector3 motion)
    {
        camera.localPosition += motion * Time.deltaTime;
    }


    private void Update()
    {
        if (!enable) return;

        CheckMotion();
        ResetPosition();
        camera.LookAt(FocusTarget());
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraSocket.localPosition.y, transform.position.z);
        pos += cameraSocket.forward * 15.0f;
        return pos;
    }
}
