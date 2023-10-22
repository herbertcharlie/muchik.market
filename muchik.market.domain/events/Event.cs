﻿namespace muchik.market.domain.events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event() 
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
