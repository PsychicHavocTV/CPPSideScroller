using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
<<<<<<< HEAD:SideScroller/Assets/Scripts/UI.cs
    [SerializeField]
    iTween.EaseType _easeType;

    private Vector3 _position = new Vector3(0, 0, 0);
=======
>>>>>>> 60d30c799f6577700ef0d418151b68513acb3738:SideScroller/Assets/Scripts/Ai/Aquatics/Shark/ObstacleBehaviour.cs
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShopClick()
    {
        
    }

    private void OnEnable()
    {
        Hashtable ht = new Hashtable();
        ht.Add("position", transform.position + Vector3.left * 300f);
        ht.Add("time", 0.5f);
        ht.Add("easeType", _easeType);


        iTween.MoveFrom(gameObject, ht);
    }
}
