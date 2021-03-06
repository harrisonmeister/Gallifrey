﻿using System;
using System.Diagnostics;
using Gallifrey.ExtensionMethods;
using Newtonsoft.Json;

namespace Gallifrey.IdleTimers
{
    public class IdleTimer
    {
        public DateTime DateStarted { get; private set; }
        public DateTime? DateFinished { get; private set; }
        public TimeSpan CurrentTime { get; private set; }
        public Guid UniqueId { get; private set; }
        public bool IsRunning { get; private set; }
        private readonly Stopwatch currentRunningTime;

        [JsonConstructor]
        public IdleTimer(DateTime dateStarted, DateTime? dateFinished, TimeSpan currentTime, Guid uniqueId)
        {
            DateStarted = dateStarted;
            DateFinished = dateFinished;
            CurrentTime = currentTime;
            UniqueId = uniqueId;
            currentRunningTime = new Stopwatch();
            IsRunning = false;
        }

        public IdleTimer()
        {
            DateStarted = DateTime.Now;
            DateFinished = null;
            CurrentTime = new TimeSpan();
            UniqueId = Guid.NewGuid();
            currentRunningTime = new Stopwatch();
            currentRunningTime.Start();
            IsRunning = true;
        }

        public TimeSpan ExactCurrentTime
        {
            get { return CurrentTime.Add(currentRunningTime.Elapsed); }
        }

       public void StopTimer()
       {
           DateFinished = DateTime.Now;
            currentRunningTime.Stop();
            CurrentTime = CurrentTime.Add(currentRunningTime.Elapsed);
            currentRunningTime.Reset();
            IsRunning = false;
        }

       public override string ToString()
       {
           return DateFinished.HasValue ? 
               string.Format("Date - {0} - From [ {1} ] To [ {2} ] - Time [ {3} ]", DateStarted.ToString("ddd, dd MMM"), DateStarted.ToString("HH:mm:ss"), DateFinished.Value.ToString("HH:mm:ss"), ExactCurrentTime.FormatAsString()) : 
               string.Format("Date - {0} - From [ {1} ] To [ IN PROGRESS ] - Time [ {2} ]", DateStarted.ToString("ddd, dd MMM"), DateStarted.ToString("HH:mm:ss"), ExactCurrentTime.FormatAsString());
       }
    }
}
