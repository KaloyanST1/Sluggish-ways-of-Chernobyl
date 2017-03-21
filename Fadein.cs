using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fadein : MonoBehaviour {

    public RawImage black;
	
	void FixedUpdate () {
        if (black.color.a > 0)
        {
            black.color = new Color(0f, 0f, 0f, black.color.a - 0.05f);
            return;
        }
        else
        {
            Destroy(this);
        }
    }
}
