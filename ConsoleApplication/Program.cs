using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApplication
{
    public class User
    {
        public event EventHandler handler;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            User user = new User();

            user.handler += (s, e) => Console.WriteLine("asd");

            EventHandler h = EventAsd<User>.Clone(user, "handler");

            h?.Invoke(null, null);
        }
    }

    public static class EventAsd<T>
    {
        public static EventHandler Clone(T value, string eventName)
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
    }
}