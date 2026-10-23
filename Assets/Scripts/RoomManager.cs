using System;
using System.Collections.Generic;
using UnityEngine;
public enum Room
{
    North,
    East,
    South,
    West
}

public readonly struct RoomData
{
    private const float PositionTolerance = 0.01f;

    public readonly Quaternion Rotation;
    public readonly Vector3 DefaultPosition;
    public readonly Vector3 ZoomPosition;

    public RoomData(Quaternion rotation, Vector3 zoomPosition)
    {
        Rotation = rotation;
        DefaultPosition = new Vector3(0f, 2f, -2f);
        ZoomPosition = zoomPosition;
    }

    public bool IsAtZoomPosition(Vector3 position) =>
        (position - ZoomPosition).sqrMagnitude <= PositionTolerance * PositionTolerance;

    public bool IsAtDefaultPosition(Vector3 position) =>
        (position - DefaultPosition).sqrMagnitude <= PositionTolerance * PositionTolerance;
}

public static class RoomManager
{
    
    public static bool IsZoomedIn(Room room, Vector3 position) =>
        Get(room).IsAtZoomPosition(position);
    public static bool IsAtDefaultPosition(Vector3 position) =>
        Get(Room.North).IsAtDefaultPosition(position);
    
    private static readonly Dictionary<Room, RoomData> rooms = new()
    {
        { Room.North, new RoomData(Quaternion.Euler(0f, 0f,   0f), new Vector3( 0f, 2f,  3f)) },
        { Room.East,  new RoomData(Quaternion.Euler(0f, 90f,  0f), new Vector3( 5f, 2f, -2f)) },
        { Room.South, new RoomData(Quaternion.Euler(0f, 180f, 0f), new Vector3( 0f, 2f, -7f)) },
        { Room.West,  new RoomData(Quaternion.Euler(0f, 270f, 0f), new Vector3(-5f, 2f, -2f)) },
    };

    private static readonly int roomCount = Enum.GetValues(typeof(Room)).Length;

    public static RoomData Get(Room room) => rooms[room];
    
    public static IEnumerable<RoomData> All => rooms.Values;

    public static Room Next(Room room) => (Room)(((int)room + 1) % roomCount);

    public static Room Previous(Room room) => (Room)(((int)room + roomCount - 1) % roomCount);}