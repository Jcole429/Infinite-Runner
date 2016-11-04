using UnityEngine;
using System.Collections;

public class randomizeFloorPanels : MonoBehaviour {



	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = GetRandomMaterial().color;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public Material GetRandomMaterial()
    {
        int x = Random.Range(0, 5);
        if (x == 0)
            return Resources.Load("Materials/BlueMat") as Material;
        else if (x == 1)
            return Resources.Load("Materials/GreenMat") as Material;
        else if (x == 2)
            return Resources.Load("Materials/PurpleMat") as Material;
        else if (x == 3)
            return Resources.Load("Materials/RedMat") as Material;
        else if (x == 4)
            return Resources.Load("Materials/WhiteMat") as Material;
        else
            return Resources.Load("Materials/YellowMat") as Material;
    }

}
