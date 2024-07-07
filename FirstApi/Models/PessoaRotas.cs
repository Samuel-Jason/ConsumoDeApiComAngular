public static class PessoaRotas
{
	public static List<Pessoa> Pessoas = new ()
	{
		new Pessoa(id:Guid.NewGuid(), nome:"Marcelo"),
		new Pessoa(id:Guid.NewGuid(), nome:"Janaina"),
		new Pessoa(id:Guid.NewGuid(), nome:"Julio")
	};

	public static void MapPessoaRotas(this webApplication app)
	{
		app.MapGet(
			pattern: "/pesoas", 
			handler: () => new { Nome = "Criss" }
		);
	};
}