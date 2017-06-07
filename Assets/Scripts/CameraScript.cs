using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform pt;
	public bool movX;
	public bool movY;
	public Transform canvas;
	bool onPause = false;
	bool pausing = false;

	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) && pausing == false) {
			if (onPause == false) {
				StartCoroutine (Pausing ());
			} else {
				StartCoroutine (UnPausing ());
			}
		}
		
		/*if ((transform.position.y - pt.position.y > 2 || pt.position.y - transform.position.y > 2) && transform.position.y >= 0) {
			transform.Translate (Vector3.Normalize (
				new Vector3 (
				Mathf.Abs (transform.position.x - pt.position.x), 
				Mathf.Abs (transform.position.y - pt.position.y)))
				*Time.deltaTime);
			cam.gameObject.transform.position = Vector3.Lerp (
				cam.gameObject.transform.position, 
				new Vector3 (pt.position.x, pt.position.y, cam.gameObject.transform.position.z), 
				1f);
		} else {
			transform.Translate (Vector3.Normalize (
				new Vector3 (Mathf.Abs (transform.position.x - pt.position.x), 0))
				*Time.deltaTime);
		}*/
		/*cam.gameObject.transform.position = Vector3.Lerp (
			cam.gameObject.transform.position, 
			new Vector3 (pt.position.x, cam.gameObject.transform.position.y, cam.gameObject.transform.position.z), 
			1f);*/
	}

	IEnumerator Pausing (){
		pausing = true;
		/*while (Time.timeScale > 0) {
			Time.timeScale -= 0.1f;
		}*/
		print ("batata");
		for (int i = 0; i <= 10; i++) {
			Time.timeScale = 1/(2^i); 
			yield return new WaitForSeconds (0.5f);
			print (i);
		}
		Time.timeScale = 0;
		canvas.gameObject.SetActive (true);
		pausing = false;
		onPause = true;
		yield return null;
	}

	IEnumerator UnPausing (){
		pausing = true;
		//canvas.gameObject.SetActive (false);
		/*while (Time.timeScale < 1) {
			Time.timeScale += 0.1f;
			//Time.fixedDeltaTime = Time.timeScale *
		}*/
		for (int i = 0; i < 10; i++) {
			Time.timeScale = i / 10; 
			yield return new WaitForSeconds (0.1f);
			print (i);
		}
		Time.timeScale = 1;
		canvas.gameObject.SetActive (false);
		pausing = false;
		onPause = false;
		yield return null;
	}

}
