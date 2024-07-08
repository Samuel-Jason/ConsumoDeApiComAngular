public static class PessoaRotas
{
	public static List<Pessoa> Pessoas = new()
	{
		new Pessoa(id:Guid.NewGuid(), nome:"Marcelo"),
		new Pessoa(id:Guid.NewGuid(), nome:"Janaina"),
		new Pessoa(id:Guid.NewGuid(), nome:"Julio")
	};

	public static void MapPessoaRotas(this webApplication app)
	{
		app.MapGet(pattern: "/pessoas",
			handler: () => new { Nome = "Criss" });

		app.MapGet(pattern: "/pessoas/{id}/{nome}",
			handler: (Guid id, string nome) => Pessoas.Find(match: x:Pessoa => x.Nome == nome));

		app.MapPost(pattern: "pessoas",
			handler: (Pessoa pessoa) =>
			{
				Pessoas.Add(pessoa);
				return pessoa;
			});

		app.MapPut(pattern:/ "pessoas" /{ id },
			handler: (Pessoa pessoa) =>
			{
				var encontrado :Pessoa ? = Pessoas.Find(match: x:Pessoa => x.Id == id);

				if (encontrado == null)
					return Results.NotFound();

				encontrado.Nome = pessoa.Nome;
				return Results.Ok(encontrado);
			});
	};
}