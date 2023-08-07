using System.Net.NetworkInformation;
using FluentAssertions;
using FluentAssertions.Collections;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using Xunit;

namespace NetworkUtility.Tests.PingTests;

public class NetworkServiceTests
{
    private readonly NetworkService _pingService;
    public NetworkServiceTests()
    {
        //SUT
        _pingService = new NetworkService();
    }
    public void NetworkService_SendPing_ReturnString()
    {
        //Arrange - variables, classes, mocks
        // var pingService = new NetworkService();

        //Act
        var result = _pingService.SendPing();

        //Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Success", Exactly.Once());

    }

    [Xunit.Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_PingTimeout_ReturnInt(int a, int b, int excepted)
    {
        //Arrange
        var pingService = new NetworkService();

        //Act
        var result = pingService.PingTimeout(a, b);

        //Assert
        result.Should().Be(excepted);
        result.Should().BeGreaterThanOrEqualTo(2);
        result.Should().NotBeInRange(-10000, 0);

    }
    [Fact]
    public void NetworkService_LastPingDate_ReturnDate()
    {
        //Arrange - variables, classes, mocks
        // var pingService = new NetworkService();

        //Act
        var result = _pingService.LastPingDate();

        //Assert
        result.Should().BeAfter(1.January(2010));
        result.Should().BeBefore(1.January(2030));

    }

    [Fact]
    public void NetworkSerice_GetPingOptions_RetursObject()
    {
        //Arrange
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };

        //Act
        var result = _pingService.GetPingOptions();

        //Assert WARNING: "Be Careful"
        result.Should().BeOfType<PingOptions>();
        result.Should().BeEquivalentTo(expected);
        result.Ttl.Should().Be(1);
    }

    [Fact]
    public void NetworkSerice_MostRecentPings_RetursObject()
    {
        //Arrange
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };

        //Act
        var result = _pingService.GetPingOptions();

        //Assert WARNING: "Be Careful"
        result.Should().BeOfType<IEnumerable<PingOptions>>();
        result.Should().ContainEquivalentOf(expected);
        result.Should().Contain
    }
} 