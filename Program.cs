// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());

    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    Random rnd = new();
    // create file
    StreamWriter sw = new("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:MM/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file
    string file = "data.txt";
    StreamReader sr = new(file);
    while (!sr.EndOfStream)
    {
        string? line = sr.ReadLine();
        string? linenumber = line.Substring(11);
        string[] arr = String.IsNullOrEmpty(linenumber) ? [] : linenumber.Split('|');

        //Datetime
        line = line.Substring(0, 10);
        string[] arr2 = String.IsNullOrEmpty(line) ? [] : line.Split('/');
        DateTime dateonly = new DateTime(Convert.ToInt32(arr2[2]), Convert.ToInt32(arr2[0]), Convert.ToInt32(arr2[1]));
        Console.WriteLine("Week of {0:MMM}, {0:dd}, {0:yyyy}", dateonly);

        Console.WriteLine("Su Mo Tu We Th Fr Sa");
        Console.WriteLine("-- -- -- -- -- -- --");
        Console.WriteLine("{0, 2} {1, 2} {2, 2} {3, 2} {4, 2} {5, 2} {6, 2}"
        , arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
    }
    sr.Close();

}