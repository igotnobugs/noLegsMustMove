using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject {
    public Script[] scripts;
}

[System.Serializable]
public class Script {

    [TextArea(3, 10)]
    public string sentence;
    public float time;
}