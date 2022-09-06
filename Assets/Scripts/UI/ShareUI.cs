using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShareUI : MonoBehaviour
{
    [SerializeField] private Text totalScore;
    [SerializeField] private Text recordScore;
    [SerializeField] private Text date;
    [SerializeField] private Text gameOverTotalScore;
	[SerializeField] private Text gameOverRecordScore;
	[SerializeField] private GameObject shareCanvas;

    public void ShareScore()
    {
        totalScore.text = gameOverTotalScore.text;
		recordScore.text = gameOverRecordScore.text;
        DateTime now = DateTime.Now;

        date.text = string.Format("{0}/{1}/{2}", now.Day, now.Month, now.Year);

        shareCanvas.SetActive(true);
		StartCoroutine(nameof(TakeScreenShotAndShare));
	}

	IEnumerator TakeScreenShotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		texture.Apply();

		string path = Path.Combine(Application.temporaryCachePath, "sharedImage.png");
		File.WriteAllBytes(path, texture.EncodeToPNG());

		Destroy(texture);

		new NativeShare()
			.AddFile(path)
			.SetSubject("This is my score")
			.SetText("share your score with your friends")
			.Share();


		shareCanvas.SetActive(false);
	}
}
