Desafio Texto IT

- Ao rodar o projeto, será verificado se o banco de dados está vazio e nesse caso será importado os dados do arquivo CSV.

- Foi adicionado o componente swagger no projeto, para que facilite o mapeamento e validação dos métodos criados. Para acesso o link é https://localhost:44341/swagger/index.html

- Foram criados métodos de CRUD básico para a entidade Award, que é a entidade de indicados e que é gravada no banco de dados. 
As rotas criadas foram: 
	Rota para consulta por id (GET):
	https://localhost:44341/award/get/{id}
	
	Rota para consulta de todos os registros (GET):
	https://localhost:44341/award/getall
	
	Rota para adicionar um novo registro (POST):
	https://localhost:44341/award/add
	
	Rota para alterar um registro (PUT):
	https://localhost:44341/award/update
	
	Rota para deletar um registro (DELETE):
	https://localhost:44341/award/delete/{id}
	
	Rota para remover todos os registros (DELETE):
	https://localhost:44341/award/deleteall

- Para o envio de um novo arquivo CSV, foi criada a rota (POST) https://localhost:44341/file/read

- Para que a API encontre o maior e menor intervalo entre os prêmios do mesmo produtor, foi criada a rota (GET) https://localhost:44341/search/searchminmax

- Foi criado um pequeno teste de integração para validar o método que busca os intervalos entre premiações por produtores estão corretos conforme os dados fornecidos.
