#define Log
using UnityEngine;

public static class DebugLog
{
    public static void Log(object message)
    {
#if Log
        Debug.Log(message);
#endif
    }
    public static void Log(object message, Object context) {
#if Log
        Debug.Log(message, context);
#endif
    }
    public static void LogError(object message, Object context) {
#if Log
        Debug.LogError(message, context);
#endif
    }
    public static void LogError(object message) {
#if Log
        Debug.LogError(message);
#endif
    }
    public static void LogWarning(object message, Object context) {
#if Log
        Debug.LogWarning(message, context);
#endif
    }
    public static void LogWarning(object message) {
#if Log
        Debug.LogWarning(message);
#endif
    }
}
