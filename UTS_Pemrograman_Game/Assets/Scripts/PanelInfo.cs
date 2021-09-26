using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInfo : MonoBehaviour
{
    public GameObject panelInfo;
    // Start is called before the first frame update
    void Start()
    {
        panelInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnInfoClicked()
    {
        panelInfo.SetActive(true);
    }

    public void BtnKembaliClicked()
    {
        panelInfo.SetActive(false);
    }
}
