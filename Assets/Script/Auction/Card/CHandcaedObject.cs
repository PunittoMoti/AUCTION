using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHandcaedObject : MonoBehaviour
{
    public List<CCardObject> mHandcaeds;//手札　カードオブジェクト配列(可変)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //手札受け渡し
    public List<CCardObject> GetHandcaeds()
    {
        return mHandcaeds;
    }

    //手札ドロー時にオブジェクト生成処理

    //手札ドロー時に位置調整
}
