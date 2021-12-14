using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

[Route("api/[controller]")]
[ApiController]
public class Neo4jController : ControllerBase
{
    private readonly IDriver _driver;

    public Neo4jController()
    {
        _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "juice"));   
    }

    [HttpPost]
    public async Task<IActionResult> CreateNode(string name)
    {
        var statementText = new StringBuilder();
        statementText.Append("CREATE (person:Person {name: $name})");
        var statementParameters = new Dictionary<string, object>
        {
            {"name", name }
        };

        var session = this._driver.AsyncSession();
        var result = await session.WriteTransactionAsync(tx => tx.RunAsync(statementText.ToString(),  statementParameters));
        return StatusCode(201, "Node has been created in the database");
    }

    [HttpGet]
    public async Task<IActionResult> GetNode(string name)
    {
        var statementText = new StringBuilder();
        statementText.Append("CREATE (person:Person {name: $name})");
        var statementParameters = new Dictionary<string, object>
        {
            {"name", name }
        };

        var session = this._driver.AsyncSession();
        var result = await session.WriteTransactionAsync(tx => tx.RunAsync(statementText.ToString(),  statementParameters));
        return StatusCode(201, "Node has been created in the database");
    }
}