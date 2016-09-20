using System;
using System.Linq;
using System.Reflection;

namespace SandS.Algorithm.Extensions.EventHandlerNamespace
{
    public static class EventHandlerExtension
    {
        #region Public Methods

        /// <summary>
        /// Returns copy of EventHandler using reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">This object contains EventHandler field or prop</param>
        /// <param name="eventName">This is EventHandler field or prop name, contains in the value. If there's no event with name like this, return null</param>
        /// <returns></returns>
        public static EventHandler GetEventHandlerFromEvent<T>(T value, string eventName)
        {
            Type type = value.GetType();
            EventInfo eventInfo = type.GetEvent(eventName);

            if (eventInfo == null)
            {
                return null;
            }

            FieldInfo fieldInfo = type.GetField(eventInfo.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty);

            if (fieldInfo == null)
            {
                return null;
            }

            Delegate fieldDelegate = fieldInfo.GetValue(value) as Delegate;

            if (fieldDelegate == null)
            {
                return null;
            }

            EventHandler handler = fieldDelegate.GetInvocationList().FirstOrDefault() as EventHandler;

            return handler;
        }

        #endregion Public Methods
    }
}