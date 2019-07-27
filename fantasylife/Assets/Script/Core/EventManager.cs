using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface EventListener {
    void HandleEvent(GameEvent e);
}

public enum GameEventType {
    RUNOUT_STATUS,
}

public class GameEvent {
    public GameEventType type;

    public readonly object[] args = new object[2];

    private static readonly List<GameEvent> pool = new List<GameEvent>();

    public static GameEvent Get(GameEventType type, object arg0 = null, object arg1 = null) {
        GameEvent e;

        lock (pool) {
            if (pool.Count == 0) {
                e = new GameEvent();
            } else {
                e = pool[0];
                pool.RemoveAt(0);
            }
        }

        //
        e.type = type;
        e.args[0] = arg0;
        e.args[1] = arg1;

        return e;
    }

    private GameEvent() {
    }

    private GameEvent(GameEventType type, object arg0 = null, object arg1 = null) {
        this.type = type;
        this.args[0] = arg0;
        this.args[1] = arg1;
    }
}

public class EventManager {
    private List<EventListener> lstListener = new List<EventListener>();

    public void AddListener(EventListener l) {
        if (lstListener.Contains(l))
            return;
        lstListener.Add(l);
    }

    public bool RemoveListener(EventListener l) {
        return lstListener.Remove(l);
    }

    public void DispatchEvent(GameEvent e) {
        foreach (var listener in lstListener) {
            try {
                listener.HandleEvent(e);
            } catch(Exception ex) {
                Debug.LogException(ex);
            }
        }
    }

    public void DispatchEvent(GameEventType type, object arg0 = null, object arg1 = null) {
        DispatchEvent(GameEvent.Get(type, arg0, arg1));
    }
}
