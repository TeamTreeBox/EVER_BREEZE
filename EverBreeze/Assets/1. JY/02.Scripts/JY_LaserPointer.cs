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

    //Ŭ���̺�Ʈ�� ������ �׼�
    //public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    //Ʈ���е��� Ŭ�� �̺�Ʈ�� ������ �׼�
    //public SteamVR_Action_Boolean teleport = SteamVR_Actions.default_Teleport;

    //������ �ִ� ��ȿ�Ÿ�
    public float maxDistance = 30.0f;

    //������ ����
    public Color color = Color.blue;
    public Color clickedColor = Color.green;

    //����ĳ��Ʈ�� ���� ���� ����
    private RaycastHit hit;
    private Transform tr;


    //�̺�Ʈ�� ������ ��ü�� ���� ����
    private GameObject prevObject;
    private GameObject currObject;

    //Pointer �������� ������ ����
    public GameObject pointer;

    //ȭ���� ��Ӱ� �����ϴ� �ð�
    public float fadeOutTime = 0.15f;

    private void Start()
    {
        tr = GetComponent<Transform>();

        //��Ʈ�ѷ��� ������ �����ϱ� ���� SteamVR_Behaviour_Pose ������Ʈ ����
        //pose = GetComponent<SteamVR_Behaviour_Pose>();

        //�Է� �ҽ� ����
        hand = pose.inputSource;

        //LineRenderer ����
        CreateLineRenderer();

        //�������� Resources �������� �ε��� �������� ����
        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(_pointer);
    }

    void CreateLineRenderer()
    {
        //LineRenderer ����
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;

        //�������� ������ ��ġ ����
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        //������ �ʺ� ����
        line.startWidth = 0.03f;
        line.endWidth = 0.005f;

        //������ ��Ƽ���� �� ���� ����
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

    private void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            //������ ������ ��ġ�� ����ĳ������ ������ ��ǥ�� ����
            line.SetPosition(1, new Vector3(0, 0, hit.distance));

            //�������� ��ġ�� ���� ����
            pointer.transform.position = hit.point + (hit.normal * 0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);


            //���� ������ �����ͷ� ����Ű�� ��ü�� ����
            currObject = hit.collider.gameObject;

            //���簴ü�� ���� ��ü�� �ٸ� ���
            if (currObject != prevObject)
            {
                //���� ��ü�� PointerEnter �̺�Ʈ ����
                ExecuteEvents.Execute(currObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);

                //���� ��ü�� PointerExit �̺�Ʈ ����
                ExecuteEvents.Execute(prevObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);

                prevObject = currObject;
            }

            // Ʈ���� ��ư�� Ŭ������ ��쿡 Ŭ�� �̺�Ʈ�� �߻���Ŵ
            if (trigger.GetLastStateDown(hand))
            {
                ExecuteEvents.Execute(currObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }

            //Ʈ���е带 Ŭ������ �� �ڷ���Ʈ ó��
            if (teleport.GetStateDown(hand))
            {
                //ȭ���� ���������� ����
                //SteamVR_Fade.Start(Color.black, 0);
                //�ڷ���Ʈ �ڷ�ƾ ȣ��
                StartCoroutine(this.Teleport(hit.point));
            }
        }
        else
        {
            if (prevObject != null)
            {
                //���� ��ü�� PointerExit �̺�Ʈ ����
                ExecuteEvents.Execute(prevObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);

                prevObject = null;
            }

            //�������� �������� ���κ����� �̵��ϰ� ��Ʈ�ѷ��� �ٶ󺸵��� ȸ��
            pointer.transform.position = tr.position + (tr.forward * maxDistance);
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);
        }

        //������ �������� ���� ����
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
        //������ ��ġ�� ���� �̵�
        tr.parent.position = pos;
        yield return new WaitForSeconds(fadeOutTime);

        //ȭ���� �ٽ� ��� ����
        //SteamVR_Fade.Start(Color.clear, 0.3f);
    }
}*/