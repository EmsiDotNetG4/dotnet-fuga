using AutoFixture;
using Mapster;
using MapsterMapper;

namespace EMSI.Fuga.Tests;

public class TestBase 
{
    protected IMapper Mapper { private set; get; }
    protected Fixture Fixture { private set; get; }
    protected TestBase()
    {
        //mapster
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(Registration).Assembly);
        Mapper = new Mapper(config);
        
        //fixture
        Fixture = new Fixture();
    }
}