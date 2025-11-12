- Para quem tiver problema na hora do commit

git config --global http.postBuffer 524288000

# Duas Partes 
1. BackEnd em .NET
2. FrondEns em HTML/CSS/JavaScript

# Trabalhando em Grupo

Caso você os dois alunos queiram desenvolver em conjunto, precisamos usar o `git`
Ele irá permitir com que façamos versionamento de código

após criar o repositório, podemos começar a trabalhar com essa tecnologia

<br />


1. Na branch main escrevemos o comenado `git checkout -b nome_da_nova_branch` <!-- Isso permiti com que criemos uma nova branch (tendo como origin a nossa branch main) -->
2. Após terminar o seu trabalho, podemos levar o cógido existe na nome_da_nova_branch para a main. Para isso vamos trocar para a branch main <!-- Isso permiti com que criemos uma única branch contendo todos os códigos criados -->
  2.1: Para isso precisamos usar o comando `git checkout main`. Isso irá trocar a branch e utilizar a branch main
  2.2: Após trocarmos de branch podemos realizar o merge: `git merge nome_da_nova_branch`
  2.3: Caso você deseje deletar a branch (tenha certeza que você pode deletar, se não perderá todo o histórico dessa branch), podemos usar o comando: `git checkout -D nova_da_nova_branch`
  2.4: Para confirmar que a deleção foi realizada com sucesso basta usar o comando: `git branch`

Obs¹: Caso você queira ter um padrão, ao criar o projeto e criar a branch main, faça uma outra branch `git checkout [branch_main_dois]`. Ela será responsável por ser a sua branch main. Isso faz com que vc não altere a main criada por padrão, e passa a ter uma única para a realização dessas ações
   
