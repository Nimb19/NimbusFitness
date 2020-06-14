using System;
using System.Collections.Generic;
using System.Linq;
using NimbusFitness.BL.Model;

namespace NimbusFitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user; 
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
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
            var act = Activities.SingleOrDefault(x => x.Name == activity.Name);

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
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercise()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private void SaveAll()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
