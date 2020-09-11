# Passo a passo para executar a aplicação.

1) Clonar repositório
```sh
Git clone https://github.com/felipesilro/TestAtc
```

2) Abrir VsCode no diretório /API

3) Restaurar pacotes
```sh
Dotnet restore
```

4) Construir Aplicação
```sh
Dotnet build
```

5) Subir Aplicação
- Acessar a aba Debbuguer (CTRL + Shift + d)
- Na caixa de seleção de aplicação (canto superior esquerdo) selecionar 'ALL'
> "Opção 'ALL' irá subir a aplicação BackEnd e FrontEnd"
- Clicar no botão "start debuguer"

6) No browser abrirá duas abas:
    - BackEnd -> https://localhost:6001/index.html
    - FrontEnd -> https://localhost:5001/

7) Acessar a aba do FrontEnd, Enjoy It.




