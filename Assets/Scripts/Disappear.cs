using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public GameObject submarine;
    public MeshRenderer outsidehull;
    public MeshRenderer outsiderim;
    public Material[] mat;
    private float solidDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        mat = outsiderim.materials;
        submarine = GameObject.Find("Nipple");
    }

    public void MakeObjectDisappear()
    {
        var distance = Vector3.Distance(transform.position, submarine.transform.position);
        if (distance < solidDistance )
        {
            outsidehull.material.color = new Color(0.5283019f, 0.5283019f, 0.5283019f, (distance / solidDistance));
            mat[0].color = new Color(1f, 0.803922f, 0.121569f, (distance / solidDistance));
            mat[1].color = new Color(1f, 0.803922f, 0.121569f, (distance / solidDistance));
            mat[2].color = new Color(1f, 0.803922f, 0.1215699f, (distance / solidDistance));
        }
        else
        {
            mat[0].color = new Color(1f, 0.803922f, 0.1215699f, 1f);
            mat[1].color = new Color(1f, 0.803922f, 0.1215699f, 1f);
            mat[2].color = new Color(1f, 0.803922f, 0.1215699f, 1f);
            outsidehull.material.color = new Color(0.5283019f, 0.5283019f, 0.5283019f, 1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        MakeObjectDisappear();
    }
}
