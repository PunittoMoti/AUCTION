using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CSceneMoveObject : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] private string mScenename; // 実行時に使うシーン名（非表示）

#if UNITY_EDITOR
    [Header("遷移先シーン選択")]
    [SerializeField] private UnityEditor.SceneAsset mSceneAsset; // エディタ用
#endif


    // Start is called before the first frame update
    void Start()
    {
        //MoveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveScene()
    {
        SceneManager.LoadScene(mScenename);
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        // エディタ上でsceneToLoadAssetが変更されるたびに呼ばれ、
        // シーン名を文字列としてsceneToLoadへ保存します
        if (mSceneAsset != null)
        {
            mScenename = mSceneAsset.name;
        }
    }
#endif
}
