using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동 속도
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    private float applySpeed;

    // 상태 변수
    private bool isRun = false;

    // 카메라 민감도
    [SerializeField]
    private float lookSensitivity;

    // 카메라 각도 제한
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float walkBobSpeed = 14f;
    [SerializeField]
    private float walkBobAmount = 14f;
    [SerializeField]
    private float sprintBobSpeed = 14f;
    [SerializeField]
    private float sprintBobAmount = 14f;

    private float defaultYPos = 0;
    private float timer;

    private Vector3 velocity;

    private Rigidbody myRigid;
    private Animator animator;


    // Use this for initialization
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        animator = GetComponent<Animator>();
        defaultYPos = cam.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Move();
        CameraRotation();
        CharacterRotation();
        HandleHeadBob();
    }

    private void HandleHeadBob()
    {
        if (velocity.magnitude != 0f)
        {
            timer += Time.deltaTime * (isRun ? sprintBobSpeed : walkBobSpeed);
            cam.transform.localPosition = new Vector3(
                cam.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer) * (isRun ? sprintBobAmount : walkBobAmount),
                cam.transform.localPosition.z);
        }
        else if (velocity.magnitude == 0f)
        {
            cam.transform.localPosition = Vector3.Lerp(
                cam.transform.localPosition,
                new Vector3(cam.transform.localPosition.x, defaultYPos, cam.transform.localPosition.z)
                , Time.deltaTime);
        }
    }

    private void Run()
    {
        // 달리기 시작
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80f, Time.deltaTime * 10);
        }
        // 달리기 그만
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRunning();
        }
        if (!isRun)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60f, Time.deltaTime * 20);
        }
    }

    private void StopRunning()
    {
        isRun = false;
        animator.SetBool("Run", false);
        applySpeed = walkSpeed;
    }

    private void Running()
    {
        isRun = true;
        animator.SetBool("Run", true);
        applySpeed = runSpeed;
    }

    private void Move()
    {
        // 입력 받아오기
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        // 방향 설정
        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVertical = transform.forward * moveDirZ;

        // 속도 설정
        velocity = (moveHorizontal + moveVertical).normalized * applySpeed;

        if (velocity.magnitude != 0.0f)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
        

        // 이동
        myRigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    // 캐릭터 좌우 회전
    private void CharacterRotation()
    {
        // 마우스 입력 받아오기
        float yRotation = Input.GetAxisRaw("Mouse X");
        // 회전할 각도
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        // 캐릭터 회전
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(characterRotationY));

        // 디버깅
        Debug.Log(myRigid.rotation);
        Debug.Log(myRigid.rotation.eulerAngles);
    }

    // 카메라 상하 회전
    private void CameraRotation()
    {
        // 마우스 입력 받아오기
        float xRotation = Input.GetAxisRaw("Mouse Y");
        // 회전할 각도
        float cameraRotationX = xRotation * lookSensitivity;
        // 최근 카메라 각도에서 회전한 각도 빼기
        currentCameraRotationX -= cameraRotationX;
        // 카메라 회전 각도 제한
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        // 카메라 회전
        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
}
