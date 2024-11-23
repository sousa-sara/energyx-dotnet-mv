# EnergyX
## Definição do Projeto
EnergyX é uma aplicação web desenvolvida para otimizar a gestão de turnos e reatores industriais, permitindo o monitoramento eficiente de dados, organização de relatórios e o controle seguro de acesso de operadores. O projeto visa resolver a dificuldade de gestão em ambientes industriais, centralizando informações críticas em uma interface intuitiva e funcional. 

Por meio do consumo de APIs e um backend robusto desenvolvido em .NET, EnergyX entrega um sistema capaz de garantir segurança, performance e escalabilidade.

---

## *Escopo*

### *Escopo Atual*
O projeto, até o momento, abrange:
- Cadastro e autenticação de operadores.
- Controle de sessão com segurança (baseado no operador logado).
- Consultas detalhadas sobre turnos e reatores.
- Relatórios gerados com base em dados armazenados.
- Implementação de regras de negócio com validações rigorosas.

### *Escopo Futuro*
- Consumo de APIs externas para integração com outros sistemas industriais.
- Implementação de monitoramento em tempo real dos reatores.
- Melhorias na interface gráfica com dashboards dinâmicos.
- Controle granular de permissões para operadores.

---

## *Requisitos Funcionais*
1. *Cadastro de Operadores*: Permitir o registro de operadores com informações básicas e credenciais.
2. *Autenticação*: Validar operadores através de login seguro.
3. *Gestão de Reatores*: Cadastro, consulta e atualização de informações dos reatores.
4. *Relatórios de Turno*: Geração e visualização de relatórios baseados nos dados operacionais.
5. *Controle de Sessão*: Garantir acesso às funcionalidades apenas para usuários autenticados.

---

## *Requisitos Não Funcionais*
1. *Escalabilidade*: A arquitetura deve permitir a expansão do sistema com o crescimento das demandas industriais.
2. *Segurança*: Proteção de dados sensíveis, autenticação robusta e controle de sessão.
3. *Performance*: Resposta eficiente às requisições, mesmo com grandes volumes de dados.
4. *Documentação*: Código claro, bem documentado e suporte ao Swagger para endpoints.

---

### *Camada de Visualização:*
- Implementação de layouts responsivos utilizando Bootstrap 5.
- Criação de rotas personalizadas para operações como login e gestão de operadores.
- Desenvolvimento de validações de front-end para melhorar a usabilidade.
- Exibição de mensagens dinâmicas de erro ou sucesso (usando ViewModels).

### *Camada de Controladores:*
- Refatoração de controladores para melhor alinhamento com as regras de negócio.
- Controle de acesso baseado em sessão, restringindo funcionalidades a operadores logados.
- Redirecionamentos seguros e manuseio eficiente de erros.

### *Camada de Dados:*
- Ajustes no mapeamento de entidades utilizando o Entity Framework Core.
- Implementação de novas consultas otimizadas para relatórios de turno.
- Configuração do banco Oracle para maior estabilidade em cenários industriais.

---

## *Tecnologias Utilizadas*

### *Backend*
- *ASP.NET Core 8.0*: Framework principal para construção do sistema.
- *Entity Framework Core*: ORM para interação com o banco de dados.
- *Oracle Database*: Banco de dados para armazenamento seguro e escalável.
- *AutoMapper*: Mapeamento de objetos para simplificar operações de transformação de dados.

### *Frontend*
- *Bootstrap 5*: Framework CSS para construção de layouts responsivos.
- *JavaScript*: Para funcionalidades dinâmicas e validações.
- *HTML/CSS*: Construção de interfaces personalizadas.

---

## *Como Executar o Projeto*

1. Clone o repositório para a sua máquina local:
   ```bash
   git clone https://github.com/sousa-sara/energyx-dotnet-mvc.git

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Apresentação em Vídeo Sobre a EnergyX

[Vídeo Pitch](https://youtu.be/4Arsd4bjMcM)

## Sobre o Projeto Global Solutions
A cada semestre, desenvolvemos um projeto que integra todas as disciplinas do curso de Análise e Desenvolvimento de Sistemas, com o objetivo de propor soluções para um tema de relevância global, promovido pela nossa instituição.

**Global Solutions - Tema:** Energia Renovável

Este projeto aborda soluções inovadoras e sustentáveis para questões relacionadas à energia renovável, buscando promover um impacto positivo na sociedade e no meio ambiente.

**Instituição:** FIAP - Faculdade de Informática e Administração Paulista

**Turma:** 2TDSPS

## Desenvolvedores

[Felipe Amador](https://github.com/felipetosma) | RM 553528

[Leonardo Oliveira](https://github.com/leooli-321) | RM 554024

[Sara Sousa](https://github.com/sousa-sara) | RM 552656

