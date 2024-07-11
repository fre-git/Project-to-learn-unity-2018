using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {

	public float rotationPeriod = 0.3f;		// Time for the next position
	public float sideLength = 1f;			// Length of Cube

	bool isRotate = false;					// Is Cube rotating now?
	float directionX = 0;					// Direction for rotation
	float directionZ = 0;					// Direction for rotation

	Vector3 startPos;						// Position before rotation
	float rotationTime = 0;					// past time for rotation
	float radius;							// Radius of the center of cube
	Quaternion fromRotation;				// Quaternion before rotation
	Quaternion toRotation;					// Quaternion after rotation

	// Use this for initialization
	void Start () {

		// Radius of the center of cube
		radius = sideLength * Mathf.Sqrt (2f) / 2f;

	}

	// Update is called once per frame
	void Update () {

		float x = 0;
		float y = 0;
		
		// key input
		x = Input.GetAxisRaw ("Horizontal");
		if (x == 0) {
			y = Input.GetAxisRaw ("Vertical");
		}


		// Key input AND cube is not rotating, rotate cube.
		if ((x == 1 || x == -1 || y == 1 || y == -1) && !isRotate) {
			directionX = y;																// 回転方向セット (x,yどちらかは必ず0)
			directionZ = x;																// 回転方向セット (x,yどちらかは必ず0)
			startPos = transform.position;												// 回転前の座標を保持
			fromRotation = transform.rotation;											// 回転前のクォータニオンを保持
			transform.Rotate (directionZ * 90, 0, directionX * 90, Space.World);		// 回転方向に90度回転させる
			toRotation = transform.rotation;											// 回転後のクォータニオンを保持
			transform.rotation = fromRotation;											// CubeのRotationを回転前に戻す。（transformのシャローコピーとかできないんだろうか…。）
			rotationTime = 0;															// 回転中の経過時間を0に。
			isRotate = true;															// 回転中フラグをたてる。
		}
	}

	void FixedUpdate() {

		if (isRotate) {

			rotationTime += Time.fixedDeltaTime;									// 経過時間を増やす
			float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);			// 回転の時間に対する今の経過時間の割合

			// Move
			float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);					// 回転角をラジアンで。
			float distanceX = -directionX * radius * (Mathf.Cos (45f * Mathf.Deg2Rad) - Mathf.Cos (45f * Mathf.Deg2Rad + thetaRad));		// X軸の移動距離。 -の符号はキーと移動の向きを合わせるため。
			float distanceY = radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin (45f * Mathf.Deg2Rad));						// Y軸の移動距離
			float distanceZ = directionZ * radius * (Mathf.Cos (45f * Mathf.Deg2Rad) - Mathf.Cos (45f * Mathf.Deg2Rad + thetaRad));			// Z軸の移動距離
			transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);						// 現在の位置をセット

			// Rotate
			transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);		

			// initialize parameters
			if (ratio == 1) {
				isRotate = false;
				directionX = 0;
				directionZ = 0;
				rotationTime = 0;
			}
		}
	}
}