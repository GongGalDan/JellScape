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
    // 적용할 속도 변수
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
    private float walkBobSpeed = 10f;
    [SerializeField]
    private float walkBobAmount = 0.05f;
    [SerializeField]
    private float sprintBobSpeed = 14f;
    [SerializeField]
    private float sprintBobAmount = 0.1f;

    private float defaultYPos = 0;
    private float timer;

    private Vector3 velocity;

    private Rigidbody myRigid;
    private Animator animator;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        // 초기엔 걷는 속도
        applySpeed = walkSpeed;
        animator = GetComponent<Animator>();
        defaultYPos = cam.transform.localPosition.y;
    }

    void Update()
    {
        Run();
    }

    void FixedUpdate()
    {
        Move();
        CameraRotation();
        CharacterRotation();
        HandleHeadBob();
    }

    // 걷거나 뛸 때 머리가 위아래 움직이는 효과
    private void HandleHeadBob()
    {
        // 현재 속도가 0 이상 일때
        if (velocity.magnitude != 0f)
        {
            // Sin 함수에 넣어줄 각도 
            // Sin(0) = 0 부터 시작하여 시간이 흐름에 따라 최대 1 ~ 최소 -1 값을 갖는다.
            timer += Time.fixedDeltaTime * (isRun ? sprintBobSpeed : walkBobSpeed);
            cam.transform.localPosition = new Vector3(
                cam.transform.localPosition.x,
                // Sin 함수를 이용하여 카메라의 Y 값을 위 아래로 움직인다.
                defaultYPos + Mathf.Sin(timer) * (isRun ? sprintBobAmount : walkBobAmount),
                cam.transform.localPosition.z);
        }
        // 속도가 0일때 (멈출 때)
        else if (velocity.magnitude == 0f)
        {
            // Lerp 함수를 이용해 원래의 포지션으로 부드럽게 돌아온다.
            cam.transform.localPosition = Vector3.Lerp(
                cam.transform.localPosition,
                new Vector3(cam.transform.localPosition.x, defaultYPos, cam.transform.localPosition.z)
                , Time.fixedDeltaTime);
        }
    }

    // 달리기
    private void Run()
    {
        // 달리기 시작
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
            // 시야가 넓어져 빠른 속도감 연출
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80f, Time.fixedDeltaTime * 10);
        }
        // 달리기 그만
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRunning();
        }
        if (!isRun)
        {
            // 시야가 좁아지며 느려진 속도감 연출
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60f, Time.fixedDeltaTime * 20);
        }
    }

    // 달리기 멈춤
    private void StopRunning()
    {
        isRun = false;
        animator.SetBool("Run", false);
        applySpeed = walkSpeed;
    }

    // 달리기 시작
    private void Running()
    {
        isRun = true;
        animator.SetBool("Run", true);
        applySpeed = runSpeed;
    }

    // 플레이어 움직임
    private void Move()
    {
        // 입력 받아오기
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        // 방향 설정
        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVertical = transform.forward * moveDirZ;

        // 속도 설정
        velocity = (moveHorizontal + moveVertical).normalized * applySpeed * Time.fixedDeltaTime;

        // 애니메이션 설정
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
        transform.position += velocity;
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