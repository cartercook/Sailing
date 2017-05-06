using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour {
	// reference to the Unity standard assets water tile
	public GameObject waterTilePrefab;

	const float TILE_SIZE = 50;
	const float HALF_TILE_SIZE = TILE_SIZE / 2; // half the width/height of the tile

	Transform[,] tiles;

	// IDEA:
	// store the tiles in a 2D array.
	// When cameraPos.x/TILE_SIZE > prevCameraPos.x/TILE_SIZE
	// move all the tiles (and their positions) to the other end of the array

	void Start () {
		// enough space to fill the area surrounding the camera with tiles
		int size = (int)(Camera.main.farClipPlane / HALF_TILE_SIZE);
		tiles = new Transform[size, size];
		for (int x = 0; x < tiles.GetLength(0); x++) {
			for (int y = 0; y < tiles.GetLength(1); y++) {
				tiles[x,y] = Instantiate(waterTilePrefab, transform.GetChild(0)).transform;
			}
		}
		
		
		
		// get start tiles
		transform.GetChild(0).GetComponentInChildren<Transform>();
	}
	
	// The tiles array occupies a square area in the world.
	void Update () {
		// Upper Left corner of the square area is -Vector3.one*Camera.main.farClipPlane away from camera
		Vector3 UL = Camera.main.transform.position - Vector3.one*Camera.main.farClipPlane;
		
		//round to nearest TILE_SIZE
		UL = new Vector3(Mathf.Round(UL.x/TILE_SIZE)*TILE_SIZE,
						 0,
						 Mathf.Round(UL.z/TILE_SIZE)*TILE_SIZE
		);



		for (int x = 0; x < tiles.GetLength(0); x++) {
			for (int y = 0; y < tiles.GetLength(1); y++) {
				tiles[x, y].position = UL + new Vector3(x*TILE_SIZE, 0, y*TILE_SIZE);
			}
		}
	}
}
