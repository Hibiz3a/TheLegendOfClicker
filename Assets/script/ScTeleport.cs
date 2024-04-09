using UnityEngine;

public class ScTeleport : MonoBehaviour {
    public int x,y;
    public GameObject image;
    public int timeAdd;

    public void ChangePos() {
        ScAudioManager.Instance.PlayRandomSFX(ScAudioManager.Instance.clics);
        x = Random.Range(-1, 1921);
        y = Random.Range(-1, 1081);
        image.transform.position = new Vector2((float)x, (float)y);
        ScTimerN.Instance.AddTime(timeAdd);
    }
}
