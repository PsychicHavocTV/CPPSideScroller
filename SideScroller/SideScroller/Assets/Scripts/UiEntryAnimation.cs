using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEntryAnimation : MonoBehaviour
{

    [SerializeField]
    iTween.EaseType easeType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Hashtable ht = new Hashtable();
        ht.Add("position", transform.position + Vector3.right * 300f);
        ht.Add("time", 0.5f);
        ht.Add("easeType", easeType);

        iTween.MoveFrom(gameObject, ht);
    }
}
