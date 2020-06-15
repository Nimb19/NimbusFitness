﻿using System;
using NimbusFitness.BL.Model;

namespace NimbusFitness.BL.Controller
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // TODO: Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

        public override string ToString()
        {
            return Activity.Name;
        }
    }
}