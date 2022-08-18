namespace DatingFoss.Server.IntegrationTests.TestUtils.QueryBuilders
{
    public static class UserQueryBuilder
    {
        public static Dictionary<string, string?> BuildGetUserQueryParameters(string username) => new()
        {
            ["username"] = username,
        };
    }
}
