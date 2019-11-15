using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    [SerializeField]
    Material offMaterial;

    [SerializeField]
    Material onMaterial;

    public bool switchActive;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = offMaterial;
        switchActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = onMaterial;
        switchActive = true;
    }

    public void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = offMaterial;
        switchActive = false;
    }
}
