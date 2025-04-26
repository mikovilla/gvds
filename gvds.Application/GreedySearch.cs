using System.Diagnostics;

namespace gvds.Application
{
    public class Activity
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    public static class GreedySearch
    {
        public static void FromTuple(List<(int start, int end)> activities)
        {
            // Ensure randomness of datastructure
            Random random = new Random();
            activities = activities.OrderBy(_ => random.Next()).ToList();
            Console.WriteLine("Randomized tuples: " + string.Join(", ", activities.Select(a => $"({a.start},{a.end})")));

            activities = activities.OrderBy(a => a.end).ToList();
            Console.WriteLine("Sorted by earliest finishing time (greedy step): " + string.Join(", ", activities.Select(a => $"({a.start},{a.end})")));

            List<(int start, int end)> selectedActivities = new List<(int, int)>();
            int lastEndTime = -1;
            bool firstPick = true;

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var activity in activities)
            {
                if (!IsOverlap(activity.start, activity.end, ref lastEndTime, firstPick))
                {
                    selectedActivities.Add(activity);
                    lastEndTime = activity.end;
                }
                firstPick = false;
            }
            Console.WriteLine($"Tuple ran for {stopwatch.ElapsedNanoSeconds()} nanoseconds");

            Console.WriteLine("Selected Activities: " + string.Join(", ", selectedActivities.Select(a => $"({a.start}, {a.end})")));
            Console.WriteLine("Maximum number of non-overlapping activities: " + selectedActivities.Count);
        }

        public static void FromHashMap(Dictionary<int, int> activities)
        {
            Random random = new Random();
            activities = activities.OrderBy(_ => random.Next()).ToDictionary(a => a.Key, a => a.Value);
            Console.WriteLine("Randomized HashMap: " + string.Join(", ", activities.Select(a => $"({a.Key},{a.Value})")));

            activities = activities.OrderBy(a => a.Value).ToDictionary(a => a.Key, a => a.Value);

            List<(int start, int end)> selectedActivities = new List<(int start, int end)>();
            int lastEndTime = -1;
            bool firstPick = true;

            Console.WriteLine("Sorted by earliest finishing time (greedy step): " + string.Join(", ", activities.Select(a => $"({a.Key},{a.Value})")));

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var activity in activities)
            {
                if (!IsOverlap(activity.Key, activity.Value, ref lastEndTime, firstPick))
                {
                    selectedActivities.Add((activity.Key, activity.Value));
                    lastEndTime = activity.Value;
                }
                firstPick = false;
            }
            Console.WriteLine($"HashMap ran for {stopwatch.ElapsedNanoSeconds()} nanoseconds");

            Console.WriteLine("Selected Activities: " + string.Join(", ", selectedActivities.Select(a => $"({a.start}, {a.end})")));
            Console.WriteLine("Maximum number of non-overlapping activities: " + selectedActivities.Count);
        }

        public static void FromActivityList(List<Activity> activities)
        {
            Random random = new Random();
            activities = activities.OrderBy(_ => random.Next()).ToList();
            Console.WriteLine("Randomized Activities: " + string.Join(", ", activities.Select(a => $"({a.Start},{a.End})")));

            activities = activities.OrderBy(a => a.End).ToList();

            List<Activity> selectedActivities = new List<Activity>();
            int lastEndTime = -1;
            bool firstPick = true;

            Console.WriteLine("Sorted by earliest finishing time (greedy step): " + string.Join(", ", activities.Select(a => $"({a.Start},{a.End})")));

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var activity in activities)
            {
                if (!IsOverlap(activity.Start, activity.End, ref lastEndTime, firstPick))
                {
                    selectedActivities.Add(activity);
                    lastEndTime = activity.End;
                }
                firstPick = false;
            }
            Console.WriteLine($"Custom Activity Class ran for {stopwatch.ElapsedNanoSeconds()} nanoseconds");

            Console.WriteLine("Selected Activities: " + string.Join(", ", selectedActivities.Select(a => $"({a.Start}, {a.End})")));
            Console.WriteLine("Maximum number of non-overlapping activities: " + selectedActivities.Count);
        }

        private static bool IsOverlap(int activityStart, int activityEnd, ref int lastEndTime, bool firstPick)
        {
            if (activityStart >= lastEndTime)
            {
                if (!firstPick)
                {
                    Console.WriteLine($"({activityStart},{activityEnd}) does not overlap because {activityStart} >= {lastEndTime}");
                }
                else
                {
                    Console.WriteLine($"First Pick on the list is ({activityStart},{activityEnd}), with lastEndTime = {lastEndTime}");
                }
                return false;
            }
            else
            {
                Console.WriteLine($"({activityStart},{activityEnd}) is skipped because {activityStart} < {lastEndTime}");
                return true;
            }
        }

        private static long ElapsedNanoSeconds(this Stopwatch stopwatch)
        {
            return stopwatch.ElapsedTicks * (1_000_000_000L / Stopwatch.Frequency);
        }
    }
}
