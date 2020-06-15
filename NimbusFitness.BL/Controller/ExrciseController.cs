using System;
using System.Collections.Generic;
using System.Linq;
using NimbusFitness.BL.Model;

namespace NimbusFitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user; 
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("user не может быть пустым.", nameof(user));

            Exercises = GetAllExercise();
            Activities = GetAllActivities();
        }

        public void AddExercise(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.FirstOrDefault(x => x.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            SaveAll();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>();
        }

        private List<Exercise> GetAllExercise()
        {
            return Load<Exercise>();
        }

        private void SaveAll()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
