using UnityEngine;

namespace Tool
{
    public class BaseSingleMono<T>: MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public void Awake()
        {
            Debug.Log("init"+ToString());
            _instance = this as T;
        }
        public static T GetInstance()
        {
            if (!_instance)
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<T>();
            }
            return _instance;
        }

    
    }
}
