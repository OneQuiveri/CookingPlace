using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed on application quit.");
                return null;
            }

            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();

                if (instance == null)
                {
                    Debug.LogError($"[Singleton] No instance of {typeof(T)} found in the scene.");
                }
                else
                {
                    DontDestroyOnLoad(instance.gameObject);
                }
            }

            return instance;
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            applicationIsQuitting = true;
        }
    }
}
