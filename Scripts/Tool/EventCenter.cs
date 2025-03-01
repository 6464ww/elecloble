using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tool
{
   public class EventCenter : BaseSingleMono<EventCenter>
   {
      private readonly Dictionary<string, UnityAction> _events = new Dictionary<string, UnityAction>();

      public void AddEvent(string eventName, UnityAction callback)
      {
         if (!_events.TryAdd(eventName, callback))
         {
            _events[eventName] += callback;
         }
      }

      public void RemoveEvent(string eventName, UnityAction callback)
      {
         if (_events.ContainsKey(eventName))
         {
            _events[eventName] -= callback;
         }
         else
         {
            Debug.Log("No Found Event");
         }
      }

      public void RemoveAllEvents()
      {
         _events.Clear();
      }

      public void TriggerEvent(string eventName)
      {
         if (_events.TryGetValue(eventName, out var @event))
         {
            @event?.Invoke();
         }
      }
   }
}
