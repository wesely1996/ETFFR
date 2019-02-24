using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
	public GameObject PanelInfo;

    // Start is called before the first frame update
    void Start()
    {
		PanelInfo.SetActive(false);
    }

    public void InfoON()
	{
		PanelInfo.SetActive(true);
	}

	public void InfoOFF()
	{
		PanelInfo.SetActive(false);
	}

}
