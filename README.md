## A demanda
Você deverá criar duas API's uma com dois endpoints e outra com um endpoint

#### API 1
##### Taxa de juros

Responde pelo path relativo `/taxaJuros`, retorna o juros de `1%` ou `0,01` (fixo no código).
```sh 
Exemplo: /taxaJuros 
Resultado esperado: 0,01**
```

#### API 2
##### Calcula juros
Responde pelo path relativo `/calculajuros`
Faz um cálculo em memória, de juros compostos, conforme abaixo: 
> Valor Final = Valor Inicial * (1 + juros) ^ Tempo

- **Valor inicial** é um decimal recebido como parâmetro. Valor do juros deve ser consultado na API 1.
- ***Tempo*** é um inteiro, que representa meses, também recebido como parâmetro.
- **^** representa a operação de potência.

Resultado final deve ser truncado (sem arredondamento) em duas casas decimais.
```sh 
Exemplo: /calculajuros?valorinicial=100&meses=5 
Resultado esperado: 105,10
```
##### Show me the code
Responde pelo path relativo `/showmethecode`, retornar a url de onde encontra-se o fonte no github.

## Esperado
- Fonte em asp.net core no github (Mostrar conhecimento básico de git)
- Teste unitários (Mostrar conhecimento de testes unitários, se possível TDD)

## Extras
- Utilização de Docker
- Teste de integração da API em linguagem de sua preferência (Damos importância para pirâmide de testes)
- Utilizar swagger

___
Para testar o que foi desenvolvido.
---
##### Criação do contêiner Docker
Para implantar o contêiner e executar a imagem do Docker, basta rodar o comando abaixo pelo terminal
```sh 
cd src
docker-compose up --build -d
```

***Obs: Como eu não tenho mais nenhuma aplicação rodando no meu host, eu configurei para o Docker rodar a imagem na porta 80***
##### Swagger
Para testar a documentação do swagger, após rodar a imagem da api basta acessar o endereço `http://localhost/api/docs`.