/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using Valve.VR;

public class JY_LaserPointer : MonoBehaviour
{
    //private SteamVR_Behaviour_Pose pose;
    //private SteamVR_Input_Sources hand;
    private LineRenderer line;

    //클릭이벤트에 반응할 액션
    //public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    //트랙패드의 클릭 이벤트에 반응할 액션
    //public SteamVR_Action_Boolean teleport = SteamVR_Actions.default_Teleport;

    //라인의 최대 유효거리
    public float maxDistance = 30.0f;

    //라인의 색상
    public Color color = Color.blue;
    public Color clickedColor = Color.green;

    //레이캐스트를 위한 변수 선언
    private RaycastHit hit;
    private Transform tr;


    //이벤트를 전달할 객체의 저장 변수
    private GameObject prevObject;
    private GameObject currObject;

    //Pointer 프리팹을 저장할 변수
    public GameObject pointer;

    //화면을 어둡게 지속하는 시간
    public float fadeOutTime = 0.15f;

    private void Start()
    {
        tr = GetComponent<Transform>();

        //컨트롤러의 정보를 검출하기 위한 SteamVR_Behaviour_Pose 컴포넌트 추출
        //pose = GetComponent<SteamVR_Behaviour_Pose>();

        //입력 소스 추출
        hand = pose.inputSource;

        //LineRenderer 생성
        CreateLineRenderer();

        //프리팹을 Resources 폴더에서 로드해 동적으로 생성
        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(_pointer);
    }

    void CreateLineRenderer()
    {
        //LineRenderer 생성
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;

        //시작점과 끝점의 위치 설정
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        //라인의 너비 설정
        line.startWidth = 0.03f;
        line.endWidth = 0.005f;

        //라인의 머티리얼 및 색상 설정
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

    private void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            //라인의 끝점의 위치를 레이캐스팅한 지점의 좌표로 변경
            line.SetPosition(1, new Vector3(0, 0, hit.distance));

            //포인터의 위치와 각도 설정
            pointer.transform.position = hit.point + (hit.normal * 0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);


            //현재 레이저 포인터로 가리키는 객체를 저장
            currObject = hit.collider.gameObject;

            //현재객체와 이전 객체가 다른 경우
            if (currObject != prevObject)
            {
                //현재 객체에 PointerEnter 이벤트 전달
                ExecuteEvents.Execute(currObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);

                //이전 객체에 PointerExit 이벤트 전달
                ExecuteEvents.Execute(prevObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);

                prevObject = currObject;
            }

            // 트리거 버튼을 클릭했을 경우에 클릭 이벤트를 발생시킴
            if (trigger.GetLastStateDown(hand))
            {
                ExecuteEvents.Execute(currObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }

            //트랙패드를 클릭했을 때 텔레포트 처리
            if (teleport.GetStateDown(hand))
            {
                //화면을 검정색으로 변경
                //SteamVR_Fade.Start(Color.black, 0);
                //텔레포트 코루틴 호출
                StartCoroutine(this.Teleport(hit.point));
            }
        }
        else
        {
            if (prevObject != null)
            {
                //이전 객체에 PointerExit 이벤트 전달
                ExecuteEvents.Execute(prevObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);

                prevObject = null;
            }

            //포인터의 레이저의 끝부분으로 이동하고 컨트롤러를 바라보도록 회전
            pointer.transform.position = tr.position + (tr.forward * maxDistance);
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);
        }

        //레이저 포인터의 색상 변경
        if (trigger.GetStateDown(hand))
        {
            line.material.color = clickedColor;
        }

        if (trigger.GetStateUp(hand))
        {
            line.material.color = this.color;
        }
    }

    IEnumerator Teleport(Vector3 pos)
    {
        //포인터 위치로 순간 이동
        tr.parent.position = pos;
        yield return new WaitForSeconds(fadeOutTime);

        //화면을 다시 밝게 변경
        //SteamVR_Fade.Start(Color.clear, 0.3f);
    }
}*/