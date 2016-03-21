namespace _01.ReformatCode
{
    using System.Text;

    public static class Messages
    {
        private static readonly StringBuilder Output = new StringBuilder();

        public static void EventAdded()
        {
            Output.Append("Event added\n");
        }

        public static void EventDeleted(int eventId)
        {
            if (eventId == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} events deleted\n", eventId);
            }
        }

        public static void NoEventsFound()
        {
            Output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint + "\n");
            }
        }
    }
}