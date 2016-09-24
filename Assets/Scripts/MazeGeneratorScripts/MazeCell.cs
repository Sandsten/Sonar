﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeCell : MonoBehaviour {

    public IntVector2 coordinates;
    private int initializedEdgeCount;
    public MazeRoom room;
    private GameObject decor;
    public MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

    public MazeCellEdge GetEdge(MazeDirection direction) {
        return edges[(int)direction];
    }

    public List<MazeCell> getNeighbours() {
        List<MazeCell> neighbours = new List<MazeCell>();
        for (int i = 0; i < MazeDirections.Count; ++i) {
            // Fixa - filtrera bort grannar som blockerade av vägg
            neighbours.Add(edges[i].otherCell);
        }
        return neighbours;
    }

    public void Initialize(MazeRoom room, bool decoration) {
        room.Add(this);
        if (decoration && room.settings.Decor.Length > 0){
            decor = Instantiate(room.settings.Decor[Random.Range(0,room.settings.Decor.Length-1)]);
            decor.transform.parent = transform;
            decor.transform.position = transform.position;
        }
        transform.GetChild(0).GetComponent<Renderer>().material = room.settings.floorMaterial;
    }

    public void SetEdge(MazeDirection direction, MazeCellEdge edge) {
        edges[(int)direction] = edge;
        initializedEdgeCount += 1;
    }

    public bool IsFullyInitialized {
        get {
            return initializedEdgeCount == MazeDirections.Count;
        }
    }

    public MazeDirection RandomUninitializedDirection {
        get {
            int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
            for (int i = 0; i < MazeDirections.Count; i++) {
                if (edges[i] == null) {
                    if (skips == 0) {
                        return (MazeDirection)i;
                    }
                    skips -= 1;
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
        }
    }
}
