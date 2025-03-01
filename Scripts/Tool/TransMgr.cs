using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransMgr : MonoBehaviour
{
    // Start is called before the first frame update
    private static TransMgr instance;
    private CanvasGroup Fade;
    private bool IsFade=false;
    public float FadeTime;
    public static TransMgr GetInstance()
    {
        if (instance == null)
        {
            GameObject obj = new GameObject();
            instance = obj.AddComponent<TransMgr>();
        }
        return instance;
    }

    private IEnumerator ChangeFade(float Tagrealpha)
    {
        IsFade = true;
        Fade.blocksRaycasts = true;
        float speed=Mathf.Abs(Fade.alpha-Tagrealpha)/FadeTime;
        while (!Mathf.Approximately(Fade.alpha,Tagrealpha))
        {
            Fade.alpha =Mathf.MoveTowards(Fade.alpha,Tagrealpha,speed*Time.deltaTime);
            yield return null;
        }
        Fade.blocksRaycasts = false;
        IsFade = false;
    }
    public void Translate(string From, string To)
    {
        if(!IsFade)
            StartCoroutine(TranstionToScene(From, To));
    }

    private IEnumerator TranstionToScene(string From, string To)
    {
        yield return ChangeFade(1);
        yield return SceneManager.UnloadSceneAsync(From);
        yield return SceneManager.LoadSceneAsync(To, LoadSceneMode.Additive);
        yield return ChangeFade(0);
        Scene newscene = SceneManager.GetSceneByName(To);
        SceneManager.SetActiveScene(newscene);
    }
    void Awake()
    {
        instance = this;
        Fade=GameObject.Find("Fade").GetComponent<CanvasGroup>();
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}