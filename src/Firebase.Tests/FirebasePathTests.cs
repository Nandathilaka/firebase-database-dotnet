namespace FireBase.Tests
{
    using Firebase;
    using Firebase.Query;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FirebasePathTests
    {
        public const string BasePath = "http://base.path.net";
        public const string Token = "abcefgh";

        [TestMethod]
        public void TestAuthPath()
        {
            var client = new FirebaseClient(BasePath);

            var path = client.Child("resource").WithAuth(Token).BuildUrl();

            path.Should().BeEquivalentTo($"{BasePath}/resource/.json?auth={Token}");
        }

        [TestMethod]
        public void TestNestedAuthPath()
        {
            var client = new FirebaseClient(BasePath);

            var path = client.Child("resource").OrderByKey().WithAuth(Token).BuildUrl();

            path.Should().BeEquivalentTo($"{BasePath}/resource/.json?orderBy=\"$key\"&auth={Token}");
        }
    }
}
