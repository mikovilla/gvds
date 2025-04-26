using gvds.Application;

List<(int start, int end)> tupleOfActivities = new List<(int, int)>
{
    (1, 4),
    (3, 5),
    (0, 6),
    (5, 7),
    (8, 9),
    // (5, 9) // remove for benchmark comparison versus HashMap
};

GreedySearch.FromTuple(tupleOfActivities);

Console.WriteLine("\r\n");

Dictionary<int, int> hashMapOfActivities = new Dictionary<int, int>
{
    {1, 4},
    {3, 5},
    {0, 6},
    {5, 7},
    {8, 9},
    // {5,9} // remove duplicate keys
};

GreedySearch.FromHashMap(hashMapOfActivities);

Console.WriteLine("\r\n");

List<Activity> activities = new List<Activity>
{
    new Activity { Start = 1, End = 4 },
    new Activity { Start = 3, End = 5 },
    new Activity { Start = 0, End = 6 },
    new Activity { Start = 5, End = 7 },
    new Activity { Start = 8, End = 9 },
    // new Activity { Start = 5, End = 9 } // remove for benchmark comparison versus HashMap
};

GreedySearch.FromActivityList(activities);