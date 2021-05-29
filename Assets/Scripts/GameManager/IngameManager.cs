using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public PlayerModellBehaviour player;
    public readonly Transform[] PlayerWaypoints = new Transform[14];
    private int waypointCounter = 0;
    private readonly List<TimedEvent> timedEvents = new List<TimedEvent>();
    private readonly List<TimedEvent> toBeRemoved = new List<TimedEvent>();

    private abstract class TimedEvent
    {
        private float timeToEvent;

        protected TimedEvent(float timeToEvent)
        {
            this.timeToEvent = timeToEvent;
        }


        public bool Update()
        {
            timeToEvent -= Time.deltaTime;
            if (timeToEvent < 0)
            {
                Execute();
                return true;
            }
            return false;
        }

        protected abstract void Execute();
    }

    private class DelayedPlayerMovement : TimedEvent
    {
        private readonly PlayerModellBehaviour playerChar;

        public DelayedPlayerMovement(float timeToEvent, PlayerModellBehaviour playerChar) : base(timeToEvent) {
            this.playerChar = playerChar;
        }

        protected override void Execute()
        {
            playerChar.FollowTarget(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SendPlayerToNextWaypoint(false);
        timedEvents.Add(new DelayedPlayerMovement(3f, player));
    }

    // Update is called once per frame
    void Update()
    {
        foreach(TimedEvent ev in timedEvents)
        {
            bool wasExecuted = ev.Update();

            if (wasExecuted)
            {
                toBeRemoved.Add(ev);
            }
        }
        foreach (TimedEvent rem in toBeRemoved)
        {
            timedEvents.Remove(rem);
        }
        toBeRemoved.Clear();

    }

    private void SendPlayerToNextWaypoint(bool follow = true)
    {
        player.SetTarget(PlayerWaypoints[waypointCounter], follow);
        waypointCounter++;
    }
}
