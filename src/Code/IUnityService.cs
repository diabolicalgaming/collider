using UnityEngine;

/// <summary>
/// Citation: -https://www.youtube.com/watch?v=MGx5mb5b3sY&t=323s
/// The above link helped me to understand the use of dependency injectors for Unit Testing.
/// The IUnityService interface and UnityService class is derived from the above link I have cited.
/// They act as dependency injectors that allow me to carry out Unit Tests on classes that inherit from
/// Unity's Monobehaviour interface. I added two functions on top of the ones already defined in the video,
/// GetTime() and GetForward(). Note that the IUnityService interface and UnityService class are not part of Unity's API.
/// </summary>

public interface IUnityService
{
    float GetDeltaTime();
    float GetTime();
    float GetAxisRaw(string axisName);
    Vector3 GetForward();
}

public class UnityService : IUnityService
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public float GetTime()
    {
        return Time.time;
    }

    public float GetAxisRaw(string axisName)
    {
        return Input.GetAxisRaw(axisName);
    }

    public Vector3 GetForward()
    {
        return Vector3.forward;
    }
}
