
![Csharp](https://img.shields.io/badge/.NETCore-0000FF?style=for-the-badge&logo=csharp&logoColor=white)
![Sqlite](https://img.shields.io/badge/SQLite-000000F?style=for-the-badge&logo=sqlite&logoColor=white)

# Gestão de eventos - Pass.In
A aplicação back-end realiza a gestão de eventos e participantes, permitindo que um usuário crie um evento, cadastre participantes e, caso eles compareçam, permite que seja registrado um check-in para cada um. Isso possibilita um controle dos eventos e dos participantes, oferecendo a capacidade de emitir relatórios das visitas.
##
# Tecnologias utilizadas
Desenvolvida em .NET a aplicação utiliza dos seguintes NuGet Packages:

- Microsoft.EntityFrameworkCore

- Microsoft.EntityFrameworkCore.Sqlite

- Swashbuckle.AspNetCore.SwaggerGen

- Swashbuckle.AspNetCore.SwaggerUI

Como banco de dados utiliza:

- SQLite

*OBS: Para visualizar o banco de dados recomendo utilizar um SGBD, e o que utilizei no desenvolvimento foi o DB Browser for SQLite (https://sqlitebrowser.org).*
##
# Como iniciar a aplicação
Para iniciar clone o repositorio em sua maquina.

   ``` shell
    git clone https://github.com/abyssmado/nlw-unite-csharp.git
 ```

Abra a pasta do projeto com sua IDE de preferencia.

Instale os pacotes.

Va até a pasta "PassIn.Infraestructure", abra o arquivo "PassInDbContext.cs" e mude o caminho da string Data Source na linha 15 para o caminho onde se encontra seu arquivo "PassInDb.db".

![image](https://github.com/abyssmado/nlw-unite-csharp/assets/85955679/c6ce58e2-2f09-41f6-9c40-a1f1143d43de)


*OBS: Pode ser que este caminho não funcione no seu PC, caso isso aconteça, pegue o caminho completo do arquivo na sua maquina, desde a pasta root do seu OS. Ex: "C:\\Users\\denis\\projetos\\nlw-unite-csharp\\PassInDb.db"*

Após configurar sua aplicação e ter baixado seu SGBD, aperte F5 no seu teclado e a aplicação irá iniciar.

Uma pagina do Swagger irá se abrir no seu navegador padrão, mostrando todas as API's da aplicação.

Ou se preferir abra o console (ex: CMD) na pasta  raiz do projeto, digite o comando 
``` shell 
dotnet run --project ./PassIn.Api/PassIn.Api.csproj
```

 e abra a seguinte URL no navegador: "http://localhost:5173/swagger/index.html".

![image](https://github.com/abyssmado/nlw-unite-csharp/assets/85955679/e4e566dc-c72b-4ed1-9466-b2dd2bac8016)


*Assim abrirá seu Swagger mostrando as API's da aplicação.*

![image](https://github.com/abyssmado/nlw-unite-csharp/assets/85955679/8b76e4f6-4441-4a2c-bef9-b00ed7e681bd)

Aqui temos todas requests e responses da aplicação documentadas.
##
# Este projeto foi desenvolvido durante o evento NLW Unite da Rocketseat 🚀

