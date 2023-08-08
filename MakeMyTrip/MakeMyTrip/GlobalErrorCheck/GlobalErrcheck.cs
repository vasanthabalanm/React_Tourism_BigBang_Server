namespace MakeMyTrip.GlobalErrorCheck
{
    public class GlobalErrcheck
    {
        public static Dictionary<string, string> ExceptionMessages { get; } =
        new Dictionary<string, string>
        {
                { "NoId", "Id is not matched.Try Again" },
                { "NoLocate", "No Locations were found.Try Again" },
                { "NoSpot", "No Spots were found.Try Again" },
                { "Empty", "This Entry cannot be null" },
                { "NoUpdate", "No value is Updated" }
        };
    }
}
