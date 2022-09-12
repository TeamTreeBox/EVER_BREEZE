using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_JemStone : MonoBehaviour
{
    Material mat;
    Texture texture;
    MeshRenderer meshRenderer;

    float emssionValue = 0;
    float emssionplus = 0.3f;
    float strengthValue = 0f;
    float strength_Plus = 0.7f;

    Color color;

    public GameObject JingleBell;
    public bool isPopOn = false;
    GameObject particle;
    float dist;

    public bool isTouchEnough = false;
    bool isTouching = false;

    int touchCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        particle = this.transform.GetChild(0).gameObject;
        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
        texture = GetComponent<Texture>();
        //mat.SetFloat("_EmissionPower", 2f);
    }

    // Update is called once per frame
    void Update()
    {

        print(touchCount);

        if (touchCount >= 2)
        {
            if (isPopOn == false)
            {
                HM_QuestManager.instance.QuestTriggerIconPopUp();
                isPopOn = true;
            }
            isTouchEnough = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Right_Song" && isTouchEnough == false && isTouching == false)
        {
            isTouching = true;
            StartCoroutine(ChangeEmissionValue());
            touchCount++;
        }

        if (other.gameObject.name == "QuestTrigger" && isTouchEnough == true && this.GetComponent<JY_ItemInfo>().state == ItemState.Grab)
        {
            HM_QuestManager.instance.isJamStoneOn = true;
            HM_QuestManager.instance.StartCoru(2);
            Destroy(this.gameObject);
        }
    }


    IEnumerator ChangeEmissionValue()
    {
        particle.SetActive(true);
        for (int i = 0; i < 18; i++)
        {
            mat.SetFloat("_EmissionPower", emssionValue += emssionplus);
            mat.SetFloat("_Translucency", strengthValue += strength_Plus);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);

        isTouching = false;
        particle.SetActive(false);
    }

    public void SizeChange()
    {

    }

}
